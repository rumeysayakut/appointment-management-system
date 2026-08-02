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

