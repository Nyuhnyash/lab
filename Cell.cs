using System.Drawing;

namespace swamp
{
    public class Cell
    {
        public readonly int ns, np;
        public bool busy;
        public int jumpLen;
        public static int p = 55;

        public Cell(int i, int j, int jl = 0, bool b = false)
        {
            ns = i;
            np = j;
            jumpLen = jl;
            busy = b;
        }

        public void Draw()
        {
            var r = new Rectangle(ns * p, np * p, p, p);
            MainForm.g.FillRectangle(new SolidBrush(Color.PaleGreen), r);
            if (jumpLen > 0)
            {
                MainForm.g.FillEllipse(new SolidBrush(busy ? Color.LimeGreen : Color.Yellow), r);
                MainForm.g.DrawString(jumpLen.ToString(),
                    new Font(FontFamily.GenericMonospace, 40),
                    new SolidBrush(Color.Black),
                    ns * p + 10, np * p);
            }

            if (jumpLen == -1)
                MainForm.g.FillEllipse(new SolidBrush(Color.SaddleBrown), (float) ((ns + .25) * p), (float) ((np +  .25) * p),
                    (float) (.5 * p), (float) (.5 * p));

            MainForm.g.DrawRectangle(new Pen(Color.Black, 2), r);
        }
    }
}