using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Form2 : Form
    {
        Graphics bm;
        Pen pen;
        SolidBrush brush, whiteB;
        Font font;
        float xCenter, yCenter;
        const float size = 40;
        float radius = 130;
        int dotsCount = 10;

        float[] arrX, arrY;

        public Form2()
        {
            InitializeComponent();
            bm = pictureBox1.CreateGraphics();
            xCenter = pictureBox1.Width / 2;
            yCenter = pictureBox1.Height / 2;

            radius = Math.Min(xCenter, yCenter) - size / 2;

            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Black);
            whiteB = new SolidBrush(Color.White);
            font = new Font(FontFamily.GenericMonospace, size * 3 / 4);
            SetTable();
        }
        //случайное построение
        private void button1_Click(object sender, EventArgs e)
        {
            bm.Clear(Color.White);
            SetCenters();
            Random rnd = new Random();

            for (int i = 0; i < dotsCount; i++)
                for (int j = 0; j < dotsCount; j++)
                    if (rnd.NextDouble() < 0.2d)
                        Connect(i, j);
            DrawVertexes();
        }

        void InitGraph(int N)
        {
            arrX = new float[N];
            arrY = new float[N];
        }
        //Задать
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dotsCount = int.Parse(textBox1.Text);
            SetTable();
            SetCenters();
        }
        //очистка
        private void button4_Click(object sender, EventArgs e)
        {
            bm.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bm.Clear(Color.White);
            int[,] arr = new int[dotsCount, dotsCount];

            for (int i = 0; i < dotsCount; i++)
            {
                for (int j = 0; j < dotsCount; j++)
                {
                    arr[i, j] = int.Parse(dataGridView1[i, j].Value.ToString());
                }
            }
            for (int i = 0; i < dotsCount; i++)
            {
                for (int j = 0; j < dotsCount; j++)
                {
                    if (arr[i, j] == 1)
                        Connect(i, j);
                }
            }
            DrawVertexes();
        }

        void SetCoord(int ind, float x, float y)
        {
            arrX[ind] = x;
            arrY[ind] = y;
        }

        void Connect(int from, int to)
        {
            bm.DrawLine(pen, arrX[from], arrY[from], arrX[to], arrY[to]);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void DrawVertexes()
        {
            for (int i = 0; i < dotsCount; i++)
            {
                float x = arrX[i] - size / 2;
                float y = arrY[i] - size / 2;

                bm.FillEllipse(whiteB, x, y, size, size);
                bm.DrawEllipse(pen, x, y, size, size);
                bm.DrawString(i.ToString(), font, brush, x, y);
            }
        }
        void SetCenters()
        {
            InitGraph(dotsCount);

            for (int i = 0; i < dotsCount; i++)
            {
                double dX = Math.Cos((2 * Math.PI / dotsCount) * i) * radius;
                double dY = Math.Sin((2 * Math.PI / dotsCount) * i) * radius;

                float x = (float)(xCenter + dX);
                float y = (float)(yCenter + dY);

                SetCoord(i, x, y);
            }
        }
        void SetTable()
        {
            for (int i = 0; i < dotsCount; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Columns[i].Width = dataGridView1.Width / (dotsCount + 1);
            }
            dataGridView1.Rows.Add(dotsCount);

            for (int i = 0; i < dotsCount; i++)
            {
                for (int j = 0; j < dotsCount; j++)
                {
                    dataGridView1[i, j].Value = "0";
                }
            }
        }
        private void ButtonWay_Click(object sender, EventArgs e)
        {
            int le = dataGridView1.Columns.Count;
            int[,] a = new int[le, le ];
            for (int i = 0; i < le; i++)
                for (int j = 0; j < le; j++)
                    a[i, j] = int.Parse(dataGridView1[i, j].Value.ToString());
            textBoxWayout.Lines = 
            Dijkstra.DijkstraAlgo(a, int.Parse(textBoxOt.Text), a.GetLength(0));

        }
    }
}
