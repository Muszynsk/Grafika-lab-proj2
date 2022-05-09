# Grafika-lab-proj2

Projekt1 z Grafika i komunikacja człowiek-komputer lab (UwB Inf I st. sem IV)

Jakub Muszyński

Zrealizowano wszystkie wymagane funkcjonalności.

Program posiada zabezpieczenia przed próbą wykonywania operacji przed wczytaniem przetwarzanych obrazów oraz funkcje zabezpieczające przed wykroczeniem wartości RGB poza dopuszczalny zakres (int 0-255 oraz double 0.0-1.0).



Uwagi do funkcjonalności:

TRANSFORMACJA: w okienku "Podaj współczynniki" wartość zatytułowana nachylenie musi być podana zgodnie z formą <część_całkowita,część_ułamkowa>.

MIESZANIE: jeśli jeden z obrazów jest większy, to oba jego wymiary muszą być większe.

HISTOGRAM: tworzone są histogramy R, G i B dla obrazu PO PRAWEJ STRONIE. Wysietlają się one każdy kolejno, po zamknięciu poprzedniego wyświetlonego histogramu.

SKALOWANIE HISTOGRAMU: jako parametry powinno się podać liczby całkowite. Brak zabezpieczenia przed dzieleniem przez 0.

FILTRY: funkcje filtrujące zostały zoptyamlizowane poprzez zapisanie do tablic dwuwymiarowych wartości barw RGB przed rozpoczęciem algorytmu filtrującego. Dzięki temu zlikwidowano wielokrotne wywoływanie getterów dla poszczególnych pikseli (przykładowo w filtrach o masce 3x3, przetworzenie 1 piksela wymagałoby 27-krotnego wywołania gettera - 9 pikseli pod maską * 3 składowe barwy) 

WSZYSTKIE OKIENKA POPUP MAJĄCE RADIOBUTTON: jeśli żaden z RadioButton'ów nie jest zaznaczony, kliknięcie 'OK' nie spowoduje działania programu
