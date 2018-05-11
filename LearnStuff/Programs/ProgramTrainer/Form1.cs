using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTrainer
{
    public partial class Form1 : Form
    {
        Point p1 = new Point(20, 20);
        Point p2 = new Point(40, 40);

        public Form1()
        {
            InitializeComponent();
            MyPanel mp = new MyPanel();
        }

        private void DrawGrid(Graphics g, int numOfCells, int cellSize)
        {
            Pen p = new Pen(Color.Black, 2);

            for (int y = 0; y <= numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x <= numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        private void DrawGrid2(Panel pan, Graphics g, int minRowHeieght, int minColumnSize)
        {
            pan.MinimumSize = new Size(minColumnSize, minRowHeieght);
            int numOfRows = pan.Height/minRowHeieght;
            int numOfColumns = pan.Width/minColumnSize;
            float cellWidth = pan.Width/numOfColumns;
            float cellHeight = pan.Height/numOfRows;

            if (numOfRows < 1 || numOfColumns < 1 || cellWidth < 1 || cellHeight < 1)
            {
                return;
            }

            Pen p = new Pen(Color.Black, 2);

            for (int y = 0; y <= numOfRows; ++y)
            {
                g.DrawLine(p, 0, y * cellHeight, numOfColumns * cellWidth, y * cellHeight);
            }

            for (int x = 0; x <= numOfColumns; ++x)
            {
                g.DrawLine(p, x * cellWidth, 0, x * cellWidth, numOfRows * cellHeight);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // DrawGrid(e.Graphics, 10, 50);
            myPanel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myPanel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid2(myPanel1, e.Graphics, 30, 50);
        }
    }
}
