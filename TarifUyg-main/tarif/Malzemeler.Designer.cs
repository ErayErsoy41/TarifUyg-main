namespace tarif
{
    partial class Malzemeler
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
            this.dgvMalzemeler = new System.Windows.Forms.DataGridView();
            this.dgvTumu = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTumu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMalzemeler
            // 
            this.dgvMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalzemeler.Location = new System.Drawing.Point(4, 38);
            this.dgvMalzemeler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMalzemeler.Name = "dgvMalzemeler";
            this.dgvMalzemeler.RowHeadersWidth = 51;
            this.dgvMalzemeler.Size = new System.Drawing.Size(701, 304);
            this.dgvMalzemeler.TabIndex = 0;
            // 
            // dgvTumu
            // 
            this.dgvTumu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTumu.Location = new System.Drawing.Point(16, 407);
            this.dgvTumu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTumu.Name = "dgvTumu";
            this.dgvTumu.RowHeadersWidth = 51;
            this.dgvTumu.Size = new System.Drawing.Size(689, 252);
            this.dgvTumu.TabIndex = 1;
            this.dgvTumu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTumu_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::tarif.Properties.Resources.Ekran_görüntüsü_2024_10_24_234618;
            this.pictureBox1.Location = new System.Drawing.Point(723, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 610);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Malzemeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1139, 686);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvTumu);
            this.Controls.Add(this.dgvMalzemeler);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Malzemeler";
            this.Text = "Malzemeler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalzemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTumu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMalzemeler;
        private System.Windows.Forms.DataGridView dgvTumu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}