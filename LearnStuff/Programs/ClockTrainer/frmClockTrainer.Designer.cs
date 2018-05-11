namespace ClockTrainer
{
    partial class FrmClockTrainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClockTrainer));
            this.btnGuessHard = new System.Windows.Forms.Button();
            this.cmbHour = new System.Windows.Forms.ComboBox();
            this.cmbMinute = new System.Windows.Forms.ComboBox();
            this.cmbSecond = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowSeconds = new System.Windows.Forms.CheckBox();
            this.btnShowGuessHours = new System.Windows.Forms.Button();
            this.btnNewAssignment = new System.Windows.Forms.Button();
            this.chkHard = new System.Windows.Forms.CheckBox();
            this.analogClockGuess = new ClockTrainer.AnalogClock();
            this.analogClock = new ClockTrainer.AnalogClock();
            this.btnStartLive = new System.Windows.Forms.Button();
            this.btnStopLive = new System.Windows.Forms.Button();
            this.chkLiveClock = new System.Windows.Forms.CheckBox();
            this.btnBackHour = new System.Windows.Forms.Button();
            this.btnBackMinut = new System.Windows.Forms.Button();
            this.btnBackSecond = new System.Windows.Forms.Button();
            this.btnForwardSecond = new System.Windows.Forms.Button();
            this.btnForwardMinut = new System.Windows.Forms.Button();
            this.btnForwardHour = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuessHard
            // 
            this.btnGuessHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuessHard.Location = new System.Drawing.Point(832, 81);
            this.btnGuessHard.Name = "btnGuessHard";
            this.btnGuessHard.Size = new System.Drawing.Size(75, 28);
            this.btnGuessHard.TabIndex = 2;
            this.btnGuessHard.Text = "Gæt tid";
            this.btnGuessHard.UseVisualStyleBackColor = true;
            this.btnGuessHard.Click += new System.EventHandler(this.btnGuessHard_Click);
            // 
            // cmbHour
            // 
            this.cmbHour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHour.FormattingEnabled = true;
            this.cmbHour.Location = new System.Drawing.Point(433, 81);
            this.cmbHour.Name = "cmbHour";
            this.cmbHour.Size = new System.Drawing.Size(100, 28);
            this.cmbHour.TabIndex = 3;
            // 
            // cmbMinute
            // 
            this.cmbMinute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMinute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMinute.FormattingEnabled = true;
            this.cmbMinute.Location = new System.Drawing.Point(539, 81);
            this.cmbMinute.Name = "cmbMinute";
            this.cmbMinute.Size = new System.Drawing.Size(100, 28);
            this.cmbMinute.TabIndex = 4;
            // 
            // cmbSecond
            // 
            this.cmbSecond.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSecond.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSecond.FormattingEnabled = true;
            this.cmbSecond.Location = new System.Drawing.Point(645, 81);
            this.cmbSecond.Name = "cmbSecond";
            this.cmbSecond.Size = new System.Drawing.Size(100, 28);
            this.cmbSecond.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Opgave:";
            // 
            // chkShowSeconds
            // 
            this.chkShowSeconds.AutoSize = true;
            this.chkShowSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowSeconds.Location = new System.Drawing.Point(674, 28);
            this.chkShowSeconds.Name = "chkShowSeconds";
            this.chkShowSeconds.Size = new System.Drawing.Size(139, 28);
            this.chkShowSeconds.TabIndex = 13;
            this.chkShowSeconds.Text = "Vis sekunder";
            this.chkShowSeconds.UseVisualStyleBackColor = true;
            this.chkShowSeconds.CheckedChanged += new System.EventHandler(this.chkShowSeconds_CheckedChanged);
            // 
            // btnShowGuessHours
            // 
            this.btnShowGuessHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowGuessHours.Location = new System.Drawing.Point(751, 81);
            this.btnShowGuessHours.Name = "btnShowGuessHours";
            this.btnShowGuessHours.Size = new System.Drawing.Size(75, 28);
            this.btnShowGuessHours.TabIndex = 14;
            this.btnShowGuessHours.Text = "Vis gæt";
            this.btnShowGuessHours.UseVisualStyleBackColor = true;
            this.btnShowGuessHours.Click += new System.EventHandler(this.btnShowGuessHours_Click);
            // 
            // btnNewAssignment
            // 
            this.btnNewAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAssignment.Location = new System.Drawing.Point(433, 17);
            this.btnNewAssignment.Name = "btnNewAssignment";
            this.btnNewAssignment.Size = new System.Drawing.Size(156, 46);
            this.btnNewAssignment.TabIndex = 15;
            this.btnNewAssignment.Text = "Ny opgave";
            this.btnNewAssignment.UseVisualStyleBackColor = true;
            this.btnNewAssignment.Click += new System.EventHandler(this.btnNewAssignment_Click);
            // 
            // chkHard
            // 
            this.chkHard.AutoSize = true;
            this.chkHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHard.Location = new System.Drawing.Point(595, 25);
            this.chkHard.Name = "chkHard";
            this.chkHard.Size = new System.Drawing.Size(73, 28);
            this.chkHard.TabIndex = 16;
            this.chkHard.Text = "Svær";
            this.chkHard.UseVisualStyleBackColor = true;
            this.chkHard.CheckedChanged += new System.EventHandler(this.chkHard_CheckedChanged);
            // 
            // analogClockGuess
            // 
            this.analogClockGuess.BackgroundImage = global::ClockTrainer.Properties.Resources.clock2;
            this.analogClockGuess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analogClockGuess.Draw1MinuteTicks = false;
            this.analogClockGuess.Draw5MinuteTicks = false;
            this.analogClockGuess.DrawHandSeconds = false;
            this.analogClockGuess.HourHandColor = System.Drawing.Color.DarkMagenta;
            this.analogClockGuess.Location = new System.Drawing.Point(648, 166);
            this.analogClockGuess.MinuteHandColor = System.Drawing.Color.Green;
            this.analogClockGuess.Name = "analogClockGuess";
            this.analogClockGuess.SecondHandColor = System.Drawing.Color.Red;
            this.analogClockGuess.Size = new System.Drawing.Size(259, 259);
            this.analogClockGuess.TabIndex = 7;
            this.analogClockGuess.TicksColor = System.Drawing.Color.Black;
            // 
            // analogClock
            // 
            this.analogClock.BackgroundImage = global::ClockTrainer.Properties.Resources.clock2;
            this.analogClock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.analogClock.Draw1MinuteTicks = false;
            this.analogClock.Draw5MinuteTicks = false;
            this.analogClock.DrawHandSeconds = false;
            this.analogClock.HourHandColor = System.Drawing.Color.DarkMagenta;
            this.analogClock.Location = new System.Drawing.Point(12, 54);
            this.analogClock.MinuteHandColor = System.Drawing.Color.Green;
            this.analogClock.Name = "analogClock";
            this.analogClock.SecondHandColor = System.Drawing.Color.Red;
            this.analogClock.Size = new System.Drawing.Size(415, 415);
            this.analogClock.TabIndex = 6;
            this.analogClock.TicksColor = System.Drawing.Color.Black;
            // 
            // btnStartLive
            // 
            this.btnStartLive.Location = new System.Drawing.Point(433, 446);
            this.btnStartLive.Name = "btnStartLive";
            this.btnStartLive.Size = new System.Drawing.Size(75, 23);
            this.btnStartLive.TabIndex = 20;
            this.btnStartLive.Text = "Start ur";
            this.btnStartLive.UseVisualStyleBackColor = true;
            this.btnStartLive.Click += new System.EventHandler(this.btnStartLive_Click);
            // 
            // btnStopLive
            // 
            this.btnStopLive.Location = new System.Drawing.Point(514, 446);
            this.btnStopLive.Name = "btnStopLive";
            this.btnStopLive.Size = new System.Drawing.Size(75, 23);
            this.btnStopLive.TabIndex = 21;
            this.btnStopLive.Text = "Stop ur";
            this.btnStopLive.UseVisualStyleBackColor = true;
            this.btnStopLive.Click += new System.EventHandler(this.btnStopLive_Click);
            // 
            // chkLiveClock
            // 
            this.chkLiveClock.AutoSize = true;
            this.chkLiveClock.Location = new System.Drawing.Point(595, 450);
            this.chkLiveClock.Name = "chkLiveClock";
            this.chkLiveClock.Size = new System.Drawing.Size(68, 17);
            this.chkLiveClock.TabIndex = 25;
            this.chkLiveClock.Text = "Rigtigt ur";
            this.chkLiveClock.UseVisualStyleBackColor = true;
            // 
            // btnBackHour
            // 
            this.btnBackHour.Location = new System.Drawing.Point(433, 343);
            this.btnBackHour.Name = "btnBackHour";
            this.btnBackHour.Size = new System.Drawing.Size(75, 23);
            this.btnBackHour.TabIndex = 26;
            this.btnBackHour.Text = "-1 time";
            this.btnBackHour.UseVisualStyleBackColor = true;
            this.btnBackHour.Click += new System.EventHandler(this.btnBackHour_Click);
            // 
            // btnBackMinut
            // 
            this.btnBackMinut.Location = new System.Drawing.Point(433, 314);
            this.btnBackMinut.Name = "btnBackMinut";
            this.btnBackMinut.Size = new System.Drawing.Size(75, 23);
            this.btnBackMinut.TabIndex = 27;
            this.btnBackMinut.Text = "-1 minut";
            this.btnBackMinut.UseVisualStyleBackColor = true;
            this.btnBackMinut.Click += new System.EventHandler(this.btnBackMinut_Click);
            // 
            // btnBackSecond
            // 
            this.btnBackSecond.Location = new System.Drawing.Point(433, 285);
            this.btnBackSecond.Name = "btnBackSecond";
            this.btnBackSecond.Size = new System.Drawing.Size(75, 23);
            this.btnBackSecond.TabIndex = 28;
            this.btnBackSecond.Text = "-1 sekund";
            this.btnBackSecond.UseVisualStyleBackColor = true;
            this.btnBackSecond.Click += new System.EventHandler(this.btnBackSecond_Click);
            // 
            // btnForwardSecond
            // 
            this.btnForwardSecond.Location = new System.Drawing.Point(433, 215);
            this.btnForwardSecond.Name = "btnForwardSecond";
            this.btnForwardSecond.Size = new System.Drawing.Size(75, 23);
            this.btnForwardSecond.TabIndex = 31;
            this.btnForwardSecond.Text = "+1 sekund";
            this.btnForwardSecond.UseVisualStyleBackColor = true;
            this.btnForwardSecond.Click += new System.EventHandler(this.btnForwardSecond_Click);
            // 
            // btnForwardMinut
            // 
            this.btnForwardMinut.Location = new System.Drawing.Point(433, 186);
            this.btnForwardMinut.Name = "btnForwardMinut";
            this.btnForwardMinut.Size = new System.Drawing.Size(75, 23);
            this.btnForwardMinut.TabIndex = 30;
            this.btnForwardMinut.Text = "+1 minut";
            this.btnForwardMinut.UseVisualStyleBackColor = true;
            this.btnForwardMinut.Click += new System.EventHandler(this.btnForwardMinut_Click);
            // 
            // btnForwardHour
            // 
            this.btnForwardHour.Location = new System.Drawing.Point(433, 157);
            this.btnForwardHour.Name = "btnForwardHour";
            this.btnForwardHour.Size = new System.Drawing.Size(75, 23);
            this.btnForwardHour.TabIndex = 29;
            this.btnForwardHour.Text = "+1 time";
            this.btnForwardHour.UseVisualStyleBackColor = true;
            this.btnForwardHour.Click += new System.EventHandler(this.btnForwardHour_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tid frem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tid tilbage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(644, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Gæt:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(716, 439);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 29);
            this.lblResult.TabIndex = 35;
            // 
            // FrmClockTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 489);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnForwardSecond);
            this.Controls.Add(this.btnForwardMinut);
            this.Controls.Add(this.btnForwardHour);
            this.Controls.Add(this.btnBackSecond);
            this.Controls.Add(this.btnBackMinut);
            this.Controls.Add(this.btnBackHour);
            this.Controls.Add(this.chkLiveClock);
            this.Controls.Add(this.btnStopLive);
            this.Controls.Add(this.btnStartLive);
            this.Controls.Add(this.chkHard);
            this.Controls.Add(this.btnNewAssignment);
            this.Controls.Add(this.btnShowGuessHours);
            this.Controls.Add(this.chkShowSeconds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.analogClockGuess);
            this.Controls.Add(this.analogClock);
            this.Controls.Add(this.cmbSecond);
            this.Controls.Add(this.cmbMinute);
            this.Controls.Add(this.cmbHour);
            this.Controls.Add(this.btnGuessHard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmClockTrainer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Lær tiden";
            this.Load += new System.EventHandler(this.FrmClockTrainer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuessHard;
        private System.Windows.Forms.ComboBox cmbHour;
        private System.Windows.Forms.ComboBox cmbMinute;
        private System.Windows.Forms.ComboBox cmbSecond;
        private AnalogClock analogClock;
        private AnalogClock analogClockGuess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowSeconds;
        private System.Windows.Forms.Button btnShowGuessHours;
        private System.Windows.Forms.Button btnNewAssignment;
        private System.Windows.Forms.CheckBox chkHard;
        private System.Windows.Forms.Button btnStartLive;
        private System.Windows.Forms.Button btnStopLive;
        private System.Windows.Forms.CheckBox chkLiveClock;
        private System.Windows.Forms.Button btnBackHour;
        private System.Windows.Forms.Button btnBackMinut;
        private System.Windows.Forms.Button btnBackSecond;
        private System.Windows.Forms.Button btnForwardSecond;
        private System.Windows.Forms.Button btnForwardMinut;
        private System.Windows.Forms.Button btnForwardHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblResult;
    }
}

