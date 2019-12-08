using System;
using System.Drawing;

namespace colorballs
{
	public class Cell
	{
		public int ns, np;
		public Color color;
		
		public Cell(int i, int j, Color c)
		{
			np = i;
			ns = j;
			color = c;
		}
		public void Draw()
		{
			int p = Board.p;
			var r = new Rectangle(ns*p, np*p, p, p);
			MainForm.g.FillRectangle(new SolidBrush(Color.LightGray),r);
			if (color != Color.LightGray) 
				MainForm.g.FillEllipse(new SolidBrush(color), r);
			MainForm.g.DrawRectangle(new Pen(Color.Black,2), r);
		}
	}
}
