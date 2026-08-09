## 24.07.2026 - Proje Başlangıcı

Bugün proje briflerini inceledim ve Randevu Sistemi projesini seçmeye karar verdim. Brif A'yı seçtim çünkü gerçek hayatta en fazla iş kuralı barındıran senaryolardan biri olduğunu düşünüyorum. Özellikle randevu çakışmaları, doktor çalışma saatleri, uygunluk kontrolleri ve iptal/erteleme süreçleri gibi domain kurallarını doğru modellemek istediğim için bu projeyi tercih ettim. Diğer iki brif de güzel ama benim öğrenmek istediğim konu daha çok domain modelleme ve iş kurallarının yönetimiydi. Randevu sistemi bu açıdan daha fazla karar vermeyi gerektiriyor.

Müşteri gereksinimlerini daha iyi anlayabilmek için toplam 9 sorudan oluşan bir soru paketi hazırladım. Sorular; doktor çalışma saatleri, randevu iptali, bildirim sistemi, öncelikli hasta grupları, üyelik sistemi ve iş kuralları gibi konuları kapsıyordu.

Aldığım karar: Tasarıma başlamadan önce eksik gereksinimleri netleştirmeye karar verdim.


## 25.07.2026 - Mimari Tasarımı

Projemin büyüklüğünü belirledim ve Clean Architecture kullanmaya karar verdim.

Ardından **mimari.md** dosyasını hazırladım. Bu dosyada;

* Clean Architecture'ı neden seçtiğimi,
* Bu mimarinin bana sağlayacağı avantajları,
* Dezavantajlarını,
* Veritabanı değişmesi durumunda sistemin nasıl etkileneceğini,
* Sistemin ileride mikroservislere ayrılması durumunda hangi noktaların kolay veya zor olacağını,
* Sistem yaklaşık 10 kat büyüdüğünde oluşabilecek performans sorunlarını ve bunlara yönelik çözüm önerilerimi

detaylı şekilde yazdım.

Aldığım karar: İş kurallarını altyapıdan bağımsız tutabilmek için Clean Architecture kullanmaya karar verdim.

**AI Kullanımı:** Clean Architecture'ın avantajlarını değerlendirirken ve olası büyüme senaryolarını analiz ederken AI'dan fikir aldım.

**Reddedilen AI Önerisi:** AI, ilk sürümde kullanıcı kimlik doğrulama (JWT) eklenmesini önerdi. Ancak müşteri gereksinimlerinde böyle bir ihtiyaç bulunmadığı için bunu ilk sürüm kapsamına dahil etmedim.


## 27.07.2026 - Tasarımın Tamamlanması

Bugün proje tasarımını tamamladım.

Öncelikle **kapsam.md** dosyasını hazırladım. Bu dosyada;

* Problemi kendi cümlelerimle tanımladım,
* İlk sürüm için kapsam içi ve kapsam dışı özellikleri belirledim,
* İlk sürümün tamamlanmış sayılabilmesi için ölçülebilir "bitti" kriterlerini yazdım,
* Projede kullanacağım varsayımları etiketleyerek ekledim.

Ardından **plan.md** dosyasını oluşturdum.

Projenin ilk sürümü için projeyi üç milestone'a ayırdım.

* Milestone 1: Branş, doktor ve çalışma saatleri yönetimi
* Milestone 2: Hasta ve randevu yönetimi
* Milestone 3: Randevu iptali, doktor izinleri, bildirim sistemi ve randevu durumları

Her milestone için yapılacak geliştirmeleri, oluşturulacak API'leri, tamamlanma kriterlerini ve tahmini sürelerini belirledim.

**Aldığım karar:** İlk sürümü küçük ama tamamlanmış bir ürün (MVP) olarak geliştirmeye karar verdim.

**AI Kullanımı:** Dokümanların eksik kalan noktalarını kontrol etmek ve milestone planını gözden geçirmek amacıyla AI'dan yararlandım.

**Reddedilen AI Önerisi:** AI, ilk sürüme raporlama ve gelişmiş istatistik ekranları eklenmesini önerdi. Ancak projenin kapsamını gereksiz şekilde büyüteceği için bu öneriyi kabul etmedim.

## 31.07.2026 - Milestone 1 Geliştirme Süreci

Bugün Milestone 1 kapsamındaki ilk geliştirmeleri tamamladım.

İlk olarak proje yapısını oluşturdum ve Clean Architecture katmanlarını yapılandırdım. Domain, Application, Persistence ve API katmanları arasındaki referans ilişkilerini düzenledim. Ardından Branch (Branş) modülünü geliştirmeye başladım.

Branch entity'sini oluşturduktan sonra Entity Framework Core konfigürasyonunu hazırladım. Repository katmanını geliştirerek branş ekleme, listeleme, güncelleme ve silme işlemleri için gerekli metotları ekledim.

Application katmanında CQRS yapısını kullanarak;

* Command ve Query sınıflarını,
* Handler sınıflarını,
* Validator sınıflarını,
* DTO yapılarını

oluşturdum.

Son olarak API katmanında BranchController geliştirerek oluşturduğum endpointleri Swagger üzerinden test ettim.

Geliştirme sırasında proje referansları, MediatR sürüm uyumsuzluğu, Dependency Injection yapılandırması ve Entity Framework Core migration işlemleriyle ilgili çeşitli teknik sorunlarla karşılaştım. Bu sorunları yapay zekadan yardım alarak hallettim.

Migration oluşturarak veritabanını hazırladım ve Branch modülünün CRUD işlemlerini başarıyla çalıştırdım.

**Aldığım karar:** Projede oluşturacağım tüm entity'ler için aynı klasör yapısını ve aynı CQRS mimarisini kullanarak tutarlı bir geliştirme standardı uygulamaya karar verdim.

**AI Kullanımı:** Katmanlar arasındaki bağımlılıkların düzenlenmesi, MediatR yapılandırması, Dependency Injection ve Entity Framework Core migration süreçlerinde AI'dan teknik destek aldım.

**Reddedilen AI Önerisi:** AI, CRUD işlemlerinde Generic Repository kullanılmasını önerdi. Ancak Repository Pattern'i daha iyi öğrenebilmek ve her entity'nin sorumluluklarını açık şekilde görebilmek amacıyla her entity için ayrı repository geliştirmeyi tercih ettim.

## 01.08.2026 - Milestone 1 devam

Bugün Milestone 1 kapsamındaki geliştirmelere devam etttim.

Doctor (Doktor) modülünü geliştirdim.

Bu kapsamda;

* Doctor entity'sini oluşturdum,
* Repository katmanını geliştirdim,
* CQRS yapısını oluşturdum,
* Command, Query, Handler ve Validator sınıflarını hazırladım,
* DoctorController geliştirerek API endpointlerini tamamladım.

## 02.08.2026 - Milestone 1'in Tamamlanması

Bugün Milestone 1 kapsamındaki geliştirmeleri tamamladım.

DoctorWorkingHour (Doktor Çalışma Saati) modülünü geliştirdim.

Bu modülde;

* Doktor ile çalışma saatleri arasındaki ilişkiyi tanımladım,
* Çalışma günü, başlangıç saati ve bitiş saati bilgilerini yöneten entity yapısını oluşturdum,
* Repository katmanını geliştirdim,
* CQRS yapısını kurdum,
* Controller ve API endpointlerini hazırladım.

Validator katmanında başlangıç saatinin bitiş saatinden önce olması gerektiği iş kuralını uyguladım.

Tüm geliştirmeler tamamlandıktan sonra yeni migration oluşturarak veritabanını güncelledim. Swagger üzerinden tüm Branch, Doctor ve DoctorWorkingHour endpointlerini test ederek sistemin beklenen şekilde çalıştığını doğruladım.

Son olarak yapılan geliştirmeleri GitHub reposuna commit edip push ederek Milestone 1'i tamamladım.


## 03.08.2026 - Milestone 2 Patient(hasta sistemi)
Bu modülde;
* Patient entity sınıfı oluşturuldu.
* Hasta bilgileri için gerekli alanlar tanımlandı.
* IPatientRepository ve PatientRepository oluşturuldu.
* Hasta ekleme, güncelleme, silme ve listeleme işlemleri hazırlandı.
* TC kimlik numarasına göre hasta sorgulama işlemi eklendi.
* Hasta bilgilerinin veritabanına kaydedilmesi test edildi.

## 04.08.2026
* Appointment (randevu) entity sınıfı oluşturuldu.
* Randevunun hasta ve doktor ile ilişkileri tanımlandı.
* Randevu ekleme, ID'ye göre randevu getirme, Doktorun randevularını listeleme, Hastanın randevularını listeleme işlemleri geliştirildi.
* Randevunun geçmiş tarihe oluşturulması engellendi.
* Hastaların en fazla 10 gün sonrasına randevu alabilmesi sağlandı.
* Doktorun çalışmadığı günlere randevu oluşturulması engellendi.
* Doktorun çalışma saatleri kontrol edildi.
* Randevu başlangıç saatlerinin 30 dakikalık aralıklarda olması sağlandı. (bunu sistemde varsaydım)
* Randevu başlangıç ve bitiş saatleri otomatik hesaplandı.
Yapay zeka randevu başlangıç ve bitiş saatlerini hastanın seçeceği şekilde yaptı ama bu karmaşaya yol açardı randevu saatlerinin sabit olması gerekiyordu
bu yüzden doktorun çalışmaya başlama saatinden bitiş saatine kadar yarım saat aralıklarla randevu başlangıç saatleri belirledik hasta bu saatleri seçip randevu oluşturabilir.


## 07.08.2026
Bugün Milestone 2 kapsamında geliştirdiğim Appointment modülünün geliştirmelerine devam ettim ve modülü tamamladım.

Öncelikle randevuların oluşturulması sırasında uygulanması gereken iş kurallarını gözden geçirdim. 
Randevu oluşturulurken;
Hasta ve doktorun sistemde kayıtlı olup olmadığı kontrol edildi.
Geçmiş tarihe randevu alınması engellendi.
En fazla 10 gün sonrasına randevu alınabilmesi sağlandı.
Doktorun ilgili gün çalışıp çalışmadığı kontrol edildi.
Doktorun çalışma saatleri dışında randevu oluşturulması engellendi.
Randevuların 30 dakikalık sabit zaman aralıklarında başlaması sağlandı.
Aynı doktorun aynı saatte birden fazla randevusunun oluşturulması engellendi.

Ayrıca AppointmentRepository içerisinde doktor ve hasta bazlı randevu listeleme işlemlerini geliştirdim.

Swagger üzerinden;

Randevu oluşturma,
Doktorun randevularını listeleme,
Hastanın randevularını listeleme

işlemlerini test ettim.

Testler sırasında randevu bilgilerinin doğru şekilde veritabanına kaydedildiğini ve ilişkili hasta/doktor bilgilerinin doğru şekilde getirildiğini kontrol ettim.

Aldığım karar: Randevu saatlerinin kullanıcı tarafından tamamen serbest şekilde girilmesi yerine, doktorun çalışma saatleri içerisinde 30 dakikalık sabit aralıklar oluşturulmasına karar verdim. Böylece hem kullanıcı deneyiminin daha anlaşılır olması hem de randevu çakışmalarının daha kolay kontrol edilebilmesi sağlandı.

AI Kullanımı: Randevu oluşturma sırasında uygulanabilecek iş kurallarının kontrol edilmesi, repository sorgularının hazırlanması ve hata ayıklama süreçlerinde AI'dan teknik destek aldım.
## 08.08.2026

Bugün Milestone 3 kapsamında randevuların yaşam döngüsünü yönetmeye başladım.

İlk olarak bir randevunun yalnızca oluşturulmuş durumda kalmasının yeterli olmadığını fark ederek randevunun mevcut durumunu takip edebilmek için AppointmentStatus enum'unu oluşturdum ve Appointment entity'sine Status alanını ekledim.

Ardından randevu durumlarını değiştirmek için CQRS yapısını kullanarak;

Randevuyu iptal etme,
Randevuyu tamamlandı olarak işaretleme,
Hastanın randevuya gelmediğini belirtme

işlemlerini geliştirdim.

Bu işlemler için ayrı command ve handler sınıfları oluşturdum. Özellikle randevu iptalinde, proje gereksinimlerinde belirtilen “randevu yalnızca 2 saat öncesine kadar iptal edilebilir” kuralını uyguladım. Tamamlanmış bir randevunun tekrar iptal edilmemesi gibi durum kontrollerini de ekledim.

Yaptığım değişiklikleri Entity Framework Core migration ile veritabanına aktardım ve Swagger üzerinden farklı randevuların durumlarını değiştirerek işlemlerin doğru çalıştığını kontrol ettim.

## 09.08.2026
Bugün Milestone 3 kapsamında doktorların izin günlerini sisteme ekledim ve doktor izinlerinin randevu sistemiyle olan ilişkisini kurdum.

İlk olarak doktorun izin tarihlerini temsil etmek için DoctorLeave entity'sini oluşturdum. Doktor, izin başlangıç tarihi ve izin bitiş tarihi arasındaki ilişkiyi modelledim.

Doktor izni oluşturulurken;

Doktorun sistemde bulunması,
İzin başlangıç tarihinin bitiş tarihinden önce olması,
Aynı tarih aralığında başka bir iznin bulunmaması
kontrollerini uyguladım.
API katmanında DoctorLeaveController oluşturarak doktor izni ekleme ve doktorun izinlerini listeleme işlemlerini Swagger üzerinden kullanılabilir hale getirdim.
Son olarak doktor izin kontrolünü randevu oluşturma sürecine entegre ettim. CreateAppointmentCommandHandler içerisinde randevu oluşturulmadan önce doktorun seçilen tarih aralığında izinli olup olmadığı kontrol ediliyor. Doktor izinliyse randevu oluşturulması engelleniyor.
Bu iş kuralını Swagger üzerinden test ettim. İzinli olduğu tarihe doktor için randevu oluşturmaya çalıştığımda sistemin randevuyu oluşturmayarak ilgili hata mesajını döndürdüğünü doğruladım.
Yapay zeka kodu hazırlarken izin tarihi için .Date kullanmıştı bu da girilen tarih ve saatin saat, dakika ve saniye kısımlarını sıfırlıyordu bu da sistemde açığa sebep oluyordu yapay zekanın bu eksiğini fark edip yapay zekadan da yardım alarak hemen düzelttim.
