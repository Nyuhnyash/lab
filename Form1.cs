using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

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
                dataGridView1[j, i].Value = data[i].ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Width = 500;
            ch.Visible = true;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ch.Series.Count; i++)
                ch.Series[i].Points.Clear();
            //dataGridView1.Rows.Add("Время:");
            int count = (int)numericUpDown1.Value;
            srtng = new Sorting(count);
            for (int i = 0; i < count; i++)
                dataGridView1.Rows.Add();
            for (int n = 0; n < 3; n++) // три набора данных
            {
                srtng.Generate();
                DataGridOut(srtng.Data, n);
                StreamWriter sw = new StreamWriter("log.txt", true);
                for (int i = 0; i < 4; i++)
                {
                    DateTime dt = DateTime.Now;
                    var r = srtng.Sort(i);
                    var t = (DateTime.Now - dt).TotalMilliseconds;
                    //DataGridOut(r, i + 1);
                    //dataGridView1[i + 1, 0].Value = t;
                    ch.Series[i].Points.AddY(t);
                    sw.Write(t + " ");
                }
                sw.WriteLine();
                sw.Close();
            }
        }
    }
}
