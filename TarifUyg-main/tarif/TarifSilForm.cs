using System;
using System.Data.SQLite;
using System.Windows.Forms;
using tarif;

namespace tarif
{
    public partial class TarifSilForm : Form
    {
        private DatabaseHelper dbHelper;
        private int tarifID;

        public TarifSilForm(DatabaseHelper dbHelper, int tarifID)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.tarifID = tarifID;

            // seçilen tarifin bilgilerini getir
            LoadTarifDetails();
        }

        
        private void LoadTarifDetails() // seçilen tarifin bilgilerini getir fonk
        {
            using (var conn = dbHelper.OpenConnection())
            {
                string query = "SELECT TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler WHERE TarifID = @TarifID"; // Tablo ismi düzeltildi
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TarifID", tarifID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTarifAdi.Text = reader["TarifAdi"].ToString();
                            txtKategori.Text = reader["Kategori"].ToString();
                            txtHazirlamaSuresi.Text = reader["HazirlamaSuresi"].ToString();
                            txtTalimatlar.Text = reader["Talimatlar"].ToString();
                        }
                    }
                }
            }
        }



        
        private void btnTarifiSil_Click(object sender, EventArgs e)
        {
            // onay?
            var confirmResult = MessageBox.Show("Bu tarifi silmek istediğinizden emin misiniz?",
                                                "Tarifi Sil",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SilTarif();
            }
        }

       
        private void SilTarif()  // db'den tarifi sil
        {
            using (var conn = dbHelper.OpenConnection())
            {
                string query = "DELETE FROM Tarifler WHERE TarifID = @TarifID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TarifID", tarifID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tarif başarıyla silindi!");
                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tarif silinirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
