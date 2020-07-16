using Audiofile.Migrations;
using Audiofile.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Audiofile.DAL
{
    public class UrzadzeniaInitializer : MigrateDatabaseToLatestVersion<UrzadzeniaContext, Configuration>
    {
 
        public static void SeedUrzadzeniaData(UrzadzeniaContext context)
        {

            var kategorie = new List<Kategoria>
            {
               new Kategoria() { KategoriaId=1, NazwaKategorii="Sluchawki", NazwaPlikuIkony="sluchawki.png", OpisKategorii="Sluchawki lalalaalal" },
                new Kategoria() { KategoriaId=2, NazwaKategorii="Glosniki", NazwaPlikuIkony="glosniki.png", OpisKategorii="Glosniki lalaal" },
                new Kategoria() { KategoriaId=3, NazwaKategorii="Mikrofony", NazwaPlikuIkony="mikrofony.png", OpisKategorii="Mikrofony lalalalla" },
                new Kategoria() { KategoriaId=4, NazwaKategorii="Akcesoria", NazwaPlikuIkony="akcesoria.png", OpisKategorii="Akcesoriaa lalala" },
               };
            kategorie.ForEach(k => context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();

            var urzadzenia = new List<Urzadzenie>
            {
                new Urzadzenie() { UrzadzenieId=1, NazwaUrzadzenia="Głośnik Bluetooth JBL Charge 4 Czarny", ProducentUrzadzenia="JBL", KategoriaId=2, CenaUrzadzenia=539,NazwaPlikuObrazka="3.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="JBL Charge 4 to kolejna generacja wodoodpornego głośnika pełniącego także funkcję powerbanku. JBL Charge 4 to bezprzewodowy głośnik, który można obsługiwać przez Bluetooth bez kłopotów z przewoda"},

               new Urzadzenie() { UrzadzenieId=2, NazwaUrzadzenia="Głośnik Bluetooth JBL Charge 3 Stealth Edition Czarny", ProducentUrzadzenia="JBL", KategoriaId=2, CenaUrzadzenia=439, NazwaPlikuObrazka="4.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="JBL Charge 3 to doskonały, wysokiej jakości przenośny głośnik Bluetooth z potężnym dźwiękiem stereo i ładowarką, wszystko w jednym pakiecie."},

                new Urzadzenie() { UrzadzenieId=3, NazwaUrzadzenia="Słuchawki bezprzewodowe JBL Live 400BT Czarny", ProducentUrzadzenia="JBL", KategoriaId=1, CenaUrzadzenia=518, NazwaPlikuObrazka="5.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Rewelacyjna jakość dźwięku przy zachowaniu łatwości użytkowania, nienarzucającym się designie i funkcjonalności – to właśnie słuchawki nauszne JBL Live 400BT."},

                 new Urzadzenie() { UrzadzenieId=4, NazwaUrzadzenia="Słuchawki przewodowe HUAWEI AM115 Biały", ProducentUrzadzenia="HUAWEI", KategoriaId=1, CenaUrzadzenia=29, NazwaPlikuObrazka="7.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Przewodowe słuchawki stereofoniczne, przeznaczone do słuchania muzyki i obsługi rozmów telefonicznych. Wyposażone w regulację głośności oraz mikrofon umieszczony na przewodzie."},

                new Urzadzenie() { UrzadzenieId=5, NazwaUrzadzenia="MIkrofon GENESIS Radium 200", ProducentUrzadzenia="GENESIS", KategoriaId=3, CenaUrzadzenia=119, NazwaPlikuObrazka="6.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Każdy młody twórca internetowy czy gracz wie, że dobry mikrofon to podstawa, aby wynieść swoja twórczość na wyższy poziom. Dlatego mikrofon to ważny element wyposażenia. Specjalnie z myślą o tym Genesis stworzył Radium 200, mikrofon kierunkowy o dobrych parametrach przetwarzania dźwięku, idealny do każdego domowego studia nagrań czy stanowiska gracza."},

                 new Urzadzenie() { UrzadzenieId=6, NazwaUrzadzenia="Mikrofon GENESIS Radium 600", ProducentUrzadzenia="GENESIS", KategoriaId=3, CenaUrzadzenia=600, NazwaPlikuObrazka="2.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Myślisz o tym jak rozwinąć swój kanał na YouTube albo ulepszyć jakość swoich transmisji on-line? Nic prostszego. Genesis Radium 600 to wysokiej jakości mikrofon studyjny z bogatym wyposażaniem oraz funkcjonalnością, która zadowoli każdego, początkującego jak i już zaawansowanego streamer'a. Zestaw składa się z mikrofonu, statywu wraz z elementami mocującymi, pop-filtrem, statywem oraz gąbką."},

                new Urzadzenie() { UrzadzenieId=7, NazwaUrzadzenia="Ładowarka BIONIK BNK-9019 Tetra Power do kontrolerów Joy Con do Nintendo Switch", ProducentUrzadzenia="BIONIK", KategoriaId=4, CenaUrzadzenia=111, NazwaPlikuObrazka="1.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="4 portowa ładowarka do kontrolerów Joy Con! Unikalna krzyżowa forma ładowarki, zapewni Ci optimum ładowania, przy minimalnym rozmiarze. Ładuj do 4 kontrolerów na raz."},

                new Urzadzenie() { UrzadzenieId=8, NazwaUrzadzenia="Kabel Audio Micro", ProducentUrzadzenia="UNITEK", KategoriaId=4, CenaUrzadzenia=29, NazwaPlikuObrazka="accesories_1.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Unitek Y-C922ABK to kabel przekazujący sygnał audio, który umożliwia podłączenie urządzenia wyposażonego w gniazdo minijack 3,5mm do innego urządzenia posiadającego również gniazdo minijack 3,5mm. Dzięki temu możliwe jest podłączenie np. komputera lub smartfona do wieży."},

                new Urzadzenie() { UrzadzenieId=9, NazwaUrzadzenia="Kabel Audio Micro", ProducentUrzadzenia="PHILIPS", KategoriaId=4, CenaUrzadzenia=59, NazwaPlikuObrazka="accesories_2.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Zwiększ swoje opcje odtwarzania muzyki dzięki temu wszechstronnemu stereofonicznemu przewodowi audio 3.5 mm. Kabel szybko łączy smartfony, odtwarzacze MP3, tablety lub inne przenośne urządzenia audio z portem wejściowym AUX np. radia samochodowego, przenośnego głośnika lub innego kompatybilnego urządzenia."},

                new Urzadzenie() { UrzadzenieId=10, NazwaUrzadzenia="Kabel RCA", ProducentUrzadzenia="ROAE", KategoriaId=4, CenaUrzadzenia=69, NazwaPlikuObrazka="accesories_3.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Kabel o wysokiej jakości i precyzji wykonania. Metalowe złącza pokryte są złotem natomiast ich obudowy wykonano z aluminium. Przewód sygnałowy wyprodukowano z miedzi beztlenowej OFC o wysokiej czystości. Dzięki zastosowaniu tego najwyższej jakości materiału uzyskano ekstremalnie niską pojemność przewodu."},

                new Urzadzenie() { UrzadzenieId=11, NazwaUrzadzenia="SLUCHAWKI NAUSZNE BOSE", ProducentUrzadzenia="BOSE", KategoriaId=1, CenaUrzadzenia=599, NazwaPlikuObrazka="headphones_1.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Model Bose Headphones 700 to luksusowe słuchawki bezprzewodowe uznanej marki BOSE. Dzięki wykorzystaniu specjalnego systemu mikrofonów Twoje rozmowy zawsze będą wyraźne, a dzięki aplikacji Bose Music w bardzo prosty sposób możesz zarządzać ustawieniami urządzenia. Nowoczesny i oryginalny design tych słuchawek idealnie dopasuje się do Twojego stylu bycia."},

                new Urzadzenie() { UrzadzenieId=12, NazwaUrzadzenia="SLUCHAWKI NAUSZNE STAR", ProducentUrzadzenia="STAR", KategoriaId=1, CenaUrzadzenia=299, NazwaPlikuObrazka="headphones_2.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Model słuchawek star 2.0 to dobry wybór dla osób, które lubią się cieszyć pięknym dźwiękiem za dobrą cenę."},

                new Urzadzenie() { UrzadzenieId=13, NazwaUrzadzenia="SLUCHAWKI NAUSZNE BEATS by. dre", ProducentUrzadzenia="BEATS", KategoriaId=1, CenaUrzadzenia=799, NazwaPlikuObrazka="headphones_3.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Słuchawki nauszne Beats EP po mistrzowsku przenoszą każdy detal dźwięku. Nie wymagają baterii, więc możesz słuchać ulubionej muzyki na okrągło. A spinający całość pałąk zawiera element z lekkiej stali nierdzewnej, który zwiększa wytrzymałość konstrukcji. Beats EP to idealny sprzęt dla miłośników muzyki poszukujących dynamicznego brzmienia."},

                new Urzadzenie() { UrzadzenieId=14, NazwaUrzadzenia="Zestaw talk-audio", ProducentUrzadzenia="STAR", KategoriaId=3, CenaUrzadzenia=999, NazwaPlikuObrazka="micro_1.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Szybki i prosty sposób nagrywania w domowym studio: Zestaw mikrofonowy V5 do domowego studia nagrań auna"},

                new Urzadzenie() { UrzadzenieId=15, NazwaUrzadzenia="MIKROFON RETRO SHURE", ProducentUrzadzenia="SHURE", KategoriaId=3, CenaUrzadzenia=359, NazwaPlikuObrazka="micro_2.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Super 55 jest przeznaczony dla aplikacji wokalnych. Dlatego też najczęściej jest wykorzystywany podczas występów na żywo, w systemach nagłośnieniowych, a także podczas transmisji, nagrywania oraz w innych aplikacjach, gdzie pożądane jest zastosowanie klasycznie wyglądającego mikrofonu montowanego na statywie."},

                new Urzadzenie() { UrzadzenieId=16, NazwaUrzadzenia="AUNA MIC-900RD USB ZESTAW V5 MIKROFON", ProducentUrzadzenia="AUNA", KategoriaId=3, CenaUrzadzenia=139, NazwaPlikuObrazka="micro_3.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="MOZOS MKIT-900PRO to profesjonalny zestaw studyjny z mikrofonem pojemnościowym usb. Mikrofon ma znakomity biegunowy wzorzec kardioidalny, wysoką moc wyjściową, niski szum własny i dokładne nagrywanie nawet najbardziej subtelnego dźwięku. Idealny zwłaszcza dla graczy, studiów nagraniowych, stacji radiowych, występów scenicznych i wokalistów. "},

                new Urzadzenie() { UrzadzenieId=17, NazwaUrzadzenia="GŁOSNIK PARTYBOX JBL", ProducentUrzadzenia="JBL", KategoriaId=2, CenaUrzadzenia=239, NazwaPlikuObrazka="speaker_1.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="JBL Partybox to wydajny, przenośny głośnik imprezowy z obsługą technologii Bluetooth i dynamicznymi efektami świetlnymi! Można dzięki niemu rozkręcić imprezę na całego!"},

                new Urzadzenie() { UrzadzenieId=18, NazwaUrzadzenia="GŁOSNICZKI STAR", ProducentUrzadzenia="STAR", KategoriaId=2, CenaUrzadzenia=119, NazwaPlikuObrazka="speaker_2.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Zasilane z USB, podłączane JACK jak słuchawki, Mocne, Bassowe, Stereofoniczne kolumienki. W zestawie z nimi dajemy kartę dźwiękową USB, co pozwoli je podłączyć do USB również w celu odtwarzania dźwięków."},

                new Urzadzenie() { UrzadzenieId=19, NazwaUrzadzenia="GŁOSNIK SONY", ProducentUrzadzenia="SONY", KategoriaId=2, CenaUrzadzenia=85, NazwaPlikuObrazka="speaker_3.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Głośnik SRS-XB01 wyróżnia się zaokrągloną konstrukcją i membraną bierną, która odpowiada za głębokie i mocne brzmienie."},

                new Urzadzenie() { UrzadzenieId=20, NazwaUrzadzenia="GŁOSNIKI STAR", ProducentUrzadzenia="STAR", KategoriaId=2, CenaUrzadzenia=239, NazwaPlikuObrazka="speaker_4.jpg",
                DataDodania = DateTime.Now, OpisUrzadzenia="Wysokiej jakości stereofoniczne głośniki do notebooków i komputerów stacjonarnych. Gwarantują czyste i naturalne brzmienie dźwięku.Nowoczesny wygląd sprawia, że doskonale komponują się na biurku z monitorami LED, LCD i innymi akcesoriami. Niebieskie podświetlenie LED nadaje charakteru głośnikom. Współpracują ze wszystkimi komputerami posiadającymi wyjście głośnikowe jack 3.5 i wyjście USB."},
            };
            urzadzenia.ForEach(k => context.Urzadzenia.AddOrUpdate(k));
            context.SaveChanges();

        }
        public static void SeedUzytkownicy(UrzadzeniaContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            const string name = "admin@audiofile.pl";
            const string password = "q1w2e3R$";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, DaneUzytkownika = new DaneUzytkownika() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin jeśli nie istnieje 
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            // dodanie uzytkownika do roli Admin jesli juz nie jest w roli
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

    }
}