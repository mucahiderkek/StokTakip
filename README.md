# 📦 Stok Takip Uygulaması

Bu proje, **C# (Windows Forms) ve SQLite** kullanılarak geliştirilmiş bir **Stok Takip Uygulamasıdır**.  
Ürünlerin **stok takibini yapmak, ürün eklemek, güncellemek ve silmek** için kullanılabilir.  

---

## 📌 **Özellikler**
- 📋 **Ürün ekleme, silme, güncelleme**  
- 🔍 **Ürünleri listeleme**  
- 📊 **Stok miktarı takibi**  
- 📑 **Ürünleri kategorilere ayırma**  
- 📥 **Verileri Excel’e aktarma**  
- 📧 **E-posta ile raporlama**  
- 🔌 **SQLite veritabanı kullanımı (Lokal veritabanı)**  

---

## 🛠 **Kullanılan Teknolojiler**
- **C# (Windows Forms)**
- **SQLite (Lokal veritabanı)**
- **Dapper ORM (Veritabanı işlemleri için)**
- **EPPlus (Excel dışa aktarma için)**

---

## 📂 **Veritabanı Yapısı**
Proje SQLite kullanmaktadır. **Veritabanı dosyası (`stoktakip.db`) proje dizininde saklanmaktadır.**  

### **🔹 Tablo: `Urunler`**
| Kolon Adı    | Veri Tipi   | Açıklama |
|-------------|------------|------------|
| `ID`        | INTEGER (PK) | Otomatik artan ID |
| `UrunAdi`   | TEXT        | Ürün Adı |
| `KategoriID`| INTEGER     | Ürünün bağlı olduğu kategori |
| `StokMiktari` | INTEGER   | Stok Adedi |
| `Fiyat`     | REAL        | Ürün Fiyatı |

### **🔹 Tablo: `Kategoriler`**
| Kolon Adı    | Veri Tipi   | Açıklama |
|-------------|------------|------------|
| `ID`        | INTEGER (PK) | Otomatik artan ID |
| `KategoriAdi` | TEXT      | Kategori Adı |

---

## 🚀 **Kurulum & Kullanım**
1️⃣ **Projeyi GitHub’dan klonla**  
```bash
git clone https://github.com/KullaniciAdi/StokTakipUygulamasi.git


👤 [Mücahid Erkek]
📧 Email: [mucahiderkek@gmail.com]
🔗 GitHub: [github.com/mucahiderkek]
🚀 LinkedIn: [linkedin.com/in/mücahid-talha-erkek]
