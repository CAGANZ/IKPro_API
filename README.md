# İK Operasyonları Yönetim Uygulaması 
## Backend Projesi Reposu

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![SQL%20Server](https://img.shields.io/badge/SQL%20Server-DB-red)


Çoklu şirket (multi-tenant) yapıda **Admin**, **Şirket Yöneticisi** ve **Çalışan** rollerine sahip; taleplerin ve personel süreçlerinin merkezî olarak yönetildiği bir web uygulaması.



---

## İçindekiler
- [Özellikler](#özellikler)
- [Roller](#roller)
- [Mimari](#mimari)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
  
- [Kurulum](#kurulum)
  - [Gereksinimler](#gereksinimler)
  - [Backend Kurulumu](#backend-kurulumu)


---

## Özellikler
- **Talep Yönetimi:** Çalışanlar talepler oluşturur, durumlarını takip eder.
- **Çoklu Şirket Desteği:** Birden fazla şirket ve kullanıcı aynı anda yönetilebilir.
- **Rol Bazlı Yetkilendirme:** Admin, Şirket Yöneticisi, Çalışan.
- **Temiz Katmanlar:** Onion Architecture ile net sorumluluk ayrımı.
- **Ölçeklenebilir API:** Bakımı kolay, genişlemeye uygun backend.

## Roller
- **Admin:** Şirketleri, çalışanları ve sistem ayarlarını yönetir.
- **Şirket Yöneticisi:** Kendi şirketindeki çalışanları ve talepleri yönetir.
- **Çalışan:** Kişisel bilgilerini görüntüler; talepler oluşturur ve takip eder.

## Mimari
Onion Architecture’da domain kuralları merkezde tutulur, bağımlılıklar içten dışa akar:

          [Domain]         
             ↑
         [Application]     
             ↑
       [Infrastructure]    
             ↑
     [Presentation / API]  



- **Domain:** Varlıklar, değer nesneleri, arayüzler  
- **Application:** Use case’ler, DTO’lar, servis sözleşmeleri  
- **Infrastructure:** Veri erişimi (EF Core/Repository), dış servis adaptörleri  
- **API (Presentation):** HTTP uçları, doğrulama, kimlik/doğrulama

## Kullanılan Teknolojiler
- **Mimari:** Onion Architecture
- **Backend API:** C# (.NET), ASP.NET Core  
- **Frontend:** React.js, Tailwind CSS
- **Veritabanı:** SQL Server  

##Projenin Frontend Reposuna https://github.com/CAGANZ/IKPro_UI adresinden ulaşabilirsiniz.
---

## Kurulum

### Gereksinimler
- .NET SDK (Backend)
- SQL Server (Veritabanı)

- Node.js (Frontend)

### Backend Kurulumu
```bash
git clone https://github.com/CAGANZ/IKPro_API.git

# ..\IKPro.Infrastructure\Data\IKProDbContext.cs içindeki connection string ile Db bağlantısı yapınız.
dotnet restore
dotnet build

# İlk migration oluşturma
dotnet ef migrations add InitialCreate -p IKPro.Infrastructure -s IKPro.API

# Veritabanını güncelleme
dotnet ef database update -p IKPro.Infrastructure -s IKPro.API

# API'yi çalıştırma
dotnet run --project IKPro.API

