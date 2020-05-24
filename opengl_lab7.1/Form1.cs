using System;
using System.Drawing;
using System.Windows.Forms;
using opengl1.Properties;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY;
        float fov;
        Bitmap bmpTex;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
        }
        void Reset()
        {
            fov = 80;
            angleX = angleY = 0;
            zoom = -2;
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            bmpTex = (Bitmap)resources.GetObject("Tex");
            Texture.LoadTexture(bmpTex);
            GL.Enable(EnableCap.Texture2D);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Flat);

            GL.Enable(EnableCap.Normalize);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light0, LightParameter.Position, new Vector4(0, 0.1f, 2, 0));
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            int size = Math.Min(panel1.Width, panel1.Height);
            glControl1.Width = glControl1.Height = size;
            GL.Viewport(0, 0, size, size);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 m = Matrix4.CreatePerspectiveFieldOfView((float)(fov * Math.PI / 180), 1, 0.1f, 100f);
            GL.LoadMatrix(ref m);
            const int o = 20;
            GL.Frustum(-o, o, -o, o, -o, o);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0, 0, zoom);

            

            GL.PushMatrix();
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);

            Color[] c = new Color[6];
            for (int i = 0; i < 6; i++)
                c[i] = Color.LightGray;
            Cube(.5f, c);
            GL.PopMatrix();

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }

        void Cube(float a, Color[] c)
        {
            int h = 1;
            a /= 2;
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(c[0]);
            GL.Normal3(1, 0, 0);
            GL.TexCoord2(0, 0);
            GL.Vertex3(a, a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(a, -a, a);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, -a, -a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, -a);

            GL.Color3(c[1]);
            GL.Normal3(-1, 0, 0);
            GL.TexCoord2(0, -h);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, -a, a);
            GL.TexCoord2(-h, 0);
            GL.Vertex3(-a, -a, -a);
            GL.TexCoord2(-h, -h);
            GL.Vertex3(-a, a, -a);
            
            GL.Color3(c[2]);
            GL.Normal3(0, 0, 1);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, -a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(-a, -a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, a);

            GL.Color3(c[3]);
            GL.Normal3(0, 1, 0);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, a, -a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, -a);

            GL.Color3(c[4]);
            GL.Normal3(0, 0, -1);
            GL.TexCoord2(-h, -h);
            GL.Vertex3(a, a, -a);
            GL.TexCoord2(0, -h);
            GL.Vertex3(-a, a, -a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, -a, -a);
            GL.TexCoord2(-h, 0);
            GL.Vertex3(a, -a, -a);

            GL.Color3(c[5]);
            GL.Normal3(0, -1, 0);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, -a, -a);
            GL.TexCoord2(0, h);
            GL.Vertex3(-a, -a, -a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, -a, a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, -a, a);
            GL.End();
        }

        #region MouseControl
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
        #endregion
    }
}