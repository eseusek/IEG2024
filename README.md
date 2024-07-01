# IEG Microservices - Projekt - most WanTED 2024

## Projektübersicht

Das Ziel der Projektarbeit im Rahmen dieser Vorlesung ist es, eine moderne, flexibel erweiterbare, austauschbare und skalierbare Microservice-Architektur als Erweiterung zur bereits bestehenden Handelsplattform zum Themenbereich „most wanTED“ zu designen, mit Microsoft ASP.NET Core zu entwickeln und in der Microsoft Azure Cloud zu betreiben. „most wanTED“ soll den beteiligten Personen und Organisationen der Handelsplattform (Kunde, Lieferant, Kreditkartenunternehmen) bei der Auswahl von Aspekten wie Produktauswahl, Produktplatzierung, Bezahlvarianten, Benutzeroberflächen, Liefervarianten und weiteren unterstützen.

**Teambezeichnung:** BestProjectTeamInTown

- [ ] Aufgabe 1 (Emanuel)
- [ ] Aufgabe 2 (Emanuel)
- [x] Aufgabe 3 (Thomas)
- [x] Aufgabe 4 (Emmanuel)
- [ ] Aufgabe 5 (Hannes)
- [ ] Aufgabe 6 (Thomas/Andreas)
- [ ] Aufgabe 7 (Andreas)
- [ ] Aufgabe 8 (Hannes)
- [ ] Aufgabe 9 (Alle)
- [ ] Aufgabe 10 (Alle)
- [ ] Bonus (Emmanuel)

### 1. Makro- und Mikro-Architektur (Emanuel):
Beschreiben Sie die Makro- und Mikro-Architektur Ihrer Lösung zum Thema „most wanTED“.

### 2. Design (Emanuel):
Entwerfen Sie die einzelnen beteiligten Microservices. Verwenden Sie dazu den Ansatz „Domain Driven Design“.

### 3. Implementierung I – Discovery & Configuration (Thomas):
Implementieren Sie konkret einen Microservice, der aus Skalierungs- und Redundanzgründen mehrfach deployed werden kann, und einen weiteren Microservice, der die Dienste dieses mehrfach vorhandenen Microservice nutzt.

[AUFGABE-3](Doku/Projekt/3.md)

### 4. Implementierung II - Secrets (Emmanuel):
Implementieren Sie konkret einen Microservice, der für die Kommunikation mit anderen Microservices „Secrets“ benötigt. Beschreiben Sie, wie „Secrets“ bzw. Tokens in einer Microservice-Umgebung verwaltet werden können.

[AUFGABE-4](Doku/Projekt/4.md)

### 5. Implementierung III – Asynchrones Messaging (Hannes):
Implementieren Sie konkret einen Microservice, der asynchrones Messaging einsetzt. Beschreiben Sie die Möglichkeiten bzw. Vor- und Nachteile der asynchronen Kommunikation im Zusammenhang mit Microservices.

### 6. Qualität & Monitoring (Thomas/Andreas):
Entwerfen Sie eine Teststrategie und eine Monitoring-Infrastruktur für das „most wanTED“ Projekt. Behandeln Sie im Bereich Test vor allem Integrationstest und Last- und Performancetests.

[AUFGABE-6](Doku/Projekt/6.md)

### 7. Alternative „Produktempfehlung“ (Andreas):
Überlegen und beschreiben Sie die Möglichkeit des Einsatzes einer Workflow-Engine im Zusammenhang mit der Möglichkeit, „sehr gute Produktplatzierung“ käuflich zu erwerben.

### 8. Integration eines spezifischen Geschäftsprozesses (Hannes):
Entwickeln und implementieren Sie ein Konzept für die Integration eines spezifischen Geschäftsprozesses im Zusammenhang mit dem Projekt „most wanTED“ unter dem Einsatz von KI oder Low-Code/No-Code.

### 9. Aufbereitung und Präsentation (Alle):
Bereiten Sie die Ergebnisse der Projektarbeit auf und präsentieren Sie diese.

### 10. Funktionierende Gesamtlösung (Alle):
Erstellen Sie eine funktionierende Gesamtlösung des Projekts „most wanTED“.

### Bonus (Emmanuel)
#### A - Einsatz des Saga-Patterns
Implementieren Sie konkret 1 Microservice welches das Saga Pattern verwendet (als Ersatz für Distributed Transactions). Beschreiben Sie in diesem Zusammenhang auch das Protokoll 2PC – two-phase commit
https://microservices.io/patterns/data/saga.html

#### B - Konsumieren eines beliebigen Service aus der „Cloud“ 
Implementieren Sie konkret 1 Microservice welches ein beliebiges „fremdes“ (Cloud)-Service verwendet 

#### C -  Einsatz des CQRS Patterns
Implementieren Sie konkret 1 Microservice welches das CQRS Pattern verwendet 

#### D -  Einsatz von Event Sourcing 
Implementieren Sie konkret das Pattern Event Sourcing 
