namespace OtobusOtomasyonu
{
    partial class GirisForm
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
            this.musteriGiris_btn = new System.Windows.Forms.Button();
            this.yoneticiGiris_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // musteriGiris_btn
            // 
            this.musteriGiris_btn.Location = new System.Drawing.Point(69, 52);
            this.musteriGiris_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.musteriGiris_btn.Name = "musteriGiris_btn";
            this.musteriGiris_btn.Size = new System.Drawing.Size(199, 75);
            this.musteriGiris_btn.TabIndex = 0;
            this.musteriGiris_btn.Text = "Müşteri Girişi";
            this.musteriGiris_btn.UseVisualStyleBackColor = true;
            this.musteriGiris_btn.Click += new System.EventHandler(this.musteriGiris_btn_Click);
            // 
            // yoneticiGiris_btn
            // 
            this.yoneticiGiris_btn.Location = new System.Drawing.Point(305, 52);
            this.yoneticiGiris_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.yoneticiGiris_btn.Name = "yoneticiGiris_btn";
            this.yoneticiGiris_btn.Size = new System.Drawing.Size(199, 75);
            this.yoneticiGiris_btn.TabIndex = 1;
            this.yoneticiGiris_btn.Text = "Yönetici Girişi";
            this.yoneticiGiris_btn.UseVisualStyleBackColor = true;
            this.yoneticiGiris_btn.Click += new System.EventHandler(this.yoneticiGiris_btn_Click);
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 182);
            this.Controls.Add(this.yoneticiGiris_btn);
            this.Controls.Add(this.musteriGiris_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Formu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GirisForm_FormClosing);
            this.Load += new System.EventHandler(this.GirisForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button musteriGiris_btn;
        private System.Windows.Forms.Button yoneticiGiris_btn;
    }
}

