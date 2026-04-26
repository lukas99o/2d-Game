# 2. Karaktärsanimationer

## Mål
Lägga till sprite-animationer för spelaren som triggas automatiskt baserat på rörelsetillstånd.

## Animationer
- **Idle** – spelaren står still
- **Gång** – spelaren rör sig i normal hastighet
- **Sprint** – spelaren rör sig i hög hastighet
- **Hopp (upp)** – spelaren är på väg uppåt
- **Hopp (ned)** – spelaren är på väg nedåt
- **Landning** – spelaren landar på marken

## Tekniska noter
- Sprite sheet med separata frames per animation
- Animationskontroller som håller koll på aktuellt tillstånd
- Tillståndsövergångar baserade på velocity och markkontakt
