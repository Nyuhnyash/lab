using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace opengl
{
    public partial class Form1 : Form
    {
        float zoom, angleX, angleY, angleZ;
        const int cubeNumOfFaces = 6;
        int fov, cubeSize;
        float elementSize;
        // B F L R D U
        readonly Color[] c = { Color.Orange, Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.White};
        int[,,] ci; // Color Indexes
        public Form1()
        {
            InitializeComponent();
            Reset();
        }
        void Reset()
        {
            angleX = angleY = angleZ = 0;
            fov = 80;
            cubeSize = (int)numericUpDown1.Value;
            zoom = -0.5f + (cubeSize - 2) * -0.3f;
            elementSize = 0.1f;
            ci = new int[cubeNumOfFaces, cubeSize, cubeSize];
            for (int i = 0; i < cubeNumOfFaces; i++)
            {
                for (int j = 0; j < cubeSize; j++)
                {
                    for (int k = 0; k < cubeSize; k++)
                    {
                        ci[i, j, k] = i;
                    }
                }
            }
            textBox1.Text = "Log: ";
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.9f, 0.9f, 0.9f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.ShadeModel(ShadingModel.Flat);
            GL.Enable(EnableCap.Normalize);
            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light0, LightParameter.Position, -Vector4.UnitZ);
            GL.Light(LightName.Light0, LightParameter.SpotDirection, Vector4.UnitZ);
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            int size = Math.Min(panel1.Width, panel1.Height);
            glControl1.Width = glControl1.Height = size;
            GL.Viewport(0, 0, size, size);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 m = Matrix4.CreatePerspectiveFieldOfView(fov * (float)(Math.PI / 180), 1, 0.1f, 100f);
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
            // поворот камеры
            GL.Rotate(angleX, 1, 0, 0);
            GL.Rotate(angleY, 0, 1, 0);
            GL.Rotate(angleZ, 0, 0, 1);

            

            // центрирование
            float fsp = elementSize * cubeSize / 2f;
            GL.Translate(-fsp, -fsp, -fsp);

            Cube();

            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }
        void Cube()
        {
            var s = elementSize;
            var fs = elementSize * cubeSize; // size of all elements in a row
            for (int x = 0; x < 2; x++)
            {
                // Left & right
                for (int i = 0; i < cubeSize; i++)
                {
                    GL.Begin(PrimitiveType.QuadStrip);
                    GL.Normal3(x == 0 ? 1 : -1, 0, 0);
                    GL.Vertex3(fs * x, 0, i * s);
                    GL.Vertex3(fs * x, 0, (i + 1) * s);

                    for (int j = 1; j <= cubeSize; j++)
                    {
                        GL.Material(MaterialFace.FrontAndBack, MaterialParameter.AmbientAndDiffuse, c[ci[x + 2, j - 1, i]]);
                        GL.Color3(c[ci[x + 2, j - 1, i]]);
                        GL.Vertex3(fs * x, j * s, i * s);
                        GL.Vertex3(fs * x, j * s, (i + 1) * s);
                    }
                    GL.End();
                }
                // Up & down
                for (int i = 0; i < cubeSize; i++)
                {
                    GL.Begin(PrimitiveType.QuadStrip);
                    GL.Normal3(0, x == 0 ? 1 : -1, 0);
                    GL.Vertex3(0, fs * x, i * s);
                    GL.Vertex3(0, fs * x, (i + 1) * s);

                    for (int j = 1; j <= cubeSize; j++)
                    {
                        GL.Material(MaterialFace.FrontAndBack, MaterialParameter.AmbientAndDiffuse, c[ci[x + 4, j - 1, i]]);
                        GL.Color3(c[ci[x + 4, j - 1, i]]);
                        GL.Vertex3(j * s, fs * x, i * s);
                        GL.Vertex3(j * s, fs * x, (i + 1) * s);
                    }
                    GL.End();
                }
                // Front & back
                for (int i = 0; i < cubeSize; i++)
                {
                    GL.Begin(PrimitiveType.QuadStrip);
                    GL.Normal3(0, 0, x == 0 ? 1 : -1);
                    GL.Vertex3(0, i * s, fs * x);
                    GL.Vertex3(0, (i + 1) * s, fs * x);

                    for (int j = 1; j <= cubeSize; j++)
                    {
                        GL.Material(MaterialFace.FrontAndBack, MaterialParameter.AmbientAndDiffuse, c[ci[x, j - 1, i]]);
                        GL.Color3(c[ci[x, j - 1, i]]);
                        GL.Vertex3(j * s, i * s, fs * x);
                        GL.Vertex3(j * s, (i + 1) * s, fs * x);
                    }
                    GL.End();
                }
            }
        }
        #region FacesRotation
        void Turn(int face, bool IsReversed) // поворот грани face в направлении dir часовой стрелки
        {
            textBox1.Text += IsReversed ? "' " : " ";
            switch (face)
            {
                case 0: for (int i = 0; i < (IsReversed ? 1 : 3); i++) FrontOrBack(false); break;
                case 1: for (int i = 0; i < (IsReversed ? 3 : 1); i++) FrontOrBack(true); break;
                case 2: for (int i = 0; i < (IsReversed ? 3 : 1); i++) LeftOrRight(true); break;
                case 3: for (int i = 0; i < (IsReversed ? 1 : 3); i++) LeftOrRight(false); break;
                case 4: for (int i = 0; i < (IsReversed ? 1 : 3); i++) UpOrDown(false); break;
                case 5: for (int i = 0; i < (IsReversed ? 3 : 1); i++) UpOrDown(true); break;
            }
        }
        void LeftOrRight(bool x)
        {
            int x1;
            if (x)
            {
                x1 = 0;
                Facet(2);
            } else
            {
                x1 = cubeSize - 1;
                Facet(3);
            }
            int[] t = new int[cubeSize] ;
            for (int i = 0; i < cubeSize; i++)
                t[i] = ci[0, x1, i];
            for (int i = 0; i < cubeSize; i++)
                ci[0, x1, i] = ci[4, x1, cubeSize - 1 - i];
            for (int i = 0; i < cubeSize; i++)
                ci[4, x1, i] = ci[1, x1, i];
            for (int i = 0; i < cubeSize; i++)
                ci[1, x1, i] = ci[5, x1, cubeSize - 1 - i];
            for (int i = 0; i < cubeSize; i++)
                ci[5, x1, i] = t[i];
        }
        void UpOrDown(bool x)
        {
            int x1;
            if (x)
            {
                x1 = cubeSize - 1;
                Facet(5);
            }
            else
            {
                x1 = 0;
                Facet(4);
            }
            int[] t = new int[cubeSize];
            for (int i = 0; i < cubeSize; i++)
                t[i] = ci[0, i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[0, i, x1] = ci[2, x1, cubeSize - 1 - i];
            for (int i = 0; i < cubeSize; i++)
                ci[2, x1, i] = ci[1, i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[1, i, x1] = ci[3, x1, cubeSize - 1 - i];
            for (int i = 0; i < cubeSize; i++)
                ci[3, x1, i] = t[i];
        }
        void FrontOrBack(bool x)
        {
            int x1;
            if (x)
            {
                x1 = cubeSize - 1;
                for (int i = 0; i < 3; i++)
                    Facet(1);
            }
            else
            {
                x1 = 0;
                for (int i = 0; i < 3; i++)
                Facet(0);
            }
            int[] t = new int[cubeSize];
            for (int i = 0; i < cubeSize; i++)
                t[i] = ci[2, i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[2, i, x1] = ci[4, cubeSize - 1 - i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[4, i, x1] = ci[3, i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[3, i, x1] = ci[5, cubeSize - 1 - i, x1];
            for (int i = 0; i < cubeSize; i++)
                ci[5, i, x1] = t[i];
        }
        void Facet(int x) // поворот фронтовых элементов грани
        {
            int xl = cubeSize - 1;
            int[] t = new int[xl];
            for (int i = 0; i < xl; i++)
                t[i] = ci[x, i, 0];
            for (int i = 0; i < xl; i++)
                ci[x, i, 0] = ci[x, 0, xl - i];
            for (int i = 0; i < xl; i++)
                ci[x, 0, xl - i] = ci[x, xl - i, xl];
            for (int i = 0; i < xl; i++)
                ci[x, xl - i, xl] = ci[x, xl, i];
            for (int i = 0; i < xl; i++)
                ci[x, xl, i] = t[i];
        }
        /*
        void Facet3x3(int x) // hardcoded поворот фронта грани куба 3^3
        {
            int t2 = ci[x, 0, 0];
            ci[x, 0, 0] = ci[x, 0, 2];
            ci[x, 0, 2] = ci[x, 2, 2];
            ci[x, 2, 2] = ci[x, 2, 0];
            ci[x, 2, 0] = t2;

            t2 = ci[x, 1, 0];
            ci[x, 1, 0] = ci[x, 0, 1];
            ci[x, 0, 1] = ci[x, 1, 2];
            ci[x, 1, 2] = ci[x, 2, 1];
            ci[x, 2, 1] = t2;
        }
        */
        #endregion

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: Application.Exit(); break;
                case Keys.Space: numericUpDown1.Value = 3; Reset();  break;
                case Keys.Prior: angleZ += 5; break;
                case Keys.Next: angleZ -= 5; break;

                case Keys.B: textBox1.Text += "B"; Turn(0, e.Shift); break;
                case Keys.F: textBox1.Text += "F"; Turn(1, e.Shift); break;
                case Keys.L: textBox1.Text += "L"; Turn(2, e.Shift); break;
                case Keys.R: textBox1.Text += "R"; Turn(3, e.Shift); break;
                case Keys.D: textBox1.Text += "D"; Turn(4, e.Shift); break;
                case Keys.U: textBox1.Text += "U"; Turn(5, e.Shift); break;
            }
            glControl1.Invalidate();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Reset();
            glControl1.Invalidate();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                GL.Enable(EnableCap.Lighting);
            else
                GL.Disable(EnableCap.Lighting);
            glControl1.Invalidate();
        }
        private void button1_MouseEnter(object sender, EventArgs e) => textBox2.Visible = true;
        private void button1_MouseLeave(object sender, EventArgs e) => textBox2.Visible = false;
        
        #region MouseRotation
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
        #endregion
        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom += (e.Delta * 0.2f / 120);
            glControl1.Invalidate();
        }
    }
}
