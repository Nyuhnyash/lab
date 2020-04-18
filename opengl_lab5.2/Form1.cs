using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY, angleZ, angleLightXoY, angleLightYoZ, lightSourceSpeed;
        const float o = 20, fov = 80 * (float)(Math.PI / 180);
        int K, N;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;
            zoom = -3;
            K = 10;
            N = 5;
            lightSourceSpeed = 1;
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Normalize);
            GL.Enable(EnableCap.Lighting);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 m = Matrix4.CreatePerspectiveFieldOfView(fov, 1, 0.1f, 100f);
            GL.LoadMatrix(ref m);
            GL.Frustum(-o, o, -o, o, -o, o);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(0, 0, zoom);
            //поворот камеры
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            
            GL.ShadeModel(ShadingModel.Smooth);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, Color.Green);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 50);

            GL.PointSize(5);
            if (cbXoY.Checked)
            {
                GL.Enable(EnableCap.Light0);
                var al = angleLightXoY * (float)Math.PI / 180;
                float x = 2 * (float)Math.Cos(al), y = 2 * (float)Math.Sin(al);
                Vector3 light0Pos = new Vector3(x, y, 0);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex3(light0Pos);
                GL.End();
                light0Pos.Z = -light0Pos.Z;
                GL.Light(LightName.Light0, LightParameter.Position, new Vector4(light0Pos));
                GL.Light(LightName.Light0, LightParameter.Ambient, Vector4.UnitW);
                GL.Light(LightName.Light0, LightParameter.Diffuse, Color.Red);
                GL.Light(LightName.Light0, LightParameter.Specular, Color.White);
                //GL.Light(LightName.Light0, LightParameter.SpotDirection, Vector4.UnitZ);
            }
            else GL.Disable(EnableCap.Light0);
            if (cbYoZ.Checked)
            {
                GL.Enable(EnableCap.Light1);
                var al = angleLightYoZ * (float)Math.PI / 180;
                float y = 2 * (float)Math.Cos(al), z = 2 * (float)Math.Sin(al);
                Vector3 light1Pos = new Vector3(0, y, z);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex3(light1Pos);
                GL.End();
                light1Pos.Z = -light1Pos.Z;
                GL.Light(LightName.Light1, LightParameter.Position, new Vector4(light1Pos));
                GL.Light(LightName.Light1, LightParameter.Diffuse, Color.Blue);
                GL.Light(LightName.Light1, LightParameter.Specular, Color.White);
                //GL.Light(LightName.Light1, LightParameter.SpotDirection, Vector4.UnitZ);
            }
            else GL.Disable(EnableCap.Light1);

            GL.LightModel(LightModelParameter.LightModelAmbient, 1);

            Sphere(0,0,0,0.9,K,N);

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }
        private void Sphere(double x0, double y0, double z0, double r, int nx, int ny)
        {
            double x, y, z;

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            for (int iy = 0; iy < ny; ++iy)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                for (int ix = 0; ix <= nx; ++ix)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        x = x0 + r * Math.Sin((iy + i) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                        y = y0 + r * Math.Sin((iy + i) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                        z = z0 + r * Math.Cos((iy + i) * Math.PI / ny);

                        GL.Normal3(x, y, z);
                        GL.Vertex3(x, y, z);
                    }
                }
                GL.End();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            angleLightXoY+=lightSourceSpeed;
            angleLightYoZ+=lightSourceSpeed;
            glControl1.Invalidate();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            K = (int)numK.Value;
            N = (int)numN.Value;
            lightSourceSpeed = (int)numLSSpeed.Value;
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:        Reset();                          break;
                case Keys.Prior:    angleZ += 5;                      break;
                case Keys.Next:     angleZ -= 5;                      break;
                case Keys.Escape: Application.Exit();                 break;
                case Keys.S: angleLightYoZ -= 5f; break;
                case Keys.W: angleLightYoZ += 5f; break;
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