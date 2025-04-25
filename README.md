# 🍽️ **Thread Restaurant Simulation**

## 📌 **Proje Tanımı**

Bu proje, **C#** programlama dili kullanılarak çoklu iş parçacığı (multithreading) tekniğiyle bir restoran simülasyonu oluşturulmuştur. Restoranın mutfak ve servis bölümleri eş zamanlı olarak çalışan iş parçacıklarıyla modellenmiştir. Müşteriler sırayla sipariş verirken, aşçılar yemekleri hazırlamakta ve servis elemanları yemekleri masalara ulaştırmaktadır. Simülasyon, restoranın her aşamasını gerçekçi bir şekilde taklit ederek, paralel işlemlerle çoklu görevlerin nasıl yönetildiğini gösterir.

Bu simülasyonun temel amacı, eş zamanlı işlemleri ve kaynak paylaşımını modellemek ve bu süreçleri iş parçacıkları arasında nasıl koordine edileceğini anlamaktır. Simülasyonda her iş parçası belirli bir işlevi yerine getirecek şekilde tanımlanmıştır:

- **Müşteri:** Restorana gelen ve sipariş veren kişidir. Her müşteri, bir iş parçacığı olarak işlenir ve sırasıyla yemek siparişi verir.
- **Aşçı:** Siparişleri alıp yemekleri hazırlayan kişidir. Her aşçı da bir iş parçacığı olarak görev yapar, yemekleri hazırlarken mutfaktaki işlemler paralel olarak gerçekleştirilir.
- **Servis Elemanı:** Hazırlanan yemekleri müşterilere masalarına ulaştıran kişidir. Servis elemanı iş parçacığı, yemekleri hızlı bir şekilde masalara ulaştırmak için zamanlamayı düzenler.

### **Simülasyonun Temel Özellikleri:**
- **İş Parçacığı Yönetimi:** Her görev (müşteri, aşçı, servis elemanı) için ayrı iş parçacıkları oluşturulur. Bu sayede her bir görev paralel olarak çalışabilir.
- **Senkronizasyon:** İş parçacıkları arasındaki senkronizasyon sağlanarak her görev doğru sırayla ve zamanında tamamlanır. Örneğin, servis elemanı yemeği ancak aşçı yemeği hazırladıktan sonra teslim edebilir.
- **Kaynak Paylaşımı:** Aynı anda birden fazla aşçı yemek hazırlarken, mutfak kaynakları (örneğin, pişirme alanları) doğru bir şekilde paylaşılır ve birbirini engellemeden verimli çalışabilirler.
- **Zaman Yönetimi:** Müşteri siparişi verildikten sonra, aşçılar yemekleri hazırlamak için bir süre bekler ve ardından servis elemanları yemeği hızla masaya ulaştırır. Bu süreçler, iş parçacıkları arasındaki zaman yönetimiyle gerçekleştirilir.

Simülasyon, restoranın günlük operasyonlarını modelleyerek eş zamanlı işlemlerin ne kadar verimli yönetilebileceğini ve aynı anda birden fazla işlemin nasıl koordineli bir şekilde çalıştığını gösterir. Bu tür bir sistem, daha büyük yazılım projelerinde çoklu iş parçacığı kullanımının önemini ve avantajlarını anlamak için ideal bir örnek teşkil eder.

### **Proje Detayları:**
- **İş Parçacıkları ve Paralel İşlemler:** Restoranın her bir bölümünde eş zamanlı çalışan iş parçacıklarıyla işlemler paralel bir şekilde yönetilir.
- **Senkronizasyon Mekanizmaları:** İş parçacıkları arasındaki koordinasyonu sağlamak için senkronizasyon teknikleri kullanılır. Bu, özellikle aşçıların yemekleri hazırlarken servis elemanlarının işini beklemeleri ve kaynakların paylaşıldığı alanlarda yaşanabilecek çakışmaların önüne geçilmesi için önemlidir.
- **Verimli Kaynak Kullanımı:** Aşçılar ve servis elemanları, sınırlı kaynaklarla en verimli şekilde çalışacak şekilde programlanmıştır, böylece restoranın tüm süreçleri düzenli bir şekilde işleyebilir.

Bu proje, gerçek zamanlı çoklu görev simülasyonlarını daha iyi anlayabilmek ve eş zamanlı iş parçacıklarını etkin bir şekilde yönetebilmek için güçlü bir araçtır. Restoran simülasyonu üzerinden eş zamanlı işlemler ve kaynak paylaşımı gibi kritik yazılım kavramları öğrenilebilir.

