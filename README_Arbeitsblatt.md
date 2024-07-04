# IEG2024
## Best project in town


Ziel der Gruppenarbeit „Trading Platform I“ im Rahmen dieser Vorlesung ist es, eine moderne, wettbewerbsfähige Internet-Handelsplattform zu entwickeln, welche als Software-Architektur auf Microservices setzt. Jeder Microservice soll dabei genau eine einzige Aufgabe erfüllen und über genau definierte Schnittstelen erreichbar sein bzw. mit anderen Microservices über die angebotenen Schnittstellen kommunizieren. 
Denkbar wären zum Beispiel folgende Microservices:
- Shopping-Microservice
- Bezahl-Microservice
- Rating-Microservice
- Bauernladen-Produktkatalog-Microservice
- Weingut-Produktkatalog-Microservice
- Storno-Microservice
- Währungsrechner-Microservice

Fokus: Integration von „elektronischen (Geschäfts)-Prozessen“ und Microservices.
Nehmen Sie in Ihrer Ausführung auch Bezug auf die im Artikel „Microservices a definition of this new architectural term“
(http://martinfowler.com/articles/microservices.html) beschriebenen Konzepte.

**Teambezeichnung:** BestProjectTeamInTown
- [x] Aufgabe 1 (Emanuel)
- [x] Aufgabe 2 (Emmanuel)
- [x] Aufgabe 3 (Thomas)
- [x] Aufgabe 4 (Emanuel)
- [x] Aufgabe 5 (Thomas)
- [ ] Aufgabe 6 (Andreas)
- [x] Aufgabe 7 (Hannes)
- [x] Aufgabe 8 (Emmanuel)
- [x] Aufgabe 9 (Hannes)
- [ ] Aufgabe 10 (Andreas)
### Aufgabe 1 (25 Punkte) (Emanuel) -- Done
**a)** 
Analyse: Machen Sie sich mit dem Ausgangs-Source-Code „SolTradingPlatform (ohne Polly)“ vertraut. Publizieren Sie die beiden Services „MeiShop“ und „IEGEasyCreditCardService“ in die Microsoft Azure Cloud und testen Sie die Funktionalität. Alternativ können Sie die Projekte natürlich auch onpremise hosten (0 Punkte)

**b)**
Beschreiben Sie zuerst den Ansatz „Domain-Driven Design (DDD) im Zusammenhang mit Microservices. Überlegen Sie welche weiteren Microservices in Zusammenhang mit der Trading Platform sinnvoll wären. Beschreiben Sie danach die Funktionalitäten / Verantwortlichkeiten der einzelnen Microservices – Stichwort: Business Capabilities

Detailbeschreibung der angebotenen Schnittstellen inkl. Datenaustauschformate

Detailbeschreibung der Datenhaltung – Stichwort: Decentralized Data Management

(25 Punkte)

[AUFGABE-1](Doku/Arbeitsblatt/1.md)

### Aufgabe 2 (10 Punkte) (Emmanuel) -- Done
2 weitere Microservice Produktkataloge: Erstellen Sie ein Microservice, welches eine Liste von Produkten anbietet. Der Inhalt der Liste soll dabei aus einem „microservice local datastore“ kommen – (Decentralized Data Management). Ersetzen Sie die hard codierten Werte im MeiShop/ProductList-Controller durch den Aufruf des soeben erstellen Services. Ein weiterer Produktkatalog-Service soll Produkte aus einem Text File auf einem FTP-Server auslesen und zur Verfügung stellen. (10 Punkte)

### Aufgabe 3 (10 Punkte) (Thomas) -- Done
Skalierung, Ausfallssicherheit und Logging (Design for failure) für CreditPaymentService. Detailsbeschreibung: Publizieren Sie das Service „IEGEasyCreditCardService“ mehrfach und rufen Sie die Services im „Round Robin“ Stil auf. Falls es beim Aufruf eines Service zu einem Fehler kommt, soll es eine Retry-Logik geben, außerdem soll der aufgetretene Fehler mit Hilfe eines zentralen Logging-Service (gRPC) protokolliert werden. Nach n erfolglosen Versuchen, soll das nächste Service aufgerufen werden. Recherchieren Sie zusätzlich nach einem geeigneten Framework und Skalierungsmöglichkeiten setzen Sie dieses gegebenenfalls ein (10 Punkte)

[AUFGABE-3](Doku/Arbeitsblatt/3.md)


### Aufgabe 4 (10 Punkte) (Emanuel) -- Done
(theoretische) Überlegungen zum Einsatz von Asynchronen Kommunikationsstilen in der Handelsplattform (10 Punkte)
https://microservices.io/patterns/communication-style/messaging.html

[AUFGABE-4](Doku/Arbeitsblatt/4.md)

### Aufgabe 5 (10 Punkte) (Thomas) -- Done
Schreiben Sie ein zusätzliches „Paymentservice“. Dieses Payment-Service soll sowohl JSON, XML-Nachrichten als auch Nachrichten im Format CSV verarbeiten und erzeugen können. Orientieren Sie sich an dem Pattern - HTTP Content Negotiation in REST APIs (restfulapi.net) (10 Punkte)

[AUFGABE-5](Doku/Arbeitsblatt/5.md)

### Aufgabe 6 (10 Punkte) (Andreas) -- In Arbeit
(theoretische) Überlegungen zu einem PaymentService-Broker. Dieses Service soll zwischen Shops und Payment-Services „vermitteln“.
SOA Patterns | Compound Patterns | Service Broker | Arcitura Patterns
ZA_Deloitte_Digita_Canonical_Schemas.pdf
http://www.enterpriseintegrationpatterns.com/patterns/messaging/CanonicalDataModel.html
 
Recherchieren Sie dazu zusätzliche Patterns


[AUFGABE-5](Doku/Arbeitsblatt/6.md)

### Aufgabe 7 (10 Punkte) (Hannes) -- Done
Webhook-Subscriber: Überlegen und implementieren Sie ein mögliches Webhook-Szenario (10 Punkte)

### Aufgabe 8 (10 Punkte) (Emmanuel) -- Done
Machen Sie sich mit dem Begriff OData vertraut. Überlegen und implementieren Sie ein mögliches OData (Service & Client)-Szenario (10 Punkte)

### Aufgabe 9 (Hier haben wir uns wie besprochen für eine Beschreibung statt einer Implementierung entschieden) (10 Punkte) (Hannes) -- Done
Machen Sie sich mit dem Begriff SAGA-Pattern vertraut. Überlegen und implementieren Sie ein mögliches SAGA-Pattern Szenario(Service & Client)-Szenario 

Umgang mit Ausfallsicherheit –Stichwort: Design for failure / Resilient Software Design (10 Punkte)

[AUFGABE-9](Doku/Arbeitsblatt/9.md)

### Aufgabe 10 (10 Punkte) (Andreas) -- In Arbeit
Machen Sie sich mit dem Begriff „Open Data“ vertraut und beschreiben Sie diesen in einigen wenigen Sätzen. Beschreiben Sie außerdem mögliche Anwendungsfälle im Zusammenhang mit der Handelsplattform


[AUFGABE-5](Doku/Arbeitsblatt/10.md)
