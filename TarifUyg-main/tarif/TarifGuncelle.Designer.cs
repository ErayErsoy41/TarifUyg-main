namespace tarif
{
    partial class TarifGuncelle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.Location = new System.Drawing.Point(68, 44);
            this.txtTarifAdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(321, 22);
            this.txtTarifAdi.TabIndex = 0;
            this.txtTarifAdi.Text = "Tarif Adı";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(68, 244);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(323, 28);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(68, 85);
            this.txtKategori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(321, 22);
            this.txtKategori.TabIndex = 4;
            this.txtKategori.Text = "Kategori";
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.Location = new System.Drawing.Point(68, 175);
            this.txtTalimatlar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(321, 22);
            this.txtTalimatlar.TabIndex = 6;
            this.txtTalimatlar.Text = "Talimatlar";
            this.txtTalimatlar.TextChanged += new System.EventHandler(this.txtTalimatlar_TextChanged);
            // 
            // txtHazirlamaSuresi
            // 
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(68, 132);
            this.txtHazirlamaSuresi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(321, 22);
            this.txtHazirlamaSuresi.TabIndex = 5;
            this.txtHazirlamaSuresi.Text = "Hazırlama Süresi";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_25_001125;
            this.pictureBox2.Location = new System.Drawing.Point(133, 290);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(227, 222);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_25_000752;
            this.pictureBox1.Location = new System.Drawing.Point(423, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 530);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // TarifGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtTarifAdi);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TarifGuncelle";
            this.Text = "AramaFormu";
            this.Load += new System.EventHandler(this.AramaFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}