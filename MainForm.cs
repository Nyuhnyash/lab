using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace swamp
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

		private static readonly Keys[] Arrows = {Keys.Up, Keys.Down, Keys.Right, Keys.Left};

		private void MainFormPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (Arrows.Contains(e.KeyCode))
				Board.Reaction(e.KeyCode);
		}
		void НоваяИграToolStripMenuItemClick(object sender, EventArgs e)
		{
			Board.NewGame();
		}
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("Разработчик - Григорий Колодешников.");
		}
	}
}