using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTK
{
    public partial class Form1 : Form
    {
        const double t_step = 0.1 * Math.PI, r_step = 0.25;
        double R = 2, t = 2.1*Math.PI;
        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-6, 6, -3, 3, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.LineStrip);
            for (double t = 0; t != this.t; t += t_step * Math.Sign(this.t))
                GL.Vertex2(R * (1 + Math.Sin(3 * t)), R * Math.Cos(t));
            GL.End();

            glControl1.SwapBuffers();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (t > 8 * Math.PI && e.KeyCode == Keys.Left)
                t -= t_step;
            if (t < 8 * Math.PI && e.KeyCode == Keys.Right)
                t += t_step;
            if (R < 3 && e.KeyCode == Keys.Up)
                R += r_step;
            if (R > -3 && e.KeyCode == Keys.Down)
                R -= r_step;

            glControl1.Invalidate();

        }
    }
}
