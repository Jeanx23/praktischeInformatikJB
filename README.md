## Fußball Bundesligatipp - Praktische Informatik WS2023/2024
Hierbei handelt es sich um ein C# WPF Projekt, welches im Rahmen der Veranstaltung Praktische Informatik erstellt wurde.
### Projektbeschreibung
Das Projekt stellt eine Bundesliga Tipp Anwendug dar. Mit Hilfe dieser Tippanwendung lassen sich die Wahrscheinlichkeiten bestimmter Ergebnisse für in der Zukunft liegende Bundesliga Partien bestimmen. Diese Wahrscheinlichkeiten basieren auf bestehenden Daten vergangener Matches zweier Teams.
Um diese Wahrscheinlichkleiten zu bestimmen wurde die Poison Verteilung verwendet. Außerdem sind die Ergebnisse von vergangenen Partien der aktuellen Saison hinterlegt.
### Anleitung
Über das Dropdown Menü kann ein bestimmter Spieltag ausgewählt werden. Zusätzlich besteht die Möglichkeit über den Kalender einen speziellen Tag auszuwählen und die Partien an diesem speziellen Tag einzusehen. Standardmäßig ist nach dem starten der Anwendung der erste Spieltag ausgewählt.
### Poison Verteilung
Die Poisson-Verteilung ist eine diskrete Wahrscheinlichkeitsverteilung, die oft verwendet wird, um die Anzahl der Ereignisse in einem festen Zeitintervall oder Raumintervall zu modellieren, wenn diese Ereignisse mit einer konstanten Rate auftreten und unabhängig voneinander sind.
Die Wahrscheinlichkeitsfunktion für die Poisson-Verteilung lautet:

\[ P(X = k) = \frac{e^{-\lambda} \cdot \lambda^k}{k!} \]

Hierbei ist:
- \( P(X = k) \) die Wahrscheinlichkeit, dass genau \( k \) Ereignisse eintreten,
- \( e \) die Euler'sche Zahl (ungefähr 2.71828),
- \( \lambda \) die erwartete Anzahl von Ereignissen pro Zeit- oder Raumintervall,
- \( k \) die tatsächliche Anzahl der Ereignisse,
- \( k! \) die Fakultät von \( k \).
### API
Um an aktuelle Daten zur Bundesliga zu kommen wurde die OpenLigaDB-API verwendet.
Weiterführende Dokumentation ist [hier](https://api.openligadb.de/index.html) ersichtlich.
