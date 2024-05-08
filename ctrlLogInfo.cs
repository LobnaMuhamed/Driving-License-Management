using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class ctrlLogInfo : UserControl
    {
        public ctrlLogInfo()
        {
            InitializeComponent();
        }

        public string UserID
        { set { lblUserID.Text = value; } }
        public string UserName
        { set { lblUserName.Text = value; } }
        public string IsActive
        { set { lblIsActive.Text = value; } }
    }
}
