namespace TestGameBlockMover
{
    partial class frmMapMaker
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
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbBlock = new System.Windows.Forms.RadioButton();
            this.rdbEmpty = new System.Windows.Forms.RadioButton();
            this.rdbWall = new System.Windows.Forms.RadioButton();
            this.rdbGoal = new System.Windows.Forms.RadioButton();
            this.rdbStart = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(749, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(731, 473);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbBlock);
            this.groupBox1.Controls.Add(this.rdbEmpty);
            this.groupBox1.Controls.Add(this.rdbWall);
            this.groupBox1.Controls.Add(this.rdbGoal);
            this.groupBox1.Controls.Add(this.rdbStart);
            this.groupBox1.Location = new System.Drawing.Point(749, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rdbBlock
            // 
            this.rdbBlock.AutoSize = true;
            this.rdbBlock.Location = new System.Drawing.Point(6, 111);
            this.rdbBlock.Name = "rdbBlock";
            this.rdbBlock.Size = new System.Drawing.Size(52, 17);
            this.rdbBlock.TabIndex = 4;
            this.rdbBlock.TabStop = true;
            this.rdbBlock.Tag = "4";
            this.rdbBlock.Text = "Block";
            this.rdbBlock.UseVisualStyleBackColor = true;
            // 
            // rdbEmpty
            // 
            this.rdbEmpty.AutoSize = true;
            this.rdbEmpty.Checked = true;
            this.rdbEmpty.Location = new System.Drawing.Point(6, 88);
            this.rdbEmpty.Name = "rdbEmpty";
            this.rdbEmpty.Size = new System.Drawing.Size(54, 17);
            this.rdbEmpty.TabIndex = 3;
            this.rdbEmpty.TabStop = true;
            this.rdbEmpty.Tag = "3";
            this.rdbEmpty.Text = "Empty";
            this.rdbEmpty.UseVisualStyleBackColor = true;
            // 
            // rdbWall
            // 
            this.rdbWall.AutoSize = true;
            this.rdbWall.Location = new System.Drawing.Point(6, 65);
            this.rdbWall.Name = "rdbWall";
            this.rdbWall.Size = new System.Drawing.Size(46, 17);
            this.rdbWall.TabIndex = 2;
            this.rdbWall.TabStop = true;
            this.rdbWall.Tag = "2";
            this.rdbWall.Text = "Wall";
            this.rdbWall.UseVisualStyleBackColor = true;
            // 
            // rdbGoal
            // 
            this.rdbGoal.AutoSize = true;
            this.rdbGoal.Location = new System.Drawing.Point(6, 42);
            this.rdbGoal.Name = "rdbGoal";
            this.rdbGoal.Size = new System.Drawing.Size(47, 17);
            this.rdbGoal.TabIndex = 1;
            this.rdbGoal.TabStop = true;
            this.rdbGoal.Tag = "1";
            this.rdbGoal.Text = "Goal";
            this.rdbGoal.UseVisualStyleBackColor = true;
            // 
            // rdbStart
            // 
            this.rdbStart.AutoSize = true;
            this.rdbStart.Location = new System.Drawing.Point(6, 19);
            this.rdbStart.Name = "rdbStart";
            this.rdbStart.Size = new System.Drawing.Size(47, 17);
            this.rdbStart.TabIndex = 0;
            this.rdbStart.TabStop = true;
            this.rdbStart.Tag = "0";
            this.rdbStart.Text = "Start";
            this.rdbStart.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(749, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMapMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 558);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "frmMapMaker";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEmpty;
        private System.Windows.Forms.RadioButton rdbWall;
        private System.Windows.Forms.RadioButton rdbGoal;
        private System.Windows.Forms.RadioButton rdbStart;
        private System.Windows.Forms.RadioButton rdbBlock;
        private System.Windows.Forms.Button button2;
    }
}

