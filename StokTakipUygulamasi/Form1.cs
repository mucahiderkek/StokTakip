using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace StokTakipUygulamasi
{
    public partial class Form1 : Form
    {
        string dbPath = "stoktakip.sqlite"; // Veritabanı dosyası
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = $"Data Source={dbPath};Version=3;";
            VeritabaniOlustur(); // Uygulama açılınca kontrol et
            UrunleriListele();
        }

        private void VeritabaniOlustur()
        {
            if (!File.Exists(dbPath)) // Eğer veritabanı dosyası yoksa oluştur
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE Urunler (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UrunAdi TEXT NOT NULL,
                        StokMiktari INTEGER NOT NULL,
                        Fiyat REAL NOT NULL
                    );";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                MessageBox.Show("Veritabanı oluşturuldu!");
            }
        }
        private void KategoriTablosuOlustur()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Kategoriler (ID INTEGER PRIMARY KEY AUTOINCREMENT, KategoriAdi TEXT NOT NULL)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Urunler (UrunAdi, StokMiktari, Fiyat) VALUES (@urunAdi, @stokMiktari, @fiyat)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@urunAdi", txtUrunAdi.Text);
                    cmd.Parameters.AddWithValue("@stokMiktari", Convert.ToInt32(txtStokMiktari.Text));
                    cmd.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtFiyat.Text));

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Ürün başarıyla eklendi!");
                UrunleriListele(); // Güncellenmiş listeyi getir
            }
            txtUrunAdi.Clear();
            txtStokMiktari.Clear();
            txtFiyat.Clear();
        }
        private void UrunleriListele()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Urunler";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        da.Fill(dt);
                        dgvUrunler.DataSource = dt; // DataGridView'e verileri yükle
                    }
                }
                conn.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["ID"].Value);

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Urunler SET UrunAdi=@urunAdi, StokMiktari=@stokMiktari, Fiyat=@fiyat WHERE ID=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@urunAdi", txtUrunAdi.Text);
                        cmd.Parameters.AddWithValue("@stokMiktari", Convert.ToInt32(txtStokMiktari.Text));
                        cmd.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtFiyat.Text));
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    MessageBox.Show("Ürün başarıyla güncellendi!");
                    UrunleriListele(); // Listeyi yenile
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir ürünü seçin.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRows[0].Cells["ID"].Value);

                DialogResult result = MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (var conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Urunler WHERE ID=@id";

                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        conn.Close();
                        MessageBox.Show("Ürün başarıyla silindi!");
                        UrunleriListele(); // Listeyi yenile
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir ürünü seçin.");
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Tıklanan satır geçerli mi?
            {
                txtUrunAdi.Text = dgvUrunler.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
                txtStokMiktari.Text = dgvUrunler.Rows[e.RowIndex].Cells["StokMiktari"].Value.ToString();
                txtFiyat.Text = dgvUrunler.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtAra.Text.Trim(); // Kullanıcının yazdığı metni al

            // Eğer kullanıcı hiçbir şey yazmadıysa, tüm ürünleri listele
            if (string.IsNullOrWhiteSpace(aramaKelimesi))
            {
                UrunleriListele(); // Tüm ürünleri göster
                return;
            }

            // Arama işlemini yap
            using (var conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Urunler WHERE UrunAdi LIKE @urunAdi"; // Arama kriterini belirledik
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@urunAdi", "%" + aramaKelimesi + "%"); // % ile eşleşme sağlıyoruz

                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new System.Data.DataTable();
                            da.Fill(dt);
                            dgvUrunler.DataSource = dt; // DataGridView'e sonuçları yüklüyoruz
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message); // Hata mesajı göster
                }
            }
        }



    }
}
