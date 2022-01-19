Merhaba,

Proje geliştirmesinde çoğu tekniği ve yapıları ilk kez kullanarak yaptım bu yönden öğrenme ve
uygulama sürecim daha zor olduğundan bazı kısımlarda eksiklikler ve yanlışlıklar olduğunun farkındayım. 
İncelemenizde bunu göz önünde bulundurup eksik ve yanlış kısımları hakkında bana geri dönüşlerinizi 
bildirirseniz yanlışlarımı ve eksiklerimi öğrenenerek kendimi geliştirmem konusunda bana yardımcı olursunuz.

Proje adımlarında ilk önce database'de iki tablo oluşturdum
-dbo.Users : Kişi bilgilerinin tutulduğu tablo
-dbo.CantactInformation : Kişilere ailt iletişim bilgilerinin tutulduğu tablo

Visul Studio da .Net Core projesei oluşturarak db bağlantısını oluşturdum.
Controller a eklediğim 
UsersController.cs ve CantactInformationsController.cs lerde GET/POST/PUT/DELETE metotlerını oluşturdum
metotların testti için Swagger kütüphanesini kullandım.

Projede yapabildiğim kısımlardan en çok Unit test kısmında zorlandım.
her iki tablonun servislerini Services folderı altında oluşturdum. Test projesinde iki ayrı cs içersinde (UserTest ve
CantactInformationTest)  test metotlarını ekledim.
