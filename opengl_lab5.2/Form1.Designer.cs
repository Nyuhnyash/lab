namespace opengl
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbYoZ = new System.Windows.Forms.CheckBox();
            this.cbXoY = new System.Windows.Forms.CheckBox();
            this.numN = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numK = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numLSSpeed = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLSSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(500, 500);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.numLSSpeed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbYoZ);
            this.panel1.Controls.Add(this.cbXoY);
            this.panel1.Controls.Add(this.numN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numK);
            this.panel1.Location = new System.Drawing.Point(399, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 107);
            this.panel1.TabIndex = 1;
            // 
            // cbYoZ
            // 
            this.cbYoZ.AutoSize = true;
            this.cbYoZ.Checked = true;
            this.cbYoZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbYoZ.Location = new System.Drawing.Point(52, 87);
            this.cbYoZ.Name = "cbYoZ";
            this.cbYoZ.Size = new System.Drawing.Size(46, 17);
            this.cbYoZ.TabIndex = 5;
            this.cbYoZ.Text = "YoZ";
            this.cbYoZ.UseVisualStyleBackColor = true;
            // 
            // cbXoY
            // 
            this.cbXoY.AutoSize = true;
            this.cbXoY.Checked = true;
            this.cbXoY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbXoY.Location = new System.Drawing.Point(6, 87);
            this.cbXoY.Name = "cbXoY";
            this.cbXoY.Size = new System.Drawing.Size(46, 17);
            this.cbXoY.TabIndex = 4;
            this.cbXoY.Text = "XoY";
            this.cbXoY.UseVisualStyleBackColor = true;
            // 
            // numN
            // 
            this.numN.Location = new System.Drawing.Point(66, 35);
            this.numN.Name = "numN";
            this.numN.Size = new System.Drawing.Size(32, 20);
            this.numN.TabIndex = 3;
            this.numN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numN.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "N =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "K =";
            // 
            // numK
            // 
            this.numK.Location = new System.Drawing.Point(66, 9);
            this.numK.Name = "numK";
            this.numK.Size = new System.Drawing.Size(33, 20);
            this.numK.TabIndex = 0;
            this.numK.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numK.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Скорость:";
            // 
            // numLSSpeed
            // 
            this.numLSSpeed.Location = new System.Drawing.Point(66, 61);
            this.numLSSpeed.Name = "numLSSpeed";
            this.numLSSpeed.Size = new System.Drawing.Size(32, 20);
            this.numLSSpeed.TabIndex = 7;
            this.numLSSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLSSpeed.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(695, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.glControl1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "5.2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLSSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numK;
        private System.Windows.Forms.NumericUpDown numN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbYoZ;
        private System.Windows.Forms.CheckBox cbXoY;
        private System.Windows.Forms.NumericUpDown numLSSpeed;
        private System.Windows.Forms.Label label3;
    }
}

