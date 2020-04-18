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
        const float o = 20, fov = 80 * (float)(Math.PI / 180);
        PolygonMode pm;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
            MessageBox.Show(@"Q - смена PolygonMode
Page Up/Down - вращение по Z
R - сброс всех настроек
", "Управление");
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;
            zoom = -2;
            pm = PolygonMode.Fill;
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Enable(EnableCap.DepthTest);

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

            GL.PolygonMode(MaterialFace.FrontAndBack, pm);
            Icosahedron();

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

        #region icosahedron
        const float X = .525731112119133606f,
                    Z = .850650808352039932f,
                    N = 0f;
        readonly float[,] vertices =
        {
            {-X,N,Z}, {X,N,Z}, {-X,N,-Z}, {X,N,-Z},
            {N,Z,X}, {N,Z,-X}, {N,-Z,X}, {N,-Z,-X},
            {Z,X,N}, {-Z,X, N}, {Z,-X,N}, {-Z,-X, N}
        };
        readonly int[,] triangles =
        {
            {0,4,1},{0,9,4},{9,5,4},{4,5,8},{4,8,1},
            {8,10,1},{8,3,10},{5,3,8},{5,2,3},{2,7,3},
            {7,10,3},{7,6,10},{7,11,6},{11,0,6},{0,1,6},
            {6,1,10},{9,0,11},{9,11,2},{9,2,5},{7,2,11}
        };
        void Icosahedron()
        {
            Random r = new Random(1);
            for (int i = 0; i < 20; i++)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                GL.Color3(r.Next(), r.Next(), r.Next());
                GL.Vertex3(vertices[triangles[i, 0], 0], vertices[triangles[i, 0], 1], vertices[triangles[i, 0], 2]);
                GL.Vertex3(vertices[triangles[i, 1], 0], vertices[triangles[i, 1], 1], vertices[triangles[i, 1], 2]);
                GL.Vertex3(vertices[triangles[i, 2], 0], vertices[triangles[i, 2], 1], vertices[triangles[i, 2], 2]);
                GL.End();
            }
        }
        #endregion

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q: pm = pm == PolygonMode.Fill ? PolygonMode.Line : PolygonMode.Fill; break;
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