<h3>Projenin Amacı</h3>

Bu proje, bir kliniğin telefon ve defter üzerinden yürüttüğü randevu süreçlerini dijital ortama taşımak amacıyla geliştirilmiştir. Mevcut yöntemde randevuların elle takip edilmesi; randevu çakışmaları, yanlış kayıtlar ve zaman kaybı gibi sorunlara neden olabilmektedir. Geliştirilecek sistem sayesinde hastalar uygun branş ve doktoru seçerek randevu oluşturabilecek, klinik çalışanları ise doktorların çalışma saatlerini ve randevularını daha düzenli bir şekilde yönetebilecektir. Böylece hem hasta memnuniyetinin artırılması hem de randevu yönetiminin daha güvenilir ve sürdürülebilir hale getirilmesi hedeflenmektedir.

<h3>Kapsam İçi</h3>

İlk sürümde aşağıdaki özellikler geliştirilecektir:

Branş yönetimi<br>
Doktor yönetimi<br>
Doktor çalışma saatlerinin yönetimi<br>
Hasta oluşturma<br>
Randevu oluşturma<br>
Randevu iptali<br>
Hastanın geçmiş randevularını görüntüleyebilmesi<br>
Doktorun randevularını görüntüleyebilmesi<br>
Randevu durumlarının (Oluşturuldu, Tamamlandı, İptal Edildi, Gelmedi) yönetilmesi<br>
Doktor izin günlerinin yönetimi<br>
Sistem içi bildirimlerin oluşturulması (SMS/e-posta yerine simülasyon)<br>

<h3>Kapsam Dışı</h3>

Aşağıdaki özellikler daha sonra geliştirilmek üzere ilk sürüm dışında bırakılmıştır:

SMS ve e-posta bildirimleri (Kurulum ve maliyet gerektirdiği için ilk sürümde sistem içi bildirim kullanılacaktır.)<br>
Kullanıcı girişi ve yetkilendirme (Müşteri isteğine göre hasta yalnızca T.C. Kimlik Numarası ve telefon bilgisiyle işlem yapacaktır.)<br>
Öncelikli hasta sistemi (Öncelikle temel randevu sürecinin doğru çalışması hedeflenmiştir.)
Ödeme sistemi (Randevu süreciyle doğrudan ilişkili olmadığı için ilk sürüme dahil edilmemiştir.)<br>
Randevu ücretlendirme ve faturalandırma<br>
Gelişmiş raporlama ve istatistik ekranları<br>


<h3>İlk Sürüm İçin Bitti Tanımı</h3>
İlk sürüm tamamlandığında;
Hasta, T.C. Kimlik Numarası ve telefon bilgisiyle sisteme kayıt oluşturarak uygun branş ve doktor için randevu alabilecektir.<br>
Sistem aynı doktor için aynı tarih ve saatte ikinci bir randevu oluşturulmasına izin vermeyecektir.<br>
Doktorun çalışma saatleri dışında randevu oluşturulamayacaktır.<br>
Hasta, kurallara uygun olması durumunda randevusunu iptal edebilecektir (randevu saatinden 2 saat öncesine kadar).<br> 
Klinik personeli doktorların çalışma saatlerini ve izin günlerini yönetebilecektir.<br>
Randevuların durumu (Oluşturuldu, Tamamlandı, İptal Edildi, Gelmedi) takip edilebilecektir. <br>

Bu özelliklerin eksiksiz ve iş kurallarına uygun şekilde çalışması, ilk sürümün tamamlandığını gösterecektir.

<h3>Varsayımlar</h3>

Varsayım 1: Her randevunun süresi 30 dakikadır.

Varsayım 2: Bir doktor aynı tarih ve saatte yalnızca bir hastaya randevu verebilir.

Varsayım 3: Hasta randevusunu en geç 2 saat öncesine kadar iptal edebilir.

Varsayım 4: Doktor izinli olduğu günlerde yeni randevu oluşturulamaz.

Varsayım 5: Hastalar sisteme kullanıcı hesabı oluşturmadan, T.C. Kimlik Numarası ve telefon bilgileriyle işlem yapacaktır.
