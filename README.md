# rGamblingSite

Projekt na zaliczenie labolatoriów z programowania w ASP .net

Dane logowania administratora: email: admin@gmail.com hasło: Adm!n0

Niestety nie udało mi się opublikować strony (ciągły błąd 502), natomiast w przypadku połączenie z bazą w chmurze i odpaleniu aplikacji lokalnie, wszytko działało.
Żeby aplikacja działała, trzeba wejść w appsettings.json i tam w connection string default zmienić Data Source na pańską nazwę serwera oraz zrobić "update-database"

Jest możliwość wielokrotnego wejścia do jednej gry.

Ustawione są standardowe szanse na wypadanie kolorów. (Szansa na zielone wynosi około 2,7%)

Każdy kod promocyjny można użyć raz na konto.

Aby dodać kod promocyjny, musimy zalogować się jako administrator, wejść w zakładnę "Admin Page", tam w "Promo Code Manager", gdzie mamy wypisane wszytkie kody i możliwość dodania nowego.

Strona posiada pełne API, żeby wejść wystarczy z panelu Ruletki wpisać /Api i dalsze polecenia:

/api/GetAppPromoCodes - dla admina, zwraca utworzone promocyjne

/api/GetLastRouletteSpins/20 - dla zalogowanych (ostatnia wartość(20), to zmienna i oznacza ile ostatnich spinów chcemy otrzymać)

/api/GetMyBalance - zwraca balans zalogowanego użytkownika

/api/AddPromoCode - dla admina, dodajemy kod promocyjny np.{
                                                            "PromoCode": "testapi500",
                                                            "CodeValue": 500
                                                            }
                                                            
/api/Register - rejestracja nowych użytkowników np.    {
                                                      "Email":"user@gmail.com" ,
                                                      "UserName": "testApiUser",
                                                      "Password":"Ci@stk0",
                                                      "ConfirmPassword":"Ci@stk0"
                                                       }
                                                       
/api/LogIn - logowanie użytkowników  np. {
                                        "Email":"user@gmail.com" ,
                                        "Password":"Ci@stk0"
                                         }
                                         
/api/LogOut - wylogowanie

/api/UsePromoCode - użycie kodu promocyjnego np. {
                                                "PromoCode":"testapi500"
                                                 }
                                                 
/api/EnterRouletteGame - wejście do gry na określony kolor i stawkę np. {
                                                                        "Colour": "black",
                                                                        "Stake": 10
                                                                        }


