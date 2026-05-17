// Form2.cs  —  ComplexNumber Calculator UI
// Subject: Windows Programming  |  Topic: Ch2 Review – OOP & WinForms
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Windows.Forms;

namespace ComplexNumberApp
{
    /// <summary>
    /// WinForms UI for ComplexNumber arithmetic.
    /// Controls: realTextBox, imaginaryTextBox, statusLabel,
    ///           firstButton (Set No 1), secondButton (Set No 2),
    ///           addButton, subtractButton, multiplyButton
    /// </summary>
    public partial class Form2 : Form
    {
        // Two complex number instances (OOP: object instantiation)
        private ComplexNumber x = new ComplexNumber();
        private ComplexNumber y = new ComplexNumber();

        public Form2()
        {
            InitializeComponent();
            this.Text = "Complex Number Calculator";
        }

        // Set No 1: read Real & Imaginary → store in x
        private void firstButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(realTextBox.Text, out int r) ||
                !int.TryParse(imaginaryTextBox.Text, out int i))
            {
                MessageBox.Show("Please enter valid integers.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            x.Real      = r;
            x.Imaginary = i;
            realTextBox.Clear();
            imaginaryTextBox.Clear();
            statusLabel.Text = "First Complex Number is: " + x;
        }

        // Set No 2: read Real & Imaginary → store in y
        private void secondButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(realTextBox.Text, out int r) ||
                !int.TryParse(imaginaryTextBox.Text, out int i))
            {
                MessageBox.Show("Please enter valid integers.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            y.Real      = r;
            y.Imaginary = i;
            realTextBox.Clear();
            imaginaryTextBox.Clear();
            statusLabel.Text = "Second Complex Number is: " + y;
        }

        // Add: uses overloaded operator +
        private void addButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = $"{x} + {y} = {x + y}";
        }

        // Subtract: uses overloaded operator -
        private void subtractButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = $"{x} - {y} = {x - y}";
        }

        // Multiply: uses overloaded operator *
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = $"{x} * {y} = {x * y}";
        }
    }
}
