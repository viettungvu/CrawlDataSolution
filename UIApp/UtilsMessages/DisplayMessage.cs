using Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIApp.UtilsMessages
{
    public static class DisplayMessage
    {
        public static void Display<T>(Response<T> res, string message)
        {
            if (res.IsSuccess)
            {
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show(res.ErrorMessage);
            }
        }
    }
}
