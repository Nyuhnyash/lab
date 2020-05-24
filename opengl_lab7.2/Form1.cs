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
        float zoom, angleX, angleY, angleZ;
        float fov,a;
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
            angleX = angleY = angleZ = 0;
            zoom = -2;
            a = 1f / 2;
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
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            Dodecahedron();

            glControl1.SwapBuffers();
        }

        #region Dodec
        const float gr = 1.61803398874989484820458683436f, x = gr - 1;
        static readonly float[][] v = {
                  new float[] {-x, 0, gr , x, 0, gr , 1, 1, 1 , 0, gr, x , -1, 1, 1 }  ,
                  new float[] {x, 0, gr , 1, 1, 1 , gr, x, 0 , gr, -x, 0 , 1, -1, 1 } ,
                  new float[] {1, 1, 1 , 0, gr, x , 0, gr, -x , 1, 1, -1 , gr, x, 0 } ,
                  new float[] {-1, 1, 1 , -gr, x, 0 , -1, 1, -1 , 0, gr, -x , 0, gr, x } ,
                  new float[] {0, gr, -x , -1, 1, -1 , -x, 0, -gr , x, 0, -gr , 1, 1, -1 } ,
                  new float[] {gr, x, 0 , 1, 1, -1 , x, 0, -gr , 1, -1, -1 , gr, -x, 0 } ,
                  new float[] {-gr, -x, 0 , -gr, x, 0 , -1, 1, -1 , -x, 0, -gr , -1, -1, -1 } ,
                  new float[] {-x, 0, gr , -1, 1, 1 , -gr, x, 0 , -gr, -x, 0 , -1, -1, 1 } ,
                  new float[] {-1, -1, -1 , -x, 0, -gr , x, 0, -gr , 1, -1, -1 , 0, -gr, -x } ,
                  new float[] {-1, -1, 1 , -gr, -x, 0 , -1, -1, -1 , 0, -gr, -x , 0, -gr, x } ,
                  new float[] {1, -1, 1 , 0, -gr, x , 0, -gr, -x , 1, -1, -1 , gr, -x, 0 } ,
                  new float[] {x, 0, gr , -x, 0, gr , -1, -1, 1 , 0, -gr, x , 1, -1, 1 }
            };
            
            float [] tV = { 
                1-x, 0,
                x, 0,
                1, x,
                .5f, 1,
                0, x
            };

        void Dodecahedron()
        {
            
            for (int i = 0; i < v.GetLength(0); i++)
            {
                Vector3 v1 = new Vector3(v[i][0], v[i][1], v[i][2]),
                v2 = new Vector3(v[i][4], v[i][5], v[i][6]),
                v3 = new Vector3(v[i][7], v[i][8], v[i][9]),
                vec1 = v2-v1, vec2 = v3-v1,
                n = Vector3.Cross(vec1,vec2);
                GL.Begin(PrimitiveType.Polygon);
                GL.Normal3(n);
                for (int j = 0; j < 5; j++)
                {
                    GL.TexCoord2(tV[j*2],tV[j*2+1]);
                    GL.Vertex3(v[i][j * 3], v[i][j * 3 + 1], v[i][j * 3 + 2]);
                }
                GL.End();
            }
        }
        #endregion

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