namespace tarif
{
    partial class TarifSilForm
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
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.btnTarifiSil = new System.Windows.Forms.Button();
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.Location = new System.Drawing.Point(40, 192);
            this.txtTalimatlar.Margin = new System.Windows.Forms.Padding(4);
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(321, 22);
            this.txtTalimatlar.TabIndex = 12;
            this.txtTalimatlar.Text = "Talimatlar";
            // 
            // txtHazirlamaSuresi
            // 
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(40, 138);
            this.txtHazirlamaSuresi.Margin = new System.Windows.Forms.Padding(4);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(321, 22);
            this.txtHazirlamaSuresi.TabIndex = 11;
            this.txtHazirlamaSuresi.Text = "Hazırlama Süresi";
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(40, 93);
            this.txtKategori.Margin = new System.Windows.Forms.Padding(4);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(321, 22);
            this.txtKategori.TabIndex = 10;
            this.txtKategori.Text = "Kategori";
            // 
            // btnTarifiSil
            // 
            this.btnTarifiSil.Location = new System.Drawing.Point(40, 248);
            this.btnTarifiSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarifiSil.Name = "btnTarifiSil";
            this.btnTarifiSil.Size = new System.Drawing.Size(323, 28);
            this.btnTarifiSil.TabIndex = 9;
            this.btnTarifiSil.Text = "Tarifi Sil";
            this.btnTarifiSil.UseVisualStyleBackColor = true;
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.Location = new System.Drawing.Point(42, 42);
            this.txtTarifAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(321, 22);
            this.txtTarifAdi.TabIndex = 7;
            this.txtTarifAdi.Text = "Tarif Adı";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_25_000342;
            this.pictureBox2.Location = new System.Drawing.Point(54, 283);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(342, 249);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_25_000048;
            this.pictureBox1.Location = new System.Drawing.Point(411, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(609, 490);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // TarifSilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1056, 548);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.txtKategori);
            this.Controls.Add(this.btnTarifiSil);
            this.Controls.Add(this.txtTarifAdi);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TarifSilForm";
            this.Text = "TarifSilForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.Button btnTarifiSil;
        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}