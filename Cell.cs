using System;
using System.Drawing;

namespace soliter
{
	public class Cell
	{
		public int ns, np;
		public bool busy;
		
		public Cell(int i, int j, bool b)
		{
			ns = i;
			np = j;
			busy = b;
		}
		public void Draw()
		{
			int p = Board.p;
			var r = new Rectangle(ns*p, np*p, p, p);
			MainForm.g.FillRectangle(new SolidBrush(Color.White),r);
			if (busy)
				MainForm.g.FillEllipse(new SolidBrush(Color.Blue), r);
			MainForm.g.DrawRectangle(new Pen(Color.Black,2), r);
		}
	}
}
