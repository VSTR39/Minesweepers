namespace minichki_v1._1.View
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
            this.panel = new System.Windows.Forms.Panel();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_mines = new System.Windows.Forms.Label();
            this.lbl_remaining_mines = new System.Windows.Forms.Label();
            this.mines_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(12, 79);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(450, 450);
            this.panel.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(167, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(114, 40);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.click);
            // 
            // lbl_mines
            // 
            this.lbl_mines.AutoSize = true;
            this.lbl_mines.Location = new System.Drawing.Point(45, 26);
            this.lbl_mines.Name = "lbl_mines";
            this.lbl_mines.Size = new System.Drawing.Size(89, 13);
            this.lbl_mines.TabIndex = 2;
            this.lbl_mines.Text = "Mines In Total:14";
            // 
            // lbl_remaining_mines
            // 
            this.lbl_remaining_mines.AutoSize = true;
            this.lbl_remaining_mines.Location = new System.Drawing.Point(328, 25);
            this.lbl_remaining_mines.Name = "lbl_remaining_mines";
            this.lbl_remaining_mines.Size = new System.Drawing.Size(91, 13);
            this.lbl_remaining_mines.TabIndex = 3;
            this.lbl_remaining_mines.Text = "Mines Remaining:";
            // 
            // mines_count
            // 
            this.mines_count.AutoSize = true;
            this.mines_count.Location = new System.Drawing.Point(417, 25);
            this.mines_count.Name = "mines_count";
            this.mines_count.Size = new System.Drawing.Size(0, 13);
            this.mines_count.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 536);
            this.Controls.Add(this.mines_count);
            this.Controls.Add(this.lbl_remaining_mines);
            this.Controls.Add(this.lbl_mines);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.panel);
            this.Name = "MainForm";
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_mines;
        private System.Windows.Forms.Label lbl_remaining_mines;
        private System.Windows.Forms.Label mines_count;
    }
}