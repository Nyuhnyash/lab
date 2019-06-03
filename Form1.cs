using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sorting
{
    public partial class Form1 : Form
    {
        Sorting srtng;
        public Form1()
        {
            InitializeComponent();
            

        }
        void DataGridOut(List<int> data, int j)
        {
            for (int i = 0; i < data.Count; i++)
            {
                dataGridView1[j, i+1].Value = data[i].ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Время:");
            int count = (int)numericUpDown1.Value;
            srtng = new Sorting(count);
            for (int i = 0; i < count; i++)
                dataGridView1.Rows.Add();
            srtng.Random();
            srtng.Data[7] = 77;
            DataGridOut(srtng.Data, 0);
            DateTime dt = DateTime.Now;
            DataGridOut(srtng.Bubble(), 1);
            dataGridView1[1,0].Value = (DateTime.Now - dt).TotalSeconds*1000;
            dt = DateTime.Now;
            DataGridOut(srtng.Selection(), 2);
            dataGridView1[2, 0].Value = (DateTime.Now - dt).TotalSeconds*1000;
            dt = DateTime.Now;
            DataGridOut(srtng.Insertion(), 3);
            dataGridView1[3, 0].Value = (DateTime.Now - dt).TotalSeconds*1000;
            dt = DateTime.Now;


            ch.ChartAreas.Add(new ChartArea("Math functions"));
            //DataPoint dp = dataPoint1;
            //mySeriesOfPoint.ChartArea = "Math functions";
            //for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            //{
            //    mySeriesOfPoint.Points.AddXY(x, Math.Sin(x));
            //}
            ////Добавляем созданный набор точек в Chart
            //ch.Series.Add(mySeriesOfPoint);


        }
    }
}
