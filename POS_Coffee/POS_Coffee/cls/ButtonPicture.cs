using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class ButtonPicture
    {
        public void MouseAction(Label lbl, string pathImage)
        {
            try
            {
                lbl.Image = Image.FromFile(pathImage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
