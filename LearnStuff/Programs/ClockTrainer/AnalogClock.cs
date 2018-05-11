using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockTrainer
{
    class AnalogClock : UserControl
    {
        public Color HourHandColor
        {
            get { return this.hrColor; }
            set { this.hrColor = value; }
        }

        public Color MinuteHandColor
        {
            get { return this.minColor; }
            set { this.minColor = value; }
        }

        public Color SecondHandColor
        {
            get { return this.secColor; }
            set
            {
                this.secColor = value;
                this.circleColor = value;
            }
        }

        public Color TicksColor
        {
            get { return this.ticksColor; }
            set { this.ticksColor = value; }
        }

        public bool Draw1MinuteTicks
        {
            get { return this.bDraw1MinuteTicks; }
            set { this.bDraw1MinuteTicks = value; }
        }

        public bool Draw5MinuteTicks
        {
            get { return this.bDraw5MinuteTicks; }
            set { this.bDraw5MinuteTicks = value; }
        }

        public bool DrawHandSeconds
        {
            get { return bDrawHandSeconds; }
            set { this.bDrawHandSeconds = value; }
        }

        const float PI = 3.141592654F;

        public DateTime GetDateTime
        {
            get { return dateTime; }
            private set { this.dateTime = value; }
        }

        DateTime dateTime;

        float fRadius;
        float fCenterX;
        float fCenterY;
        float fCenterCircleRadius;

        float fHourLength;
        float fMinLength;
        float fSecLength;

        float fHourThickness;
        float fMinThickness;
        float fSecThickness;

        bool bDraw5MinuteTicks = false;
        bool bDraw1MinuteTicks = false;
        float fTicksThickness = 1;

        bool bDrawHandSeconds = false;
        bool bLiveClock = false;

        Color hrColor = Color.DarkMagenta;
        Color minColor = Color.Green;
        Color secColor = Color.Red;
        Color circleColor = Color.Red;
        private System.ComponentModel.IContainer components;
        private Timer timer1 = new Timer();
        Color ticksColor = Color.Black;

        private void AnalogClock_Load(object sender, System.EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            dateTime = DateTime.Now;
            this.AnalogClock_Resize(sender, e);
        }

        private void AnalogClock_Resize(object sender, System.EventArgs e)
        {
            this.Width = this.Height;
            this.fRadius = this.Height / 2;
            this.fCenterX = this.ClientSize.Width / 2;
            this.fCenterY = this.ClientSize.Height / 2;
            this.fHourLength = (float)this.Height / 2 / 1.65F;
            this.fMinLength = (float)this.Height / 2 / 1.20F;
            this.fSecLength = (float)this.Height / 2 / 1.15F;
            this.fHourThickness = (float)this.Height / 100;
            this.fMinThickness = (float)this.Height / 150;
            this.fSecThickness = (float)this.Height / 200;
            this.fCenterCircleRadius = this.Height / 50;
            this.Refresh();
        }

        private void DrawLine(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
            fCenterX - (float)(fLength / 9 * System.Math.Sin(fRadians)),
            fCenterY + (float)(fLength / 9 * System.Math.Cos(fRadians)),
            fCenterX + (float)(fLength * System.Math.Sin(fRadians)),
            fCenterY - (float)(fLength * System.Math.Cos(fRadians)));
        }

        private void DrawPolygon(float fThickness, float fLength, Color color,
                float fRadians, System.Windows.Forms.PaintEventArgs e)
        {

            PointF A = new PointF((float)(fCenterX +
                     fThickness * 2 * System.Math.Sin(fRadians + PI / 2)),
                     (float)(fCenterY -
                     fThickness * 2 * System.Math.Cos(fRadians + PI / 2)));
            PointF B = new PointF((float)(fCenterX +
                     fThickness * 2 * System.Math.Sin(fRadians - PI / 2)),
                    (float)(fCenterY -
                    fThickness * 2 * System.Math.Cos(fRadians - PI / 2)));
            PointF C = new PointF((float)(fCenterX +
                     fLength * System.Math.Sin(fRadians)),
                     (float)(fCenterY -
                     fLength * System.Math.Cos(fRadians)));
            PointF D = new PointF((float)(fCenterX -
                     fThickness * 4 * System.Math.Sin(fRadians)),
                     (float)(fCenterY +
                     fThickness * 4 * System.Math.Cos(fRadians)));
            PointF[] points = { A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (bLiveClock)
            {
                this.dateTime = DateTime.Now;
            }
            else
            {
                this.dateTime = this.dateTime.AddSeconds(1);
            }
            
            this.Refresh();
        }

        public void ShowTime(int Hour = 0, int Minute = 0, int Second = 0)
        {
            DateTime t = DateTime.Now;
            this.dateTime = new DateTime(t.Year, t.Month, t.Day, Hour, Minute, Second);
            this.Refresh();
        }

        public void ShowTime(DateTime date)
        {
            this.dateTime = date;
            this.Refresh();
        }

        public void Start(bool liveClock = false)
        {
            bLiveClock = liveClock;
            timer1.Enabled = true;
            this.Refresh();
        }

        public void Stop()
        {
            timer1.Enabled = false;
            bLiveClock = false;
        }

        private void AnalogClock_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            float fRadHr = (dateTime.Hour % 12 + dateTime.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (dateTime.Minute) * 6 * PI / 180;
            float fRadSec = (dateTime.Second) * 6 * PI / 180;

            DrawPolygon(this.fHourThickness,
                  this.fHourLength, hrColor, fRadHr, e);
            DrawPolygon(this.fMinThickness,
                  this.fMinLength, minColor, fRadMin, e);
            if (bDrawHandSeconds)
            {
                DrawLine(this.fSecThickness,
                  this.fSecLength, secColor, fRadSec, e);
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor),
                       fCenterX - fCenterCircleRadius / 2,
                       fCenterY - fCenterCircleRadius / 2,
                       fCenterCircleRadius, fCenterCircleRadius);
            
            //draw squares
            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0)
                // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                      fCenterX +
                      (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                      fCenterX +
                      (float)(this.fRadius / 1.65F * System.Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.65F * System.Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                      fCenterX +
                      (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                      fCenterX +
                      (float)(this.fRadius / 1.55F * System.Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.55F * System.Math.Cos(i * 6 * PI / 180)));
                }
            }

            
        }

        public AnalogClock()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AnalogClock
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "AnalogClock";
            this.Size = new System.Drawing.Size(499, 466);
            this.Load += new System.EventHandler(this.AnalogClock_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);
            this.Resize += new System.EventHandler(this.AnalogClock_Resize);
            this.ResumeLayout(false);

        }
    }
}
