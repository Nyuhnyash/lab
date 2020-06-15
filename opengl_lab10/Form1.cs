using System;
using System.Drawing;
using System.Windows.Forms;
using opengl1.Properties;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY, angleZ, moveZ, moveX;
        float fov;
        public Form1()
        {
            InitializeComponent();
            this.glControl1.MouseWheel += new MouseEventHandler(this.glControl1_MouseWheel);
            Reset();
        }
        void Reset()
        {
            fov = 80;
            angleY = angleZ = 0;
            angleX = 20;
            moveZ = moveX = 0;
            zoom = -5;
        }
        static readonly Color4 skyColor = Color4.DeepSkyBlue;
        readonly float[] fogColor = { skyColor.R, skyColor.G, skyColor.B, skyColor.A };
        private void glControl1_Load(object sender, EventArgs e)
        {
            
            GL.ClearColor(skyColor);
            
            GL.Enable(EnableCap.Texture2D);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Flat);

            GL.Enable(EnableCap.Normalize);

            if (L) GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            
            GL.Fog(FogParameter.FogMode, (int)FogMode.Linear); //режим тумана. линейный, экспоненциальный и другие опции. Можно посмотреть в документации
            GL.Fog(FogParameter.FogColor, fogColor);
            GL.Fog(FogParameter.FogStart, 1f); //расстояние от зрителя, с которого начинается туман
            GL.Fog(FogParameter.FogEnd, 25f);
            if (F) GL.Enable(EnableCap.Fog);
            

            
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, panel1.Width, panel1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 m = Matrix4.CreatePerspectiveFieldOfView((float)(fov * Math.PI / 180), (float)panel1.Width / panel1.Height, 0.1f, 100f);
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
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            Figure.Plane(40,0);
            float x = 3, y = 0.5f, z = 0;
            Figure.Cube(1, x, y, z);
            Figure.Sphere(1, 20, 20, x-=10,y,z);
            Figure.Dodecahedron(x+moveX+3f,y+0.5f, z+moveZ);
            
            GL.LoadIdentity();
            GL.Light(LightName.Light0, LightParameter.Position, new Vector4(0, 3f, 2, 0));

            glControl1.SwapBuffers();
        }

        bool L = false, F = true;
        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W: moveZ += 0.5f; break;
                case Keys.S: moveZ -= 0.5f; break;
                case Keys.A: moveX += 0.5f; break;
                case Keys.D: moveX -= 0.5f; break;
                case Keys.L:
                    L = !L;
                    if (L) GL.Enable(EnableCap.Lighting);
                    else   GL.Disable(EnableCap.Lighting);
                    break;
                case Keys.F:
                    F = !F;
                    if (F) GL.Enable(EnableCap.Fog);
                    else   GL.Disable(EnableCap.Fog);
                    break;
                case Keys.Escape:
                    Reset();
                    break;
            }
            glControl1.Invalidate();
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
        public static Color c;
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int pixel = default;
            GL.ReadPixels(e.X, e.Y, 1, 1, PixelFormat.Bgra, PixelType.UnsignedByte, ref pixel);
            panel2.Location = new Point(e.Location.X+30, e.Location.Y-30);
            c = Color.FromArgb(pixel);
            panel2.BackColor = (Color)new Color4(c.R, c.G, c.B, 255);
            textBox1.Text = String.Format("{0} {1} {2} {3}", c.R, c.G, c.B, c.A);

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