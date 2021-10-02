using ES;
using Models;
using Models.Links;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using static Models.AllEnums;

namespace UIApp
{
    public partial class frmTestService : Form
    {
        private HttpClient client;
        public frmTestService()
        {
            InitializeComponent();
            client = new HttpClient();
        }

     
    }
}
