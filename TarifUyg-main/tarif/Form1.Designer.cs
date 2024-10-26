namespace tarif
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTarifEkle = new System.Windows.Forms.Button();
            this.btnTarifGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.lstTarifler = new System.Windows.Forms.ListView();
            this.TarifID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TarifAdı = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HazirlamaSuresi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Talimatlar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTarifSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMalzemeler = new System.Windows.Forms.ComboBox();
            this.numHazirlamaSuresi = new System.Windows.Forms.NumericUpDown();
            this.numMaliyet = new System.Windows.Forms.NumericUpDown();
            this.btnMalzemeler = new System.Windows.Forms.Button();
            this.btnArtan = new System.Windows.Forms.Button();
            this.numMaliyet2 = new System.Windows.Forms.NumericUpDown();
            this.btnAzalan = new System.Windows.Forms.Button();
            this.btnArasında = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numHazirlamaSuresi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnTarifEkle
            // 
            this.btnTarifEkle.Location = new System.Drawing.Point(95, 514);
            this.btnTarifEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarifEkle.Name = "btnTarifEkle";
            this.btnTarifEkle.Size = new System.Drawing.Size(285, 28);
            this.btnTarifEkle.TabIndex = 5;
            this.btnTarifEkle.Text = "Tarif Ekle Ekranına Git";
            this.btnTarifEkle.UseVisualStyleBackColor = true;
            this.btnTarifEkle.Click += new System.EventHandler(this.btnTarifEkle_Click);
            // 
            // btnTarifGuncelle
            // 
            this.btnTarifGuncelle.Location = new System.Drawing.Point(428, 514);
            this.btnTarifGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarifGuncelle.Name = "btnTarifGuncelle";
            this.btnTarifGuncelle.Size = new System.Drawing.Size(285, 28);
            this.btnTarifGuncelle.TabIndex = 6;
            this.btnTarifGuncelle.Text = "Tarif Güncelleme Ekranına Git";
            this.btnTarifGuncelle.Click += new System.EventHandler(this.btnTarifGuncelle_Click);
            // 
            // lstTarifler
            // 
            this.lstTarifler.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lstTarifler.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstTarifler.BackColor = System.Drawing.Color.Lavender;
            this.lstTarifler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TarifID,
            this.TarifAdı,
            this.Kategori,
            this.HazirlamaSuresi,
            this.Talimatlar});
            this.lstTarifler.ForeColor = System.Drawing.Color.Firebrick;
            this.lstTarifler.HideSelection = false;
            this.lstTarifler.HotTracking = true;
            this.lstTarifler.HoverSelection = true;
            this.lstTarifler.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lstTarifler.Location = new System.Drawing.Point(13, 142);
            this.lstTarifler.Margin = new System.Windows.Forms.Padding(4);
            this.lstTarifler.MultiSelect = false;
            this.lstTarifler.Name = "lstTarifler";
            this.lstTarifler.Size = new System.Drawing.Size(1032, 346);
            this.lstTarifler.TabIndex = 7;
            this.lstTarifler.UseCompatibleStateImageBehavior = false;
            this.lstTarifler.View = System.Windows.Forms.View.Details;
            // 
            // TarifID
            // 
            this.TarifID.Text = "Tarif ID";
            this.TarifID.Width = 49;
            // 
            // TarifAdı
            // 
            this.TarifAdı.Text = "Tarif Adı";
            this.TarifAdı.Width = 200;
            // 
            // Kategori
            // 
            this.Kategori.Text = "Kategori";
            this.Kategori.Width = 87;
            // 
            // HazirlamaSuresi
            // 
            this.HazirlamaSuresi.Text = "Hazırlama Süresi";
            this.HazirlamaSuresi.Width = 102;
            // 
            // Talimatlar
            // 
            this.Talimatlar.Text = "Talimatlar";
            this.Talimatlar.Width = 273;
            // 
            // btnTarifSil
            // 
            this.btnTarifSil.Location = new System.Drawing.Point(761, 514);
            this.btnTarifSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarifSil.Name = "btnTarifSil";
            this.btnTarifSil.Size = new System.Drawing.Size(285, 28);
            this.btnTarifSil.TabIndex = 8;
            this.btnTarifSil.Text = "Tarif Silme Ekranına Git";
            this.btnTarifSil.Click += new System.EventHandler(this.btnTarifSil_Click_1);
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.Location = new System.Drawing.Point(78, 112);
            this.txtTarifAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(256, 22);
            this.txtTarifAdi.TabIndex = 9;
            this.txtTarifAdi.TextChanged += new System.EventHandler(this.TarifAdi_TextChanged);
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(349, 108);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(111, 24);
            this.cmbKategori.TabIndex = 14;
            this.cmbKategori.Text = "Kategori Seç";
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 118);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 16);
            this.labelControl1.TabIndex = 17;
            // 
            // cmbMalzemeler
            // 
            this.cmbMalzemeler.FormattingEnabled = true;
            this.cmbMalzemeler.Location = new System.Drawing.Point(601, 110);
            this.cmbMalzemeler.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMalzemeler.Name = "cmbMalzemeler";
            this.cmbMalzemeler.Size = new System.Drawing.Size(195, 24);
            this.cmbMalzemeler.TabIndex = 18;
            this.cmbMalzemeler.Text = "Malzeme Seç";
            this.cmbMalzemeler.SelectedIndexChanged += new System.EventHandler(this.cmbMalzemeler_SelectedIndexChanged);
            // 
            // numHazirlamaSuresi
            // 
            this.numHazirlamaSuresi.Location = new System.Drawing.Point(468, 110);
            this.numHazirlamaSuresi.Margin = new System.Windows.Forms.Padding(4);
            this.numHazirlamaSuresi.Name = "numHazirlamaSuresi";
            this.numHazirlamaSuresi.Size = new System.Drawing.Size(125, 22);
            this.numHazirlamaSuresi.TabIndex = 19;
            this.numHazirlamaSuresi.ValueChanged += new System.EventHandler(this.numHazirlamaSuresi_ValueChanged);
            // 
            // numMaliyet
            // 
            this.numMaliyet.Location = new System.Drawing.Point(804, 42);
            this.numMaliyet.Margin = new System.Windows.Forms.Padding(4);
            this.numMaliyet.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numMaliyet.Name = "numMaliyet";
            this.numMaliyet.Size = new System.Drawing.Size(115, 22);
            this.numMaliyet.TabIndex = 20;
            this.numMaliyet.ValueChanged += new System.EventHandler(this.numMaliyet_ValueChanged);
            // 
            // btnMalzemeler
            // 
            this.btnMalzemeler.Location = new System.Drawing.Point(468, 567);
            this.btnMalzemeler.Margin = new System.Windows.Forms.Padding(4);
            this.btnMalzemeler.Name = "btnMalzemeler";
            this.btnMalzemeler.Size = new System.Drawing.Size(185, 28);
            this.btnMalzemeler.TabIndex = 21;
            this.btnMalzemeler.Text = "Malzeme Ekranına Git";
            this.btnMalzemeler.UseVisualStyleBackColor = true;
            this.btnMalzemeler.Click += new System.EventHandler(this.btnMalzemeler_Click);
            // 
            // btnArtan
            // 
            this.btnArtan.Location = new System.Drawing.Point(804, 108);
            this.btnArtan.Margin = new System.Windows.Forms.Padding(4);
            this.btnArtan.Name = "btnArtan";
            this.btnArtan.Size = new System.Drawing.Size(115, 28);
            this.btnArtan.TabIndex = 23;
            this.btnArtan.Text = "Artan Sıralama Yap";
            this.btnArtan.UseVisualStyleBackColor = true;
            this.btnArtan.Click += new System.EventHandler(this.btnArtan_Click);
            // 
            // numMaliyet2
            // 
            this.numMaliyet2.Location = new System.Drawing.Point(936, 42);
            this.numMaliyet2.Margin = new System.Windows.Forms.Padding(4);
            this.numMaliyet2.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numMaliyet2.Name = "numMaliyet2";
            this.numMaliyet2.Size = new System.Drawing.Size(121, 22);
            this.numMaliyet2.TabIndex = 24;
            this.numMaliyet2.ValueChanged += new System.EventHandler(this.numMaliyet2_ValueChanged);
            // 
            // btnAzalan
            // 
            this.btnAzalan.Location = new System.Drawing.Point(926, 108);
            this.btnAzalan.Margin = new System.Windows.Forms.Padding(4);
            this.btnAzalan.Name = "btnAzalan";
            this.btnAzalan.Size = new System.Drawing.Size(121, 28);
            this.btnAzalan.TabIndex = 25;
            this.btnAzalan.Text = "Azalan Sıralama Yap";
            this.btnAzalan.UseVisualStyleBackColor = true;
            this.btnAzalan.Click += new System.EventHandler(this.btnAzalan_Click);
            // 
            // btnArasında
            // 
            this.btnArasında.Location = new System.Drawing.Point(804, 72);
            this.btnArasında.Margin = new System.Windows.Forms.Padding(4);
            this.btnArasında.Name = "btnArasında";
            this.btnArasında.Size = new System.Drawing.Size(253, 28);
            this.btnArasında.TabIndex = 26;
            this.btnArasında.Text = "Değerler Arası Sırala";
            this.btnArasında.UseVisualStyleBackColor = true;
            this.btnArasında.Click += new System.EventHandler(this.btnArasında_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Arama : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_24_233404;
            this.pictureBox1.Location = new System.Drawing.Point(1078, -127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 765);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1540, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArasında);
            this.Controls.Add(this.btnAzalan);
            this.Controls.Add(this.numMaliyet2);
            this.Controls.Add(this.btnArtan);
            this.Controls.Add(this.btnMalzemeler);
            this.Controls.Add(this.numMaliyet);
            this.Controls.Add(this.numHazirlamaSuresi);
            this.Controls.Add(this.cmbMalzemeler);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.txtTarifAdi);
            this.Controls.Add(this.btnTarifSil);
            this.Controls.Add(this.lstTarifler);
            this.Controls.Add(this.btnTarifGuncelle);
            this.Controls.Add(this.btnTarifEkle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHazirlamaSuresi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnTarifEkle;
        private DevExpress.XtraEditors.SimpleButton btnTarifGuncelle;
        private System.Windows.Forms.ListView lstTarifler;
        private System.Windows.Forms.ColumnHeader TarifAdı;
        private System.Windows.Forms.ColumnHeader Kategori;
        private System.Windows.Forms.ColumnHeader HazirlamaSuresi;
        private System.Windows.Forms.ColumnHeader Talimatlar;
        private System.Windows.Forms.ColumnHeader TarifID;
        private DevExpress.XtraEditors.SimpleButton btnTarifSil;
        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.ComboBox cmbKategori;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cmbMalzemeler;
        private System.Windows.Forms.NumericUpDown numHazirlamaSuresi;
        private System.Windows.Forms.NumericUpDown numMaliyet;
        private System.Windows.Forms.Button btnMalzemeler;
        private System.Windows.Forms.Button btnArtan;
        private System.Windows.Forms.NumericUpDown numMaliyet2;
        private System.Windows.Forms.Button btnAzalan;
        private System.Windows.Forms.Button btnArasında;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

