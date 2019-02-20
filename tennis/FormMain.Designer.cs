namespace tennis
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BeginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionControl = new System.Windows.Forms.Timer(this.components);
            this.ballSpin = new System.Windows.Forms.Timer(this.components);
            this.ballMove = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.collisionDetection = new System.Windows.Forms.Timer(this.components);
            this.enemyActionControl = new System.Windows.Forms.Timer(this.components);
            this.ballMove2 = new System.Windows.Forms.Timer(this.components);
            this.ballMove3 = new System.Windows.Forms.Timer(this.components);
            this.ballMove4 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1768, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeginToolStripMenuItem,
            this.EndToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // BeginToolStripMenuItem
            // 
            this.BeginToolStripMenuItem.Name = "BeginToolStripMenuItem";
            this.BeginToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.BeginToolStripMenuItem.Text = "开始";
            this.BeginToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // EndToolStripMenuItem
            // 
            this.EndToolStripMenuItem.Name = "EndToolStripMenuItem";
            this.EndToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.EndToolStripMenuItem.Text = "结束";
            this.EndToolStripMenuItem.Click += new System.EventHandler(this.EndToolStripMenuItem_Click);
            // 
            // actionControl
            // 
            this.actionControl.Interval = 50;
            this.actionControl.Tick += new System.EventHandler(this.actionControl_Tick);
            // 
            // ballSpin
            // 
            this.ballSpin.Tick += new System.EventHandler(this.ballSpin_Tick);
            // 
            // ballMove
            // 
            this.ballMove.Interval = 10;
            this.ballMove.Tick += new System.EventHandler(this.ballMove_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::tennis.Properties.Resources.background;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1768, 689);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // collisionDetection
            // 
            this.collisionDetection.Interval = 10;
            this.collisionDetection.Tick += new System.EventHandler(this.collisionDetection_Tick);
            // 
            // enemyActionControl
            // 
            this.enemyActionControl.Interval = 200;
            this.enemyActionControl.Tick += new System.EventHandler(this.enemyActionControl_Tick);
            // 
            // ballMove2
            // 
            this.ballMove2.Interval = 10;
            this.ballMove2.Tick += new System.EventHandler(this.ballMove2_Tick);
            // 
            // ballMove3
            // 
            this.ballMove3.Interval = 10;
            this.ballMove3.Tick += new System.EventHandler(this.ballMove3_Tick);
            // 
            // ballMove4
            // 
            this.ballMove4.Tick += new System.EventHandler(this.ballMove4_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1220, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = "记分板";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1270, 607);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 64);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1270, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 64);
            this.label3.TabIndex = 4;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1474, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "游戏说明：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1474, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 39);
            this.label5.TabIndex = 6;
            this.label5.Text = "上下左右键控制移动";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1474, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 39);
            this.label6.TabIndex = 7;
            this.label6.Text = "Z键发球";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1474, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 39);
            this.label7.TabIndex = 8;
            this.label7.Text = "X键必杀技（V字抽球）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1474, 583);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 39);
            this.label8.TabIndex = 9;
            this.label8.Text = "V键左击球";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1474, 632);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 39);
            this.label9.TabIndex = 10;
            this.label9.Text = "C键右击球";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tennis.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1768, 714);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Tennis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BeginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EndToolStripMenuItem;
        private System.Windows.Forms.Timer actionControl;
        private System.Windows.Forms.Timer ballSpin;
        private System.Windows.Forms.Timer ballMove;
        private System.Windows.Forms.Timer collisionDetection;
        private System.Windows.Forms.Timer enemyActionControl;
        private System.Windows.Forms.Timer ballMove2;
        private System.Windows.Forms.Timer ballMove3;
        private System.Windows.Forms.Timer ballMove4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

