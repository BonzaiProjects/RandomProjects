using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowTestLabyrinth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FixLaby();
        }

        private void FixLaby()
        {
            LabyrinthCreater.Class1 cc = new LabyrinthCreater.Class1();
            int[,] laby = cc.CreateLabyrinth(20,10);

            int x = laby.GetLength(0);
            int y = laby.GetLength(1);

            int sizeX = flowLayoutPanel1.Width / x;
            int sizeY = flowLayoutPanel1.Height / y;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(sizeX, sizeY);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Margin = new Padding(0);
                    pic.Load(Environment.CurrentDirectory + @"\Pics\" + laby[i, j].ToString() + ".png");
                    flowLayoutPanel1.Controls.Add(pic);
                }
            }
        }
    }
}
