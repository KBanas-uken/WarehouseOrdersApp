### Wymagania
System operacyjny: Windows 10 lub nowszy <br>
Środowisko uruchomieniowe: .NET SDK 9.0 <br>
Środowisko programistyczne: Visual Studio 2022 lub nowsze <br>
Serwer baz danych: Microsoft SQL Server <br>

**Wykorzystane technologie:** <br>
ASP.NET Core MVC <br>
ASP.NET Core Identity <br>
Entity Framework Core <br>

### Instalacja
Lokalne uruchomienie aplikacji jest możliwe za pomocą trybu debugowania Visual Studio lub z poziomu wiersza poleceń za pomocą komend: <br>
>dotnet restore<br>
>dotnet build<br>
>dotnet run<br>

Po uruchomieniu, aplikacja będzie dostępna lokalnie pod adresem *https://localhost:44321/*.

### Konfiguracja
Nazwa serwera: (localdb)\\mssqllocaldb <br>
Nazwa bazy danych: WarehouseOrdersDb <br>
<br>
Konfigurację należy sprawdzić w pliku */WarehouseOrdersApp/appsettings.json*

**Testowi użytkownicy:**
<br><br>**admin - pełny dostęp**
<br>login (e-mail): jonadmin@example.com
<br>hasło: 1Secretpassword
<br><br>
**zwykły użytkownik - dostęp do wszystkich formularzy z wyłączeniem AddProduct**
<br>login (e-mail): johnworker@example.com
<br>hasło: Johnny1

### Opis działania dla użytkownika końcowego:
Aplikacja umożliwia prowadzenie ewidencji stanu magazynowego personelowi przedsiębiorstwa. Zalogowany użytkownik ma możliwość dodawania wpisów o przyjęciu *(formularz Add Stock Entry)*
i wydawaniu *(Add Stock Issue)* towarów z magazynu, a rekordy zawierające nazwę produktu, ilość i czas dodania zostaną zapisane w bazie danych. Dostępny jest także formularz *Create an Order*,
służący wprowadzeniu nowego zamówienia z datą, nazwą klienta i zawartością. Administrator ma również możliwość skorzystania z formularza *Add Product*, co poszerzy ofertę magazynu w spisie i pozwoli
na używanie nowego produktu w innych formularzach, wraz z automatycznym nadaniem mu unikalnego numeru identyfikacyjnego. Wszystkie formularze są walidowane - system nie pozwoli np. przyjęcia
ujemnej ilości towaru lub wydania towaru bez zamówienia. Możliwa jest rejestracja za pomocą adresu e-mail oraz imienia i nazwiska. Wszystkie konta muszą być chronione hasłami składającymi się z 
przynajmniej 6 znaków, jednej wielkiej litery i jednej cyfry.



