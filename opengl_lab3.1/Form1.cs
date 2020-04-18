using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY, angleZ;
        float R, r;
        double step;
        PrimitiveType pt;
        PolygonMode pm;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
            MessageBox.Show(@"T - смена PrimitiveType
Q - смена PolygonType
Page Up/Down - вращение по Z
NumPad +/- - изменение малого радиуса
Стрелки вверх/вниз - количество полигонов
R - сброс всех настроек","Управление");
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;
            zoom = 1; 
            R = 4; r = 0.8f;
            step = Math.PI / 12;
            pt = PrimitiveType.QuadStrip;
            pm = PolygonMode.Line;
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            float o = 6;
            GL.Ortho(-o, o, -o, o, -o, o);
            GL.MatrixMode(MatrixMode.Modelview);
            glControl1.Invalidate();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            Matrix4 matrix4 = new Matrix4(new Matrix3(zoom, 0, 0, 0, zoom, 0, 0, 0, zoom));
            GL.LoadMatrix(ref matrix4);
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            GL.Begin(PrimitiveType.Lines);
            // ось x
            GL.Color3(Vector3.One); GL.Vertex2(-6, 0);
            GL.Color3(Color.Blue); GL.Vertex2(6, 0);
            // ось y
            GL.Color3(Vector3.One); GL.Vertex2(0, -6);
            GL.Color3(Color.Green); GL.Vertex2(0, 6);
            // ось z
            GL.Color3(Vector3.One); GL.Vertex3(0, 0, -6);
            GL.Color3(Color.Red); GL.Vertex3(0, 0, 6);
            GL.End();

            GL.Color3(Color.DarkGray);
            GL.PolygonMode(MaterialFace.FrontAndBack, pm);
            GL.Begin(pt);
                for (double psi = -Math.PI; psi < Math.PI; psi+=step)
                {
                    for (double fi = 0; fi < 2 * Math.PI; fi += step)
                    {
                        Coords(fi, psi, out var x, out var y, out var z);
                        GL.Vertex3(x, y, z);
                        Coords(fi, psi+step, out x, out y, out z);
                        GL.Vertex3(x, y, z);
                    }
                }
            GL.End();

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }

        void Coords(double fi, double psi, out double x, out double y, out double z)
        {
            x = (R + r * Math.Cos(psi)) * Math.Cos(fi);
            y = (R + r * Math.Cos(psi)) * Math.Sin(fi);
            z = r * Math.Sin(psi);
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.T: pt = pt == PrimitiveType.TriangleStrip ? PrimitiveType.QuadStrip : PrimitiveType.TriangleStrip; break;
                case Keys.Q: pm = pm == PolygonMode.Fill ? PolygonMode.Line : PolygonMode.Fill; break;
                case Keys.R:        Reset();                          break;
                case Keys.Subtract: r -= 0.2f;                        break;
                case Keys.Add:      r += 0.2f;                        break;
                case Keys.Prior:    angleZ += 5;                      break;
                case Keys.Next:     angleZ -= 5;                      break;
            }
            glControl1.Invalidate();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up) step += Math.PI/48;
            if (e.KeyCode == Keys.Down) step -= Math.PI/48;
            glControl1.Invalidate();
        }

        bool LMB_is_down = false;
        int moX, moY;
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LMB_is_down = true;
                moX = e.X;
                moY = e.Y;
            }
        }
        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                LMB_is_down = false;
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LMB_is_down)
            {
                angleY += e.X - moX;
                angleX += e.Y - moY;
                glControl1.Invalidate();

                moX = e.X;
                moY = e.Y;
            }
        }
        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom += (e.Delta * 0.2f / 120);
            glControl1.Invalidate();
        }
    }
}