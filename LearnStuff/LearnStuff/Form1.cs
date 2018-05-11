using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;

namespace LearnStuff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testy2();
        }

        private void testy2()
        {
            string remoteUri = "http://localhost:20536/api/values/putty";
            string fileName = "ubuntu.iso", myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadProgressChanged += MyWebClient_DownloadProgressChanged;
            myWebClient.DownloadFileCompleted += MyWebClient_DownloadFileCompleted;
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri; // + fileName;
            //Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFileAsync(new Uri(remoteUri), fileName);
            //Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            //Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
        }

        private void MyWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Completed";
        }

        private void MyWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            UpdateLabel2(totalBytes.ToString(), bytesIn.ToString(), percentage);
            UpdateLabel1(bytesIn.ToString(), totalBytes.ToString(), percentage);
            UpdateProgressBar(bytesIn.ToString(), totalBytes.ToString(), percentage);
        }

        delegate void StringArgReturningVoidDelegate(string t1,string t2, double d1);
        private void UpdateLabel2(string totalBytes, string bytesIn, double percentage)
        {
            if (label2.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(UpdateLabel2);
                label2.Invoke(d);
            }
            else
            {
                label2.Text = "Total bytes: " + totalBytes;
            }
        }

        private void UpdateLabel1(string totalBytes, string bytesIn, double percentage)
        {
            if (label1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(UpdateLabel1);
                label1.Invoke(d);
            }
            else
            {
                label1.Text = "Current bytes : " + bytesIn + " -- " + percentage + "%";
            }
        }

        private void UpdateProgressBar(string totalBytes, string bytesIn, double percentage)
        {
            if (progressBar1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(UpdateProgressBar);
                progressBar1.Invoke(d);
            }
            else
            {
                progressBar1.Value = (int)Math.Floor(percentage);
            }

            //if (listBox1.InvokeRequired)
            //{
            //    StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(WriteToGUI);
            //    listBox1.Invoke(d, new object[] { "Downloaded " + bytesIn + " of " + totalBytes });
            //}
            //else
            //{
            //    listBox1.Items.Add("Downloaded " + bytesIn + " of " + totalBytes);
            //}
        }
    }
}
