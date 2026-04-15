# **Analiza i dizajn sistema**

_U nastavku je potrebno definisati sve potencijalne klase koje će se koristiti u sistemu. Za određivanje klasa koje će biti neophodne za rad sistema potrebno je koristiti specifikaciju sistema i prethodno kreirane dijagrame._

_Template za jednu klasu potrebno je iskopirati onoliko puta koliko je neophodno da bi se definisale sve klase u sistemu._

_Definicija klasa u sistemu_

---

**Naziv klase:** ApplicationUser : IdentityUser

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Bazna klasa za sve korisnike u sistemu. Nasljeđuje ASP.NET Core IdentityUser koji pruža ugrađene atribute za autentifikaciju (Id, UserName, Email, PhoneNumber, PasswordHash, SecurityStamp, itd.). Svi korisnici (Klijent, Majstor, Firma, Administrator) nasljeđuju ovu klasu direktno ili indirektno preko Izvršilac usluge.

**Atributi naslijeđeni iz IdentityUser (ne definišu se ponovo):**

Id (string), UserName, Email, PhoneNumber, PasswordHash, SecurityStamp, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount

**Dodatni atributi koje klasa posjeduje:**

| Naziv atributa     | Tip varijable | Dodatne napomene                                                      |
| ------------------ | ------------- | --------------------------------------------------------------------- |
| Ime                | String?       | Nullable — Firma koristi Naziv firme umjesto Ime/Prezime              |
| Prezime            | String?       | Nullable — Firma koristi Naziv firme umjesto Ime/Prezime              |
| Datum registracije | Date          | ☐ Atribut je statički ☐ Atribut je _enumeration_                      |
| Slika              | String?       | Profilna slika — putanja do uploadovane slike                         |

---

**Naziv klase:** Izvršilac usluge : ApplicationUser

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa predstavlja apstraktnu strukturu iz koje se nasljeđuju korisnici koji predstavljaju izvršioce usluga (Majstor, Firma). Nasljeđuje ApplicationUser.

**Atributi koje klasa posjeduje:**

| Naziv atributa         | Tip varijable | Dodatne napomene                                 |
| ---------------------- | ------------- | ------------------------------------------------ |
| Adresa                 | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Kucni broj             | Integer?      | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Prosječna ocjena       | Double (1-5)  | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Broj završenih poslova | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ |

Ostali atributi (Id, Email, PhoneNumber, Ime, Prezime, Datum registracije, Slika) su naslijeđeni iz ApplicationUser / IdentityUser.

**Naziv klase:** Firma : Izvršilac usluge

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa je jedna od osnovnih klasa u sistemu, učestvuje u svim sinhronim funkcionalnim zahtjevima u sistemu

**Atributi koje klasa posjeduje:**

| Naziv atributa                    | Tip varijable      | Dodatne napomene                                 |
| --------------------------------- | ------------------ | ------------------------------------------------ |
| Naziv firme                       | String (ogranicen) | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Min. broj zaposlenih              | Integer            | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Max. broj zaposlenih              | Integer            | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Status verifikacije               | Enum               | ☐ Atribut je statički ☒ Atribut je _enumeration_ |
| JIB (Jedinstveni ID)              | String             | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Radno vrijeme                     | String             |                                                  |
| Web stranica                      | String?            |                                                  |
| Datum osnivanja                   | Date?              |                                                  |
| O firmi                           | String?            |                                                  |
| Odgovorna osoba — ime i prezime   | String             | Vidljivo adminu, popunjava se iz verifikacije    |
| Odgovorna osoba — pozicija        | String             | Vidljivo adminu, popunjava se iz verifikacije    |
| Odgovorna osoba — email           | String             | Vidljivo adminu, popunjava se iz verifikacije    |
| Odgovorna osoba — mobilni telefon | String             | Vidljivo adminu, popunjava se iz verifikacije    |

Ostali atributi su naslijeđeni iz klase Izvršilac usluge.

**Naziv klase:** Majstor : Izvršilac usluge

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa je jedna od osnovnih klasa u sistemu, učestvuje u svim sinhronim funkcionalnim zahtjevima u sistemu

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                 |
| -------------- | ------------- | ------------------------------------------------ |
| O meni         | String?       | Slobodan tekst biografije na profilu majstora    |

Ostali atributi (Ime, Prezime, itd.) su naslijeđeni iz ApplicationUser preko Izvršilac usluge.

**Naziv klase:** Klijent : ApplicationUser

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa je jedna od osnovnih klasa u sistemu, učestvuje u svim funkcionalnim zahtjevima u sistemu, osim u zahtjevu "Upravljanje i uređivanje profila".

**Atributi koje klasa posjeduje:**

Svi atributi (Id, Ime, Prezime, Email, PhoneNumber, Datum registracije, Slika) su naslijeđeni iz ApplicationUser / IdentityUser. Klasa nema dodatne vlastite atribute.

**Naziv klase:** Administrator : ApplicationUser

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa je jedna od osnovnih klasa u sistemu, učestvuje u svim sinhronim funkcionalnim zahtjevima u sistemu

**Atributi koje klasa posjeduje:**

Svi atributi (Id, Ime, Prezime, Email) su naslijeđeni iz ApplicationUser / IdentityUser. Klasa nema dodatne vlastite atribute. Pristup admin funkcionalnostima se kontroliše putem Identity uloga (roles).

---

**Naziv klase:** Mjesto

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa je jedna od osnovnih klasa u sistemu, ne ispunjava direktno nijedan funkcionalni zahtjev.

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                 |
| -------------- | ------------- | ------------------------------------------------ |
| Jedinstveni ID | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_ |
| Naziv          | String        | ☒ Atribut je statički ☐ Atribut je _enumeration_ |

---

**Naziv klase:** KorisnikMjesto

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 07: Upravljanje i uređivanje profila)

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                                            |
| -------------- | ------------- | --------------------------------------------------------------------------- |
| ID             | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| KorisnikID     | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| MjestoID       | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ |

---

**Naziv klase:** KorisnikKategorija

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 07: Upravljanje i uređivanje profila)

Junction tabela koja omogućava Many-to-Many vezu između korisnika (Majstor, Firma) i kategorija. Majstor bira do 5 zanimanja, Firma bira do 5 djelatnosti pri registraciji (UI str. 15–17).

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                                            |
| -------------- | ------------- | --------------------------------------------------------------------------- |
| ID             | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| KorisnikID     | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| KategorijaID   | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ |

---

**Naziv klase:** OglasKategorija

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)

Junction tabela koja omogućava Many-to-Many vezu između oglasa i kategorija. Oglas može pripadati više kategorija (UI str. 12 — dropdown za kategoriju na formi oglasa).

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                                            |
| -------------- | ------------- | --------------------------------------------------------------------------- |
| ID             | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| OglasID        | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ |
| KategorijaID   | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ |

---

**Naziv klase:** OglasUser  

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 05: Verifikacija profila pri registraciji putem maila)  
(FZ br. 08: Automatsko zatvaranje neaktivnih oglasa)

Junction tabela koja povezuje korisnike sa oglasima (vlasništvo).

**Atributi koje klasa posjeduje:**

| Naziv atributa     | Tip varijable | Dodatne napomene                                                            |
| ------------------ | ------------- | --------------------------------------------------------------------------- |
| ID veze oglas-user | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| OglasID            | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ |
| UserID             | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |

---

**Naziv klase:** Oglas

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

Klasa predstavlja osnovnu apstraktnu strukturu iz koje se nasljeđuju različiti tipovi oglasa. Ne posjeduje direktno funkcionalne zahtjeve.

**Atributi koje klasa posjeduje:**

| Naziv atributa       | Tip varijable              | Dodatne napomene                                                            |
| -------------------- | -------------------------- | --------------------------------------------------------------------------- |
| Naslov               | string (ogranicena duzina) | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Opis                 | string (ogranicena duzina) | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Datum objave         | Date                       | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| ID oglasa (privatno) | int                        | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| VlasnikOglasaID      | string                     | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Mjesto               | string                     | ☐ Atribut je statički ☒ Atribut je _enumeration_                            |
| Broj prijava         | int                        | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Slika                | String                     | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |

**Naziv klase:** Oglas za radno mjesto : Oglas

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)

**Atributi koje klasa posjeduje:**

| Naziv atributa           | Tip varijable | Dodatne napomene                                 |
| ------------------------ | ------------- | ------------------------------------------------ |
| Broj traženih izvršilaca | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| OglasVozackeDozvoleID    | int           | ☐ Atribut je statički ☒ Atribut je _enumeration_ |
| VrstaZaposlenjaID        | int           | ☐ Atribut je statički ☒ Atribut je _enumeration_ |
| Datum isteka oglasa      | Date          | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Minimalni prihod         | int           |                                                  |
| Maksimalni prihod        | int           |                                                  |
| TipIsplateID             | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ |

Ostali atributi su naslijeđeni iz klase Oglas.

**Naziv klase:** Oglas za uslugu : Oglas

**Funkcionalni zahtjevi u kojima klasa učestvuje:**  
(FZ br. 01: Postavljanje oglasa za popravke)  
(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)  
(FZ br. 08: Automatsko zatvaranje neaktivnih oglasa)

**Atributi koje klasa posjeduje:**

| Naziv atributa      | Tip varijable | Dodatne napomene                                                            |
| ------------------- | ------------- | --------------------------------------------------------------------------- |
| Telefon             | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Email               | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Minimalni budžet    | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Maksimalni budžet   | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| PonudeOglasUslugeID | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☐ Atribut je _foreign key_ |

Ostali atributi su naslijeđeni iz klase Oglas.

**Naziv klase:** Promotivni oglas majstora : Oglas

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 01: Postavljanje oglasa za popravke)  
(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)  
(FZ br. 08: Automatsko zatvaranje neaktivnih oglasa)  

**Atributi koje klasa posjeduje:**

Ostali atributi su naslijeđeni iz klase Oglas.

| Naziv atributa | Tip varijable | Dodatne napomene                                 |
| -------------- | ------------- | ------------------------------------------------ |
| min. Cijena    | double?       | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| TipIsplateID   | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ |

**Naziv klase:** Recenzija

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 03: Sistem recenzija i ocjenjivanja usluga)  
(FZ br. 04: Rangiranje i statistika o majstorima na platformi na osnovu filtera)

**Atributi koje klasa posjeduje:**

| Naziv atributa      | Tip varijable | Dodatne napomene                                                            |
| ------------------- | ------------- | --------------------------------------------------------------------------- |
| KlijentID           | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| IzvršilacUslugeID   | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Ocjena              | enum          | ☐ Atribut je statički ☒ Atribut je _enumeration_                            |
| Komentar            | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Datum recenzije     | Date          | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Prijavljena         | bool          |                                                                             |
| Razlog prijave      | String?       |                                                                             |
| Datum prijave       | Date?         |                                                                             |
| Status prijave      | Enum?         |                                                                             |

**Naziv klase:** Kategorija

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 01: Postavljanje usluga za popravke)  
(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 03: Rangiranje i statistika o majstorima na platformi na osnovu filtera)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)  
(FZ br. 07: Upravljanje i uređivanje profila)

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable | Dodatne napomene                                 |
| -------------- | ------------- | ------------------------------------------------ |
| Naziv          | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Opis           | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ |

**Naziv klase:** Ponuda za izvršavanje usluge

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 01: Postavljanje oglasa za popravke)  
(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 03: Sistem recenzija i ocjenjivanja usluga)

**Atributi koje klasa posjeduje:**

| Naziv atributa           | Tip varijable     | Dodatne napomene                                                            |
| ------------------------ | ----------------- | --------------------------------------------------------------------------- |
| IzvršilacID              | string            | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| KlijentID                | string            | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Datum slanja ponude      | Date              | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Datum očekivanog početka | Date              | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Datum očekivanog kraja   | Date?             | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Cijena                   | double            | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| StatusPonude             | int               | ☐ Atribut je statički ☒ Atribut je _enumeration_                            |
| TipIsplateID             | int               | ☐ Atribut je statički ☒ Atribut je _enumeration_                            |
| Poruka klijentu          | String? (max 500) |                                                                             |

**Naziv klase:** Prijava za radno mjesto

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)

**Atributi koje klasa posjeduje:**

| Naziv atributa | Tip varijable           | Dodatne napomene                                                            |
| -------------- | ----------------------- | --------------------------------------------------------------------------- |
| Oglas          | Oglas za radno mjesto\* | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| MajstorID      | string                  | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Datum prijave  | Date                    | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |

**Naziv klase:** Radno iskustvo

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)  
(FZ br. 04: Rangiranje i statistika o majstorima)  
(FZ br. 06: Pretraga usluga s mogućnošću filtriranja)  
(FZ br. 07: Upravljanje i uređivanje profila)

**Atributi koje klasa posjeduje:**

| Naziv atributa       | Tip varijable      | Dodatne napomene                                 |
| -------------------- | ------------------ | ------------------------------------------------ |
| Opis radnog iskustva | String (ogranicen) | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Datum pocetka        | Date               | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Datum zavrsetka      | Date               | ☐ Atribut je statički ☐ Atribut je _enumeration_ |
| Naziv firme/firmi    | string             | ☐ Atribut je statički ☐ Atribut je _enumeration_ |

**Naziv klase:** Notifikacija

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 05: Verifikacija profila pri registraciji putem maila)  
(FZ br. 08: Automatsko zatvaranje neaktivnih oglasa)

**Atributi koje klasa posjeduje:**

| Naziv atributa  | Tip varijable      | Dodatne napomene                                                            |
| --------------- | ------------------ | --------------------------------------------------------------------------- |
| Id notifikacije | int                | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| PrimalacID      | string             | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Naslov          | String (ogranicen) | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Sadrzaj         | String (ogranicen) | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |
| Datum slanja    | date               | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |

---

**Naziv klase:** VerifikacijaFirme

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 05: Verifikacija profila pri registraciji putem maila)

Klasa predstavlja zahtjev za verifikaciju firme. UI (str. 24/25) prikazuje kompletnu formu sa podacima o firmi, odgovornoj osobi i dokumentacijom.

**Atributi koje klasa posjeduje:**

| Naziv atributa                    | Tip varijable | Dodatne napomene                                                               |
| --------------------------------- | ------------- | ------------------------------------------------------------------------------ |
| ID verifikacije                   | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                               |
| FirmaID                           | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Naziv firme                       | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| JIB                               | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Sjediste firme                    | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Kontakt telefon                   | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Web stranica                      | String?       | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Odgovorna osoba — ime i prezime   | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Odgovorna osoba — pozicija        | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Odgovorna osoba — email           | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Odgovorna osoba — mobilni telefon | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| Rjesenje o registraciji           | String        | Putanja do uploadovanog fajla (obavezno)                                       |
| Uvjerenje o poreznoj registraciji | String        | Putanja do uploadovanog fajla (obavezno)                                       |
| Licenca / certifikat djelatnosti  | String?       | Putanja do uploadovanog fajla (opcionalno)                                     |
| Logo firme                        | String        | Putanja do uploadovanog fajla (obavezno)                                       |
| Datum podnosenja                  | Date          | ☐ Atribut je statički ☐ Atribut je _enumeration_                               |
| StatusID                          | int           | ☐ Atribut je statički ☒ Atribut je _enumeration_ — NaCekanju/Odobrena/Odbijena |
| Datum obrade                      | Date?         | ☐ Atribut je statički ☐ Atribut je _enumeration_ — nullable, popunjava admin   |

---

**Naziv klase:** PortfolioSlika

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 07: Upravljanje i uređivanje profila)

Klasa predstavlja pojedinačnu sliku u portfoliju izvršioca usluge.

**Atributi koje klasa posjeduje:**

| Naziv atributa    | Tip varijable | Dodatne napomene                                                            |
| ----------------- | ------------- | --------------------------------------------------------------------------- |
| ID                | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                            |
| IzvršilacUslugeID | string        | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_ — FK na ApplicationUser.Id |
| Slika URL         | String        | Putanja do uploadovane slike                                                |
| Opis              | String?       | ☐ Atribut je statički ☐ Atribut je _enumeration_ — opcionalni opis slike    |
| Datum dodavanja   | Date          | ☐ Atribut je statički ☐ Atribut je _enumeration_                            |

---

**Naziv klase:** UvjetOglasa

**Funkcionalni zahtjevi u kojima klasa učestvuje:**

(FZ br. 02: Kategorizacija zanimanja)

Klasa predstavlja pojedinačni uvjet na oglasu za radno mjesto. UI (str. 12) prikazuje formu sa "+ Dodaj uvjet" funkcionalnosti gdje se uvjeti dodaju pojedinačno (maksimalno 3).

**Atributi koje klasa posjeduje:**

| Naziv atributa     | Tip varijable | Dodatne napomene                                                                          |
| ------------------ | ------------- | ----------------------------------------------------------------------------------------- |
| ID                 | int           | ☒ Atribut je statički ☐ Atribut je _enumeration_                                          |
| OglasRadnoMjestoID | int           | ☐ Atribut je statički ☐ Atribut je _enumeration_ ☒ Atribut je _foreign key_               |
| Tekst              | String        | ☐ Atribut je statički ☐ Atribut je _enumeration_ — npr. "Vozačka dozvola kategorije C/CE" |
