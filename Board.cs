using System.Windows.Forms;

namespace swamp
{
	public static class Board
	{
		static readonly Cell[,] cells;
		static Cell busyCell;
		static Board()
		{
			cells = new Cell[6,6];
			Cell.p = 55;
		}
        public static void Reaction(Keys key)
        {
	        var dx = 0; 
	        var dy = 0;
	        switch (key)
	        {
		        case Keys.Up: dy = -1; break;
		        case Keys.Down: dy = 1; break;
		        case Keys.Right: dx = 1; break;
		        case Keys.Left: dx = -1; break;
	        }
			
	        var x = busyCell.ns + dx * busyCell.jumpLen;
	        var y = busyCell.np + dy * busyCell.jumpLen;
	        if (   0 <= x && x < cells.GetLength(0) 
	            && 0 <= y && y < cells.GetLength(1) 
	            && cells[x, y].jumpLen != 0)
	        {
		        if (cells[x, y].jumpLen == -1)
		        {
			        MessageBox.Show("Вы прошли игру.");
			        NewGame();
			        return;
		        }

		        busyCell.busy = false;
		        busyCell.Draw();
		        busyCell = cells[x, y];
		        busyCell.busy = true;
		        busyCell.Draw();
	        }
           
        }

        public static void Draw()
		{
			foreach (var cell in cells)
				cell.Draw();
		}
		public static void NewGame()
		{
			for (var j = 0; j < cells.GetLength(0); j++)
			{
				for (var i = 0; i < cells.GetLength(1); i++)
					cells[i, j] = new Cell(i, j);
			}
			cells[0, 0].jumpLen = 2;
			cells[2, 0].jumpLen = 2;
			cells[4, 0].jumpLen = 3;
			cells[5, 0].jumpLen = -1; // Финишная точка
			
			cells[1, 1].jumpLen = 2;
			cells[3, 1].jumpLen = 2;
			cells[5, 1].jumpLen = 1;
			
			cells[0, 2].jumpLen = 4;
			cells[4, 2].jumpLen = 2;
			
			cells[1, 3].jumpLen = 2;
			cells[2, 3].jumpLen = 3;
			cells[3, 3].jumpLen = 1;
			cells[5, 3].jumpLen = 1;
			
			cells[1, 4].jumpLen = 3;
			cells[4, 4].jumpLen = 3;
			
			busyCell = cells[0, 5]= new Cell(0,5 ,3 , true);
			cells[3, 5].jumpLen = 2;
			cells[5, 5].jumpLen = 2;
			
			Draw();
		}
	}
}
