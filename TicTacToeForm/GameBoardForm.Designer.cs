namespace TicTacToeForm {
    partial class GameBoardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkComputer = new System.Windows.Forms.CheckBox();
            this.checkFriend = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coinTossStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnFlipCoin = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.checkFriend);
            this.groupBox1.Controls.Add(this.checkComputer);
            this.groupBox1.Location = new System.Drawing.Point(12, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // checkComputer
            // 
            this.checkComputer.AutoSize = true;
            this.checkComputer.Location = new System.Drawing.Point(7, 21);
            this.checkComputer.Name = "checkComputer";
            this.checkComputer.Size = new System.Drawing.Size(131, 17);
            this.checkComputer.TabIndex = 0;
            this.checkComputer.Text = "Play against Computer";
            this.checkComputer.UseVisualStyleBackColor = true;
            this.checkComputer.Click += new System.EventHandler(this.checkComputer_Click);
            // 
            // checkFriend
            // 
            this.checkFriend.AutoSize = true;
            this.checkFriend.Location = new System.Drawing.Point(7, 44);
            this.checkFriend.Name = "checkFriend";
            this.checkFriend.Size = new System.Drawing.Size(109, 17);
            this.checkFriend.TabIndex = 1;
            this.checkFriend.Text = "Play with a Friend";
            this.checkFriend.UseVisualStyleBackColor = true;
            this.checkFriend.Click += new System.EventHandler(this.checkFriend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(249, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coinTossStartToolStripMenuItem,
            this.resetGameToolStripMenuItem,
            this.exitGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // coinTossStartToolStripMenuItem
            // 
            this.coinTossStartToolStripMenuItem.Name = "coinTossStartToolStripMenuItem";
            this.coinTossStartToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.coinTossStartToolStripMenuItem.Text = "Coin Toss (Start)";
            this.coinTossStartToolStripMenuItem.Click += new System.EventHandler(this.coinTossStartToolStripMenuItem_Click);
            // 
            // resetGameToolStripMenuItem
            // 
            this.resetGameToolStripMenuItem.Name = "resetGameToolStripMenuItem";
            this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetGameToolStripMenuItem.Text = "Reset Game";
            this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.resetGameToolStripMenuItem_Click);
            // 
            // exitGameToolStripMenuItem
            // 
            this.exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            this.exitGameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitGameToolStripMenuItem.Text = "Exit Game";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rulesToolStripMenuItem.Text = "How to play";
            // 
            // BtnFlipCoin
            // 
            this.BtnFlipCoin.BackColor = System.Drawing.Color.Gray;
            this.BtnFlipCoin.Location = new System.Drawing.Point(162, 296);
            this.BtnFlipCoin.Name = "BtnFlipCoin";
            this.BtnFlipCoin.Size = new System.Drawing.Size(75, 23);
            this.BtnFlipCoin.TabIndex = 3;
            this.BtnFlipCoin.Text = "Flip Coin";
            this.BtnFlipCoin.UseVisualStyleBackColor = false;
            this.BtnFlipCoin.Click += new System.EventHandler(this.BtnRollDice_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.Gray;
            this.BtnReset.Enabled = false;
            this.BtnReset.Location = new System.Drawing.Point(162, 319);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset Game";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 361);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnFlipCoin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkFriend;
        private System.Windows.Forms.CheckBox checkComputer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coinTossStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.Button BtnFlipCoin;
        private System.Windows.Forms.Button BtnReset;
    }
}

