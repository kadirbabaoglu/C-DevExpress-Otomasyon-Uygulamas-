# Proje Adı

Bu proje **C#** ve **DevExpress** kullanılarak geliştirilmiştir. Projede çeşitli işlevleri kapsayan zengin menüler ve kullanıcı giriş işlemleri bulunmaktadır.

## Özellikler

- DevExpress bileşenleri ile modern ve kullanıcı dostu arayüz
- Kullanıcı giriş sistemi ile güvenli erişim
- Aşağıdaki menü seçenekleri ile kapsamlı yönetim özellikleri:
  - **Anasayfa**: Genel bakış ve sistem durumu.
  - **Ürün Yönetimi**: Ürün ekleme, silme ve güncelleme işlemleri.
  - **Stok Yönetimi**: Stok takibi ve yönetimi.
  - **Fatura Yönetimi**: Faturaların oluşturulması ve yönetilmesi.
  - **Müşteri Yönetimi**: Müşteri kayıtları ve müşteriyle ilgili bilgiler.
  - **Personel Yönetimi**: Personel bilgileri ve performans takibi.
  - **Giderler**: İşletme giderlerinin kaydı ve yönetimi.
  - **Kasa Yönetimi**: Kasa işlemleri ve gelir-gider yönetimi.
  - **Notlar**: Not ekleme ve hatırlatma.
  - **Rehber**: Kişi ve kurum rehberi.
  - **Faturalar**: Faturaların detaylı takibi ve yönetimi.
  - **Hareketler**: İşlemler ve hareketler kaydı.
  - **Raporlar**: Detaylı raporlar ve analiz.

## Kullanıcı Girişi

- Proje, yetkisiz erişimi engellemek için kullanıcı giriş sistemi içermektedir.
- Kullanıcı adı ve şifre ile güvenli giriş sağlanır.
- Yetkilendirme ile kullanıcının sadece yetkili olduğu bölümlere erişmesi sağlanır.

## Gereksinimler

- .NET Framework veya .NET Core SDK
- Visual Studio (veya herhangi bir C# IDE)
- DevExpress bileşenleri
- SQL Server (veya projenizde kullanılan veritabanı)

## Kurulum

Projeyi yerel ortamınıza kurmak için adımlar:

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/kullanici/proje-adı.git

2. Proje dizinine gidin: cd proje-adı

3. Projeyi Visual Studio ile açın:

Visual Studio'yu başlatın ve proje-adı.sln dosyasını açın.
Gerekli DevExpress bileşenlerinin yüklü olduğundan emin olun.

4. Gerekli NuGet paketlerini indirin:

Visual Studio'da Tools > NuGet Package Manager > Manage NuGet Packages for Solution... yolunu izleyin.
Gerekli paketleri yükleyin.

5. Veritabanı bağlantı ayarlarını yapılandırın:

app.config veya appsettings.json dosyasındaki veritabanı bağlantı dizesini düzenleyin.

Kullanım
Projeyi çalıştırmak için:

1. Visual Studio'da Ctrl+F5 ile projeyi başlatın.
2. Kullanıcı giriş ekranında geçerli kullanıcı adı ve şifre ile giriş yapın.
3. Menüler aracılığıyla çeşitli yönetim işlemlerini gerçekleştirin (ürün, stok, fatura vb.).

Katkıda Bulunma
Katkıda bulunmak isterseniz:

1. Depoyu forklayın.
2. Yeni bir dal oluşturun (git checkout -b özellik/ÖzellikAdı).
3. Değişikliklerinizi commit edin (git commit -m 'Yeni özellik ekle').
4. Dalınızı gönderin (git push origin özellik/ÖzellikAdı).
5. Bir "Pull Request" açın.
Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakın.