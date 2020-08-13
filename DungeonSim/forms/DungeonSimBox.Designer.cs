using System.Drawing;
namespace DungeonSim
{
    partial class DungeonSimBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonSimBox));
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddPartyButton = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSimTurn = new System.Windows.Forms.Button();
            this.BtnClearParty = new System.Windows.Forms.Button();
            this.BtnClearMonsters = new System.Windows.Forms.Button();
            this.LblLoss = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Party State";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1390, 778);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::DungeonSim.Properties.Resources.DnD5e_Banner;
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1464, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // AddPartyButton
            // 
            this.AddPartyButton.Location = new System.Drawing.Point(158, 248);
            this.AddPartyButton.Name = "AddPartyButton";
            this.AddPartyButton.Size = new System.Drawing.Size(119, 25);
            this.AddPartyButton.TabIndex = 7;
            this.AddPartyButton.Text = "Edit Party";
            this.AddPartyButton.UseVisualStyleBackColor = true;
            this.AddPartyButton.Click += new System.EventHandler(this.AddPartyButton_Click);
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.SkyBlue;
            this.plotView1.Location = new System.Drawing.Point(909, 196);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(577, 225);
            this.plotView1.TabIndex = 8;
            this.plotView1.Text = "This will Be A place";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotView2
            // 
            this.plotView2.BackColor = System.Drawing.Color.SkyBlue;
            this.plotView2.Location = new System.Drawing.Point(912, 462);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(573, 262);
            this.plotView2.TabIndex = 10;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView2.Click += new System.EventHandler(this.plotView2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monsters States";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(508, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 25);
            this.button2.TabIndex = 12;
            this.button2.Text = "Edit Monsters";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddMonsterButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(267, 571);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 33);
            this.progressBar1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Battle Progress";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 641);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Previous Events";
            // 
            // BtnSimTurn
            // 
            this.BtnSimTurn.Location = new System.Drawing.Point(317, 475);
            this.BtnSimTurn.Name = "BtnSimTurn";
            this.BtnSimTurn.Size = new System.Drawing.Size(132, 23);
            this.BtnSimTurn.TabIndex = 17;
            this.BtnSimTurn.Text = "Simulate Turn";
            this.BtnSimTurn.UseVisualStyleBackColor = true;
            this.BtnSimTurn.Click += new System.EventHandler(this.BtnSimTurnClick);
            // 
            // BtnClearParty
            // 
            this.BtnClearParty.Location = new System.Drawing.Point(158, 292);
            this.BtnClearParty.Name = "BtnClearParty";
            this.BtnClearParty.Size = new System.Drawing.Size(119, 25);
            this.BtnClearParty.TabIndex = 18;
            this.BtnClearParty.Text = "Clear Party";
            this.BtnClearParty.UseVisualStyleBackColor = true;
            this.BtnClearParty.Click += new System.EventHandler(this.BtnClearParty_Click);
            // 
            // BtnClearMonsters
            // 
            this.BtnClearMonsters.Location = new System.Drawing.Point(508, 292);
            this.BtnClearMonsters.Name = "BtnClearMonsters";
            this.BtnClearMonsters.Size = new System.Drawing.Size(121, 25);
            this.BtnClearMonsters.TabIndex = 19;
            this.BtnClearMonsters.Text = "Clear Monsters";
            this.BtnClearMonsters.UseVisualStyleBackColor = true;
            this.BtnClearMonsters.Click += new System.EventHandler(this.BtnClearMonsters_Click);
            // 
            // LblLoss
            // 
            this.LblLoss.AutoSize = true;
            this.LblLoss.Location = new System.Drawing.Point(335, 678);
            this.LblLoss.Name = "LblLoss";
            this.LblLoss.Size = new System.Drawing.Size(0, 23);
            this.LblLoss.TabIndex = 20;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(297, 755);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(181, 46);
            this.BtnReset.TabIndex = 21;
            this.BtnReset.Text = "Reset Sim";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // DungeonSimBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1535, 837);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.LblLoss);
            this.Controls.Add(this.BtnClearMonsters);
            this.Controls.Add(this.BtnClearParty);
            this.Controls.Add(this.BtnSimTurn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.AddPartyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DungeonSimBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DungeonSim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DungeonSimBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddPartyButton;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSimTurn;
        private System.Windows.Forms.Button BtnClearParty;
        private System.Windows.Forms.Button BtnClearMonsters;
        private System.Windows.Forms.Label LblLoss;
        private System.Windows.Forms.Button BtnReset;
    }
}

