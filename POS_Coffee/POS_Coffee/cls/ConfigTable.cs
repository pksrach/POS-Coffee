using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class ConfigTable
    {
        // Default Constructor
        public ConfigTable() { }

        // Set config into constructor
        public ConfigTable(DataGridView dgv)
        {
            // should be config
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.AllowUserToAddRows= false;
            dgv.AllowUserToDeleteRows= false;
            dgv.AllowUserToOrderColumns= false;
            dgv.AllowUserToResizeRows = false;
            dgv.CellBorderStyle= DataGridViewCellBorderStyle.None;
            dgv.MultiSelect = false;
        }

        //Set Default Values 
        private string headerFont = "Khmer OS Siemreap";
        private short headerSize = 10;
        private short headerHeight = 40;
        private string rowsFont = "Khmer OS Siemreap";
        private short rowSize = 10;
        private short rowHeight = 30;

        //Get Set Method for access public 
        public string HeaderFont { get => headerFont; set => headerFont = value; }
        public short HeaderSize { get => headerSize; set => headerSize = value; }
        public short HeaderHeight { get => headerHeight; set => headerHeight = value; }
        public string RowsFont { get => rowsFont; set => rowsFont = value; }
        public short RowSize { get => rowSize; set => rowSize = value; }
        public short RowHeight { get => rowHeight; set => rowHeight = value; }

        public void DisplayTable(DataGridView dgv)
        {
            //This consructor method to set default before read data

            if (dgv == null) { return; }

            //Set header and font
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = this.HeaderHeight;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(this.HeaderFont, this.HeaderSize);

            //Set rows and font
            dgv.RowTemplate.Height = this.RowHeight;
            dgv.RowTemplate.DefaultCellStyle.Font = new Font(this.RowsFont, this.RowSize);


            //set column auto fill (fullscreen)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ========== Method Custom Color ==============
        // Header
        public void SetHeaderBackColor(DataGridView dgv, Color color)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = color;
        }
        public void SetHeaderForeColor(DataGridView dgv, Color color)
        {
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = color;
        }

        // Rows
        public void SetRowsBackColor(DataGridView dgv, Color color)
        {
            // check if color is tranparent do not set grid color
            dgv.RowTemplate.DefaultCellStyle.BackColor = color;
            dgv.DefaultCellStyle.SelectionBackColor = color;
        }
        public void SetRowsForeColor(DataGridView dgv, Color color)
        {
            dgv.RowTemplate.DefaultCellStyle.ForeColor = color;
            dgv.DefaultCellStyle.SelectionForeColor = color;
        }

        public void SetAlternativeBackColor(DataGridView dgv, Color color)
        {
            dgv.AlternatingRowsDefaultCellStyle.BackColor = color;
        }
        public void SetAlternativeForeColor(DataGridView dgv, Color color)
        {
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = color;
        }

        public void SetRowsBackColorSelected(DataGridView dgv, Color color)
        {
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor= color;
        }
        public void SetRowsForeColorSelected(DataGridView dgv, Color color)
        {
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = color;
        }

        // Set Grid Color
        public void SetGridColor(DataGridView dgv, Color color)
        {
            if(dgv.GridColor == Color.Transparent)
            {
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
            else
            {
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.GridColor = color;
                
            }
        }
    }
}
