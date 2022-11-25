namespace Client.Forms
{
    partial class MainGameForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.inventoryList = new System.Windows.Forms.CheckedListBox();
            this.equipButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.dropButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 93);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(138, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name: Necron";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // inventoryList
            // 
            this.inventoryList.FormattingEnabled = true;
            this.inventoryList.Location = new System.Drawing.Point(193, 289);
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.Size = new System.Drawing.Size(300, 293);
            this.inventoryList.TabIndex = 2;
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(418, 588);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(75, 23);
            this.equipButton.TabIndex = 3;
            this.equipButton.Text = "Equip";
            this.equipButton.UseVisualStyleBackColor = true;
            // 
            // sellButton
            // 
            this.sellButton.Location = new System.Drawing.Point(337, 588);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(75, 23);
            this.sellButton.TabIndex = 4;
            this.sellButton.Text = "Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // dropButton
            // 
            this.dropButton.Location = new System.Drawing.Point(193, 588);
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(113, 23);
            this.dropButton.TabIndex = 5;
            this.dropButton.Text = "Drop Selected";
            this.dropButton.UseVisualStyleBackColor = true;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 623);
            this.Controls.Add(this.dropButton);
            this.Controls.Add(this.sellButton);
            this.Controls.Add(this.equipButton);
            this.Controls.Add(this.inventoryList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "MainGameForm";
            this.Text = "MainGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox inventoryList;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Button dropButton;
    }
}