using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Control_Panel_Deluxe
{
    public partial class InputBoxForm : Form
    {
        public string InputText
        {
            get { return textBox.Text; }
        }

        public InputBoxForm(string title, string defaultText)
        {
            InitializeComponent();
            Text = title;
            textBox.Text = defaultText;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
