using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Patcher2.Forms
{
    public partial class TextForm : Form
    {
        public bool Success;

        public TextForm()
        {
            InitializeComponent();
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
