# 📦 Stok Takip Uygulaması / Stock Tracking Application

Bu proje, **C# (Windows Forms) ve SQLite** kullanılarak geliştirilmiş bir **Stok Takip Uygulamasıdır**.  
Ürünlerin **stok takibini yapmak, ürün eklemek, güncellemek ve silmek** için kullanılabilir.  

This project is a **Stock Tracking Application** developed using **C# (Windows Forms) and SQLite**.  
It allows users to **track stock, add, update, and delete products**.  

---

## 📌 **Özellikler / Features**
✅ **Ürün ekleme, silme, güncelleme**  
✅ **Ürünleri listeleme**  
✅ **Stok miktarı takibi**  
✅ **Ürünleri kategorilere ayırma**  
✅ **Verileri Excel’e aktarma**  
✅ **E-posta ile raporlama**  
✅ **SQLite veritabanı kullanımı**  

✅ **Add, delete, and update products**  
✅ **List products**  
✅ **Track stock quantities**  
✅ **Categorize products**  
✅ **Export data to Excel**  
✅ **Send reports via email**  
✅ **Uses SQLite database**  

---

## 🛠 **Kullanılan Teknolojiler / Technologies Used**
- **C# (Windows Forms)**
- **SQLite (Local Database)**
- **Dapper ORM (For database operations)**
- **EPPlus (For Excel Exporting)**

---

## 📂 **Veritabanı Yapısı / Database Structure**
Proje **SQLite** kullanmaktadır.  
The project uses **SQLite** as the database.  

### **🔹 Tablo: `Urunler` (Products Table)**
| Kolon Adı (Column Name) | Veri Tipi (Data Type) | Açıklama (Description) |
|----------------|------------|----------------|
| `ID` | INTEGER (PK) | Otomatik artan ID (Auto Increment ID) |
| `UrunAdi` | TEXT | Ürün Adı (Product Name) |
| `KategoriID` | INTEGER | Ürünün kategorisi (Category of the product) |
| `StokMiktari` | INTEGER | Stok Adedi (Stock Quantity) |
| `Fiyat` | REAL | Ürün Fiyatı (Product Price) |

### **🔹 Tablo: `Kategoriler` (Categories Table)**
| Kolon Adı (Column Name) | Veri Tipi (Data Type) | Açıklama (Description) |
|----------------|------------|----------------|
| `ID` | INTEGER (PK) | Otomatik artan ID (Auto Increment ID) |
| `KategoriAdi` | TEXT | Kategori Adı (Category Name) |

---

## 🚀 **Kurulum & Kullanım / Installation & Usage**
1️⃣ **Projeyi GitHub’dan klonla / Clone the project from GitHub**  
```bash
git clone https://github.com/KullaniciAdi/StokTakipUygulamasi.git
