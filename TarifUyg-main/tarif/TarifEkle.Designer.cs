namespace TarifRehberi
{
    partial class TarifEkle
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
            this.btnTarifEkle = new System.Windows.Forms.Button();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTarifEkle
            // 
            this.btnTarifEkle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTarifEkle.Location = new System.Drawing.Point(164, 195);
            this.btnTarifEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarifEkle.Name = "btnTarifEkle";
            this.btnTarifEkle.Size = new System.Drawing.Size(100, 28);
            this.btnTarifEkle.TabIndex = 10;
            this.btnTarifEkle.Text = "Tarif Ekle";
            this.btnTarifEkle.UseVisualStyleBackColor = true;
            this.btnTarifEkle.Click += new System.EventHandler(this.btnTarifEkle_Click);
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTalimatlar.Location = new System.Drawing.Point(57, 165);
            this.txtTalimatlar.Margin = new System.Windows.Forms.Padding(4);
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(321, 22);
            this.txtTalimatlar.TabIndex = 9;
            this.txtTalimatlar.Text = "Talimatlar";
            // 
            // txtHazirlamaSuresi
            // 
            this.txtHazirlamaSuresi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(57, 122);
            this.txtHazirlamaSuresi.Margin = new System.Windows.Forms.Padding(4);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(321, 22);
            this.txtHazirlamaSuresi.TabIndex = 8;
            this.txtHazirlamaSuresi.Text = "Hazırlama Süresi";
            // 
            // txtKategori
            // 
            this.txtKategori.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtKategori.Location = new System.Drawing.Point(57, 75);
            this.txtKategori.Margin = new System.Windows.Forms.Padding(4);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(321, 22);
            this.txtKategori.TabIndex = 7;
            this.txtKategori.Text = "Kategori";
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTarifAdi.Location = new System.Drawing.Point(57, 29);
            this.txtTarifAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(321, 22);
            this.txtTarifAdi.TabIndex = 6;
            this.txtTarifAdi.Text = "Tarif Adı";
            this.txtTarifAdi.TextChanged += new System.EventHandler(this.txtTarifAdi_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_24_235254;
            this.pictureBox2.Location = new System.Drawing.Point(57, 246);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(308, 259);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_24_234618;
            this.pictureBox1.Location = new System.Drawing.Point(421, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 465);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // TarifEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(806, 526);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTarifEkle);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.txtTarifAdi);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TarifEkle";
            this.Text = "TarifEkle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTarifEkle;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}