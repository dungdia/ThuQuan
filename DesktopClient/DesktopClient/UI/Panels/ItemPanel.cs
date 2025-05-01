using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.Models;

namespace DesktopClient.UI
{
    public partial class ItemPanel : UserControl
    {
        List<VatDung> vatDungs = new List<VatDung>();
        public ItemPanel()
        {
            InitializeComponent();
            vatDungs = APIContext.GetMethod<VatDung>("VatDung");
            dataGridView1.DataSource = vatDungs;
            
        }

    }
}
