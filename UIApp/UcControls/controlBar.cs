using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIApp.UcControls
{
    public partial class controlBar : UserControl
    {
        public controlBar()
        {
            InitializeComponent();
        }
        private event EventHandler closeControl;
        public event EventHandler CloseControl
        {
            add { closeControl += value; }
            remove { closeControl -= value; }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (closeControl != null)
            {
                closeControl(this, new EventArgs());
            }
        }
    }
}
