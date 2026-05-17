namespace FormsDemo
{
    partial class frmProperties
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
            this.btnNewForm = new System.Windows.Forms.Button();
            this.btnOpacity = new System.Windows.Forms.Button();
            this.btnIcon = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnAcceptButton = new System.Windows.Forms.Button();
            this.btnChildForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewForm
            // 
            this.btnNewForm.Location = new System.Drawing.Point(70, 92);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(92, 34);
            this.btnNewForm.TabIndex = 0;
            this.btnNewForm.Text = "New Form";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // btnOpacity
            // 
            this.btnOpacity.Location = new System.Drawing.Point(252, 92);
            this.btnOpacity.Name = "btnOpacity";
            this.btnOpacity.Size = new System.Drawing.Size(75, 34);
            this.btnOpacity.TabIndex = 1;
            this.btnOpacity.Text = "Opacity";
            this.btnOpacity.UseVisualStyleBackColor = true;
            this.btnOpacity.Click += new System.EventHandler(this.btnOpacity_Click);
            // 
            // btnIcon
            // 
            this.btnIcon.Location = new System.Drawing.Point(430, 92);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(75, 34);
            this.btnIcon.TabIndex = 2;
            this.btnIcon.Text = "Icon";
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(616, 92);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(75, 34);
            this.btnBackColor.TabIndex = 3;
            this.btnBackColor.Text = "BackColor";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.Location = new System.Drawing.Point(70, 271);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(92, 32);
            this.btnForeColor.TabIndex = 4;
            this.btnForeColor.Text = "ForeColor";
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(252, 271);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 32);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnAcceptButton
            // 
            this.btnAcceptButton.Location = new System.Drawing.Point(430, 271);
            this.btnAcceptButton.Name = "btnAcceptButton";
            this.btnAcceptButton.Size = new System.Drawing.Size(75, 32);
            this.btnAcceptButton.TabIndex = 6;
            this.btnAcceptButton.Text = "AcceptButton";
            this.btnAcceptButton.UseVisualStyleBackColor = true;
            // 
            // btnChildForm
            // 
            this.btnChildForm.Location = new System.Drawing.Point(616, 271);
            this.btnChildForm.Name = "btnChildForm";
            this.btnChildForm.Size = new System.Drawing.Size(75, 32);
            this.btnChildForm.TabIndex = 7;
            this.btnChildForm.Text = "Chid Form";
            this.btnChildForm.UseVisualStyleBackColor = true;
            this.btnChildForm.Click += new System.EventHandler(this.btnChildForm_Click);
            // 
            // frmProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChildForm);
            this.Controls.Add(this.btnAcceptButton);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnForeColor);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.btnOpacity);
            this.Controls.Add(this.btnNewForm);
            this.Name = "frmProperties";
            this.Text = "frmProperties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewForm;
        private System.Windows.Forms.Button btnOpacity;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnAcceptButton;
        private System.Windows.Forms.Button btnChildForm;
    }
}