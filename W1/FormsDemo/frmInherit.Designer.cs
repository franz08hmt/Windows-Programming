namespace FormsDemo
{
    partial class frmInherit
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
            this.btnShow = new System.Windows.Forms.Button();
            this.lvData = new System.Windows.Forms.ListView();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(493, 109);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(104, 36);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lvData
            // 
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(96, 211);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(299, 166);
            this.lvData.TabIndex = 1;
            this.lvData.UseCompatibleStateImageBehavior = false;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(96, 114);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(299, 26);
            this.txtPath.TabIndex = 2;
            // 
            // frmInherit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lvData);
            this.Controls.Add(this.btnShow);
            this.Name = "frmInherit";
            this.Text = "frmInherit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.TextBox txtPath;
    }
}