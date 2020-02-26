using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        int Count = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-20, 20, -20, 20, -20, 20);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(Color.Black);
            int x = 0, y = 0;
            GL.Vertex2(x, y);
            for (int i = 0; i < Count; i++)
            {
                y += i * (int)Math.Pow(-1, i % 2);
                GL.Vertex2(x, y);
                x -= i * (int)Math.Pow(-1, i % 2);
                GL.Vertex2(x, y);
            }
            GL.End();

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Count < 40 && e.KeyCode == Keys.Oemplus)
                Count++;
            if (Count > 1 && e.KeyCode == Keys.OemMinus)
                Count--;
            glControl1.Invalidate();
        }
    }
}