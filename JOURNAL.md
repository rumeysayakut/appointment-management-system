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
