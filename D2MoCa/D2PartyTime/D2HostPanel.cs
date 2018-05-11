using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace D2PartyTime
{
    class D2HostPanel : Control
    {
        private D2Window d2window = null;
        public D2Window D2Window { get { return d2window; } }

        public D2HostPanel()
        {
            this.BackColor = Color.Black;
        }

        public void RegisterEvents()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);
        }

        public void BindDiabloWindow(D2Window diabloWindow)
        {
            this.d2window = diabloWindow;
        }

        public void ReleaseDiabloWindow()
        {
            if (this.d2window != null)
            {
                this.d2window.Show();
                this.d2window.UnRegisterThumbnail();
                this.d2window = null;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (d2window != null)
            {
                Point point = ResolvePoint(e.Location);
                d2window.MouseMove(point.X, point.Y);
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (d2window != null)
            {
                //foreach (D2Window window in d2window.DiabloWindows)
                //{
                //    if (window != d2window)
                //    {
                //        window.MakeInactive();
                //    }
                //}
                d2window.MakeActive();

                Point point = ResolvePoint(e.Location);
                if (e.Button == MouseButtons.Left)
                {
                    d2window.LeftMouseDown(point.X, point.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    d2window.RightMouseDown(point.X, point.Y);
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    d2window.MiddleMouseDown(point.X, point.Y);
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (d2window != null)
            {
                Point point = ResolvePoint(e.Location);
                if (e.Button == MouseButtons.Left)
                {
                    d2window.LeftMouseUp(point.X, point.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    d2window.RightMouseUp(point.X, point.Y);
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    d2window.MiddleMouseUp(point.X, point.Y);
                }
            }

            this.Focus();
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            //Cursor.Show();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (d2window != null)
            {
                if (!e.Handled)
                {
                    d2window.SendKeyDown(e);
                }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (d2window != null)
            {
                if (!e.Handled)
                {
                    d2window.SendKeyUp(e);
                }
            }
        }

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            return true;
        }

        private Point ResolvePoint(Point point)
        {
            double x = (d2window.Width / this.Width) * point.X;
            double y = (d2window.Height / this.Height) * point.Y;
            return new Point((int)x, (int)y);
        }
    }
}
