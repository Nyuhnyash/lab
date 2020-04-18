using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY, angleZ, gray;
        const float o = 20, fov = 80 * (float)(Math.PI / 180);
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;
            zoom = -4;
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Normalize);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Light1);

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

            
            Vector3 light0Pos = new Vector3(0, 1, 2);
            Vector3 light1Pos = new Vector3(1,0,1);
            GL.PointSize(5);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(light0Pos);
            GL.Vertex3(light1Pos);
            GL.End();
            light0Pos.Z = -light0Pos.Z;
            light1Pos.Z = -light1Pos.Z;

            GL.Light(LightName.Light0, LightParameter.Position, new Vector4(light0Pos));
            GL.Light(LightName.Light0, LightParameter.Diffuse, Color.White);
            GL.Light(LightName.Light0, LightParameter.Specular, Color.White);
            GL.Light(LightName.Light0, LightParameter.SpotDirection, -Vector4.UnitZ);

            GL.Light(LightName.Light1, LightParameter.Position, new Vector4(light1Pos));
            GL.Light(LightName.Light1, LightParameter.Diffuse, new Vector4(angleX, angleY, angleZ, 1).Normalized());
            GL.Light(LightName.Light1, LightParameter.Specular, Color.White);
            GL.Light(LightName.Light1, LightParameter.SpotDirection, Vector4.UnitZ);


            GL.LightModel(LightModelParameter.LightModelAmbient, 1);
            Icosahedron();

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
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
            for (int i = 0; i < 20; i++)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                var v = new Vector3[3];
                for (int j = 0; j < 3; j++)
                    v[j] = new Vector3(vertices[triangles[i, j], 0], vertices[triangles[i, j], 1], vertices[triangles[i, j], 2]);
                Vector3 edge1 = v[0] - v[1],
                        edge2 = v[0] - v[2],
                        n = Vector3.Cross(edge1, edge2);
                GL.Normal3(n);
                for (int j = 0; j < 3; j++)
                    GL.Vertex3(v[j]);
                GL.End();
            }

        }
        #endregion

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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