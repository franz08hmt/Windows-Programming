namespace ComplexNumberApp
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.realTextBox       = new System.Windows.Forms.TextBox();
            this.imaginaryTextBox  = new System.Windows.Forms.TextBox();
            this.label1            = new System.Windows.Forms.Label();
            this.label2            = new System.Windows.Forms.Label();
            this.firstButton       = new System.Windows.Forms.Button();
            this.secondButton      = new System.Windows.Forms.Button();
            this.addButton         = new System.Windows.Forms.Button();
            this.subtractButton    = new System.Windows.Forms.Button();
            this.multiplyButton    = new System.Windows.Forms.Button();
            this.statusLabel       = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // label1 — "Real"
            this.label1.AutoSize  = true;
            this.label1.Location  = new System.Drawing.Point(20, 20);
            this.label1.Name      = "label1";
            this.label1.Size      = new System.Drawing.Size(28, 13);
            this.label1.Text      = "Real";

            // realTextBox
            this.realTextBox.Location = new System.Drawing.Point(100, 17);
            this.realTextBox.Name     = "realTextBox";
            this.realTextBox.Size     = new System.Drawing.Size(150, 20);

            // label2 — "Imaginary"
            this.label2.AutoSize  = true;
            this.label2.Location  = new System.Drawing.Point(20, 55);
            this.label2.Name      = "label2";
            this.label2.Size      = new System.Drawing.Size(57, 13);
            this.label2.Text      = "Imaginary";

            // imaginaryTextBox
            this.imaginaryTextBox.Location = new System.Drawing.Point(100, 52);
            this.imaginaryTextBox.Name     = "imaginaryTextBox";
            this.imaginaryTextBox.Size     = new System.Drawing.Size(150, 20);

            // firstButton — "Set No 1"
            this.firstButton.Location = new System.Drawing.Point(280, 15);
            this.firstButton.Name     = "firstButton";
            this.firstButton.Size     = new System.Drawing.Size(80, 25);
            this.firstButton.Text     = "Set No 1";
            this.firstButton.Click   += new System.EventHandler(this.firstButton_Click);

            // secondButton — "Set No 2"
            this.secondButton.Location = new System.Drawing.Point(280, 50);
            this.secondButton.Name     = "secondButton";
            this.secondButton.Size     = new System.Drawing.Size(80, 25);
            this.secondButton.Text     = "Set No 2";
            this.secondButton.Click   += new System.EventHandler(this.secondButton_Click);

            // addButton — "Add"
            this.addButton.Location = new System.Drawing.Point(20, 100);
            this.addButton.Name     = "addButton";
            this.addButton.Size     = new System.Drawing.Size(80, 25);
            this.addButton.Text     = "Add";
            this.addButton.Click   += new System.EventHandler(this.addButton_Click);

            // subtractButton — "Subtract"
            this.subtractButton.Location = new System.Drawing.Point(120, 100);
            this.subtractButton.Name     = "subtractButton";
            this.subtractButton.Size     = new System.Drawing.Size(80, 25);
            this.subtractButton.Text     = "Subtract";
            this.subtractButton.Click   += new System.EventHandler(this.subtractButton_Click);

            // multiplyButton — "Multiply"
            this.multiplyButton.Location = new System.Drawing.Point(220, 100);
            this.multiplyButton.Name     = "multiplyButton";
            this.multiplyButton.Size     = new System.Drawing.Size(80, 25);
            this.multiplyButton.Text     = "Multiply";
            this.multiplyButton.Click   += new System.EventHandler(this.multiplyButton_Click);

            // statusLabel — "Notice:"
            this.statusLabel.AutoSize  = false;
            this.statusLabel.Location  = new System.Drawing.Point(20, 145);
            this.statusLabel.Name      = "statusLabel";
            this.statusLabel.Size      = new System.Drawing.Size(400, 30);
            this.statusLabel.Text      = "Notice:";

            // Form2
            this.ClientSize  = new System.Drawing.Size(440, 200);
            this.Name        = "Form2";
            this.Text        = "Complex Number Calculator";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.realTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imaginaryTextBox);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.secondButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.statusLabel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox  realTextBox;
        private System.Windows.Forms.TextBox  imaginaryTextBox;
        private System.Windows.Forms.Label    label1;
        private System.Windows.Forms.Label    label2;
        private System.Windows.Forms.Button   firstButton;
        private System.Windows.Forms.Button   secondButton;
        private System.Windows.Forms.Button   addButton;
        private System.Windows.Forms.Button   subtractButton;
        private System.Windows.Forms.Button   multiplyButton;
        private System.Windows.Forms.Label    statusLabel;
    }
}
