namespace DungeonSim.forms
{
    partial class AddForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.LblStr = new System.Windows.Forms.Label();
            this.LblDex = new System.Windows.Forms.Label();
            this.LblCon = new System.Windows.Forms.Label();
            this.LblInt = new System.Windows.Forms.Label();
            this.LblWis = new System.Windows.Forms.Label();
            this.LblCha = new System.Windows.Forms.Label();
            this.LblMove = new System.Windows.Forms.Label();
            this.LblAC = new System.Windows.Forms.Label();
            this.LblPrimary = new System.Windows.Forms.Label();
            this.LblSecondary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblStr
            // 
            this.LblStr.AutoSize = true;
            this.LblStr.Location = new System.Drawing.Point(60, 9);
            this.LblStr.Name = "LblStr";
            this.LblStr.Size = new System.Drawing.Size(36, 17);
            this.LblStr.TabIndex = 1;
            this.LblStr.Text = "STR";
            // 
            // LblDex
            // 
            this.LblDex.AutoSize = true;
            this.LblDex.Location = new System.Drawing.Point(111, 9);
            this.LblDex.Name = "LblDex";
            this.LblDex.Size = new System.Drawing.Size(45, 21);
            this.LblDex.TabIndex = 2;
            this.LblDex.Text = "DEX";
            // 
            // LblCon
            // 
            this.LblCon.AutoSize = true;
            this.LblCon.Location = new System.Drawing.Point(158, 9);
            this.LblCon.Name = "LblCon";
            this.LblCon.Size = new System.Drawing.Size(48, 21);
            this.LblCon.TabIndex = 3;
            this.LblCon.Text = "CON";
            this.LblCon.Click += new System.EventHandler(this.label3_Click);
            // 
            // LblInt
            // 
            this.LblInt.AutoSize = true;
            this.LblInt.Location = new System.Drawing.Point(203, 9);
            this.LblInt.Name = "LblInt";
            this.LblInt.Size = new System.Drawing.Size(30, 17);
            this.LblInt.TabIndex = 4;
            this.LblInt.Text = "INT";
            // 
            // LblWis
            // 
            this.LblWis.AutoSize = true;
            this.LblWis.Location = new System.Drawing.Point(249, 9);
            this.LblWis.Name = "LblWis";
            this.LblWis.Size = new System.Drawing.Size(41, 21);
            this.LblWis.TabIndex = 5;
            this.LblWis.Text = "WIS";
            this.LblWis.Click += new System.EventHandler(this.label5_Click);
            // 
            // LblCha
            // 
            this.LblCha.AutoSize = true;
            this.LblCha.Location = new System.Drawing.Point(295, 9);
            this.LblCha.Name = "LblCha";
            this.LblCha.Size = new System.Drawing.Size(45, 21);
            this.LblCha.TabIndex = 6;
            this.LblCha.Text = "CHA";
            // 
            // LblMove
            // 
            this.LblMove.AutoSize = true;
            this.LblMove.Location = new System.Drawing.Point(345, 9);
            this.LblMove.Name = "LblMove";
            this.LblMove.Size = new System.Drawing.Size(73, 17);
            this.LblMove.TabIndex = 7;
            this.LblMove.Text = "Movement";
            // 
            // LblAC
            // 
            this.LblAC.AutoSize = true;
            this.LblAC.Location = new System.Drawing.Point(424, 9);
            this.LblAC.Name = "LblAC";
            this.LblAC.Size = new System.Drawing.Size(33, 21);
            this.LblAC.TabIndex = 8;
            this.LblAC.Text = "AC";
            // 
            // LblPrimary
            // 
            this.LblPrimary.AutoSize = true;
            this.LblPrimary.Location = new System.Drawing.Point(472, 9);
            this.LblPrimary.Name = "LblPrimary";
            this.LblPrimary.Size = new System.Drawing.Size(113, 17);
            this.LblPrimary.TabIndex = 9;
            this.LblPrimary.Text = "Primary Weapon";
            // 
            // LblSecondary
            // 
            this.LblSecondary.AutoSize = true;
            this.LblSecondary.Location = new System.Drawing.Point(601, 9);
            this.LblSecondary.Name = "LblSecondary";
            this.LblSecondary.Size = new System.Drawing.Size(133, 17);
            this.LblSecondary.TabIndex = 10;
            this.LblSecondary.Text = "Secondary Weapon";
            this.LblSecondary.Click += new System.EventHandler(this.label10_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblSecondary);
            this.Controls.Add(this.LblPrimary);
            this.Controls.Add(this.LblAC);
            this.Controls.Add(this.LblMove);
            this.Controls.Add(this.LblCha);
            this.Controls.Add(this.LblWis);
            this.Controls.Add(this.LblInt);
            this.Controls.Add(this.LblCon);
            this.Controls.Add(this.LblDex);
            this.Controls.Add(this.LblStr);
            this.Controls.Add(this.button1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblStr;
        private System.Windows.Forms.Label LblDex;
        private System.Windows.Forms.Label LblCon;
        private System.Windows.Forms.Label LblInt;
        private System.Windows.Forms.Label LblWis;
        private System.Windows.Forms.Label LblCha;
        private System.Windows.Forms.Label LblMove;
        private System.Windows.Forms.Label LblAC;
        private System.Windows.Forms.Label LblPrimary;
        private System.Windows.Forms.Label LblSecondary;
    }
}