namespace FormsDemo
{
    partial class Form1
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
            this.btnForm2 = new System.Windows.Forms.Button();
            this.btnForm3 = new System.Windows.Forms.Button();
            this.btnForm4 = new System.Windows.Forms.Button();
            this.btnForm5 = new System.Windows.Forms.Button();
            this.btnNewForm = new System.Windows.Forms.Button();
            this.btnInheritForm = new System.Windows.Forms.Button();
            this.btnUseInherit = new System.Windows.Forms.Button();
            this.btnOtherMDI = new System.Windows.Forms.Button();
            this.btnTron = new System.Windows.Forms.Button();
            this.btnKhac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm2
            // 
            this.btnForm2.Location = new System.Drawing.Point(53, 59);
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(75, 33);
            this.btnForm2.TabIndex = 1;
            this.btnForm2.Text = "Form2";
            this.btnForm2.UseVisualStyleBackColor = true;
            this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
            // 
            // btnForm3
            // 
            this.btnForm3.Location = new System.Drawing.Point(211, 59);
            this.btnForm3.Name = "btnForm3";
            this.btnForm3.Size = new System.Drawing.Size(75, 33);
            this.btnForm3.TabIndex = 2;
            this.btnForm3.Text = "Form3";
            this.btnForm3.UseVisualStyleBackColor = true;
            this.btnForm3.Click += new System.EventHandler(this.btnForm3_Click);
            // 
            // btnForm4
            // 
            this.btnForm4.Location = new System.Drawing.Point(366, 59);
            this.btnForm4.Name = "btnForm4";
            this.btnForm4.Size = new System.Drawing.Size(75, 33);
            this.btnForm4.TabIndex = 3;
            this.btnForm4.Text = "Form4";
            this.btnForm4.UseVisualStyleBackColor = true;
            this.btnForm4.Click += new System.EventHandler(this.btnForm4_Click);
            // 
            // btnForm5
            // 
            this.btnForm5.Location = new System.Drawing.Point(528, 59);
            this.btnForm5.Name = "btnForm5";
            this.btnForm5.Size = new System.Drawing.Size(75, 33);
            this.btnForm5.TabIndex = 4;
            this.btnForm5.Text = "Form5";
            this.btnForm5.UseVisualStyleBackColor = true;
            this.btnForm5.Click += new System.EventHandler(this.btnForm5_Click);
            // 
            // btnNewForm
            // 
            this.btnNewForm.Location = new System.Drawing.Point(671, 59);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(92, 33);
            this.btnNewForm.TabIndex = 5;
            this.btnNewForm.Text = "New Form";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // btnInheritForm
            // 
            this.btnInheritForm.Location = new System.Drawing.Point(167, 227);
            this.btnInheritForm.Name = "btnInheritForm";
            this.btnInheritForm.Size = new System.Drawing.Size(119, 31);
            this.btnInheritForm.TabIndex = 6;
            this.btnInheritForm.Text = "Inherit Form";
            this.btnInheritForm.UseVisualStyleBackColor = true;
            this.btnInheritForm.Click += new System.EventHandler(this.btnInheritForm_Click);
            // 
            // btnUseInherit
            // 
            this.btnUseInherit.Location = new System.Drawing.Point(339, 227);
            this.btnUseInherit.Name = "btnUseInherit";
            this.btnUseInherit.Size = new System.Drawing.Size(137, 31);
            this.btnUseInherit.TabIndex = 7;
            this.btnUseInherit.Text = "Use Inherit Form";
            this.btnUseInherit.UseVisualStyleBackColor = true;
            this.btnUseInherit.Click += new System.EventHandler(this.btnUseInherit_Click);
            // 
            // btnOtherMDI
            // 
            this.btnOtherMDI.Location = new System.Drawing.Point(528, 227);
            this.btnOtherMDI.Name = "btnOtherMDI";
            this.btnOtherMDI.Size = new System.Drawing.Size(100, 31);
            this.btnOtherMDI.TabIndex = 8;
            this.btnOtherMDI.Text = "Other MDI";
            this.btnOtherMDI.UseVisualStyleBackColor = true;
            this.btnOtherMDI.Click += new System.EventHandler(this.btnOtherMDI_Click);
            // 
            // btnTron
            // 
            this.btnTron.Location = new System.Drawing.Point(53, 221);
            this.btnTron.Name = "btnTron";
            this.btnTron.Size = new System.Drawing.Size(75, 37);
            this.btnTron.TabIndex = 9;
            this.btnTron.Text = "Tron";
            this.btnTron.UseVisualStyleBackColor = true;
            this.btnTron.Click += new System.EventHandler(this.btnTron_Click);
            // 
            // btnKhac
            // 
            this.btnKhac.Location = new System.Drawing.Point(688, 224);
            this.btnKhac.Name = "btnKhac";
            this.btnKhac.Size = new System.Drawing.Size(75, 37);
            this.btnKhac.TabIndex = 10;
            this.btnKhac.Text = "Khac";
            this.btnKhac.UseVisualStyleBackColor = true;
            this.btnKhac.Click += new System.EventHandler(this.btnKhac_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKhac);
            this.Controls.Add(this.btnTron);
            this.Controls.Add(this.btnOtherMDI);
            this.Controls.Add(this.btnUseInherit);
            this.Controls.Add(this.btnInheritForm);
            this.Controls.Add(this.btnNewForm);
            this.Controls.Add(this.btnForm5);
            this.Controls.Add(this.btnForm4);
            this.Controls.Add(this.btnForm3);
            this.Controls.Add(this.btnForm2);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm2;
        private System.Windows.Forms.Button btnForm3;
        private System.Windows.Forms.Button btnForm4;
        private System.Windows.Forms.Button btnForm5;
        private System.Windows.Forms.Button btnNewForm;
        private System.Windows.Forms.Button btnInheritForm;
        private System.Windows.Forms.Button btnUseInherit;
        private System.Windows.Forms.Button btnOtherMDI;
        private System.Windows.Forms.Button btnTron;
        private System.Windows.Forms.Button btnKhac;
    }
}

