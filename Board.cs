using System;
using System.Drawing;
using System.Windows.Forms;

namespace soliter
{
	public static class Board
	{
		static Cell[,] cells;
		public static int p, count;
		public static Cell first;
		static Board()
		{
			cells = new Cell[7,7];
			p = 55;
			count = 0;
		}
		public static void OnClickReaction(Point pt)
		{
			try
			{
				Cell c = cells[pt.X / p, pt.Y / p];
				if (c.busy)
					first = c;
				else if (first != null)
				{
					int m1 = Math.Abs(first.np-c.np),
					m2 = Math.Abs(first.ns-c.ns);
					if ((m1 == 0 || m1 == 2) && (m2 == 0 || m2 == 2))
					{
						Cell temp = cells[first.ns + Math.Sign(c.ns - first.ns), first.np + Math.Sign(c.np - first.np)];
						if (temp.busy)
						{
							temp.busy = first.busy = false;
						c.busy = true;
						temp.Draw();
						c.Draw();
						first.Draw();
						first = null;
						count++;
						}
					}
				}
			}
			catch (IndexOutOfRangeException) {}	
			catch (NullReferenceException) {}
			if (count == 7)
			{
				MessageBox.Show("Задача решена");
				NewGame();
				count=0;
			}
		}
		public static void Draw()
		{
			for (int j = 2; j < 5; j++)
			{
				for (int i = 0; i < 2; i++)
				{
					cells[i, j].Draw();
					cells[j, i].Draw();
					cells[6 - i, 6 - j].Draw();
					cells[6 - j, 6 - i].Draw();
				}
				for (int i = 2; i < 5; i++)
					cells[i, j].Draw();
			}
		}
		public static void NewGame()
		{
			for (int j = 2; j < 5; j++)
			{
				for (int i = 0; i < 2; i++)
				{
					cells[i, j] = new Cell(i, j, false);
					cells[j, i] = new Cell(j, i, false);
					cells[6 - i, 6 - j] = new Cell(6 - i, 6 - j, false);
					cells[6 - j, 6 - i] = new Cell(6 - j, 6 - i, false);
				}
				for (int i = 2; i < 5; i++)
					cells[i, j] = new Cell(i, j, true);
			}
			cells[3, 3].busy = false;
			Draw();
		}
	}
}
