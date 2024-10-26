using System;
using System.Data.SQLite;
using System.Windows.Forms;
using tarif;

namespace TarifRehberi
{
    public partial class TarifEkle : Form
    {

        private DatabaseHelper _dbHelper; 

        public TarifEkle(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper; 
        }


        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            // girilen değerler
            string tarifAdi = txtTarifAdi.Text;
            string kategori = txtKategori.Text;
            int hazirlamaSuresi = int.Parse(txtHazirlamaSuresi.Text);
            string talimatlar = txtTalimatlar.Text;

            // tarif ekle
            using (var conn = _dbHelper.OpenConnection()) 
            {
                string query = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                    cmd.Parameters.AddWithValue("@Kategori", kategori);
                    cmd.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                    cmd.Parameters.AddWithValue("@Talimatlar", talimatlar);

                    try
                    {
                        cmd.ExecuteNonQuery(); 
                        MessageBox.Show("Tarif başarıyla eklendi!");
                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tarif eklenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void txtTarifAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
