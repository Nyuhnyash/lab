using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Switches
{
    public partial class Form1 : Form
    {
        Board board = new Board(4);
        public Form1()
        {
            InitializeComponent();
            Board.size = (float)panel1.Size.Width / Board.N;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (board.Check())
                button1.Visible = true;
            else
            {
                board.Reaction(panel1.PointToClient(MousePosition));
                board.Draw(panel1.CreateGraphics());
                if (board.Check())
                    button1.Visible = true;
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            board.Draw(panel1.CreateGraphics());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            board.New();
            board.Draw(panel1.CreateGraphics());
        }
    }
}
