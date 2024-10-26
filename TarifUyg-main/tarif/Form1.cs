using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TarifRehberi;

namespace tarif
{
    public partial class Form1 : Form
    {


        private DatabaseHelper _dbHelper;

        private void InitializeListViewColumns() // tablo için kolonlar
        {
            lstTarifler.Columns.Clear();

            lstTarifler.Columns.Add("Tarif ID", 100);            // Tarif ID
            lstTarifler.Columns.Add("Tarif Adı", 150);            // Tarif Adı 
            lstTarifler.Columns.Add("Kategori", 120);             // Kategori 
            lstTarifler.Columns.Add("Hazırlama Süresi", 120);     // Hazırlama Süresi 
            lstTarifler.Columns.Add("Talimatlar", 200);           // Talimatlar 
            lstTarifler.Columns.Add("Toplam Maliyet", 120);       // Toplam Maliyet 

            // Malzemeler için 5 adet dinamik sütun oluştur
            //for (int i = 1; i <= 5; i++)
            //{
            //    lstTarifler.Columns.Add($"Malzeme {i} Adı", 150); // Malzeme adı sütunu
            //    lstTarifler.Columns.Add($"Malzeme {i} Fiyatı", 100); // Malzeme birim fiyatı
            //    lstTarifler.Columns.Add($"Malzeme {i} Miktarı", 120); // Malzeme toplam maliyet sütunu
            //    lstTarifler.Columns.Add($"Malzeme {i} Toplam Fiyat", 120); // Malzeme toplam maliyet sütunu
            //}
        }



        public Form1(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;

            InitializeListViewColumns();

            // tabloları oluştur
            // _dbHelper.CreateTables();

            // tabloları yeniden oluştur
            _dbHelper.ClearAndRecreateTables();

            // db den tarif ve malzemeleri ekle
            _dbHelper.InsertRealRecipesWithIngredients();



            ListeleTarifler(); // tarifleri tabloya doldur
            MalzemeleriYukle(); // malzemeleri getir
            KategorileriYukle(); // comboboxa kategorileri yükle

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }



        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            // tarif ekleme formunu aç
            TarifEkle ekleForm = new TarifEkle(_dbHelper); // dbHelper yerine _dbHelper
            ekleForm.Show();

        }


        public void ListeleTarifler() // tarifleri tabloya doldur fonk
        {
            string query = @"
    SELECT t.TarifID, t.TarifAdi, t.Kategori, t.HazirlamaSuresi, t.Talimatlar, 
           (SELECT SUM(CASE 
                WHEN m.MalzemeBirim = 'kg' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                WHEN m.MalzemeBirim = 'adet' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                WHEN m.MalzemeBirim = 'su bardağı' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                WHEN m.MalzemeBirim = 'yemek kaşığı' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                ELSE 0
            END)
            FROM TarifMalzemeler tm
            JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = t.TarifID) AS ToplamMaliyet
    FROM Tarifler t
    ORDER BY t.TarifID";  

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear();

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());
                            item.SubItems.Add(reader["TarifAdi"].ToString());
                            item.SubItems.Add(reader["Kategori"].ToString());
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString());
                            item.SubItems.Add(reader["Talimatlar"].ToString());

                            decimal toplamMaliyet = reader["ToplamMaliyet"] != DBNull.Value ? Convert.ToDecimal(reader["ToplamMaliyet"]) : 0;
                            item.SubItems.Add(toplamMaliyet.ToString("0.##") + " TL");

                            item.Tag = reader["TarifID"]; // TarifID'yi Tag olarak ayarlıyoruz
                            lstTarifler.Items.Add(item);
                        }

                    }
                }
            }
        }


        private void MalzemeleriYukle() // malzemeler fonk
        {
            using (var conn = _dbHelper.OpenConnection())
            {
                string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        cmbMalzemeler.Items.Clear(); 
                        cmbMalzemeler.Items.Add(new KeyValuePair<int, string>(0, "Tüm Tarifler")); 

                        Dictionary<int, string> malzemelerDict = new Dictionary<int, string>(); // malzemeler burda tutulacak

                        while (reader.Read())
                        {
                            // MalzemeID = Value - MalzemeAdi = Text 
                            malzemelerDict.Add(Convert.ToInt32(reader["MalzemeID"]), reader["MalzemeAdi"].ToString());
                        }

                        foreach (var malzeme in malzemelerDict)
                        {
                            cmbMalzemeler.Items.Add(new KeyValuePair<int, string>(malzeme.Key, malzeme.Value));
                        }

                        cmbMalzemeler.DisplayMember = "Value"; // MalzemeAdi
                        cmbMalzemeler.ValueMember = "Key";     //  MalzemeID
                    }
                }
            }
        }






        private void btnTarifGuncelle_Click(object sender, EventArgs e)
        {
            int tarifID = 0;
            if (lstTarifler.SelectedItems.Count > 0)
            {
                if (lstTarifler.SelectedItems[0].Tag != null)
                {
                     tarifID = int.Parse(lstTarifler.SelectedItems[0].Tag.ToString());
                    // Proceed with your logic
                }
                else
                {
                    MessageBox.Show("Selected item's Tag is null.");
                }


                // ana formu güncelleme formuna (AramaFormu) gönder
                TarifGuncelle guncelleForm = new TarifGuncelle(_dbHelper, tarifID, this);
                guncelleForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir tarif seçin.");
            }
        }




        private void txtTalimatlar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHazirlamaSuresi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKategori_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTarifAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTarifSil_Click_1(object sender, EventArgs e)
        {
            if (lstTarifler.SelectedItems.Count > 0)
            {
                // seçilen id
                var tarifID = int.Parse(lstTarifler.SelectedItems[0].Tag.ToString());

                // tarif silme Formunu aç ve id gönder 
                TarifSilForm silForm = new TarifSilForm(_dbHelper, tarifID);
                silForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir tarif seçin.");
            }
        }

        private void TarifAdi_TextChanged(object sender, EventArgs e) // tarife göre filtrele
        {
            string aramaMetni = txtTarifAdi.Text;

            if (string.IsNullOrWhiteSpace(aramaMetni))
            {
                ListeleTarifler(); 
            }
            else
            {
                AramaTarifAdi(aramaMetni); // Tarif adına göre filtre 
            }
        }


        private void AramaTarifAdi(string tarifAdi) // tarife göre filtrele fonk
        {
            string query = "SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler WHERE TarifAdi LIKE @TarifAdi";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TarifAdi", "%" + tarifAdi + "%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                            item.SubItems.Add(reader["TarifAdi"].ToString());
                            item.SubItems.Add(reader["Kategori"].ToString());
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString());
                            item.SubItems.Add(reader["Talimatlar"].ToString()); 

                            item.Tag = reader["TarifID"].ToString();

                            lstTarifler.Items.Add(item);
                        }
                    }
                }
            }
        }



        private void btnMalzemeAra_Click(object sender, EventArgs e)
        {
           
        }


        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            
        }

        

        private void cmbMalzemeler_SelectedIndexChanged(object sender, EventArgs e) // malzemeye göre filtrele
        {
            if (cmbMalzemeler.SelectedItem != null)
            {
                var selectedMalzeme = (KeyValuePair<int, string>)cmbMalzemeler.SelectedItem;

                if (selectedMalzeme.Key == 0)
                {
                    ListeleTarifler();
                }
                else
                {
                    //  malzemenin adını talimatlarda ara - tarifleri filtrele
                    AramaTalimatlarIleMalzemeyeGore(selectedMalzeme.Value);
                }
            }
        }

        private void AramaTalimatlarIleMalzemeyeGore(string malzemeAdi) // malzemeye göre filtrele fonk
        {
            string query = @"
    SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar
    FROM Tarifler
    WHERE Talimatlar LIKE @MalzemeAdi"; 

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MalzemeAdi", "%" + malzemeAdi + "%"); // malzeme adı

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                            item.SubItems.Add(reader["TarifAdi"].ToString()); 
                            item.SubItems.Add(reader["Kategori"].ToString()); 
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString()); 
                            item.SubItems.Add(reader["Talimatlar"].ToString()); 

                            item.Tag = reader["TarifID"].ToString();

                            lstTarifler.Items.Add(item);
                        }
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // kategoriye göre filtrele
        {
            if (cmbKategori.SelectedItem != null)
            {
                string selectedKategori = cmbKategori.SelectedItem.ToString();

                if (selectedKategori == "Tüm Kategoriler")
                {
                    ListeleTarifler();
                }
                else
                {
                    //  kategoriye göre tarifleri filtrele
                    AramaKategoriIleTarifler(selectedKategori);
                }
            }
        }

        private void KategorileriYukle() // comboboxa kategorileri yükle fonk
        {
            using (var conn = _dbHelper.OpenConnection())
            {
                string query = "SELECT DISTINCT Kategori FROM Tarifler"; 

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        cmbKategori.Items.Clear(); 
                        cmbKategori.Items.Add("Tüm Kategoriler"); 

                        while (reader.Read())
                        {
                            cmbKategori.Items.Add(reader["Kategori"].ToString()); // comboboxa kategorileri ekle
                        }
                    }
                }
            }
        }


        private void AramaKategoriIleTarifler(string kategori) // kategoriye göre filtrele fonk
        {
            string query = "SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler WHERE Kategori = @Kategori";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Kategori", kategori);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                            item.SubItems.Add(reader["TarifAdi"].ToString()); 
                            item.SubItems.Add(reader["Kategori"].ToString());
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString()); 
                            item.SubItems.Add(reader["Talimatlar"].ToString()); 

                            item.Tag = reader["TarifID"].ToString();

                            lstTarifler.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void numHazirlamaSuresi_ValueChanged(object sender, EventArgs e) // hazirlama süresine göre filtrele
        {
            int hazirlamaSuresi = (int)numHazirlamaSuresi.Value;

            if (hazirlamaSuresi == 0)  // numericupdown boş değer alamadığı için 0 ise tümü gelsin
            {
                // Eğer 0 veya boşsa tüm tarifler
                ListeleTarifler();
            }
            else
            {
                // hazırlama süresine göre filtrele
                FiltreleHazirlamaSuresineGore(hazirlamaSuresi);
            }
        }

        private void FiltreleHazirlamaSuresineGore(int hazirlamaSuresi) // hazirlama süresine göre filtrele fonk
        {
            string query = "SELECT TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM Tarifler WHERE HazirlamaSuresi = @HazirlamaSuresi";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                            // Diğer sütunları sırasıyla ekleyelim
                            item.SubItems.Add(reader["TarifAdi"].ToString()); 
                            item.SubItems.Add(reader["Kategori"].ToString());
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString()); 
                            item.SubItems.Add(reader["Talimatlar"].ToString());

                            item.Tag = reader["TarifID"].ToString();

                            lstTarifler.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void numMaliyet_ValueChanged(object sender, EventArgs e)
        {
            decimal maliyet = numMaliyet.Value;

            if (maliyet == 0)  //  maliyet sıfırsa tüm tarifleri glesin
            {
                ListeleTarifler();
            }
        }

        private void numMaliyet2_ValueChanged(object sender, EventArgs e)
        {
            decimal maliyet = numMaliyet.Value;

            if (maliyet == 0)  //  maliyet sıfırsa tüm tarifleri glesin
            {
                ListeleTarifler();
            }
        }


        private void FiltreleMaliyeteGoreSiralama(string orderBy) // Artan azalan sıralama
        {
            string query = $@"
    SELECT t.TarifID, t.TarifAdi, t.Kategori, t.HazirlamaSuresi, t.Talimatlar, 
           (SELECT SUM(CASE 
                WHEN m.MalzemeBirim = 'kg' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                WHEN m.MalzemeBirim = 'adet' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                WHEN m.MalzemeBirim = 'su bardağı' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                WHEN m.MalzemeBirim = 'yemek kaşığı' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                ELSE 0
            END)
            FROM TarifMalzemeler tm
            JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = t.TarifID) AS ToplamMaliyet
    FROM Tarifler t
    ORDER BY ToplamMaliyet {orderBy}";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                            item.SubItems.Add(reader["TarifAdi"].ToString());
                            item.SubItems.Add(reader["Kategori"].ToString()); 
                            item.SubItems.Add(reader["HazirlamaSuresi"].ToString()); 
                            item.SubItems.Add(reader["Talimatlar"].ToString()); 
                            item.SubItems.Add(reader["ToplamMaliyet"].ToString()); 

                            item.Tag = reader["TarifID"].ToString();

                            lstTarifler.Items.Add(item);
                        }
                    }
                }
            }
        }



        public void FiltreleMaliyetAraligiGore(decimal maliyetMin, decimal maliyetMax) // arasında maliyet
        {
            string query = @"
    SELECT t.TarifID, t.TarifAdi, t.Kategori, t.HazirlamaSuresi, t.Talimatlar, 
           (SELECT SUM(CASE 
                WHEN m.MalzemeBirim = 'kg' THEN (m.BirimFiyat * tm.MalzemeMiktar) 
                WHEN m.MalzemeBirim = 'adet' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                WHEN m.MalzemeBirim = 'su bardağı' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                WHEN m.MalzemeBirim = 'yemek kaşığı' THEN (m.BirimFiyat * tm.MalzemeMiktar)
                ELSE 0
            END)
            FROM TarifMalzemeler tm
            JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = t.TarifID) AS ToplamMaliyet
    FROM Tarifler t
    ORDER BY t.TarifID";

            using (var conn = _dbHelper.OpenConnection())
            {
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        lstTarifler.Items.Clear(); 

                        while (reader.Read())
                        {
                            decimal toplamMaliyet = 0;
                            if (!reader.IsDBNull(reader.GetOrdinal("ToplamMaliyet")))
                            {
                                toplamMaliyet = Convert.ToDecimal(reader["ToplamMaliyet"]);
                            }

                            if (toplamMaliyet >= maliyetMin && toplamMaliyet <= maliyetMax)
                            {
                                ListViewItem item = new ListViewItem(reader["TarifID"].ToString());

                                item.SubItems.Add(reader["TarifAdi"].ToString());
                                item.SubItems.Add(reader["Kategori"].ToString());
                                item.SubItems.Add(reader["HazirlamaSuresi"].ToString()); 
                                item.SubItems.Add(reader["Talimatlar"].ToString());
                                item.SubItems.Add(toplamMaliyet.ToString());

                                item.Tag = reader["TarifID"].ToString();

                                lstTarifler.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }


        private void btnMalzemeler_Click(object sender, EventArgs e)
        {
            // malzemeler formunu aç
            Malzemeler malzemeForm = new Malzemeler(_dbHelper);
            malzemeForm.Show();
        }

        private void btnArtan_Click(object sender, EventArgs e) // artan sıralama
        {
            decimal minMaliyet = numMaliyet.Value;
            FiltreleMaliyeteGoreSiralama("ASC");  // Artan sıralama
        }

        private void btnAzalan_Click(object sender, EventArgs e) // azalan sıralama
        {
            decimal minMaliyet = numMaliyet.Value;
            FiltreleMaliyeteGoreSiralama("DESC");  // Azalan sıralama
        }

        private void btnArasında_Click(object sender, EventArgs e) // arasında sıralama
        {
            decimal maliyetMin = numMaliyet.Value;
            decimal maliyetMax = numMaliyet2.Value;

            FiltreleMaliyetAraligiGore(maliyetMin, maliyetMax);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
