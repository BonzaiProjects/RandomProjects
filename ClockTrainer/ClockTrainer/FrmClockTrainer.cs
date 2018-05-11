using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockTrainer
{
    public partial class FrmClockTrainer : Form
    {
        public FrmClockTrainer()
        {
            InitializeComponent();
        }

        private void FrmClockTrainer_Load(object sender, EventArgs e)
        {
            cmbSecond.Enabled = false;

            FillComboBoxes();

            //CreateAssignment();
        }

        private void FillComboBoxes(bool hard = false)
        {
            cmbHour.Items.Clear();
            cmbMinute.Items.Clear();
            cmbSecond.Items.Clear();

            for (int i = 0; i <= 60; i++)
            {
                cmbSecond.Items.Add(i);
            }

            if (hard)
            {
                for (int i = 0; i < 12; i++)
                {
                    cmbHour.Items.Add(i + 1);
                }

                for (int i = 0; i < 60; i++)
                {
                    cmbMinute.Items.Add(i);
                }
            }
            else
            {
                cmbHour.Items.AddRange(new string[] { "Hel", "5 over", "10 over", "Kvart over", "20 over", "5 i halv", "Halv", "5 over halv", "20 i", "Kvart i", "10 i", "5 i" });
                
                for (int i = 0; i < 12; i++)
                {
                    cmbMinute.Items.Add(i + 1);
                }
            }

            cmbHour.SelectedIndex = 0;
            cmbMinute.SelectedIndex = 0;
            cmbSecond.SelectedIndex = 0;

            analogClock.ShowTime();
            analogClockGuess.ShowTime();
        }

        private void btnGuessHard_Click(object sender, EventArgs e)
        {
            ShowGuess();

            DateTime assignment = analogClock.GetDateTime;
            DateTime guess;

            if (chkHard.Checked)
            {
                // hard guess
                int hour = (int)cmbHour.SelectedItem;
                int minute = (int)cmbMinute.SelectedItem;
                int second = assignment.Second;

                if (chkShowSeconds.Checked)
                {
                    second = (int)cmbSecond.SelectedItem;
                }

                guess = new DateTime(assignment.Year, assignment.Month, assignment.Day, hour, minute, second);
            }
            else
            {
                // easy guess
                int[] temp = GetHourMinute((int)cmbMinute.SelectedItem, (string)cmbHour.SelectedItem);
                guess = new DateTime(assignment.Year, assignment.Month, assignment.Day, temp[0], temp[1], assignment.Second);
            }

            if (assignment.Hour == 0 && (guess.Hour == 12 || guess.Hour == 0) && guess.Minute == 0 && guess.Second == 0)
            {
                lblResult.Text = "RIGTIGT! :)";
                lblResult.ForeColor = Color.Green;
                return;
            }
            if (assignment == guess)
            {
                lblResult.Text = "RIGTIGT! :)";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = "FORKERT! :(";
                lblResult.ForeColor = Color.Red;
            }
        }

        private int[] GetHourMinute(int hours, string quarter)
        {
            int[] temp = new int[2];

            int minute = 0;
            int hour = hours;

            switch (quarter)
            {
                case "Hel":
                    minute = 0;
                    break;
                case "5 over":
                    minute = 5;
                    break;
                case "10 over":
                    minute = 10;
                    break;
                case "Kvart over":
                    minute = 15;
                    break;
                case "20 over":
                    minute = 20;
                    break;
                case "5 i halv":
                    minute = 25;
                    break;
                case "Halv":
                    minute = 30;
                    hour--;
                    break;
                case "5 over halv":
                    minute = 35;
                    hour--;
                    break;
                case "20 i":
                    minute = 40;
                    hour--;
                    break;
                case "Kvart i":
                    minute = 45;
                    hour--;
                    break;
                case "10 i":
                    minute = 50;
                    hour--;
                    break;
                case "5 i":
                    minute = 55;
                    hour--;
                    break;
                default:
                    break;
            }

            temp[0] = hour;
            temp[1] = minute;

            return temp;
        }

        private void btnShowGuessHours_Click(object sender, EventArgs e)
        {
            ShowGuess();
        }

        private void ShowGuess()
        {
            if (chkHard.Checked)
            {
                analogClockGuess.ShowTime((int)cmbHour.SelectedItem, (int)cmbMinute.SelectedItem, (int)cmbSecond.SelectedItem);
            }
            else
            {
                int[] temp = GetHourMinute((int)cmbMinute.SelectedItem, (string)cmbHour.SelectedItem);

                analogClockGuess.ShowTime(temp[0], temp[1]);
            }
        }

        private void chkShowSeconds_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSeconds.Checked)
            {
                cmbSecond.Enabled = true;
                analogClock.DrawHandSeconds = true;
                analogClockGuess.DrawHandSeconds = true;
            }
            else
            {
                cmbSecond.Enabled = false;
                analogClock.DrawHandSeconds = false;
                analogClockGuess.DrawHandSeconds = false;
            }
            analogClock.Refresh();
            analogClockGuess.Refresh();
        }

        private void btnNewAssignment_Click(object sender, EventArgs e)
        {
            CreateAssignment();
            lblResult.Text = "";
        }

        private void CreateAssignment()
        {
            TrainingSettings t = new TrainingSettings();

            if (chkHard.Checked)
            {
                t.UseAllNumbers = true;
            }
            if (chkShowSeconds.Checked)
            {
                t.UseSeconds = true;
            }
            analogClock.ShowTime(t.CreateTrainingSession());
        }

        private void btnStopLive_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
        }

        private void btnStartLive_Click(object sender, EventArgs e)
        {
            analogClock.Start(chkLiveClock.Checked);
        }

        private void chkHard_CheckedChanged(object sender, EventArgs e)
        {
            FillComboBoxes(chkHard.Checked);

            CreateAssignment();
        }

        private void btnBackSecond_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddSeconds(-1));
        }

        private void btnBackMinut_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddMinutes(-1));
        }

        private void btnBackHour_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddHours(-1));
        }

        private void btnForwardSecond_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddSeconds(1));
        }

        private void btnForwardMinut_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddMinutes(1));
        }

        private void btnForwardHour_Click(object sender, EventArgs e)
        {
            analogClock.Stop();
            analogClock.ShowTime(analogClock.GetDateTime.AddHours(1));
        }
    }
}
