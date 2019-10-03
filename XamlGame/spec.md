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

Fontos, hogy egymás után következhessen két egyforma kártya. Ez csak akkor lehetséges, ha vannak egyforma kártyák a pakliban. Vagy minden húzás után visszatesszük a kártyát és újra megkeverjük, vagy a pakliban eleve több egyforma kártya van.
        
   Minden alkalommal újra keverjük a kártyát.

   Mekkora legyen a kártyapakli. Minél nagyobb a pakli, annál valószínűtlenebb, hogy egymás után kétszer ugyanaz a kártya legyen a legtetején.

   Tehát egy értelmes pakli méretet kell választani. Legyen 6, de majd ezt tesztelni kell, később változtatható legyen.
   
   Majd választjuk a pakliból valamelyik kártyát.

   **Ilyenkor még nem várunk visszajelzést**

- Megmutatjuk a következő kártyát

    Ugyanúgy mint az első kártyánál

  - Várunk a felhasználó visszajelzésére
    - első lépésben gombok használata
    - majd billentyűzet használata
  - Vagy lejár az idő
  - Értékeljük a visszajelzést
    - Jó/nem jó
    - Mennyi volt a reakcióidő
  - Az értékelést megjelnítjük
    - jó/nem jó
    - pontszám frissítése (hogy számoljuk a pontokat?)

- Ezt ismételjük, amíg le nem jár az idő
  - a hátralévő időt folymatosan kijelezzük (mennyi a játékidő?)

### Hibajavítások, apróbb módosítások
- legyen az ablaknak egy minimális mérete
- fogadjunk el a billentyűzetről is visszajelzést
- adjunk segítséget a képernyőn (milyen billentyűk)
- a visszejelzés méretén és színén javítás
- a billentyűk csak akkor éljenek, ha a játék már elindult
- 
