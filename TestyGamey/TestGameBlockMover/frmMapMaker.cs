using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockMoverGameFiles;

namespace TestGameBlockMover
{
    public partial class frmMapMaker : Form
    {
        GameController worker = new GameController();

        public frmMapMaker()
        {
            InitializeComponent();
            SetMap(new int[] { 3,3,3,3,3,3,3,3,3 }, 3, 3);
            worker.OnMapChange += Stuff;
            
        }

        private int[] LoadMap(string path)
        {
            if(System.IO.File.Exists(path))
            {
                int[] map = new int[9 * 9];
                System.IO.StreamReader reader = new System.IO.StreamReader(path);

                int i = 0;
                int input = -1;
                while (!reader.EndOfStream)
                {
                    string read = reader.ReadLine();
                    if (read != "" || read != null)
                    {
                        int.TryParse(read, out input);
                        map[i] = input;
                        i++;
                    }
                }
                reader.Close();
                return map;
            }
            throw new Exception("No path");
        }

        private void SetMap(int[] map, int columns, int rows)
        {
            //worker.LoadMapFromArray(map, columns, rows);
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < columns * rows; i++)
            {
                Control cc = new Control();
                cc.Margin = new Padding(0);
                cc.Tag = map[i];
                cc.BackColor = GetColor((TerrainType)map[i]);

                cc.Size = new Size(flowLayoutPanel1.Width / columns, flowLayoutPanel1.Height / rows);
                cc.Click += Cc_Click;
                flowLayoutPanel1.Controls.Add(cc);
            }
        }

        private int[] GetMapArray(int[,] map)
        {
            int a = map.GetLength(0);
            int b = map.GetLength(1);
            int arraySize = a * b;
            int[] array = new int[arraySize];

            int c = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array[c] = map[i, j];
                    c++;
                }
            }

            return array;
        }

        private void Cc_Click(object sender, EventArgs e)
        {
            int tag = 0;
            foreach (var item in groupBox1.Controls)
            {
                if (item is RadioButton && ((RadioButton)item).Checked)
                {
                    int.TryParse(((RadioButton)item).Tag.ToString(), out tag);
                }
            }
            ((Control)sender).BackColor = GetColor((TerrainType)tag);
            ((Control)sender).Tag = tag;

            int[] array = new int[flowLayoutPanel1.Controls.Count];
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                array[i] = (int)((Control)sender).Tag;
            }
            //worker.LoadMapFromArray(array, 3, 3);
        }

        private Color GetColor(TerrainType tag)
        {
            Color c = Color.Gray;
            switch (tag)
            {
                case TerrainType.Player: //start
                    c = Color.DarkRed;
                    break;
                case TerrainType.Goal: //goal
                    c = Color.LightGoldenrodYellow;
                    break;
                case TerrainType.Wall: //wall
                    c = Color.Black;
                    break;
                case TerrainType.Empty: //empty
                    c = Color.Gray;
                    break;
                case TerrainType.MoveableBlock: //block
                    c = Color.Blue;
                    break;
            }
            return c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] testy = new int[flowLayoutPanel1.Controls.Count];

            for (int i = 0; i < testy.Length; i++)
            {
                testy[i] = (int)flowLayoutPanel1.Controls[i].Tag;
            }
            //int[,] tt = worker.FromArray(testy, 9, 9);

            string path = @"D:\maparray.txt";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path);

            for (int i = 0; i < testy.Length; i++)
            {
                writer.WriteLine(testy[i]);
            }
            writer.Flush();
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetMap(LoadMap(@"D:\maparray.txt"), 9, 9);
        }

        private void ChangeFlow(int[] to)
        {
            if (flowLayoutPanel1.Controls.Count != to.Length)
            {
                throw new Exception("Stuff died");
            }
            for (int i = 0; i < to.Length; i++)
            {
                if ((int)flowLayoutPanel1.Controls[i].Tag != to[i])
                {
                    flowLayoutPanel1.Controls[i].BackColor = GetColor((TerrainType)to[i]);
                    flowLayoutPanel1.Controls[i].Tag = to[i];
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                worker.MovePlayer(Directon.Right);
            }
            else if (e.KeyCode == Keys.A)
            {
                worker.MovePlayer(Directon.Left);
            }
            else if (e.KeyCode == Keys.W)
            {
                worker.MovePlayer(Directon.Up);
            }
            else if (e.KeyCode == Keys.S)
            {
                worker.MovePlayer(Directon.Down);
            }
            //ChangeFlow(worker.MapArray);
        }

        private int[] Stuff(TerrainType[] i)
        {
            return null;
        }
    }
}
