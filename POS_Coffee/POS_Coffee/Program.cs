using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using POS_Coffee.Subform;
using POS_Coffee.cls;
using POS_Coffee.form;

namespace POS_Coffee
{
    internal static class Program
    {
        //public static string name_user;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConnectionDb.MyConnection();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmMain());
        }
    }
}
