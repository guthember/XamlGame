# Egyszerű játék XAML alapokon

Egyszerű **desktop** alkalmazás, segít fejleszteni a 
reakció időt!

Minden alkalommal el kell dönteni, hogy az előzővel egyező-e?


## Szereplők
- Tudom Ányos
 A szellemi képességeit szeretné nyomonkövetni
 Reakció időket pontosan kell mérni, számítógépes megvalósítás.

## Forgatókönyvek
### Játék (A felhasználó szemszögéből)
  
  Ányos elindítja az alkalmazást (fontos döntés), majd ha felkészült elindítja a játékot.
  Ha végzett akkor a végeredményt kiírja a játék.

  Hány képernyő legyen?

  Egy és három képernyő között.
  - alkalmazás induló képernyője (mindkét kártya lefordítva)
  - játék képernyője
  - végeredmény képernyője (mindkét kártya lefordítva)

  Fontos a reakció idő mérése, ezért gombokkal is irányítható kell legyen.

Játék közben vagy eltaláljuk vagy nem. Ezt tudjuk jelezni (zöld pipa, piros kereszt, előző kártya mutatása).

### A játék menete részletesen (A programozó szemszögéből)

Elindul a játék
- A kezdőképernyőn nincs semmilyen felfordított kártya.
- Megmutatjuk az első kártyát

    Ilyenkor még nem várunk visszajelzést

- Megmutatjuk a következő kártyát
  - Várunk a felhasználó visszajelzésére
  - Vagy lejár az idő
  - Értékeljük a visszajelzést
    - Jó/nem jó
    - Mennyi volt a reakcióidő
  - Az értékelést megjelnítjük
    - jó/nem jó
    - pontszám frissítése (hogy számoljuk a pontokat?)

- Ezt ismételjük, amíg le nem jár az idő
  - a hátralévő időt folymatosan kijelezzük (mennyi a játékidő?)
