using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            this.experienceProgressBar = new System.Windows.Forms.ProgressBar();
            this.nameLabelFixed = new System.Windows.Forms.Label();
            this.equipButton = new System.Windows.Forms.Button();
            this.dropButton = new System.Windows.Forms.Button();
            this.detailedButton = new System.Windows.Forms.Button();
            this.Timer1S = new System.Windows.Forms.Timer(this.components);
            this.Timer01S = new System.Windows.Forms.Timer(this.components);
            this.nameRaceFixed = new System.Windows.Forms.Label();
            this.nameClassFixed = new System.Windows.Forms.Label();
            this.nameLevelFixed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.equipmentList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statList = new System.Windows.Forms.ListBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.raceLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.doActivityButton = new System.Windows.Forms.Button();
            this.autoDoActivityButton = new System.Windows.Forms.Button();
            this.poiLabel = new System.Windows.Forms.Label();
            this.logsList = new System.Windows.Forms.ListBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.ClearLogsButton = new System.Windows.Forms.Button();
            this.poiList = new System.Windows.Forms.ListBox();
            this.inventoryList = new System.Windows.Forms.ListBox();
            this.activityProgressBar = new System.Windows.Forms.ProgressBar();
            this.xpLabel = new System.Windows.Forms.Label();
            this.poolsLabel = new System.Windows.Forms.Label();
            this.maxHPLabelStatic = new System.Windows.Forms.Label();
            this.maxMPLabelStatic = new System.Windows.Forms.Label();
            this.maxHealthLabel = new System.Windows.Forms.Label();
            this.maxManaLabel = new System.Windows.Forms.Label();
            this.goldLabelFixed = new System.Windows.Forms.Label();
            this.goldLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // experienceProgressBar
            // 
            this.experienceProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.experienceProgressBar.Location = new System.Drawing.Point(12, 129);
            this.experienceProgressBar.Name = "experienceProgressBar";
            this.experienceProgressBar.Size = new System.Drawing.Size(163, 23);
            this.experienceProgressBar.TabIndex = 0;
            // 
            // nameLabelFixed
            // 
            this.nameLabelFixed.AutoSize = true;
            this.nameLabelFixed.Location = new System.Drawing.Point(15, 25);
            this.nameLabelFixed.Name = "nameLabelFixed";
            this.nameLabelFixed.Size = new System.Drawing.Size(44, 16);
            this.nameLabelFixed.TabIndex = 1;
            this.nameLabelFixed.Text = "Name";
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(418, 588);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(75, 23);
            this.equipButton.TabIndex = 3;
            this.equipButton.Text = "Equip";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.Click += new System.EventHandler(this.equipButton_Click);
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
            // detailedButton
            // 
            this.detailedButton.Location = new System.Drawing.Point(337, 588);
            this.detailedButton.Name = "detailedButton";
            this.detailedButton.Size = new System.Drawing.Size(75, 23);
            this.detailedButton.TabIndex = 6;
            this.detailedButton.Text = "Detailed";
            this.detailedButton.UseVisualStyleBackColor = true;
            // 
            // Timer1S
            // 
            this.Timer1S.Enabled = true;
            this.Timer1S.Interval = 1000;
            this.Timer1S.Tick += new System.EventHandler(this.Timer1s);
            // 
            // Timer01S
            // 
            this.Timer01S.Enabled = true;
            this.Timer01S.Tick += new System.EventHandler(this.Timer01s);
            // 
            // nameRaceFixed
            // 
            this.nameRaceFixed.AutoSize = true;
            this.nameRaceFixed.Location = new System.Drawing.Point(15, 41);
            this.nameRaceFixed.Name = "nameRaceFixed";
            this.nameRaceFixed.Size = new System.Drawing.Size(40, 16);
            this.nameRaceFixed.TabIndex = 7;
            this.nameRaceFixed.Text = "Race";
            // 
            // nameClassFixed
            // 
            this.nameClassFixed.AutoSize = true;
            this.nameClassFixed.Location = new System.Drawing.Point(15, 57);
            this.nameClassFixed.Name = "nameClassFixed";
            this.nameClassFixed.Size = new System.Drawing.Size(41, 16);
            this.nameClassFixed.TabIndex = 8;
            this.nameClassFixed.Text = "Class";
            // 
            // nameLevelFixed
            // 
            this.nameLevelFixed.AutoSize = true;
            this.nameLevelFixed.Location = new System.Drawing.Point(15, 73);
            this.nameLevelFixed.Name = "nameLevelFixed";
            this.nameLevelFixed.Size = new System.Drawing.Size(40, 16);
            this.nameLevelFixed.TabIndex = 9;
            this.nameLevelFixed.Text = "Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Character Sheet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(190, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Inventory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Experience";
            // 
            // equipmentList
            // 
            this.equipmentList.FormattingEnabled = true;
            this.equipmentList.ItemHeight = 16;
            this.equipmentList.Location = new System.Drawing.Point(193, 26);
            this.equipmentList.Name = "equipmentList";
            this.equipmentList.ScrollAlwaysVisible = true;
            this.equipmentList.Size = new System.Drawing.Size(300, 244);
            this.equipmentList.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Equipment";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Stats";
            // 
            // statList
            // 
            this.statList.FormattingEnabled = true;
            this.statList.ItemHeight = 16;
            this.statList.Location = new System.Drawing.Point(12, 174);
            this.statList.Name = "statList";
            this.statList.Size = new System.Drawing.Size(172, 180);
            this.statList.TabIndex = 17;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(131, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 16);
            this.nameLabel.TabIndex = 18;
            this.nameLabel.Text = "Name";
            // 
            // raceLabel
            // 
            this.raceLabel.AutoSize = true;
            this.raceLabel.Location = new System.Drawing.Point(131, 41);
            this.raceLabel.Name = "raceLabel";
            this.raceLabel.Size = new System.Drawing.Size(40, 16);
            this.raceLabel.TabIndex = 19;
            this.raceLabel.Text = "Race";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(130, 57);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(41, 16);
            this.classLabel.TabIndex = 20;
            this.classLabel.Text = "Class";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(130, 73);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(14, 16);
            this.levelLabel.TabIndex = 21;
            this.levelLabel.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Detailed";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Equip";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // doActivityButton
            // 
            this.doActivityButton.Location = new System.Drawing.Point(651, 276);
            this.doActivityButton.Name = "doActivityButton";
            this.doActivityButton.Size = new System.Drawing.Size(73, 23);
            this.doActivityButton.TabIndex = 25;
            this.doActivityButton.Text = "Attack";
            this.doActivityButton.UseVisualStyleBackColor = true;
            this.doActivityButton.Click += new System.EventHandler(this.doActivityButtonCallBack);
            // 
            // autoDoActivityButton
            // 
            this.autoDoActivityButton.Location = new System.Drawing.Point(543, 276);
            this.autoDoActivityButton.Name = "autoDoActivityButton";
            this.autoDoActivityButton.Size = new System.Drawing.Size(102, 23);
            this.autoDoActivityButton.TabIndex = 26;
            this.autoDoActivityButton.Text = "Auto Attack";
            this.autoDoActivityButton.UseVisualStyleBackColor = true;
            this.autoDoActivityButton.Click += new System.EventHandler(this.autoDoActivityButtonCallBack);
            // 
            // poiLabel
            // 
            this.poiLabel.AutoSize = true;
            this.poiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poiLabel.Location = new System.Drawing.Point(496, 7);
            this.poiLabel.Name = "poiLabel";
            this.poiLabel.Size = new System.Drawing.Size(124, 16);
            this.poiLabel.TabIndex = 28;
            this.poiLabel.Text = "Points Of Interest";
            // 
            // logsList
            // 
            this.logsList.AllowDrop = true;
            this.logsList.FormattingEnabled = true;
            this.logsList.ItemHeight = 16;
            this.logsList.Location = new System.Drawing.Point(499, 306);
            this.logsList.Name = "logsList";
            this.logsList.ScrollAlwaysVisible = true;
            this.logsList.Size = new System.Drawing.Size(225, 276);
            this.logsList.TabIndex = 29;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsLabel.Location = new System.Drawing.Point(496, 283);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(41, 16);
            this.logsLabel.TabIndex = 30;
            this.logsLabel.Text = "Logs";
            // 
            // ClearLogsButton
            // 
            this.ClearLogsButton.Location = new System.Drawing.Point(499, 588);
            this.ClearLogsButton.Name = "ClearLogsButton";
            this.ClearLogsButton.Size = new System.Drawing.Size(225, 23);
            this.ClearLogsButton.TabIndex = 31;
            this.ClearLogsButton.Text = "Clear Logs";
            this.ClearLogsButton.UseVisualStyleBackColor = true;
            this.ClearLogsButton.Click += new System.EventHandler(this.ClearLogsButton_Click);
            // 
            // poiList
            // 
            this.poiList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.poiList.FormattingEnabled = true;
            this.poiList.ItemHeight = 16;
            this.poiList.Location = new System.Drawing.Point(499, 25);
            this.poiList.Name = "poiList";
            this.poiList.ScrollAlwaysVisible = true;
            this.poiList.Size = new System.Drawing.Size(225, 244);
            this.poiList.TabIndex = 32;
            this.poiList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.poiList.SelectedIndexChanged += new System.EventHandler(this.poiList_SelectedIndexChanged);
            // 
            // inventoryList
            // 
            this.inventoryList.FormattingEnabled = true;
            this.inventoryList.ItemHeight = 16;
            this.inventoryList.Location = new System.Drawing.Point(193, 306);
            this.inventoryList.Name = "inventoryList";
            this.inventoryList.ScrollAlwaysVisible = true;
            this.inventoryList.Size = new System.Drawing.Size(300, 276);
            this.inventoryList.TabIndex = 33;
            // 
            // activityProgressBar
            // 
            this.activityProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.activityProgressBar.Location = new System.Drawing.Point(7, 617);
            this.activityProgressBar.Name = "activityProgressBar";
            this.activityProgressBar.Size = new System.Drawing.Size(717, 23);
            this.activityProgressBar.TabIndex = 34;
            // 
            // xpLabel
            // 
            this.xpLabel.AutoSize = true;
            this.xpLabel.Location = new System.Drawing.Point(117, 110);
            this.xpLabel.Name = "xpLabel";
            this.xpLabel.Size = new System.Drawing.Size(67, 16);
            this.xpLabel.TabIndex = 35;
            this.xpLabel.Text = "1120/1980";
            this.xpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // poolsLabel
            // 
            this.poolsLabel.AutoSize = true;
            this.poolsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poolsLabel.Location = new System.Drawing.Point(9, 357);
            this.poolsLabel.Name = "poolsLabel";
            this.poolsLabel.Size = new System.Drawing.Size(47, 16);
            this.poolsLabel.TabIndex = 36;
            this.poolsLabel.Text = "Pools";
            // 
            // maxHPLabelStatic
            // 
            this.maxHPLabelStatic.AutoSize = true;
            this.maxHPLabelStatic.Location = new System.Drawing.Point(15, 373);
            this.maxHPLabelStatic.Name = "maxHPLabelStatic";
            this.maxHPLabelStatic.Size = new System.Drawing.Size(54, 16);
            this.maxHPLabelStatic.TabIndex = 37;
            this.maxHPLabelStatic.Text = "Max HP";
            // 
            // maxMPLabelStatic
            // 
            this.maxMPLabelStatic.AutoSize = true;
            this.maxMPLabelStatic.Location = new System.Drawing.Point(15, 389);
            this.maxMPLabelStatic.Name = "maxMPLabelStatic";
            this.maxMPLabelStatic.Size = new System.Drawing.Size(55, 16);
            this.maxMPLabelStatic.TabIndex = 38;
            this.maxMPLabelStatic.Text = "Max MP";
            // 
            // maxHealthLabel
            // 
            this.maxHealthLabel.AutoSize = true;
            this.maxHealthLabel.Location = new System.Drawing.Point(164, 373);
            this.maxHealthLabel.Name = "maxHealthLabel";
            this.maxHealthLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.maxHealthLabel.Size = new System.Drawing.Size(14, 16);
            this.maxHealthLabel.TabIndex = 39;
            this.maxHealthLabel.Text = "0";
            this.maxHealthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // maxManaLabel
            // 
            this.maxManaLabel.AutoSize = true;
            this.maxManaLabel.Location = new System.Drawing.Point(164, 389);
            this.maxManaLabel.Name = "maxManaLabel";
            this.maxManaLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.maxManaLabel.Size = new System.Drawing.Size(14, 16);
            this.maxManaLabel.TabIndex = 40;
            this.maxManaLabel.Text = "0";
            this.maxManaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // goldLabelFixed
            // 
            this.goldLabelFixed.AutoSize = true;
            this.goldLabelFixed.Location = new System.Drawing.Point(15, 89);
            this.goldLabelFixed.Name = "goldLabelFixed";
            this.goldLabelFixed.Size = new System.Drawing.Size(36, 16);
            this.goldLabelFixed.TabIndex = 41;
            this.goldLabelFixed.Text = "Gold";
            // 
            // goldLabel
            // 
            this.goldLabel.AutoSize = true;
            this.goldLabel.Location = new System.Drawing.Point(130, 89);
            this.goldLabel.Name = "goldLabel";
            this.goldLabel.Size = new System.Drawing.Size(14, 16);
            this.goldLabel.TabIndex = 42;
            this.goldLabel.Text = "0";
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 646);
            this.Controls.Add(this.goldLabel);
            this.Controls.Add(this.goldLabelFixed);
            this.Controls.Add(this.maxManaLabel);
            this.Controls.Add(this.maxHealthLabel);
            this.Controls.Add(this.maxMPLabelStatic);
            this.Controls.Add(this.maxHPLabelStatic);
            this.Controls.Add(this.poolsLabel);
            this.Controls.Add(this.xpLabel);
            this.Controls.Add(this.activityProgressBar);
            this.Controls.Add(this.inventoryList);
            this.Controls.Add(this.poiList);
            this.Controls.Add(this.ClearLogsButton);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.logsList);
            this.Controls.Add(this.poiLabel);
            this.Controls.Add(this.autoDoActivityButton);
            this.Controls.Add(this.doActivityButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.raceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.statList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.equipmentList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameLevelFixed);
            this.Controls.Add(this.nameClassFixed);
            this.Controls.Add(this.nameRaceFixed);
            this.Controls.Add(this.detailedButton);
            this.Controls.Add(this.dropButton);
            this.Controls.Add(this.equipButton);
            this.Controls.Add(this.nameLabelFixed);
            this.Controls.Add(this.experienceProgressBar);
            this.Name = "MainGameForm";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar experienceProgressBar;
        private System.Windows.Forms.Label nameLabelFixed;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.Button dropButton;
        private System.Windows.Forms.Button detailedButton;
        private System.Windows.Forms.Timer Timer1S;
        private System.Windows.Forms.Timer Timer01S;
        private System.Windows.Forms.Label nameRaceFixed;
        private System.Windows.Forms.Label nameClassFixed;
        private System.Windows.Forms.Label nameLevelFixed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox equipmentList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox statList;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label raceLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button doActivityButton;
        private System.Windows.Forms.Button autoDoActivityButton;
        private System.Windows.Forms.Label poiLabel;
        private System.Windows.Forms.ListBox logsList;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.Button ClearLogsButton;
        private System.Windows.Forms.ListBox poiList;
        private System.Windows.Forms.ListBox inventoryList;
        private System.Windows.Forms.ProgressBar activityProgressBar;
        private System.Windows.Forms.Label xpLabel;
        private System.Windows.Forms.Label poolsLabel;
        private System.Windows.Forms.Label maxHPLabelStatic;
        private System.Windows.Forms.Label maxMPLabelStatic;
        private System.Windows.Forms.Label maxHealthLabel;
        private System.Windows.Forms.Label maxManaLabel;
        private Label goldLabelFixed;
        private Label goldLabel;
    }
}