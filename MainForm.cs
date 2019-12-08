
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace colorballs
{
	public partial class MainForm : Form
	{
		public static Graphics g;
		public MainForm()
		{
			InitializeComponent();
			g = panel1.CreateGraphics();
			Board.NewGame();
		}
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			Board.Draw();
		}
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			Board.OnClickReaction(e.Location);
		}
		void ButtonMouseDown(object sender, MouseEventArgs e)
		{
			Board.chosenColor = (sender as Button).BackColor;
		}
		void Button5Click(object sender, EventArgs e)
		{
			Board.NewGame();
		}
	}
}
