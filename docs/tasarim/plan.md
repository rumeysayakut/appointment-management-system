# Milestone 1
Bu aşamada sistemin temelini oluşturulur ve doktorların randevu verebileceği yapı hazırlanır.

<h3>Yapılacaklar</h3>
Branş, doktor, DoktorÇalışmaSaati entityleri oluşturulacak. Bu entity'lere ait Domain, Application, Infrastructure ve WebAPI katmanlarındaki gerekli bileşenler (repository, service, DTO, handler, validator, controller vb.) geliştirilecek.
İş kuralları uygulanarak gerekli API'ler oluşturulacak.
Veritabanı ilişkileri tanımlanacak.

<h3>Yapılacak API'ler</h3>
Branş ekle <br>
Branş listele<br>
Doktor ekle<br>
Doktor listele<br>
Doktor çalışma saati ekle<br>
Doktor çalışma saatlerini listele<br>

<h3>Bitti Kriteri</h3>
Branş oluşturulabiliyor.<br>
Doktor oluşturulabiliyor.<br>
Doktora çalışma saatleri atanabiliyor.<br>

Tahmini Süre: 3 gün 


# Milestone 2
Bu kısımda hasta ve randevu yönetimi tamamlanacak. Hastalar sisteme kaydedilebilecek ve iş kurallarına uygun şekilde randevu oluşturulabilecektir.
Hasta ve randevu entity sınıfları tamamlanacak. Bu entity'lere ait Domain, Application, Infrastructure ve WebAPI katmanlarındaki gerekli bileşenler (repository, service, DTO, handler, validator, controller vb.) geliştirilecek.
İş kuralları uygulanarak gerekli API'ler oluşturulacak.
Veritabanı ilişkileri tanımlanacak.

<h3>Yapılacak API'ler</h3>
Hasta oluştur<br>
Randevu oluştur<br>
Doktorun randevularını listele<br>
Hastanın randevularını listele<br>


<h3>İş Kuralları</h3>
Aynı doktora aynı saatte ikinci randevu oluşturulamaz.<br>
Doktor çalışma saati dışında randevu oluşturulamaz.<br>
Randevu geçmiş tarihe oluşturulamaz.<br>
Randevu yalnızca doktorun çalıştığı günlerde oluşturulabilir.<br>

<h3>Bitti Kriteri</h3>
Hasta randevu oluşturabiliyor.<br>
Sistem çakışan randevuyu reddediyor.<br>
Çalışma saati dışındaki randevuyu reddediyor.<br>

Tahmini Süre: 2 gün 


# Milestone 3

Bu aşamada sistem artık gerçek kullanıma yaklaşacak. Randevu İptali, Randevu Durumu, Doktor İzin Günü, Bildirim sınıfları tamamlanacak. Bu sınıflara ait Domain, Application, Infrastructure ve WebAPI katmanlarındaki gerekli bileşenler (repository, service, DTO, handler, validator, controller vb.) geliştirilecek.
İş kuralları uygulanarak gerekli API'ler oluşturulacak.
Veritabanı ilişkileri tanımlanacak.

<h3>İş Kuralları</h3>

Randevu yalnızca 2 saat öncesine kadar iptal edilir.<br>
Doktor izinliyken randevu oluşturulamaz.<br>
Tamamlanan randevu tekrar iptal edilemez.<br>

<h3>Yapılacak API'ler</h3>
Randevu iptal et<br>
Randevuyu tamamlandı yap<br>
Gelmedi olarak işaretle<br>
Doktor izni ekle<br>
Bildirimleri listele<br>

<h3>Bitti Kriteri</h3>
Randevular iptal edilebiliyor.<br>
Gelmedi işaretlenebiliyor.<br>
Tamamlandı yapılabiliyor.<br>
Doktor izinliyken yeni randevu oluşturulamıyor.<br>

Tahmini Süre: 3 gün

# Milestone 4

Bu aşamada randevu oluşturma süreci geliştirilecek ve hastaların doktorların müsait randevu saatlerini önceden görüntüleyebilmesi sağlanacaktır. Doktorun sonradan izin alması nedeniyle randevusu etkilenen hastaların mağduriyetini azaltmak amacıyla yeniden randevu oluşturma süreci geliştirilecektir.

Yapılacaklar

Doktorun çalışma saatleri, mevcut randevuları, izinleri ve diğer randevu kuralları dikkate alınarak müsait randevu saatlerinin hesaplanması sağlanacak. Hastanın doktor ve tarih seçerek yalnızca alınabilir randevu saatlerini görüntüleyebilmesi için gerekli API geliştirilecek.

Hasta daha önce randevu aldıktan sonra doktorun bu tarihi kapsayan bir izin oluşturması durumunda etkilenen randevular tespit edilecek. İlgili hastanın randevusu iptal edilerek hastaya normal randevu alma süresine ek olarak 5 günlük süre tanımlanacak. Hastaya durum hakkında bildirim gönderilecek.

Bitti Kriteri

Hasta doktor ve tarih seçerek müsait randevu saatlerini görüntüleyebiliyor.

Dolu, geçmiş ve izinli saatler listelenmiyor.

Doktor sonradan izin aldığında etkilenen randevular tespit ediliyor.

Etkilenen randevu iptal ediliyor.

Hastaya ek 5 günlük randevu oluşturma süresi tanımlanıyor.

Hasta kendisine tanımlanan süre içerisinde yeni randevu oluşturabiliyor.

Tahmini Süre 2 gün

# Milestone 5

Bu aşamada hastaların özel durumlarının sisteme tanımlanması ve öncelikli hastalar için randevu oluşturma sürecinin geliştirilmesi sağlanacaktır. Ayrıca hastaların geçmiş randevu bilgilerinin T.C. kimlik numarası üzerinden sorgulanabilmesi için gerekli yapı oluşturulacaktır.

Yapılacaklar

Hasta için öncelik durumları tanımlanacak ve hastanın öncelik bilgilerinin yönetilebilmesi sağlanacak.

Yaşlı, gazi ve engelli gibi öncelikli grupların sisteme tanımlanması sağlanacak.

Öncelikli hastalar için randevu oluşturma kuralları geliştirilecek.

Hastanın geçmiş randevularının T.C. kimlik numarası kullanılarak sorgulanabilmesi sağlanacak.

Geçmiş randevuların tarih, doktor, branş ve randevu durumu bilgilerinin görüntülenmesi sağlanacak.

Gelecek randevuların tarih, doktor, branş ve randevu durumu bilgilerinin görüntülenmesi sağlanacak.

Yapılacak API'ler

Hasta öncelik durumunu güncelle

Hasta öncelik durumunu görüntüle

T.C. kimlik numarasıyla hasta sorgula

T.C. kimlik numarasıyla geçmiş randevuları listele

T.C. kimlik numarasıyla gelecek randevuları listele

İş Kuralları

Hasta yalnızca tanımlı öncelik kategorilerinden birine sahip olabilir.

Öncelikli hastalara belirlenen randevu öncelik kuralları uygulanmalıdır.

T.C. kimlik numarasıyla yapılan sorgulamalar yetkisiz kullanıcılar tarafından gerçekleştirilememelidir.

Bitti Kriteri

Hastanın öncelik durumu tanımlanabiliyor.

Yaşlı, gazi ve engelli hastalar sisteme tanımlanabiliyor.

Öncelikli hastalar için belirlenen randevu kuralları uygulanıyor.

T.C. kimlik numarasıyla hasta geçmişi sorgulanabiliyor.

Hastanın geçmiş randevuları görüntülenebiliyor.

Yetkisiz kullanıcıların hasta geçmişine erişmesi engelleniyor.

Tahmini Süre 2 gün

# Milestone 6

Bu aşamada mevcut bildirim sistemi geliştirilerek hastalara ve doktorlara uygulama içi bildirimlerin yanında e-posta yoluyla da bilgilendirme yapılması sağlanacaktır.

Yapılacaklar

Mevcut Notification yapısı geliştirilecek.

Hastaların ve doktorların e-posta bilgilerinin sisteme eklenmesi sağlanacak.

E-posta gönderim altyapısı oluşturulacak.

Randevu işlemlerine bağlı olarak otomatik e-posta gönderilmesi sağlanacak.

Randevuya 1 gün kala hastalara bilgilendirme maili gönderilecek.

Yapılacak API'ler

Bildirimleri listele

Bildirimi okundu olarak işaretle

Bildirim tercihlerini güncelle

Gönderilecek Bildirimler

Randevu oluşturuldu

Randevu iptal edildi

Doktor izin aldı ve randevu etkilendi

Randevunun yeniden oluşturulması gerekiyor

Randevu durumu değişti

Bitti Kriteri

Hastaya uygulama içi bildirim gönderilebiliyor.

Doktora uygulama içi bildirim gönderilebiliyor.

Hastaya e-posta gönderilebiliyor.

Doktora e-posta gönderilebiliyor.

Randevu işlemleri sonucunda ilgili bildirimler otomatik oluşturuluyor.

E-posta gönderiminde oluşan hata randevu işleminin başarısız olmasına neden olmuyor.

Tahmini Süre 3 gün

# Milestone 7

Bu aşamada sistemin kimlik doğrulama, yetkilendirme ve güvenlik altyapısı oluşturulacaktır. Kullanıcıların sisteme T.C. kimlik numarası ve telefon numarası ile giriş yapabilmesi sağlanacak ve kullanıcıların yalnızca yetkileri dahilindeki verilere erişebilmesi için gerekli güvenlik mekanizmaları uygulanacaktır.

Yapılacaklar

Kullanıcı yönetim yapısı oluşturulacak.

T.C. kimlik numarası ve telefon numarası ile giriş sistemi geliştirilecek.

JWT tabanlı authentication yapısı oluşturulacak.

Patient, Doctor ve Admin rollerinin oluşturulması sağlanacak.

Role-based authorization uygulanacak.

Kullanıcıların yalnızca kendi verilerine erişebilmesi sağlanacak.

Hassas hasta verilerinin korunması sağlanacak.

Swagger üzerinde JWT authentication yapılandırılacak.

Global exception handling uygulanacak.

Güvenli hata response yapısı oluşturulacak.

CORS yapılandırması yapılacak.

Gizli bilgilerin kaynak kod içerisinde tutulması engellenecek.

Yapılacak API'ler

Kullanıcı giriş yap

Kullanıcı bilgilerini görüntüle

Kullanıcının kendi randevularını listele

Kullanıcının kendi bildirimlerini listele

İş Kuralları

T.C. kimlik numarası ve telefon numarası eşleşmeyen kullanıcı sisteme giriş yapamaz.

Kimliği doğrulanmamış kullanıcı korumalı endpointlere erişemez.

Hasta yalnızca kendi randevularına ve bildirimlerine erişebilir.

Doktor yalnızca kendi randevularına erişebilir.

Hasta başka hastaların bilgilerine erişemez.

Doktor başka doktorların yönetim işlemlerini gerçekleştiremez.

Admin yetkisi olmayan kullanıcı yönetim işlemlerini gerçekleştiremez.

T.C. kimlik numarası ve diğer hassas bilgiler yetkisiz kullanıcılara gösterilemez.

Hata response'larında uygulamanın iç yapısı ve stack trace bilgileri gösterilmemelidir.

Şifre kullanılmayan giriş sisteminde dahi JWT token güvenli şekilde oluşturulmalı ve doğrulanmalıdır.

Bitti Kriteri

Kullanıcı T.C. kimlik numarası ve telefon numarasıyla giriş yapabiliyor.

Başarılı giriş sonucunda JWT token oluşturuluyor.

Kullanıcı rolleri doğru şekilde belirleniyor.

Yetkisiz kullanıcı korumalı endpointlere erişemiyor.

Hasta başka bir hastanın verilerine erişemiyor.

Doktor yalnızca kendi verilerine erişebiliyor.

Admin yetkileri doğru şekilde uygulanıyor.

Swagger üzerinden JWT ile yetkilendirilmiş istek gönderilebiliyor.

Hassas bilgiler korunuyor.

API hatalarında sistemin iç bilgileri kullanıcıya gösterilmiyor.

Tahmini Süre 4 gün

# Milestone 8

Bu aşamada sistemin güvenilirliği ve kod kalitesi artırılacak, kritik iş kuralları otomatik testlerle doğrulanacak ve proje kullanıma daha hazır bir hale getirilecektir.

Yapılacaklar

Unit test altyapısı oluşturulacak.

Integration test altyapısı oluşturulacak.

Randevu oluşturma iş kuralları test edilecek.

Randevu iptal kuralları test edilecek.

Doktor izin kuralları test edilecek.

+5 günlük yeniden randevu kuralı test edilecek.

Öncelikli hasta kuralları test edilecek.

Authentication ve authorization testleri oluşturulacak.

Bildirim ve e-posta işlemleri test edilecek.

Exception handling testleri oluşturulacak.

Kod tekrarları ve gereksiz kodlar temizlenecek.

README ve API dokümantasyonu güncellenecek.

Projenin baştan sona son testleri gerçekleştirilecek.

Test Edilecek Temel Senaryolar

Aynı doktora aynı saatte ikinci randevu alınamaması.

Çalışma saati dışında randevu alınamaması.

İzinli doktora randevu alınamaması.

Geçmiş tarihe randevu alınamaması.

2 saatten az kala randevu iptal edilememesi.

Tamamlanan randevunun iptal edilememesi.

Doktor izni nedeniyle iptal edilen randevuda hastaya +5 gün verilmesi.

Öncelikli hasta kurallarının doğru uygulanması.

Yetkisiz kullanıcının başka hastanın verilerine erişememesi.

Bildirimlerin doğru oluşturulması.

E-posta gönderim işlemlerinin doğru çalışması.

Tahmini Süre 3 gün
