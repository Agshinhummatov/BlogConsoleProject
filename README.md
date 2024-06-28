# BLog Application

Course Application is a console-based application for managing blogs, authors, and tags.

## Technologies Used

- C#
- Console Application

## Project Structure

This project follows the principles of Onion Architecture, aiming for a clean and modular design.

### Project Components

- **DomainLayer**: Contains entities (`Blog`, `Author`, `Tag`) and domain logic.
- **ServiceLayer**: Implements business logic and interfaces (`IBlogService`, `IAuthorService`, `ITagService`).
- **InfrastructureLayer**: Handles data access with repositories (`IBlogRepository`, `IAuthorRepository`, `ITagRepository`) and DbContext.
- **Application**: Contains application-specific logic, including console interactions (`ConsoleHelper`).
- **Presentation**: Houses console application entry points (`Program.cs`) and controllers (`BlogController`).

### Features

- **Create, Read, Update, Delete (CRUD)** operations for blogs, authors, and tags.
- **Search** functionality for blogs based on text.
- **Console-based** user interface for interaction.

## How to Run

To run the application:

1. Clone the repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution.
4. Set the console application (`CourseApplication`) as the startup project.
5. Run the application.


## Additional Notes

- Ensure you have .NET Core SDK installed.
- Modify `appsettings.json` in the InfrastructureLayer for database connection settings.


Azerbaijan 

# Blog Tətbiqi

Kurs Tətbiqi bloqları, müəllifləri və teqləri idarə etmək üçün konsol əsaslı proqramdır.

## İstifadə olunan Texnologiyalar

- C#
- Konsol Tətbiqi

## Layihənin Strukturu

Bu layihə təmiz və modul dizaynı hədəfləyən Onion Architecture prinsiplərinə əməl edir.

### Layihə Komponentləri

- **DomainLayer**: Tərkibləri ('Blog', 'Müəllif', 'Tag') və domen məntiqindən ibarətdir.
- **ServiceLayer**: Biznes məntiqi və interfeysləri həyata keçirir (`IBlogService`, `IAuthorService`, `ITagService`).
- **InfrastructureLayer**: Repozitoriyalar ('IBlogRepository', 'IAuthorRepository', 'ITagRepository') və DbContext ilə verilənlərə girişi idarə edir.
- **Tətbiq**: Konsolla qarşılıqlı əlaqə (`ConsoleHelper`) daxil olmaqla, proqrama xas məntiqi ehtiva edir.
- **Təqdimat**: Evlərin konsol tətbiqi giriş nöqtələri (`Program.cs`) və nəzarətçilər (`BlogController`).

### Xüsusiyyətləri

- **Bloqlar, müəlliflər və teqlər üçün yaradın, oxuyun, yeniləyin, silin (CRUD)** əməliyyatları.
- Mətnə əsaslanan bloqlar üçün **Axtar** funksiyası.
- Qarşılıqlı əlaqə üçün **Konsol əsaslı** istifadəçi interfeysi.

## Necə Qaçış

Tətbiqi işə salmaq üçün:

1. Repozitoriyanı klonlayın.
2. Həllini Visual Studio və ya seçdiyiniz IDE-də açın.
3. Həllini qurun.
4. Konsol tətbiqini (`CourseApplication`) başlanğıc layihəsi kimi təyin edin.
5. Proqramı işə salın.


Turkey :

# BLog Uygulaması

Kurs Uygulaması blogları, yazarları ve etiketleri yönetmek için kullanılan konsol tabanlı bir uygulamadır.

## Kullanılan Teknolojiler

- C#
- Konsol uygulaması

## Proje Yapısı

Bu proje, temiz ve modüler bir tasarımı amaçlayan Onion Mimarisinin ilkelerini takip ediyor.

### Proje Bileşenleri

- **DomainLayer**: Varlıkları ('Blog', 'Yazar', 'Etiket') ve etki alanı mantığını içerir.
- **ServiceLayer**: İş mantığını ve arayüzleri ('IBlogService', 'IAuthorService', 'ITagService') uygular.
- **InfrastructureLayer**: Depolarla (`IBlogRepository`, `IAuthorRepository`, `ITagRepository`) ve DbContext ile veri erişimini yönetir.
- **Uygulama**: Konsol etkileşimleri ("ConsoleHelper") dahil olmak üzere uygulamaya özel mantığı içerir.
- **Sunum**: Konsol uygulaması giriş noktalarını ("Program.cs") ve denetleyicileri ("BlogController") barındırır.

### Özellikler

- **Bloglar, yazarlar ve etiketler için **Oluşturma, Okuma, Güncelleme, Silme (CRUD)** işlemleri.
- Metne dayalı bloglar için **Arama** işlevi.
- Etkileşim için **konsol tabanlı** kullanıcı arayüzü.

## Nasıl Çalıştırılır

Uygulamayı çalıştırmak için:

1. Depoyu klonlayın.
2. Çözümü Visual Studio'da veya tercih ettiğiniz IDE'de açın.
3. Çözümü oluşturun.
4. Konsol uygulamasını (`CourseApplication`) başlangıç ​​projesi olarak ayarlayın.
5. Uygulamayı çalıştırın.

