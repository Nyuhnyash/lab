
namespace colorballs
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button5;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Margin = new System.Windows.Forms.Padding(5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(300, 300);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseDown);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Aqua;
			this.button4.Location = new System.Drawing.Point(315, 247);
			this.button4.Margin = new System.Windows.Forms.Padding(1);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(65, 65);
			this.button4.TabIndex = 3;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Red;
			this.button3.Location = new System.Drawing.Point(315, 180);
			this.button3.Margin = new System.Windows.Forms.Padding(1);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(65, 65);
			this.button3.TabIndex = 2;
			this.button3.UseVisualStyleBackColor = false;
			this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Blue;
			this.button2.Location = new System.Drawing.Point(315, 113);
			this.button2.Margin = new System.Windows.Forms.Padding(1);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(65, 65);
			this.button2.TabIndex = 1;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.DarkGreen;
			this.button1.Location = new System.Drawing.Point(315, 46);
			this.button1.Margin = new System.Windows.Forms.Padding(1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(65, 65);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(315, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(65, 30);
			this.button5.TabIndex = 4;
			this.button5.Text = "New game";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(423, 326);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "colorballs";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
			this.ResumeLayout(false);

		}
	}
}
