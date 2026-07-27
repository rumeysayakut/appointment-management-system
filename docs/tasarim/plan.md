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


