using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace D2Testing
{
    class D2Overlay : Control
    {
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_LBUTTONDOWN = 0x201;
        private const uint WM_LBUTTONUP = 0x202;
        private const uint WM_RBUTTONDOWN = 0x204;
        private const uint WM_RBUTTONUP = 0x205;
        private const uint WM_MBUTTONDOWN = 0x207;
        private const uint WM_MBUTTONUP = 0x208;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        //private const int WM_CHAR = 0x102;

        [DllImport("User32.Dll", EntryPoint = "PostMessage")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("User32.dll")]
        private static extern IntPtr LoadCursorFromFile(String str);

        public event StatusUpdate status;
        public EventArgs e = null;
        public delegate void StatusUpdate(string status, EventArgs e);
        private IntPtr d2;
        private D2HostPanel panel;
        public bool drag = false;
        public bool enab = true;
        private int m_opacity = 100;

        private int alpha;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            Color frmColor = this.Parent.BackColor;
            Brush bckColor = default(Brush);

            alpha = (m_opacity * 255) / 100;

            if (drag)
            {
                Color dragBckColor = default(Color);

                if (BackColor != Color.Transparent)
                {
                    int Rb = BackColor.R * alpha / 255 + frmColor.R * (255 - alpha) / 255;
                    int Gb = BackColor.G * alpha / 255 + frmColor.G * (255 - alpha) / 255;
                    int Bb = BackColor.B * alpha / 255 + frmColor.B * (255 - alpha) / 255;
                    dragBckColor = Color.FromArgb(Rb, Gb, Bb);
                }
                else
                {
                    dragBckColor = frmColor;
                }

                alpha = 255;
                bckColor = new SolidBrush(Color.FromArgb(alpha, dragBckColor));
            }
            else
            {
                bckColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor));
            }

            if (this.BackColor != Color.Transparent | drag)
            {
                g.FillRectangle(bckColor, bounds);
            }

            bckColor.Dispose();
            g.Dispose();
            base.OnPaint(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                Parent.Invalidate(this.Bounds, true);
            }
            base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnParentBackColorChanged(e);
        }

        public static Cursor CreateCursor(string filename)
        {
            IntPtr hCursor = LoadCursorFromFile(filename);

            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                throw new ApplicationException("Could not create cursor from file " + filename);
            }
        }

        public D2Overlay(D2HostPanel panel, IntPtr d2handle)
        {
            this.panel = panel;
            this.d2 = d2handle;
            this.Size = panel.Size;
            panel.Controls.Add(this);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
            Focus();

            RegisterEvents();
            Cursor cur = CreateCursor(@".\Resources\d2_hand.ani");
            this.Cursor = cur;
        }

        private void RegisterEvents()
        {
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);
        }

        public void UnRegisterEvents()
        {
            this.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp -= new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.MouseEnter -= new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave -= new System.EventHandler(this.OnMouseLeave);
            this.KeyDown -= new KeyEventHandler(OnKeyDown);
            this.KeyUp -= new KeyEventHandler(OnKeyUp);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point point = ResolvePoint(e.Location);
            PostMessage(d2, WM_MOUSEMOVE, 0, point.Y * 0x10000 + point.X);

            //if (d2Cursor != null)
            //{
            //    System.Windows.Point wpfLocation = new System.Windows.Point(point.X, point.Y);

            //    d2Cursor.SetValue(System.Windows.Controls.Canvas.LeftProperty, wpfLocation.X);
            //    d2Cursor.SetValue(System.Windows.Controls.Canvas.TopProperty, wpfLocation.Y);
            //}
            status("x: " + point.X + " | y: " + point.Y + " -- x: " + e.Location.X + " y: " + e.Location.Y, e);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            //foreach (DiabloWindow window in DiabloWindow.DiabloWindows)
            //{
            //    if (window != diabloWindow)
            //    {
            //        window.MakeInactive();
            //    }
            //}
            //diabloWindow.MakeActive();

            Point point = ResolvePoint(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                PostMessage(d2, WM_LBUTTONDOWN, 0, point.Y * 0x10000 + point.X);
            }
            else if (e.Button == MouseButtons.Right)
            {
                PostMessage(d2, WM_RBUTTONDOWN, 0, point.Y * 0x10000 + point.X);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                PostMessage(d2, WM_MBUTTONDOWN, 0, point.Y * 0x10000 + point.X);
            }
            status("mouse down", e);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Point point = ResolvePoint(e.Location);

            if (e.Button == MouseButtons.Left)
            {
                PostMessage(d2, WM_LBUTTONUP, 0, point.Y * 0x10000 + point.X);
            }
            else if (e.Button == MouseButtons.Right)
            {
                PostMessage(d2, WM_RBUTTONUP, 0, point.Y * 0x10000 + point.X);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                PostMessage(d2, WM_MBUTTONUP, 0, point.Y * 0x10000 + point.X);
            }
            
            status("mouse up", e);
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            //Cursor.Hide();
            status("mouse enter", e);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            //Cursor.Show();
            status("mouse exit", e);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            status("keydown", e);
            if (!e.Handled)
            {
                PostMessage(d2, WM_KEYDOWN, e.KeyValue, 0);
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                uint lparam = 0x80000000;
                PostMessage(d2, WM_KEYUP, e.KeyValue, (int)lparam);
            }
            status("keyup", e);
        }

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            return true;
        }

        private Point ResolvePoint(Point point)
        {
            double x = ((double)800 / this.Width) * point.X;
            double y = ((double)600 / this.Height) * point.Y;
            return new Point((int)x, (int)y);
        }
    }
}
