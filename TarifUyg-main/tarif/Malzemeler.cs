using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace tarif
{
    public partial class Malzemeler : Form
    {
        private DatabaseHelper _dbHelper;

        public Malzemeler(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;

            // malzemeleri yükle
            ListeleMalzemeler();
            ListeleTumu();
        }

        private void ListeleMalzemeler()
        {
            string query = "SELECT MalzemeID, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM Malzemeler";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable malzemeTable = new DataTable();
                        adapter.Fill(malzemeTable); // tabloya ekle


                        dgvMalzemeler.DataSource = malzemeTable;
                    }
                }
            }
        }


        private void ListeleTumu()
        {
            string query = "SELECT TarifID, MalzemeID, MalzemeMiktar from TarifMalzemeler";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable tumTable = new DataTable();
                        adapter.Fill(tumTable); 

                
                        dgvTumu.DataSource = tumTable;
                    }
                }
            }
        }

        private void dgvTumu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
