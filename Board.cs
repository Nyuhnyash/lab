using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Switches
{
    class Board
    {
        public static int N;
        public static float size;
        Cell[,] mcell;
        public Board(int N)
        {
            Board.N = N;
            mcell = new Cell[N,N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    mcell[i, j] = new Cell();
                    mcell[i, j].ns = i;
                    mcell[i, j].np = j;
                }
            New();
        }
        public void Reaction(Point mousePos)
        {
            foreach (Cell c in mcell)
                if (new Rectangle((int)(size * c.ns), (int)(size * c.np), (int)size, (int)size).Contains(mousePos))
                    for (int i = 0; i < N; i++)
                        for (int j = 0; j < N; j++)
                            if ((c.ns == i) || (c.np == j))
                                mcell[i, j].status ^= true;
            Check();
        }
        public void Draw(Graphics g)
        {
            foreach (Cell c in mcell)
                c.Draw(g);
        }
        public bool Check()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (mcell[i, j].status != mcell[0, 0].status)
                        return false;
                
            return true;
        }
        public void New()
        {
            Random rand = new Random();
            foreach (Cell c in mcell)
                c.status = rand.Next(2) == 1 ? true : false;
        }
    }
}
