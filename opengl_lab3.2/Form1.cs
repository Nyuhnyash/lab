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
        float a;
        PolygonMode pm;
        bool ortho =true;
        bool ortho_prev = false;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
//            MessageBox.Show(@"Q - смена PolygonMode
//Page Up/Down - вращение по Z
//R - сброс всех настроек
//P - смена матрицы проекций
//", "Управление");
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;

            zoom = ortho ? 20 : -2;
            a = 1f / 2;
            pm = PolygonMode.Fill;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);


            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            if (ortho)
            {
                Matrix4 matrix4 = new Matrix4(new Matrix3(zoom, 0, 0, 0, zoom, 0, 0, 0, zoom));
                GL.LoadMatrix(ref matrix4);
            }
            else
                GL.Translate(0, 0, zoom);
            //поворот камеры
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            float o = 20;
            if (ortho != ortho_prev)
            {
                
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                if (ortho)
                    GL.Ortho(-o, o, -o, o, -o, o);
                else
                {
                    float fov = 80;
                    Matrix4 m = Matrix4.CreatePerspectiveFieldOfView((float)(fov * Math.PI / 180), 1, 0.1f, 100f);
                    GL.LoadMatrix(ref m);
                    GL.Frustum(-o, o, -o, o, -o, o);
                }
                ortho_prev = ortho;
            }

            
            
            GL.Enable(EnableCap.DepthTest);

            GL.ShadeModel(ShadingModel.Flat);
            Color[] c = { Color.Blue, Color.Green, Color.Red, Color.White, Color.Orange, Color.Yellow };
            Cube(a,c);

            for (int i = 0; i < c.Length; i++)
                c[i] = Color.LightGray;
            Cube(20*a, c);

            GL.ShadeModel(ShadingModel.Smooth);
            Axis(6);

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }
        void Axis(float a)
        {
            GL.Begin(PrimitiveType.Lines);
            // ось x
            GL.Color3(Vector3.One); GL.Vertex2(-a, 0);
            GL.Color3(Color.Blue); GL.Vertex2(a, 0);
            // ось y
            GL.Color3(Vector3.One); GL.Vertex2(0, -a);
            GL.Color3(Color.Green); GL.Vertex2(0, a);
            // ось z
            GL.Color3(Vector3.One); GL.Vertex3(0, 0, -a);
            GL.Color3(Color.Red); GL.Vertex3(0, 0, a);
            GL.End();
        }
        void Cube(float a, Color[] c)
        {
            a /= 2;
            GL.PolygonMode(MaterialFace.Front, pm);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(c[0]);
            GL.Vertex3(a, a, a);
            GL.Vertex3(a, -a, a);
            GL.Vertex3(a, -a, -a);
            GL.Vertex3(a, a, -a);
            GL.Color3(c[1]);
            GL.Vertex3(-a, a, a);
            GL.Vertex3(-a, -a, a);
            GL.Vertex3(-a, -a, -a);
            GL.Vertex3(-a, a, -a);
            GL.End();

            GL.Begin(PrimitiveType.QuadStrip);
            GL.Color3(c[2]);
            GL.Vertex3(-a, -a, a);
            GL.Vertex3(a, -a, a);
            GL.Vertex3(-a, a, a);
            GL.Vertex3(a, a, a);
            GL.Color3(c[3]);
            GL.Vertex3(-a, a, -a);
            GL.Vertex3(a, a, -a);
            GL.Color3(c[4]);
            GL.Vertex3(-a, -a, -a);
            GL.Vertex3(a, -a, -a);
            GL.Color3(c[5]);
            GL.Vertex3(-a, -a, a);
            GL.Vertex3(a, -a, a);
            GL.End();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q: pm = pm == PolygonMode.Fill ? PolygonMode.Line : PolygonMode.Fill; break;
                case Keys.P: ortho = !ortho; Reset();                 break;
                case Keys.R:        Reset();                          break;
                case Keys.Prior:    angleZ += 5;                      break;
                case Keys.Next:     angleZ -= 5;                      break;
                case Keys.Escape: Application.Exit();                 break;
            }
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
                angleY -= e.X - moX;
                angleX -= e.Y - moY;
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