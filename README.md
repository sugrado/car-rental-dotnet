# Multitier architecture project. Daily car rental simulation.  

   <a href = "https://www.linkedin.com/in/sugrado/"><img src = "https://marka-logo.com/wp-content/uploads/2020/04/Linkedin-Logo.png" width = "85" height = "50" alt = "My Linkedin Profile"/></a>  
My e-mail address: gorkemarik2018@gmail.com
  
# Technologies and techniques  used in the project. (Projede kullanılan teknikler ve teknolojiler.)
- **N-Tier Architecture**  
- **AOP**  

- **"Entity Framework"**  
- **"Autofac"**  
- **"Fluent Validation"**  
- **"Json Web Token"**  
- **"API"**  
- **"LINQ"**  

- **Interceptors**  
- **Aspects**  
- **Repository Design Pattern**  
- **Custom Error Middleware**  
- **DTO's**  
- **Authorization System**  
- **Result structure in every part of the project**  
 
# Mar 29, 2021  
-->**(English)**
- Refactoring auth manager.  
- Erasability control for brands and colors.  
- Customer findex score control and management.  
- Change password feature.  
- For more information and Front-End visit my repository: [Daily Car Rental Project](https://github.com/sugrado/carrental-ng)  
  
-->**(Türkçe)**  
- Auth Manager dosyası yeniden düzenlendi.  
- Renk ve marka için silinebilme durumu kontrolü eklendi.  
- Müşteri findeks skoru kontrolü ve yönetimi, VIP müşteri durumları eklendi.  
- Şifre değiştirme özelliği yazıldı. Şifreyi değiştirebilmek için kullanıcı eski şifresini doğru girmelidir.  
- Daha fazla bilgi, projeden görseller ve front-end kodlarını görmek için bu depomu ziyaret edebilirsiniz: [Günlük Araç Kiralama Projesi](https://github.com/sugrado/carrental-ng)  
  
# Mar 24, 2021  
-->**(English)**
- Backend Custom Error Middleware added.  
- Payment feature added.  
- Fixed some bugs.  
  
-->**(Türkçe)**  
- Backend Custom Error Middleware sistemi yazıldı.  
- Ödeme yapma sistemi eklendi.  
- Hatalar düzeltildi.  
  
# Mar 17, 2021  
-->**(English)**
- Fixed GetImagesByCarId method.  
- Add "get car details by brand" method.  
- Add "get car details by color" method.  
  
-->**(Türkçe)**  
- GetImagesByCarId metodu düzeltildi.  
- Araç detaylarını marka id'sine göre çağırma özelliği eklendi.  
- Araç detaylarını renk id'sine göre çağırma özelliği eklendi.  
  
# Mar 5, 2021  
-->**(English)**
- Authorization system added.  
- JWT integration added.  
- Cache Aspect added.  
- Transaction Aspect added.  
- Performance Aspect added.  
  
-->**(Türkçe)**  
- Yetkilendirme sistemi eklendi.  
- JWT entegrasyonu yapıldı.  
- Cache Aaspect eklendi.  
- Transaction Aspect eklendi.  
- Performance Aspect eklendi.  
  
# Feb 28, 2021  
-->**(English)**
- Add CarImages table.  
- Add a picture to the car via the WebAPI.  
- Pictures stored with GUID.  
- Image deletion, update capabilities added.  
- A car can have up to 5 images.  
- The date of the picture upload is determined automatically.  
- The default image is shown for vehicles without photos.  
  
-->**(Türkçe)**  
- CarImages tablosu eklendi.  
- WebAPI aracılığıyla her araca özel resim ekleme özelliği.  
- Resimlerin ismi ne olursa olsun yeniden isimlendirilip GUID şeklinde kaydolur.  
- Resim silme ve güncelleme özellikleri eklendi.  
- Bir aracın en fazla 5 tane fotoğrafı olabilir.  
- Fotoğrafın yüklenme tarihi otomatik olarak şimdiki zamandır.  
- Fotoğrafı olmayan araçlar için varsayılan bir resim gösterilir.  
  
# Feb 20, 2021  
-->**(English)**
- "AOP" support added.  
- ValidationAspect added.  
- "FluentValidation" support added.  
- "Autofac" support added.  
  
-->**(Türkçe)**  
- "AOP" desteği eklendi.  
- ValidationAspect eklendi.  
- FluentValidation desteği eklendi.  
- "Autofac" desteği eklendi.  
  
# Feb 15, 2021  
-->**(English)**
- "WebAPI" layer was established.  
- All services in the business layer were written for APIs.  
- GetById method added for rentals.  
  
-->**(Türkçe)**  
- WebAPI katmanı oluşturuldu.  
- Business katmanındaki tüm fonksiyonlar WebAPI için yazıldı.  
- Kiralamalar için GetById metodu eklendi.  
  
# Feb 14, 2021  
-->**(English)**
- "Results" configuration created in "Core" layer.  
- "Business" classes have been refactored.  
- Created "Users" table.  
- Created "Customers" table.  
- Created "Rentals" table.  
- The necessary conditions have been added for renting a car.  
  
-->**(Türkçe)**  
- "Result" konfigürasyonu Core katmanında oluşturuldu.  
- "Business" sınıfı refactor edildi.
- "Users" tablosu oluşturuldu.  
- "Customers" tablosu oluşturuldu.  
- "Rentals" tablosu oluşturuldu.  
- Araç kiralamak için bazı şartlar eklendi.
  
# Feb 7, 2021  
-->**(English)**
- Fixed GetById method and made available for each object.  
- Globel Core layer added.  
- Some universal interfaces moved to the Core layer.  
- Dto used.  
- Added all CRUD operations for Car, Brand and Color objects.  
- GetCarDetails method was added by joining 3 tables in the database.  
- GetCarDetails method is used in program.cs.  
  
-->**(Türkçe)**  
- GetById metodu düzeltildi ve her nesne için kullanılabilir hale getirildi.  
- Core katmanı oluşturuldu.  
- Global interface'ler Core katmanına taşındı.  
- DTO yapıları oluşturuldu.  
- Tüm nesneler için CRUD operasyonları işleme sunuldu.  
- GetCarDetails metodu eklendi. (3 farklı tablo join edilerek DTO oluşturuldu.)  
- GetCarDetails metodunun kullanım örneği Program.cs'de kullanıma sunuldu.  
  
# Feb 5, 2021  
-->**(English)**
- Car update method added.  
- Adding each method's sample usage to Program.cs  
  
-->**(Türkçe)**  
- Araç güncelleme metodu eklendi.  
- Bazı metodların kullanımı Program.cs'ye eklendi.  
  
# Feb 4, 2021  
-->**(English)**
- Brand and Color objects have been added.  
- EntityFramework added.  
- GetCarsByBrandId and GetCarsByColorId methods added.  
- Some conditions have been added to add vehicles to the database.  
  
-->**(Türkçe)**  
- Marka ve renk objeleri eklendi.  
- EntityFramework desteği eklendi.  
- GetCarsByBrandId ve GetCarsByColorId metodları eklendi.  
- Veritabanına araç eklemek için bazı koşullar eklendi.  
# Feb 1, 2021  
-->**(English)**
- Add project files.  
  
-->**(Türkçe)**  
- Proje dosyalarının eklenmesi.