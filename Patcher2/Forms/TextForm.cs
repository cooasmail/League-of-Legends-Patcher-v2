using System;
using System.Windows.Forms;

namespace Patcher2.Forms
{
    public partial class TextForm : Form
    {
        public bool Success;

        public TextForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.leaguepatcher;
            this.Text = "Patcher v2 :: Text Input";
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Success = true;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Success = false;
            Close();
        }
    }
}
