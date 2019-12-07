using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace soliter
{
	public partial class MainForm : Form
	{
		public static Graphics g;
		public MainForm()
		{
			InitializeComponent();
			g = panel.CreateGraphics();
			Board.NewGame();
		}
		void PanelPaint(object sender, PaintEventArgs e)
		{
			Board.Draw();
		}
		void PanelMouseDown(object sender, MouseEventArgs e)
		{
			Board.OnClickReaction(e.Location);
		}
		void НоваяИграToolStripMenuItemClick(object sender, EventArgs e)
		{
			Board.NewGame();
		}
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}
	}
}