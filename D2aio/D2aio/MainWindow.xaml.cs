﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D2aio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process p = new Process();
        D2BotBox d2botbox = new D2BotBox();

        private const int SW_SHOWMAXIMIZED = 3;

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOREPOSITION = 0x0200;

        public static int GWL_STYLE = -16;
        private const int WS_MAXIMIZE = 0x01000000;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = 0x00C00000;
        public static int WS_SIZEBOX = 0x00040000;
        public static int WS_THICKFRAME = 0x00040000;
        private static int MYSTUFF = WS_BORDER | WS_DLGFRAME | WS_CAPTION | WS_SIZEBOX | WS_THICKFRAME;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mitvindue_Loaded(object sender, RoutedEventArgs e)
        {
            DoStuff();
            FixShit();
        }

        private void DoStuff()
        {
            brugmig.Children.Add(d2botbox);
            
            //Grid.SetColumn(d2botbox, 0);
            //Grid.SetRow(d2botbox, 0);
        }

        internal class SafeNativeMethods
        {
            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

            [DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        }

        private void FixShit()
        {
            string path = @"D:\Dropbox\GitHub\d2bot-with-kolbot - vHack new\D2Bot.exe";
            string path2 = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe";
            ProcessStartInfo psi = new ProcessStartInfo(path);
            psi.Arguments = "-w";
            psi.WindowStyle = ProcessWindowStyle.Minimized;
            p = Process.Start(psi);
            p.WaitForInputIdle();

            while (p.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            HwndSource source = (HwndSource)HwndSource.FromVisual(d2botbox);

            //IntPtr hh = d2botbox.Handle;

            IntPtr pt = p.MainWindowHandle;
            SafeNativeMethods.SetParent(pt, source.Handle); // Process.GetCurrentProcess().MainWindowHandle);
            int style = SafeNativeMethods.GetWindowLong(pt, GWL_STYLE); // get the original window style
            SafeNativeMethods.SetWindowLong(pt, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)
            SafeNativeMethods.ShowWindow(pt, SW_SHOWMAXIMIZED); // maximize the window
        }

        private void toolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            menuList.Visibility = Visibility.Visible;
        }

        private void btnMenuListCancel_Click(object sender, RoutedEventArgs e)
        {
            menuList.Visibility = Visibility.Hidden;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process temp = null;
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Contains("D2Bot"))
                {
                    IntPtr pt = p.MainWindowHandle;
                    SafeNativeMethods.SetParent(pt, Process.GetCurrentProcess().MainWindowHandle);
                    temp = theprocess;
                    break;
                }
            }
            if (temp != null)
            {
                
            }
            //tabControl.SelectedIndex = 1;
        }
    }
}
