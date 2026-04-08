# Software Engineering Term Project: Unit Testing Implementation

Bu proje, Yazılım Mühendisliği dersi kapsamında geliştirilmiş bir Birim Testi (Unit Testing) ve yazılım doğrulama (software verification) uygulamasıdır. Proje, C# tabanlı temel algoritmaların ve veri yapılarının NUnit framework'ü kullanılarak uçtan uca test edilmesini amaçlamaktadır.

Tüm test senaryoları AAA (Arrange, Act, Assert) prensiplerine uygun olarak tasarlanmış olup, sınır değer analizleri (boundary value analysis) ve hata fırlatma (exception handling) durumlarını kapsamaktadır.

## Proje Modülleri

Proje temel olarak üç farklı iş mantığı bileşeninden ve bunların testlerinden oluşmaktadır:

* **DemeritPointsCalculator:** Sürücülerin hız limitlerine göre ceza puanlarını hesaplayan sistem. 65 km/s sınırı, her 5 km/s aşımında puan eklenmesi ve 12 puan sınırında ehliyetin askıya alınması durumlarını test eder.
* **FizzBuzz:** Geleneksel FizzBuzz algoritması. 3'e, 5'e ve 15'e bölünebilme kurallarının doğru çalışıp çalışmadığını farklı girdilerle (TestCase) doğrular.
* **Stack:** Özel olarak tasarlanmış bir Yığın (LIFO) veri yapısı. Push, Pop ve Peek metodlarının davranışı, eleman sayacının (Count) doğruluğu ve boş yığından eleman çekilmeye çalışıldığında fırlatılan istisnalar (InvalidOperationException vb.) test edilir.

---

## Kullanılan Teknolojiler

* **Çalışma Zamanı ve Dil:** .NET 8.0, C#
* **Test Framework:** NUnit (v3.14.0)
* **Test Adaptörü:** NUnit3TestAdapter (v4.5.0)
* **Test SDK:** Microsoft.NET.Test.Sdk (v17.8.0)

---

## Kurulum ve Çalıştırma

Projeyi yerel ortamınızda derlemek ve testleri koşturmak için bilgisayarınızda .NET 8.0 SDK'nın kurulu olması gerekmektedir.

**1. Repoyu Klonlayın**
```bash
git clone [https://github.com/ozdizlekli/TermProject2.git](https://github.com/ozdizlekli/TermProject2.git)
cd TermProject2
```
2. Bağımlılıkları Yükleyin (Restore)
Projedeki NUnit ve diğer gerekli paketleri yüklemek için:

```bash
dotnet restore
```
3. Projeyi Derleyin (Build)

```bash
dotnet build
```
4. Testleri Çalıştırın
Tüm birim testlerini konsol üzerinden koşturmak ve sonuçları görmek için:

```bash
dotnet test
```
## Proje Dizini ve Mimari
Proje, ana uygulama kodları ve test kodları olmak üzere standart .NET proje yapısına uygun olarak ikiye ayrılmıştır:

TermProject2/: Çözümün ana iş mantığını (DemeritPointsCalculator.cs, FizzBuzz.cs, Stack.cs) barındırır.

TermProject2.Tests/: NUnit kullanılarak yazılmış doğrulama sınıflarını (DemeritPointsCalculatorTests.cs, vb.) barındırır.

### Not: Derleme aşamasında otomatik oluşturulan bin/ ve obj/ klasörleri repoya dahil edilmemiştir. Sadece kaynak kodlar ve proje bağımlılık dosyaları (.csproj, .sln) bulunmaktadır.

## Dokümantasyon
Projenin teorik altyapısı, test senaryolarının belirlenme kriterleri ve yazılım mühendisliği yaklaşımları hakkında detaylı bilgi için dizinde bulunan SOFTWARE ENGINEERING TERM PROJECT.pdf dosyasını inceleyebilirsiniz.
