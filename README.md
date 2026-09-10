# ElectricityCost

WPF rakendus elektrikulu arvutamiseks 30 paeva jooksul.

## Projekti struktuur

- ElectricityCost.Core - Class Library, kus on arvutused ja sisendi kontroll
- ElectricityCost.WpfApp - WPF rakendus kasutajaliidesega

## Sisendid

- Seadme voimsus W
- Tootunnid paevas
- Elektri hind €/kWh

## Arvutus

Energiakulu arvutatakse:

`(voimsus / 1000) * tootunnid * 30`

Maksumus arvutatakse:

`energiakulu * elektri hind`

Tulemus umardatakse kahe komakohani.

Maksud ja lisatasud ei ole arvestatud.

## Naide 1

Sisend:

- 1500 W
- 4 tundi paevas
- 0.18 €/kWh

Oodatud tulemus:

- 180.00 kWh
- 32.40 €

## Naide 2

Sisend:

- 1500 W
- 25 tundi paevas
- 0.18 €/kWh

Oodatud veateade:

`Tootunnid paevas peavad olema vahemikus 0 kuni 24.`

## Kaivitamine

Ava projekt Visual Studios ja kaivita ElectricityCost.WpfApp.
