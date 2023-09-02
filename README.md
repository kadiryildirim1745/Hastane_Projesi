#                                                                                                  Hastane Randevu Sistemi Projesi

Proje Açıklaması
Bu proje, hastanelerdeki randevu kayıt sürecini kolaylaştırmak için tasarlanmış bir masaüstü uygulamasıdır. Kullanıcılar, doktor seçimi, tarih ve saat seçimi gibi bilgileri girerek randevu oluşturabilirler. Ayrıca, doktorların çalışma saatleri ve randevu takvimi yönetimi için bir yönetici paneli bulunmaktadır.

Kurulum

-Projeyi yerel bir geliştirme ortamında çalıştırmak ve özelleştirmek için aşağıdaki adımları izleyebilirsiniz:

-Gereksinimler: Projeyi çalıştırmak için Visual Studio veya benzeri bir C# geliştirme ortamına ihtiyacınız olacak. Ayrıca, bir SQL veritabanı sunucusuna erişim gereklidir.

-Veri Tabanı Ayarları: Repository içerisindeki hastane.db.mdf ve hastanedb_log.ldf dosyalarını indirin. MsSQL Program Files/Microsoft SQL Server/MSSQL16.SQLEXPRESS/MSSQL/DATA içine kopyalayın. 

-Veri Tabanına Ekleme: Bağlantıyı kurduktan sonra Databases'e sağ tıklayıp Attach deyin. Açılan sayfada mdf file location kısmına az önce eklediğimiz mdf uzantılı dosyayı ekleyin. Otomatik olarak gelen log dosyasıyla birilikte 'OK' diyerek yüklemeyi tamamlayın.

-Visual Studio'da Bağlantı Kurma: Varsayılan olarak adres girilidir fakat bir sorun çıkması halinde; Project-> Add New Data Source-> Database-> Dataset deyip new connection kısmından veri tabanını ekleyin. Daha sonra altta bulunan "show the connection string..." seçeneğine tıklayarak gelen adresi kopyalayıp kapatın.

-Projeye Ekleme: baglanti.cs sınıfını açıp SQLConnection sınıfına metod olarak adresi yapıştırın.

-Proje İndirme: Bu GitHub deposunu klonlayın veya ZIP olarak indirin.

-Projeyi Açma: Visual Studio'da proje dosyasını açın (.sln uzantılı dosya).



Kullanım

-Giriş Yapma: 3 farklı giriş yöntemi mevcut: Doktor,hasta ve sekreter girişi. Giriş bilgileri veri tabanında kayıtlı olmasına rağmen kolaylık açısından kodlara da gömülmüştür, hızlıca giriş yapılabilir.

-Sekreter Detay:Duyuru oluşturulabilir. Branş ve doktora göre randevu açılabilir. Doktor paneli ve branş panelinde doktor ve branş kaydı yapılabilir. Randevular sekmesinde tüm randevular görüntülenir. Duyurular kısmında ise tüm duyurular görüntülenebilir.

-Hasta Detay Ekranı: Sırasıyla seçilen branş ve doktora göre müsati randevu çift tıklanarak seçilir ve şikayet yazılarak randevu alınır. Üst kısımda geçmiş randevular görüntülenebilir.

-Doktor Detay: Girilen doktora göre tüm randevular görüntülenir. Çift tıklayarak randevu bilgilerine erişilebiir. Duyurular kısmında ise tüm duyurular görüntülenebilir.

-Not: Sol üst köşedeki 'Menü' seçeneğinden sayfalar arası geçiş yapılabilir.

-İstatistik Ekranı: Hasta, branş, doktor ve randevular hakkındaki istatistikler çeşitli tablolarla burada görüntülenir.

