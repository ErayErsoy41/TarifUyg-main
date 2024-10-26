using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace tarif
{
    public class DatabaseHelper
    {
        private string _connectionString;

        public DatabaseHelper(string dbFilePath)
        {
            // SQLite için bağlantı dizesi 
            _connectionString = $"Data Source={dbFilePath};Version=3;";
        }

        // SQLite veritabanı ile bağlantı aç
        public SQLiteConnection OpenConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }

        // veritabanı üzerinde SELECT sorgusu çalıştır
        public SQLiteDataReader ExecuteQuery(string query)
        {
            var connection = OpenConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            return command.ExecuteReader();
        }

        // veritabanında veri ekleme, güncelleme, silme işlemleri 
        public int ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            using (var connection = OpenConnection())
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }


        public void CreateTables() // tabloları oluştur
        {
            using (var conn = OpenConnection())
            {
                string createTariflerTable = @"
                CREATE TABLE IF NOT EXISTS Tarifler (
                    TarifID INTEGER PRIMARY KEY AUTOINCREMENT,
                    TarifAdi TEXT NOT NULL,
                    Kategori TEXT NOT NULL,
                    HazirlamaSuresi INTEGER NOT NULL,
                    Talimatlar TEXT NOT NULL
                );";

                string createMalzemelerTable = @"
                CREATE TABLE IF NOT EXISTS Malzemeler (
                    MalzemeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    MalzemeAdi TEXT NOT NULL,
                    ToplamMiktar INTEGER,
                    MalzemeBirim TEXT NOT NULL,
                    BirimFiyat REAL
                );";

                string createTarifMalzemelerTable = @"
                CREATE TABLE IF NOT EXISTS TarifMalzemeler (
                    TarifID INTEGER,
                    MalzemeID INTEGER,
                    MalzemeMiktar REAL,
                    FOREIGN KEY (TarifID) REFERENCES Tarifler(TarifID),
                    FOREIGN KEY (MalzemeID) REFERENCES Malzemeler(MalzemeID),
                    PRIMARY KEY (TarifID, MalzemeID)
            ); ";

                using (SQLiteCommand cmd = new SQLiteCommand(createTariflerTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createMalzemelerTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(createTarifMalzemelerTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Tablolar başarıyla oluşturuldu.");
            }
        }




        public void ClearAndRecreateTables() // önce tabloları boşalt sonra CreateTables ile doldur
        {
            using (var conn = OpenConnection())
            {
                // Önce mevcut tabloları sil
                string dropTarifler = "DROP TABLE IF EXISTS Tarifler";
                string dropMalzemeler = "DROP TABLE IF EXISTS Malzemeler";
                string dropTarifMalzemeler = "DROP TABLE IF EXISTS TarifMalzemeler";

                using (var cmd = new SQLiteCommand(dropTarifler, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand(dropMalzemeler, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand(dropTarifMalzemeler, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Tabloları yeniden oluştur
                CreateTables();
            }
        }




        public void InsertRealRecipesWithIngredients() // tarifler ve malzemeler
        {
            using (var conn = OpenConnection())
            {
                // kategoriler ve tarifler
                string[] kategoriler = { "Çorbalar", "Ana Yemekler", "Salatalar", "Tatlılar", "Aperatifler" };

                // id
                var tarifler = new List<(int, string, string, int, string)>
        {
            // Çorbalar
            (1, "Mercimek Çorbası", "Çorbalar", 30, "2 su bardağı kırmızı mercimek, 1 adet soğan, 1 yemek kaşığı tuz, 5 su bardağı su"),
            (2, "Ezogelin Çorbası", "Çorbalar", 40, "1 su bardağı bulgur, 1 su bardağı kırmızı mercimek, 1 adet soğan, 1 yemek kaşığı biber salçası"),
            (3, "Domates Çorbası", "Çorbalar", 20, "4 adet domates, 2 yemek kaşığı un, 2 su bardağı su, 1 yemek kaşığı tereyağı"),
            (4, "İşkembe Çorbası", "Çorbalar", 50, "5 adet işkembe, 4 baş sarımsak, 2 yemek kaşığı sirke, 1 adet limon"),
            (5, "Tavuk Çorbası", "Çorbalar", 25, "1 adet tavuk göğsü, 1 adet havuç, 1 adet soğan, 5 su bardağı su"),
            (6, "Sebze Çorbası", "Çorbalar", 35, "2 adet patates, 1 adet havuç, 1 adet kabak, 1 yemek kaşığı tuz"),
            (7, "Tarhana Çorbası", "Çorbalar", 45, "5 yemek kaşığı tarhana, 1 yemek kaşığı biber salçası, 4 su bardağı su"),
            (8, "Mantar Çorbası", "Çorbalar", 30, "10 adet mantar, 2 yemek kaşığı un, 1 yemek kaşığı tereyağı, 1 su bardağı süt"),
            (9, "Şehriye Çorbası", "Çorbalar", 20, "1 su bardağı şehriye, 2 su bardağı et suyu, 1 yemek kaşığı tereyağı"),
            (10, "Balık Çorbası", "Çorbalar", 40, "1 adet levrek, 1 adet soğan, 1 adet patates, 5 su bardağı su"),

            // Ana Yemekler
            (11, "Karnıyarık", "Ana Yemekler", 60, "5 adet patlıcan, 2 su bardağı kıyma, 1 adet domates, 1 yemek kaşığı biber salçası"),
            (12, "Mantı", "Ana Yemekler", 90, "2 su bardağı un, 2 su bardağı kıyma, 1 adet soğan, 1 yemek kaşığı tereyağı"),
            (13, "Tavuk Sote", "Ana Yemekler", 30, "2 adet tavuk göğsü, 1 adet biber, 1 adet domates, 1 yemek kaşığı tuz"),
            (14, "Lahmacun", "Ana Yemekler", 45, "2 su bardağı kıyma, 2 adet domates, 1 adet soğan, 1 yemek kaşığı biber salçası"),
            (15, "İmam Bayıldı", "Ana Yemekler", 50, "4 adet patlıcan, 1 adet soğan, 2 adet domates, 1 yemek kaşığı zeytinyağı"),
            (16, "Pilav", "Ana Yemekler", 20, "2 su bardağı pirinç, 3 su bardağı su, 1 yemek kaşığı tereyağı, 1 yemek kaşığı tuz"),
            (17, "Kuru Fasulye", "Ana Yemekler", 45, "2 su bardağı kuru fasulye, 1 adet soğan, 1 yemek kaşığı domates salçası"),
            (18, "Etli Nohut", "Ana Yemekler", 50, "2 su bardağı et, 2 su bardağı nohut, 1 adet soğan, 1 yemek kaşığı domates salçası"),
            (19, "Dolma", "Ana Yemekler", 70, "4 adet dolmalık biber, 2 su bardağı kıyma, 1 su bardağı pirinç, 1 adet domates"),
            (20, "Köfte", "Ana Yemekler", 30, "2 su bardağı kıyma, 1 adet soğan, 2 adet bayat ekmek, 1 yemek kaşığı kimyon"),

            // Tatlılar
            (21, "Baklava", "Tatlılar", 120, "1 su bardağı baklavalık yufka, 2 su bardağı ceviz içi, 2 su bardağı şeker, 3 su bardağı su"),
            (22, "Sütlaç", "Tatlılar", 40, "1 litre süt, 1 su bardağı pirinç, 1 su bardağı şeker, 1 paket vanilin"),
            (23, "Kazandibi", "Tatlılar", 45, "1 litre süt, 2 yemek kaşığı un, 2 yemek kaşığı nişasta, 1 su bardağı şeker"),
            (24, "Aşure", "Tatlılar", 90, "2 su bardağı buğday, 1 su bardağı nohut, 1 su bardağı kuru fasulye, 2 su bardağı şeker"),
            (25, "Şekerpare", "Tatlılar", 60, "2 su bardağı un, 1 su bardağı irmik, 1 su bardağı şeker, 1 adet yumurta"),
            (26, "Revani", "Tatlılar", 50, "2 su bardağı irmik, 1 su bardağı şeker, 3 adet yumurta, 1 su bardağı yoğurt"),
            (27, "Künefe", "Tatlılar", 40, "2 su bardağı kadayıf, 1 su bardağı tereyağı, 2 su bardağı şeker"),
            (28, "Muhallebi", "Tatlılar", 30, "1 litre süt, 2 yemek kaşığı un, 1 yemek kaşığı nişasta, 1 su bardağı şeker"),
            (29, "Puding", "Tatlılar", 20, "1 litre süt, 2 yemek kaşığı kakao, 1 su bardağı şeker, 2 yemek kaşığı un"),
            (30, "Güllaç", "Tatlılar", 60, "1 su bardağı güllaç, 2 litre süt, 2 su bardağı şeker, 1 su bardağı ceviz içi"),

            // Aperatifler
            (31, "Patates Kızartması", "Aperatifler", 20, "4 adet patates, 1 su bardağı sıvı yağ, 1 yemek kaşığı tuz"),
            (32, "Sigara Böreği", "Aperatifler", 30, "10 adet yufka, 2 su bardağı beyaz peynir, 1 su bardağı sıvı yağ"),
            (33, "Cips", "Aperatifler", 15, "3 adet patates, 1 yemek kaşığı kırmızı biber, 1 yemek kaşığı tuz"),
            (34, "Sosisli Sandviç", "Aperatifler", 10, "2 adet sosis, 2 adet sandviç ekmeği, 1 yemek kaşığı ketçap"),
            (35, "Pizza", "Aperatifler", 40, "2 su bardağı un, 1 su bardağı su, 2 su bardağı kaşar peyniri, 1 su bardağı domates sosu"),
            (36, "Çiğ Köfte", "Aperatifler", 50, "3 su bardağı ince bulgur, 2 yemek kaşığı biber salçası, 1 yemek kaşığı isot"),
            (37, "Mısır Patlağı", "Aperatifler", 15, "1 su bardağı mısır, 2 yemek kaşığı sıvı yağ, 1 yemek kaşığı tuz"),
            (38, "Tavuk Kanadı", "Aperatifler", 25, "2 adet tavuk kanadı, 1 yemek kaşığı zeytinyağı, 1 yemek kaşığı tuz"),
            (39, "Lavaş", "Aperatifler", 30, "2 su bardağı un, 1 su bardağı su, 1 yemek kaşığı tuz"),
            (40, "Dürüm", "Aperatifler", 20, "2 adet lavaş, 2 su bardağı kıyma, 1 adet domates, 1 yemek kaşığı biber salçası")
        };

                // malzemeler için manuel ID, malzeme adları, miktarlar, birim ve fiyatlar
                var malzemeler = new List<(int, string, float, string, float)>
        {
            (1, "Kırmızı Mercimek", 2.0f, "su bardağı", 20.0f),
            (2, "Soğan", 10.0f, "adet", 5.0f),
            (3, "Tuz", 1.0f, "kg", 3.0f),
            (4, "Su", 10.0f, "su bardağı", 0.5f),
            (5, "Bulgur", 1.0f, "su bardağı", 15.0f),
            (6, "Biber Salçası", 1.0f, "yemek kaşığı", 30.0f),
            (7, "Domates", 10.0f, "adet", 7.0f),
            (8, "Un", 2.0f, "yemek kaşığı", 12.0f),
            (9, "Tereyağı", 1.0f, "yemek kaşığı", 45.0f),
            (10, "İşkembe", 5.0f, "adet", 50.0f),
            (11, "Sarımsak", 4.0f, "baş", 4.0f),
            (12, "Sirke", 2.0f, "yemek kaşığı", 12.0f),
            (13, "Limon", 5.0f, "adet", 2.0f),
            (14, "Tavuk Göğsü", 2.0f, "adet", 40.0f),
            (15, "Havuç", 5.0f, "adet", 4.0f),
            (16, "Patates", 5.0f, "adet", 6.0f),
            (17, "Kabak", 2.0f, "adet", 6.0f),
            (18, "Mantar", 10.0f, "adet", 25.0f),
            (19, "Şehriye", 1.0f, "su bardağı", 10.0f),
            (20, "Levrek", 1.0f, "adet", 50.0f),
            (21, "Patlıcan", 5.0f, "adet", 8.0f),
            (22, "Kıyma", 2.0f, "su bardağı", 60.0f),
            (23, "Pirinç", 2.0f, "su bardağı", 10.0f),
            (24, "Kuru Fasulye", 2.0f, "su bardağı", 20.0f),
            (25, "Nohut", 2.0f, "su bardağı", 18.0f),
            (26, "Dolmalık Biber", 4.0f, "adet", 5.0f),
            (27, "Bayat Ekmek", 1.0f, "adet", 1.0f),
            (28, "Kimyon", 1.0f, "yemek kaşığı", 80.0f),
            (29, "Baklavalık Yufka", 1.0f, "su bardağı", 100.0f),
            (30, "Ceviz İçi", 2.0f, "su bardağı", 120.0f),
            (31, "Şeker", 10.0f, "su bardağı", 8.0f),
            (32, "Süt", 5.0f, "su bardağı", 12.0f),
            (33, "Nişasta", 2.0f, "yemek kaşığı", 15.0f),
            (34, "Buğday", 2.0f, "su bardağı", 9.0f),
            (35, "İrmik", 2.0f, "su bardağı", 6.0f),
            (36, "Kadayıf", 2.0f, "su bardağı", 70.0f),
            (37, "Peynir", 2.0f, "su bardağı", 80.0f),
            (38, "Mısır", 1.0f, "su bardağı", 7.0f),
            (39, "Kaşar Peyniri", 2.0f, "su bardağı", 60.0f)
        };

                // malzemeler
                foreach (var malzeme in malzemeler)
                {
                    string queryMalzeme = "INSERT INTO Malzemeler ( MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES ( @MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";
                    using (var cmd = new SQLiteCommand(queryMalzeme, conn))
                    {
                        cmd.Parameters.AddWithValue("@MalzemeAdi", malzeme.Item2);
                        cmd.Parameters.AddWithValue("@ToplamMiktar", malzeme.Item3);
                        cmd.Parameters.AddWithValue("@MalzemeBirim", malzeme.Item4);
                        cmd.Parameters.AddWithValue("@BirimFiyat", malzeme.Item5);
                        cmd.ExecuteNonQuery();
                    }
                }

                // tarifler
                foreach (var tarif in tarifler)
                {
                    string queryTarif = "INSERT INTO Tarifler ( TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) VALUES ( @TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar)";
                    using (var cmd = new SQLiteCommand(queryTarif, conn))
                    {
                        cmd.Parameters.AddWithValue("@TarifAdi", tarif.Item2);
                        cmd.Parameters.AddWithValue("@Kategori", tarif.Item3);
                        cmd.Parameters.AddWithValue("@HazirlamaSuresi", tarif.Item4);
                        cmd.Parameters.AddWithValue("@Talimatlar", tarif.Item5);
                        cmd.ExecuteNonQuery();
                    }

                    // tariflerde geçen malzemeleri bul ve tarif-malzeme ilişkisi kur
                    foreach (var malzeme in malzemeler)
                    {
                        if (tarif.Item5.Contains(malzeme.Item2))  // eğer talimatlar içinde malzeme adı geçiyorsa
                        {
                            string queryTarifMalzeme = "INSERT INTO TarifMalzemeler ( MalzemeMiktar) VALUES ( @MalzemeMiktar)";
                            using (var cmdTarifMalzeme = new SQLiteCommand(queryTarifMalzeme, conn))
                            {
                                cmdTarifMalzeme.Parameters.AddWithValue("@MalzemeMiktar", malzeme.Item3);
                                cmdTarifMalzeme.ExecuteNonQuery();
                            }
                        }
                    }
                }
                Console.WriteLine("Tarifler ve malzemeler başarıyla eklendi.");
                AnalyzeAndInsertTarifMalzemeler();
            }
        }






        // tariflerin talimatlarında malzemeleri bul, TarifMalzemeler tablosuna ekle
        public void AnalyzeAndInsertTarifMalzemeler()
        {
            using (var conn = OpenConnection())
            {
                Dictionary<string, int> malzemeDict = new Dictionary<string, int>();

                string malzemeQuery = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";
                using (var cmdMalzeme = new SQLiteCommand(malzemeQuery, conn))
                {
                    using (SQLiteDataReader reader = cmdMalzeme.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            malzemeDict.Add(reader["MalzemeAdi"].ToString().ToLower(), Convert.ToInt32(reader["MalzemeID"]));
                        }
                    }
                }

                string tarifQuery = "SELECT TarifID, Talimatlar FROM Tarifler";
                using (var cmdTarif = new SQLiteCommand(tarifQuery, conn))
                {
                    using (SQLiteDataReader readerTarif = cmdTarif.ExecuteReader())
                    {
                        while (readerTarif.Read())
                        {
                            int tarifID = Convert.ToInt32(readerTarif["TarifID"]);
                            string talimatlar = readerTarif["Talimatlar"].ToString().ToLower();

                            foreach (var malzeme in malzemeDict)
                            {
                                if (talimatlar.Contains(malzeme.Key))
                                {
                                    float miktar = ExtractMiktar(talimatlar, malzeme.Key);

                                    if (miktar > 0)
                                    {
                                        string insertQuery = "INSERT INTO TarifMalzemeler (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";
                                        using (var cmdInsert = new SQLiteCommand(insertQuery, conn))
                                        {
                                            cmdInsert.Parameters.AddWithValue("@TarifID", tarifID);
                                            cmdInsert.Parameters.AddWithValue("@MalzemeID", malzeme.Value);
                                            cmdInsert.Parameters.AddWithValue("@MalzemeMiktar", miktar);
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private float ExtractMiktar(string talimatlar, string malzemeAdi)
        {
            string pattern = $@"(\d+(\.\d+)?)\s*(kg|su bardağı|adet|yemek kaşığı)\s*{malzemeAdi}";
            Match match = Regex.Match(talimatlar, pattern);

            if (match.Success)
            {
                return float.Parse(match.Groups[1].Value);
            }

            return 0;
        }








    }
}
