--Gamer Market Adımları--
--Core--
1)Ntier.Core C# Library açılır=>Entity Framework yüklenir.
1.1)Entity klasörü açılır.
1.1.1)IEntity açılır (Core Entity buradan miras alacaktır)
1.1.2)Core Entity açılır. Tüm entitylerin kullanacağı propertyler tanımlanır.
1.2)Enum Açılır, içerisine statuler eklenir.
1.3)Map açılır. temel entity propertylerinin maplemeleri yapılır(maximum karakter alanı vb...)
1.4)Service açılır.İçerisine ICoreService interface açılır.Her entity üzerinde çalışacak olan metotlar tanımlanır.

--Model--
2)Model C# Library açılır=>NTier.Core referanslara eklenir.
2.1)Option klasörü açılır.
2.1.1)AppUser,Category ve Product entityleri oluşturulur. Hepsi CoreEntity sınıfından miras almalıdır. Bu sayede ortak propertylere erişim sağlanacaktır.

--Map--
3)Map C# Library açılır.Entity Framework yüklenir,Referanslara Core ve Model eklenir.
3.1)Option Klasörü açılır.
3.1.1)Her entity için mapleme işlemleri gerçekleştirilir.(Category ve Product için ekstra ilişki durumu belirtilir.)

--Dal--
4)Dal katmanı oluşturulur. Context klasörü açılır içerisine Project COntext sınıfı oluşturulur.
4.1)Constructor ile db connection yazılır.
4.2)OnModelCreating override edilir ve mapler konfigürasyonlara eklenir.
4.3)SaveChanges override edilir ve yükleme aşamasında temel propertyler içerisinde değerler eklenir.
NOT:Ip yakalama gibi işlemler Utility Katmanı açılarak gerçekleştirilir. Projeye yararlı olacak genel sınıf ve metotlar bu katman içerisinde saklanır. Utility library Dal içerisine eklenmeli.

5)console üzerinden DAL projesi seçilerek enable-migrations -enableAutomaticMigrations yazılır. Arkasından problem yaşanmadıysa update-database yazılarak veri tabanı oluşturulur.
