using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.Dialog.ChildDialog
{
    public partial class SelectFineType : Form
    {
        public PenaltyDialog _parent;
        public SelectFineType(PenaltyDialog parent)
        {
            InitializeComponent();
            _parent = parent;

            hinhThucDropDown.SelectedIndex = 0;
            
        }

        private void hinhThucDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hinhThucDropDown.SelectedIndex == 1)//1 là khoá tài khoản
            {
                mucPhatTextBox.Enabled = false;
            }
            else
            {
                mucPhatTextBox.Enabled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (hinhThucDropDown.SelectedIndex == 1)
            {
                _parent._phieuPhatDTO.mucphat = "Khoá tài khoản";
                _parent.RefeshAtribute();
                Close();
                return;
            }

            if (hinhThucDropDown.SelectedIndex == 0)
            {
                bool isNum = int.TryParse(mucPhatTextBox.Text, out int num);
                if (!isNum)
                {
                    MessageBox.Show("Mức phạt phải là số nguyên dương");
                    return;
                }
                if (num < 0)
                {
                    MessageBox.Show("Mức phạt phải là số nguyên dương");
                    return;
                }
            }
            if (mucPhatTextBox.Text == "")
            {
                MessageBox.Show("Mức phạt không được để trống");
                return;
            }

            _parent._phieuPhatDTO.mucphat = mucPhatTextBox.Text;

            _parent.RefeshAtribute();
            Close();

        }
    }
}
