using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Coffee.cls
{
    internal class Refresh
    {
        static LoadData loadDb = new LoadData();
        public static void LoadingData(DataGridView dataGridView1, string query)
        {
            loadDb.loadData(dataGridView1, query, 0, 1);

            //clear selection must be under code process
            dataGridView1.ClearSelection();
        }
    }
}
