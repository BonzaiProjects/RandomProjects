using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;

namespace D2QS
{
    enum StaticSize
    {
        [Description("Don't set")]
        None,
        [Description("800x600")]
        Normal,
        [Description("1024x768")]
        Big,
        [Description("1280x960")]
        Bigger,
        [Description("1600x1200")]
        Biggest
    }

    class DiabloManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(IntPtr hWnd, string text);
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public BindingList<DiabloInfo> DiabloInfoList { get; private set; }
        public BindingList<DiabloRealm> DiabloRealmList { get; set; }
        public bool SaveOnListChange { get; set; }
        public int SelectedRealm { get { return _selectedRealm; } private set { SelectedRealm = value; } }
        private int _selectedRealm = -1;
        private List<Process> CapturedDiablo;
        private GlideSettings backupSettings;
        private static string glideKeyName = @"HKEY_CURRENT_USER\Software\GLIDE3toOpenGL";

        public DiabloManager()
        {
            DiabloInfoList = new BindingList<DiabloInfo>();
            DiabloRealmList = new BindingList<DiabloRealm>();
            CapturedDiablo = new List<Process>();

            SaveOnListChange = true;
            DiabloInfoList.ListChanged += DiabloInfoList_ListChanged;

            FillRealmList();
        }

        private void DiabloInfoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (SaveOnListChange)
            {
                SaveDiabloInfoListToSettings();
            }
        }

        private void FillRealmList()
        {
            DiabloRealmList.Clear();
            string regKey = @"HKEY_CURRENT_USER\Software\Battle.net\Configuration";
            string[] value = (string[])Registry.GetValue(regKey, "Diablo II Battle.net gateways", null);
            int.TryParse(value[1], out _selectedRealm);
            _selectedRealm--; // blizz don't start from 0
            for (int i = 2; i < value.Length; i += 3)
            {
                DiabloRealmList.Add(new DiabloRealm(value[i], value[i + 1], value[i + 2]));
            }
        }

        public void SaveDiabloInfoListToSettings()
        {
            if (Properties.Settings.Default.DiabloSettings == null)
            {
                Properties.Settings.Default.DiabloSettings = new System.Collections.Specialized.StringCollection();
            }
            Properties.Settings.Default.DiabloSettings.Clear();

            foreach (DiabloInfo item in DiabloInfoList)
            {
                string d2 = D2InfoToString(item);

                Properties.Settings.Default.DiabloSettings.Add(d2);
            }

            Properties.Settings.Default.Save();
        }

        public void LoadDiabloInfoListFromSettings()
        {
            if (Properties.Settings.Default.DiabloSettings != null && Properties.Settings.Default.DiabloSettings.Count > 0)
            {
                string[] settings = new string[Properties.Settings.Default.DiabloSettings.Count];

                for (int i = 0; i < Properties.Settings.Default.DiabloSettings.Count; i++)
                {
                    settings[i] = Properties.Settings.Default.DiabloSettings[i];
                }

                DiabloInfoList.Clear(); // is causing the save to happen because we bound it to the ListChanged

                foreach (string item in settings)
                {
                    //string gamePath, string arguments, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool runAsAdmin = false, bool useGlideSettings = false, 
                    //int glideWindMode = 1, int glideCaptureMouse = 0, StaticSize glideSaticSize = 0, int glideDesktopResolution = 1
                    DiabloInfo di = D2InfoFromString(item);

                    di.PropertyChanged += D_PropertyChanged;
                    di.GlideSettings.PropertyChanged += D_PropertyChanged;
                    DiabloInfoList.Add(di);
                }
            }
        }

        #region CRUD
        public void AddDiabloEntry(string gamePath, string arguments = null, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool useGlide = false, bool runAsAdmin = false, int glideWindowMode = 1, int glideCaptureMouse = 0, StaticSize glideStaticSize = 0, int glideDesktopResolution = 1)
        {
            DiabloInfo d = new DiabloInfo(gamePath, arguments, windowTitle, buttonText, showOnMain, runAsAdmin, useGlide, glideWindowMode, glideCaptureMouse, glideStaticSize, glideDesktopResolution);
            d.PropertyChanged += D_PropertyChanged;
            d.GlideSettings.PropertyChanged += D_PropertyChanged;
            DiabloInfoList.Add(d);
        }

        public void AddDiabloEntry(string gamePath, string arguments = null, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool useGlide = false, bool runAsAdmin = false, GlideSettings settings = null)
        {
            DiabloInfo d = new DiabloInfo(gamePath, arguments, windowTitle, buttonText, showOnMain, runAsAdmin, useGlide, settings);
            d.PropertyChanged += D_PropertyChanged;
            d.GlideSettings.PropertyChanged += D_PropertyChanged;
            DiabloInfoList.Add(d);
        }

        private void D_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveDiabloInfoListToSettings();
        }

        public void AddDiabloEntry(DiabloInfo diablo)
        {
            DiabloInfoList.Add(diablo);
        }

        public void RemoveDiabloEntry(DiabloInfo diablo)
        {
            DiabloInfoList.Remove(diablo);
        }
        #endregion

        public void StartDiablo(DiabloInfo diablo, Control diabloContainer)
        {
            // find and capture other Diablo windows so we can start this one
            CaptureDiabloWindows(diabloContainer);
            
            Process p = new Process();
            p.StartInfo.WorkingDirectory = diablo.GamePath;
            p.StartInfo.FileName = diablo.GamePath;
            p.StartInfo.Arguments = diablo.Arguments;

            if (diablo.RunAsAdmin)
            {
                p.StartInfo.Verb = "runas"; // run d2 as admin
            }

            // use specific glide settings
            if (diablo.UseGlideSettings)
            {
                UseGlideSettings(diablo.GlideSettings);

                // in case someone forgot to put it in their arguments
                if (!p.StartInfo.Arguments.ToLower().Contains("-3dfx"))
                {
                    p.StartInfo.Arguments += " -3dfx";
                }
                if (diablo.GlideSettings.WindowMode == 1 && !p.StartInfo.Arguments.ToLower().Contains("-w"))
                {
                    p.StartInfo.Arguments += " -w";
                }
            }

            // try and start d2
            try
            {
                p.Start();
                p.WaitForInputIdle();

                while (p.Handle == IntPtr.Zero)
                {
                    // to make sure the window is up and running
                }
                if (p.StartInfo.Arguments.ToLower().Contains("-3dfx"))
                {
                    // if using 3dfx we need to give it a sec
                    Thread.Sleep(1000);
                }
                if (diablo.WindowTitle != "" && diablo.WindowTitle != null)
                {
                    // set title for Diablo window
                    SetWindowText(p.MainWindowHandle, diablo.WindowTitle);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            // capturering this window too to make the release better
            SetParent(p.MainWindowHandle, diabloContainer.Handle);
            CapturedDiablo.Add(p);

            // release the Diablo windows we captured in the beginning
            ReleaseDiabloWindows();

            // reset to original settings
            if (diablo.UseGlideSettings)
            {
                //RestoreGlideSettings();
            }
        }

        private void UseGlideSettings(GlideSettings settings)
        {
            int windowed = (int)Registry.GetValue(glideKeyName, "windowed", 1);
            int capturedMouse = (int)Registry.GetValue(glideKeyName, "capturedmouse", 0);
            StaticSize staticSize = (StaticSize)(int)Registry.GetValue(glideKeyName, "staticview", 0);
            int desktopResolution = (int)Registry.GetValue(glideKeyName, "desktopresolution", 1);
            backupSettings = new GlideSettings(windowed, capturedMouse, staticSize, desktopResolution);

            SetGlideValues(settings.WindowMode, settings.CaptureMouse, settings.StaticSize);
        }

        private void RestoreGlideSettings()
        {
            SetGlideValues(backupSettings.WindowMode, backupSettings.CaptureMouse, backupSettings.StaticSize, backupSettings.DesktopResolution);
        }

        private void SetGlideValues(int windowMode = 1, int captureMouse = 0, StaticSize staticSize = 0, int desktopResolution = 1)
        {
            Registry.SetValue(glideKeyName, "windowed", windowMode, RegistryValueKind.DWord);
            Registry.SetValue(glideKeyName, "capturedmouse", captureMouse, RegistryValueKind.DWord);
            Registry.SetValue(glideKeyName, "staticview", (int)staticSize, RegistryValueKind.DWord);
            Registry.SetValue(glideKeyName, "desktopresolution", desktopResolution, RegistryValueKind.DWord);
        }

        private void CaptureDiabloWindows(Control diabloContainer)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Equals("Game"))
                {
                    SetParent(theprocess.MainWindowHandle, diabloContainer.Handle);
                    CapturedDiablo.Add(theprocess);
                }
            }
        }

        private void ReleaseDiabloWindows()
        {
            if (CapturedDiablo.Count > 0)
            {
                foreach (Process proc in CapturedDiablo)
                {
                    SetParent(proc.MainWindowHandle, IntPtr.Zero);
                }
            }
        }

        public string D2InfoToString(DiabloInfo d)
        {
            //string gamePath, string arguments, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool runAsAdmin = false, bool useGlideSettings = false, 
            //int glideWindMode = 1, int glideCaptureMouse = 0, StaticSize glideSaticSize = 0, int glideDesktopResolution = 1
            string d2 = d.GamePath + "," + d.Arguments + "," + d.WindowTitle + "," + d.ButtonText;
            d2 += "," + (d.ShowOnMain ? "1" : "0") + "," + (d.RunAsAdmin ? "1" : "0") + "," + (d.UseGlideSettings ? "1" : "0");
            d2 += "," + d.GlideSettings.WindowMode + "," + d.GlideSettings.CaptureMouse + "," + (int)d.GlideSettings.StaticSize + "," + d.GlideSettings.DesktopResolution;
            d2 += "," + Helper.ToShortString(d.ID);

            return d2;
        }

        public DiabloInfo D2InfoFromString(string s)
        {
            //string gamePath, string arguments, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool runAsAdmin = false, bool useGlideSettings = false, 
            //int glideWindMode = 1, int glideCaptureMouse = 0, StaticSize glideSaticSize = 0, int glideDesktopResolution = 1
            string[] d2 = s.Split(',');
            DiabloInfo di = new DiabloInfo(d2[0], d2[1], d2[2], d2[3], (d2[4] == "1" ? true : false), (d2[5] == "1" ? true : false), (d2[6] == "1" ? true : false), int.Parse(d2[7]), int.Parse(d2[8]), (StaticSize)int.Parse(d2[9]), int.Parse(d2[10]));
            di.ID = Helper.FromShortString(d2[11]);

            return di;
        }
    }

    static class Helper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static IList ToList(this Type type)
        {
            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetEnumDescription(value)));
            }

            return list;
        }

        public static string GetArguments(Process proc)
        {
            string result = null;
            try
            {
                string s = $"{proc.GetCommandLine()}";
                var kk = s.Split('"');
                result = kk[2].Substring(1);
            }
            // Catch and ignore "access denied" exceptions.
            catch (Win32Exception ex) when (ex.HResult == -2147467259) { }
            // Catch and ignore "Cannot process request because the process (<pid>) has
            // exited." exceptions.
            // These can happen if a process was initially included in 
            // Process.GetProcesses(), but has terminated before it can be
            // examined below.
            catch (InvalidOperationException ex) when (ex.HResult == -2146233079) { }
            return result;
        }

        private static string GetCommandLine(this Process process)
        {
            string cmdLine = null;
            using (var searcher = new ManagementObjectSearcher(
              $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
            {
                // By definition, the query returns at most 1 match, because the process 
                // is looked up by ID (which is unique by definition).
                var matchEnum = searcher.Get().GetEnumerator();
                if (matchEnum.MoveNext()) // Move to the 1st item.
                {
                    cmdLine = matchEnum.Current["CommandLine"]?.ToString();
                }
            }
            if (cmdLine == null)
            {
                // Not having found a command line implies 1 of 2 exceptions, which the
                // WMI query masked:
                // An "Access denied" exception due to lack of privileges.
                // A "Cannot process request because the process (<pid>) has exited."
                // exception due to the process having terminated.
                // We provoke the same exception again simply by accessing process.MainModule.
                var dummy = process.MainModule; // Provoke exception.
            }
            return cmdLine;
        }

        public static string ToShortString(Guid guid)
        {
            var base64Guid = Convert.ToBase64String(guid.ToByteArray());

            // Replace URL unfriendly characters with better ones
            base64Guid = base64Guid.Replace('/', '_');

            // Remove the trailing ==
            return base64Guid.Substring(0, base64Guid.Length - 2);
        }

        public static Guid FromShortString(string str)
        {
            str = str.Replace('_', '/');
            var byteArray = Convert.FromBase64String(str + "==");
            return new Guid(byteArray);
        }
    }

    class DiabloRealm
    {
        public string Server { get; set; }
        public string Timezone { get; set; }
        public string Realm { get; set; }

        public DiabloRealm(string server, string timezone, string realm)
        {
            Server = server;
            Timezone = timezone;
            Realm = realm;
        }
    }
    
    class DiabloInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _ShowOnMain;
        private string _GamePath;
        private string _Arguments;
        private string _WindowTitle;
        private string _ButtonText;
        private bool _UseGlideSettings;
        private bool _RunAsAdmin;
        private GlideSettings _GlideSettings;

        public Guid ID { get; set; }

        public bool ShowOnMain { get { return _ShowOnMain; } set { if (value != _ShowOnMain) { _ShowOnMain = value; NotifyPropertyChanged(); } } }
        public string GamePath { get { return _GamePath; } set { if (value != _GamePath) { _GamePath = value; NotifyPropertyChanged(); } } }
        public string Arguments { get { return _Arguments; } set { if (value != _Arguments) { _Arguments = value; NotifyPropertyChanged(); } } }
        public string WindowTitle { get { return _WindowTitle; } set { if (value != _WindowTitle) { _WindowTitle = value; NotifyPropertyChanged(); } } }
        public string ButtonText { get { return _ButtonText; } set { if (value != _ButtonText) { _ButtonText = value; NotifyPropertyChanged(); } } }
        public bool UseGlideSettings { get { return _UseGlideSettings; } set { if (value != _UseGlideSettings) { _UseGlideSettings = value; NotifyPropertyChanged(); } } }
        public bool RunAsAdmin { get { return _RunAsAdmin; } set { if (value != _RunAsAdmin) { _RunAsAdmin = value; NotifyPropertyChanged(); } } }
        public GlideSettings GlideSettings { get { return _GlideSettings; } set { if (value != _GlideSettings) { _GlideSettings = value; NotifyPropertyChanged(); } } }

        public DiabloInfo(string gamePath, string arguments, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool runAsAdmin = false, bool useGlideSettings = false, int glideWindMode = 1, int glideCaptureMouse = 0, StaticSize glideSaticSize = 0, int glideDesktopResolution = 1)
        {
            ID = Guid.NewGuid();
            ShowOnMain = showOnMain;
            GamePath = gamePath;
            WindowTitle = windowTitle;
            ButtonText = buttonText;
            Arguments = arguments;
            UseGlideSettings = useGlideSettings;
            RunAsAdmin = runAsAdmin;
            GlideSettings = new GlideSettings(glideWindMode, glideCaptureMouse, glideSaticSize, glideDesktopResolution);
        }

        public DiabloInfo(string gamePath, string arguments, string windowTitle = null, string buttonText = "", bool showOnMain = true, bool runAsAdmin = false, bool useGlideSettings = false, GlideSettings settings = null)
        {
            ID = Guid.NewGuid();
            ShowOnMain = showOnMain;
            GamePath = gamePath;
            WindowTitle = windowTitle;
            ButtonText = buttonText;
            Arguments = arguments;
            UseGlideSettings = useGlideSettings;
            RunAsAdmin = runAsAdmin;
            GlideSettings = settings;
        }

        public DiabloInfo() // used for json
        {

        }
    }
    
    class GlideSettings: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _WindowMode;
        private int _CaptureMouse;
        private StaticSize _StaticSize;
        private int _DesktopResolution;

        public int WindowMode { get { return _WindowMode; } set { if (value != _WindowMode) { _WindowMode = value; NotifyPropertyChanged(); } } }
        public int CaptureMouse { get { return _CaptureMouse; } set { if (value != _CaptureMouse) { _CaptureMouse = value; NotifyPropertyChanged(); } } }
        public StaticSize StaticSize { get { return _StaticSize; } set { if (value != _StaticSize) { _StaticSize = value; NotifyPropertyChanged(); } } } // 0=no, 1=800x600, 2=1024x768, 3=1280x960, 4=1600x1200
        public int DesktopResolution { get { return _DesktopResolution; } set { if (value != _DesktopResolution) { _DesktopResolution = value; NotifyPropertyChanged(); } } }

        public GlideSettings(int windowMode = 1, int captureMouse = 0, StaticSize staticSize = 0, int desktopResolution = 1)
        {
            if (windowMode < 0 || windowMode > 1 || captureMouse < 0 || captureMouse > 1 || (int)staticSize < 0 || (int)staticSize > 4 || desktopResolution < 0 || desktopResolution > 1)
            {
                throw new Exception("Glide to OpenGL values out of wack");
            }
            WindowMode = windowMode;
            CaptureMouse = captureMouse;
            StaticSize = staticSize;
            DesktopResolution = desktopResolution;
        }
    }
}
