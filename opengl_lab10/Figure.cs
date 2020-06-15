using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace opengl
{
    public class Figure
    {
        public static void Plane(float a, float y)
        {
            a = a / 2;
            GL.Color3(Color.LightGray);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.AmbientAndDiffuse, Color.LightSkyBlue);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-a, y, -a);
            GL.Vertex3(-a, y, a);
            GL.Vertex3(a, y, a);
            GL.Vertex3(a, y, -a);
            GL.End();
        }
        #region Dodec
        public const float gr = 1.61803398874989484820458683436f, x = gr - 1;
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

        static float[] tV = {
                1-x, 0,
                x, 0,
                1, x,
                .5f, 1,
                0, x
            };

        public static void Dodecahedron(float moveX, float moveY, float moveZ)
        {
            Texture.LoadTexture("Dodec");
            GL.Translate(-moveX, -moveY+gr * 0.855f, -moveZ);
            GL.Rotate(31.5f, 0, 0, 1);
            GL.Color3(Color.White);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.AmbientAndDiffuse, Color.White);

            for (int i = 0; i < v.GetLength(0); i++)
            {
                Vector3 v1 = new Vector3(v[i][0], v[i][1], v[i][2]),
                v2 = new Vector3(v[i][4], v[i][5], v[i][6]),
                v3 = new Vector3(v[i][7], v[i][8], v[i][9]),
                vec1 = v2 - v1, vec2 = v3 - v1,
                n = Vector3.Cross(vec1, vec2);
                GL.Begin(PrimitiveType.Polygon);
                GL.Normal3(n);
                for (int j = 0; j < 5; j++)
                {
                    GL.TexCoord2(tV[j * 2], tV[j * 2 + 1]);
                    GL.Vertex3(v[i][j * 3], v[i][j * 3 + 1], v[i][j * 3 + 2]);
                }
                GL.End();
            }
        }
        #endregion
        public static void Cube(float a, float moveX, float moveY,float moveZ)
        {
            GL.Translate(moveX, moveY, moveZ);
            Texture.LoadTexture("Cube");
            GL.Color3(Color.White);
            int h = 1;
            a /= 2;
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Quads);

            //GL.Color3(c[0]);
            GL.Normal3(1, 0, 0);
            GL.TexCoord2(0, 0);
            GL.Vertex3(a, a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(a, -a, a);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, -a, -a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, -a);

            //GL.Color3(c[1]);
            GL.Normal3(-1, 0, 0);
            GL.TexCoord2(0, -h);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, -a, a);
            GL.TexCoord2(-h, 0);
            GL.Vertex3(-a, -a, -a);
            GL.TexCoord2(-h, -h);
            GL.Vertex3(-a, a, -a);

            //GL.Color3(c[2]);
            GL.Normal3(0, 0, 1);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, -a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(-a, -a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, a);

            //GL.Color3(c[3]);
            GL.Normal3(0, 1, 0);
            GL.TexCoord2(h, h);
            GL.Vertex3(a, a, a);
            GL.TexCoord2(0, h);
            GL.Vertex3(-a, a, a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, a, -a);
            GL.TexCoord2(h, 0);
            GL.Vertex3(a, a, -a);

            //GL.Color3(c[4]);
            GL.Normal3(0, 0, -1);
            GL.TexCoord2(-h, -h);
            GL.Vertex3(a, a, -a);
            GL.TexCoord2(0, -h);
            GL.Vertex3(-a, a, -a);
            GL.TexCoord2(0, 0);
            GL.Vertex3(-a, -a, -a);
            GL.TexCoord2(-h, 0);
            GL.Vertex3(a, -a, -a);

            //GL.Color3(c[5]);
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
        public static void Sphere(double r, int nx, int ny, float moveX, float moveY, float moveZ)
        {
            GL.Translate(moveX,moveY,moveZ);
            Texture.LoadTexture("Sphere");
            double x, y, z;

            for (int iy = 0; iy < ny; ++iy)
            {
                GL.Begin(PrimitiveType.QuadStrip);
                for (int ix = 0; ix <= nx; ++ix)
                {
                    x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x, y, z);//нормаль направлена от центра
                    GL.TexCoord2((double)ix / (double)nx, (double)iy / (double)ny);
                    GL.Vertex3(x, y, z);

                    x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.TexCoord2((double)ix / (double)nx, (double)(iy + 1) / (double)ny);
                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }
        }
    }
}