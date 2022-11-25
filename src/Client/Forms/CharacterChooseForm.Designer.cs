namespace Client
{
    partial class CharacterChooseForm
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
            this.characterSelectionListBox = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // characterSelectionListBox
            // 
            this.characterSelectionListBox.FormattingEnabled = true;
            this.characterSelectionListBox.Location = new System.Drawing.Point(12, 12);
            this.characterSelectionListBox.Name = "characterSelectionListBox";
            this.characterSelectionListBox.Size = new System.Drawing.Size(290, 276);
            this.characterSelectionListBox.TabIndex = 0;
            this.characterSelectionListBox.SelectedIndexChanged += new System.EventHandler(this.characterSelectionListBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enter Game World";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.characterSelectionListBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox characterSelectionListBox;
        private System.Windows.Forms.Button button1;
    }
}