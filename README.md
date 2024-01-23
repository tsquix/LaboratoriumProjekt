# Dokumentacja projektu ASP.NET

## Lista wykorzystanych technologii:
- Microsoft.AspNet.Identity.Entity Framework: 2.2.4
- Microsoft.AspNetCore.Identity.EntityFrameworkCore: 8.0.1
- Microsoft.EntityFrameworkCore: 8.0.1
- Microsoft.EntityFrameworkCore.Design: 8.0.1
- Microsoft.EntityFrameworkCore.Sqlite: 8.0.1

## Przykładowe dane użytkowników:
### Rola Admin
- **login:** adam@wsei.pl
- **hasło:** 1234abcd!@

### Rola User
- **login:** maciek@wsei.pl
- **hasło:** maciek123!

## Proces Uruchomienia Aplikacji w Wersji Deweloperskiej:
1. Migracja Bazy Danych:
   - Uruchom konsolę Menedżera Pakietów w Visual Studio.
   - Wprowadź komendę 'dotnet ef database update' w celu zastosowania migracji bazy danych.

2. Uruchomienie Aplikacji:
   - W Visual Studio, uruchom projekt, naciskając klawisz F5.
   - Alternatywnie, użyj komendy 'dotnet run' w konsoli.
