using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Switches
{
    class Cell
    {
        public int ns, np;
        public bool status;
        public Cell()
        {
            ns = np = default;
            status = default;
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(status == true ? Color.Black : Color.White), Board.size * ns, Board.size * np, Board.size, Board.size);
        }
    }
}
