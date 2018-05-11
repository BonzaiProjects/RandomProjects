using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormedRPG
{
    public partial class Form1 : Form
    {
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStartingPosition();

            lblXloc.Text = lblX.Location.ToString();
        }

        private void SetStartingPosition()
        {
            Point p1 = new Point(ClientSize.Width / 2 - lblX.Width / 2 - lblX.Location.X, ClientSize.Height / 2 - lblX.Height / 2 - lblX.Location.Y);

            panel1.Location = p1;

            pictureBox1.Location = lblX.Location;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (tabControl1.SelectedIndex == tabControl1.TabPages.Count -1)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    e.Handled = true; // prevent tabcontrol from doing its own thing
                }
                else
                {
                    tabControl1.SelectTab(tabControl1.SelectedIndex + 1);
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                    e.Handled = true; // prevent tabcontrol from doing its own thing
                }
                else
                {
                    tabControl1.SelectTab(tabControl1.SelectedIndex - 1);
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.D)
            {
                MoveObject(pictureBox1, Direction.Right);
                MoveObject(panel1, Direction.Left);
            }
            if (e.KeyCode == Keys.A)
            {
                MoveObject(pictureBox1, Direction.Left);
                MoveObject(panel1, Direction.Right);
            }
            if (e.KeyCode == Keys.W)
            {
                MoveObject(pictureBox1, Direction.Up);
                MoveObject(panel1, Direction.Down);
            }
            if (e.KeyCode == Keys.S)
            {
                MoveObject(pictureBox1, Direction.Down);
                MoveObject(panel1, Direction.Up);
            }
            CheckCollision();
        }

        private void MoveObject(Control toMove, Direction whatWay)
        {
            switch (whatWay)
            {
                case Direction.Up:
                    toMove.Location = new Point(toMove.Location.X, toMove.Location.Y - 1);
                    break;
                case Direction.Down:
                    toMove.Location = new Point(toMove.Location.X, toMove.Location.Y + 1);
                    break;
                case Direction.Left:
                    toMove.Location = new Point(toMove.Location.X - 1, toMove.Location.Y);
                    break;
                case Direction.Right:
                    toMove.Location = new Point(toMove.Location.X + 1, toMove.Location.Y);
                    break;
                default:
                    break;
            }
        }

        private void CheckCollision()
        {
            //pictureBox1.Bounds.IntersectsWith(pictureBox1.Bounds);

            Control temp = null;

            foreach (Control item in panel1.Controls)
            {
                if (item.Tag != pictureBox1.Tag && pictureBox1.Bounds.IntersectsWith(item.Bounds))
                {
                    temp = item;
                    break;
                }
            }

            if (temp == null)
            {
                return;
            }
            
            switch (temp.Tag)
            {
                case "Loot":
                    lblHit.Text = "We found loot!";
                    panel1.Controls.Remove(temp);
                    break;
                case "Enemy":
                    lblHit.Text = "We killed an enemy!";
                    panel1.Controls.Remove(temp);
                    break;
                case "Wall":
                    lblHit.Text = "We walked into a wall! Ouch!";
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
            lblLoc.Text = pictureBox1.Location.ToString();
        }
    }
}
