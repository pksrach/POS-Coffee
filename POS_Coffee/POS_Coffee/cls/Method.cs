using POS_Coffee.AlertMessage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class Method
    {
        private string defaultPath = "Pictures/nopic.png";
        public string DefaultParth
        {
            get => defaultPath; 
            set => defaultPath = value;
        }

        private string path_img;
        public string MyPath
        {
            get => path_img;
            set => path_img = value;
        }
        
        public Image DefaultImage()
        {
            MyPath = "Pictures/nopic.png";
            return Image.FromFile(MyPath);
        }

        //save image into db type image (byte data)
        public byte[] SavePhoto(PictureBox pic)
        {
            if(pic.Image == null) return null;

            try
            {
                MemoryStream ms = new MemoryStream();
                pic.Image.Save(ms, pic.Image.RawFormat);
                return ms.GetBuffer();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Boolean DisableTableWhenSelected(DataGridView dgv, Button btnEdit, Button btnSave)
        {
            bool check = false;
            if(dgv.Enabled == true)
            {
                dgv.Enabled = false;
                btnEdit.Text = "ត្រឡប់";
                btnSave.Text = "រក្សាទុក";
                dgv.DefaultCellStyle.SelectionBackColor = Color.Red;
                check = true;
            }
            else
            {
                dgv.ClearSelection();
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
                dgv.Enabled = true;

                btnEdit.Text = "កែប្រែ";
                btnSave.Text = "បង្កើតថ្មី";
                check = false;
            }

            return check;
        }

        // Dynamic
        public static Boolean isEmptyTextBoxCurrency(params TextBox[] txts)
        {
            foreach (TextBox txt in txts)
            {
                if(txt.Text == "")
                {
                    txt.BackColor = Color.Red;
                    Warning warning = new Warning("សូមបញ្ចូលទិន្នន័យ", "មានទិន្នន័យទទេរ");
                    warning.ShowDialog();
                    txt.BackColor = Color.White;
                    txt.Focus();
                    return true;
                }
            }
            return false;
        }

    }//
}///
