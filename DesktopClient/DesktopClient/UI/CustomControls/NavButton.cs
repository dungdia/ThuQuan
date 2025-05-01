using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient.UI.CustomControls
{
    public partial class NavButton : UserControl
    {
        public bool isSelected = false;
        public NavButton()
        {
            InitializeComponent();
        }

        public NavButton(string Text, Image image)
        {
            InitializeComponent();
            this.text.Text = Text;
            this.icon.Image = image;
        }

        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            if(!isSelected) {
                BackColor = Color.DarkGray;
            }
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            if(!isSelected) {
                BackColor = SystemColors.ControlLight;
            }
        }
    }
}
