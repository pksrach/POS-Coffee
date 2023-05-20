using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class Clear
    {
        public static void ClearTextBox(Control control)
        {
            foreach(Control c in control.Controls)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    c.Text = null;
                }
            }
        }
    }
}
