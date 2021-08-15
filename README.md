## QuizEmployeeLister
##### Bu Projede Oracle Database üzerindeki çalışan verisinin listeleneceği bir sayfa geliştirme amaçlanmıştır.

Kurulum

>DBPrepareCommands.txt SQL script i databasede HR şeması üzerinde bir kez çalıştırılmalıdır.
>NetFrameworkSoapApi klasörü içerisindeki Webconfig kontrol edilmeli ve gerekli bilgiler girilmelidir.


Beklentiler

•	PLSQL prosedür/fonksiyon kullanarak HR şemasında bulunan çalışanların aşağıda belirtilen kritere göre alfabetik olarak cursor'a alınması.
>HR şemasına GETALLEMPLOYEES adında bir procedür yazılarak veriler cursor a alındı.

•	IT departmanında maaşı 4200'ün üzerinde olan kişilerin adı, soyadı, pozisyonu (title olarak), eğer mevcutsa bir önceki pozisyonu (title olarak), çalıştıkları şehir ve yöneticilerinin tam isimleri mutlaka bu cursorda bulunmalıdır
>HR şemasında oluşturulan GETALLEMPLOYEES procedürü 2 adet parametre ile desteklendi(dep_id,salary).Bu parametler aracılığıyla storeprocedure e esnek bir şekilde veri gönderilebilmesi ve farklı sonuçlar alınabilmesi sağlandı.

•	Yeni bir log tablosu oluşturulması ve logların bu tabloya düzenli olarak aracı bir prosedür tarafından sürdürülebilir ve takip edilebilir bir şekilde girilmesi
>HR şemasına DB_LOGS adında bir tablo oluşturuldu ve INSERTLOG Adında bir procedür yaratılarak ilerde loglama yapılabilmesi sağlandı.

•	.NET Framework kullanılarak prosedürün çağırılabileceği bir SOAP API'nin yaratılması
>NET Framework SOAP API yaratıldı ve Oracle Database ile procedure ler üzerinden haberleşip verileri alması sağlandı.

•	React 17'de geliştirilmiş ve SOAP API'den elde edilen verinin işlenip tablolar aracılığıyla kullanıcılara gösterileceği bir Node.js uygulamasının geliştirilmesi
>NodeJs uygulaması(ServerSide) tamamlandı.NET Framework SOAP API 'ye istek atıp gelen cevaptan verileri alması temizlemesi ve işlemesi , ve sonrasında 
	Client uygulaması olan React a gönderilmesi tamamlandı.
	
	* Eksikler:
	React uygulama çalıştırıldığı zaman datanın geldiği görülemiyor.Gelen json veriyi doğru maplayıp ekrana gösterilmesi sağlanamadı.
	GoogleChrome-İncele fonksiyonu ile verilerin React içerisine geldiği görüntülenebilir durumda.
