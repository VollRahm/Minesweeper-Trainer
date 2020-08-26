namespace MinesweeperCheeto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stopTmrBtn = new System.Windows.Forms.Button();
            this.resumeTmrBtn = new System.Windows.Forms.Button();
            this.updateUITimer = new System.Windows.Forms.Timer(this.components);
            this.timerValue = new System.Windows.Forms.Label();
            this.reverseTmrBtn = new System.Windows.Forms.Button();
            this.winBtn = new System.Windows.Forms.Button();
            this.looseBtn = new System.Windows.Forms.Button();
            this.gameStateLbl = new System.Windows.Forms.Label();
            this.alwaysLooseCb = new System.Windows.Forms.CheckBox();
            this.solveBtn = new System.Windows.Forms.Button();
            this.solveDelayNUP = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.solveDelayNUP)).BeginInit();
            this.SuspendLayout();
            // 
            // stopTmrBtn
            // 
            this.stopTmrBtn.Location = new System.Drawing.Point(94, 12);
            this.stopTmrBtn.Name = "stopTmrBtn";
            this.stopTmrBtn.Size = new System.Drawing.Size(75, 23);
            this.stopTmrBtn.TabIndex = 0;
            this.stopTmrBtn.Text = "Stop Timer";
            this.stopTmrBtn.UseVisualStyleBackColor = true;
            this.stopTmrBtn.Click += new System.EventHandler(this.stopTmrBtn_Click);
            // 
            // resumeTmrBtn
            // 
            this.resumeTmrBtn.Location = new System.Drawing.Point(175, 12);
            this.resumeTmrBtn.Name = "resumeTmrBtn";
            this.resumeTmrBtn.Size = new System.Drawing.Size(91, 23);
            this.resumeTmrBtn.TabIndex = 1;
            this.resumeTmrBtn.Text = "Resume Timer";
            this.resumeTmrBtn.UseVisualStyleBackColor = true;
            this.resumeTmrBtn.Click += new System.EventHandler(this.resumeTmrBtn_Click);
            // 
            // updateUITimer
            // 
            this.updateUITimer.Tick += new System.EventHandler(this.updateUITimer_Tick);
            // 
            // timerValue
            // 
            this.timerValue.AutoSize = true;
            this.timerValue.Location = new System.Drawing.Point(12, 17);
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(39, 13);
            this.timerValue.TabIndex = 2;
            this.timerValue.Text = "Timer: ";
            // 
            // reverseTmrBtn
            // 
            this.reverseTmrBtn.Location = new System.Drawing.Point(272, 12);
            this.reverseTmrBtn.Name = "reverseTmrBtn";
            this.reverseTmrBtn.Size = new System.Drawing.Size(93, 23);
            this.reverseTmrBtn.TabIndex = 3;
            this.reverseTmrBtn.Text = "Reverse Timer";
            this.reverseTmrBtn.UseVisualStyleBackColor = true;
            this.reverseTmrBtn.Click += new System.EventHandler(this.reverseTmrBtn_Click);
            // 
            // winBtn
            // 
            this.winBtn.Location = new System.Drawing.Point(94, 52);
            this.winBtn.Name = "winBtn";
            this.winBtn.Size = new System.Drawing.Size(75, 23);
            this.winBtn.TabIndex = 4;
            this.winBtn.Text = "Win";
            this.winBtn.UseVisualStyleBackColor = true;
            this.winBtn.Click += new System.EventHandler(this.winBtn_Click);
            // 
            // looseBtn
            // 
            this.looseBtn.Location = new System.Drawing.Point(175, 52);
            this.looseBtn.Name = "looseBtn";
            this.looseBtn.Size = new System.Drawing.Size(75, 23);
            this.looseBtn.TabIndex = 5;
            this.looseBtn.Text = "Loose";
            this.looseBtn.UseVisualStyleBackColor = true;
            this.looseBtn.Click += new System.EventHandler(this.looseBtn_Click);
            // 
            // gameStateLbl
            // 
            this.gameStateLbl.AutoSize = true;
            this.gameStateLbl.Location = new System.Drawing.Point(12, 57);
            this.gameStateLbl.Name = "gameStateLbl";
            this.gameStateLbl.Size = new System.Drawing.Size(66, 13);
            this.gameStateLbl.TabIndex = 6;
            this.gameStateLbl.Text = "Game State:";
            // 
            // alwaysLooseCb
            // 
            this.alwaysLooseCb.AutoSize = true;
            this.alwaysLooseCb.Location = new System.Drawing.Point(256, 56);
            this.alwaysLooseCb.Name = "alwaysLooseCb";
            this.alwaysLooseCb.Size = new System.Drawing.Size(124, 17);
            this.alwaysLooseCb.TabIndex = 7;
            this.alwaysLooseCb.Text = "Loose on every click";
            this.alwaysLooseCb.UseVisualStyleBackColor = true;
            this.alwaysLooseCb.CheckedChanged += new System.EventHandler(this.alwaysLooseCb_CheckedChanged);
            // 
            // solveBtn
            // 
            this.solveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveBtn.Location = new System.Drawing.Point(175, 96);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(190, 41);
            this.solveBtn.TabIndex = 8;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // solveDelayNUP
            // 
            this.solveDelayNUP.Location = new System.Drawing.Point(107, 109);
            this.solveDelayNUP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.solveDelayNUP.Name = "solveDelayNUP";
            this.solveDelayNUP.Size = new System.Drawing.Size(62, 20);
            this.solveDelayNUP.TabIndex = 9;
            this.solveDelayNUP.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Solve Delay (ms):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 160);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solveDelayNUP);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.alwaysLooseCb);
            this.Controls.Add(this.gameStateLbl);
            this.Controls.Add(this.looseBtn);
            this.Controls.Add(this.winBtn);
            this.Controls.Add(this.reverseTmrBtn);
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.resumeTmrBtn);
            this.Controls.Add(this.stopTmrBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Minesweeper Cheeto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.solveDelayNUP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopTmrBtn;
        private System.Windows.Forms.Button resumeTmrBtn;
        private System.Windows.Forms.Timer updateUITimer;
        private System.Windows.Forms.Label timerValue;
        private System.Windows.Forms.Button reverseTmrBtn;
        private System.Windows.Forms.Button winBtn;
        private System.Windows.Forms.Button looseBtn;
        private System.Windows.Forms.Label gameStateLbl;
        private System.Windows.Forms.CheckBox alwaysLooseCb;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.NumericUpDown solveDelayNUP;
        private System.Windows.Forms.Label label1;
    }
}

