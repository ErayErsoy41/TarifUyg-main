using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tarif
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string dbFilePath = "test123.db";
            DatabaseHelper dbHelper = new DatabaseHelper(dbFilePath);  // DatabaseHelper'ı başlat

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dbHelper));  
        }
    }
}
