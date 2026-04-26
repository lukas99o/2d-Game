# 2D Spel – Projektplan

## Syfte
Det här projektet är ett testprojekt utan något specifikt slutmål ännu. Poängen är att experimentera med olika spelsystem och mekaniker i MonoGame. Planen kan förändras allteftersom.

---

## System att bygga

### 1. Rörelssystem
- Gå åt vänster och höger
- Sprint (håll knapp för att springa snabbare)
- Hoppa (enkel hopp, eventuellt dubbelhoppa senare)
- Grundläggande kollision med marken

### 2. Nivådesign
- En enkel testlevel med plattformar och mark
- Grundläggande tilemap eller handritad miljö
- Hinder och höjdskillnader för att testa rörelsen

### 3. Karaktär och animationer
- Sprite-baserad karaktär
- Animationer:
  - Idle (stå still)
  - Gång
  - Sprint
  - Hoppa (upp-fas och ned-fas)
  - Landning
- Animationer triggas automatiskt baserat på rörelsetillstånd

### 4. Fiender (eventuellt)
- En enkel fiende med grundläggande AI (patrullera fram och tillbaka)
- Kollision med spelaren

### 5. Attacker (eventuellt)
- Enkel attack (slag eller projektil)
- Träff-detektion mot fiender
- Animationer för attack

---

## Teknisk stack
- **Språk:** C#
- **Framework:** MonoGame
- **Plattform:** Desktop (Windows)

---

## Prioritetsordning
1. Rörelssystem med kollision
2. Karaktärsanimationer
3. Enkel level
4. Fiende
5. Attacker
