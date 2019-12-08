
using System;
using System.Drawing;
using System.Windows.Forms;

namespace colorballs
{
	public static class Board
	{
		static Cell[,] cells;
		public static int p;
		public static Color chosenColor;
		static Board()
		{
			cells = new Cell[4,4];
			chosenColor = Color.LightGray;
			p = 75;
		}
		public static void OnClickReaction(Point pt)
		{
			Cell c = cells[pt.Y / p, pt.X / p];
			if (c.color == Color.LightGray)
			{
				c.color = chosenColor;
				c.Draw();
				for (int i = 0; i < cells.GetLength(0); i++) {
					for (int j = 0; j < cells.GetLength(1); j++) {
						if (cells[i,j].color == Color.LightGray)
							return;
						for (int k = 0; k < 4; k++) {
							if (i == j && i != k && cells[i,i].color == cells[k,k].color)
								return;
							else if (j != k && cells[i,j].color == cells[i,k].color) 
								return;
							else if (i != k && cells[i,j].color == cells[k,j].color)
								return;
						}
					}
				}
				MessageBox.Show("Конец");
				NewGame();
			}
		}
		public static void Draw()
		{
			for (int i = 0; i < cells.GetLength(0); i++) {
				for (int j = 0; j < cells.GetLength(1); j++) {
					cells[i,j].Draw();
				}
			}
		}
		public static void NewGame()
		{
			for (int i = 0; i < cells.GetLength(0); i++)
				for (int j = 0; j < cells.GetLength(1); j++)
					cells[i, j] = new Cell(i, j, Color.LightGray);
			cells[0,0].color = Color.Aqua;
			cells[0,1].color = Color.Red;
			cells[0,2].color = Color.Blue;
			cells[3,1].color = Color.DarkGreen;
			Draw();
		}
	}
}
