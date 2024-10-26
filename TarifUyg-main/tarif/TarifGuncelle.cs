using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SQLite;

namespace tarif
{
    public partial class TarifGuncelle : Form
    {

        private DatabaseHelper dbHelper;
        private int tarifID;
        private Form1 anaForm;

        // seçileni al
        public TarifGuncelle(DatabaseHelper dbHelper, int tarifID, Form1 anaForm)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.tarifID = tarifID;
            this.anaForm = anaForm; 

            LoadTarifDetails();
        }

        private void LoadTarifDetails()
        {
            using (var conn = dbHelper.OpenConnection())
            {
                string query = "SELECT TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler WHERE TarifID = @TarifID";
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

        private void AramaFormu_Load(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string tarifAdi = txtTarifAdi.Text;
            string kategori = txtKategori.Text;
            int hazirlamaSuresi;
            string talimatlar = txtTalimatlar.Text;

            if (!int.TryParse(txtHazirlamaSuresi.Text, out hazirlamaSuresi))
            {
                MessageBox.Show("Lütfen geçerli bir hazırlama süresi girin.");
                return;
            }

            using (var conn = dbHelper.OpenConnection())
            {
                string query = "UPDATE Tarifler SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar WHERE TarifID = @TarifID";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                    cmd.Parameters.AddWithValue("@Kategori", kategori);
                    cmd.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                    cmd.Parameters.AddWithValue("@Talimatlar", talimatlar);
                    cmd.Parameters.AddWithValue("@TarifID", tarifID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tarif başarıyla güncellendi!");

                        // ana formdaki tarifi güncelle
                        anaForm.ListeleTarifler(); 

                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tarif güncellenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        
        private void txtTalimatlar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
