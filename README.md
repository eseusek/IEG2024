# IEG2024
## Best project in town


Ziel der Gruppenarbeit �Trading Platform I� im Rahmen dieser Vorlesung ist es, eine moderne, wettbewerbsf�hige Internet-Handelsplattform zu entwickeln, welche als Software-Architektur auf Microservices setzt. Jeder Microservice soll dabei genau eine einzige Aufgabe erf�llen und �ber genau definierte Schnittstelen erreichbar sein bzw. mit anderen Microservices �ber die angebotenen Schnittstellen kommunizieren. 
Denkbar w�ren zum Beispiel folgende Microservices:
- Shopping-Microservice
- Bezahl-Microservice
- Rating-Microservice
- BauernladenAProduktkatalog-Microservice
- WeingutBProduktkatalgo-Microservice
- Storno-Microservice
- W�hrungsrechner-Microservice

Fokus: Integration von �elektronischen (Gesch�fts)-Prozessen� und Microservices.
Nehmen Sie in Ihrer Ausf�hrung auch Bezug auf die im Artikel �Microservices a definition of this new architectural term�
(http://martinfowler.com/articles/microservices.html) beschriebenen Konzepte.

**Teambezeichnung:** BestProjectTeamInTown

### Aufgabe 1 (25 Punkte) (Emanuel)
**a)** 
Analyse: Machen Sie sich mit dem Ausgangs-Source-Code �SolTradingPlatform (ohne Polly)� vertraut. Publizieren Sie die beiden Services �MeiShop� und �IEGEasyCreditCardService� in die Microsoft Azure Cloud und testen Sie die Funktionalit�t. Alternativ k�nnen Sie die Projekte nat�rlich auch onpremise hosten (0 Punkte)

**b)**
Beschreiben Sie zuerst den Ansatz �Domain-Driven Design (DDD) im Zusammenhang mit Microservices. �berlegen Sie welche weiteren Microservices in Zusammenhang mit der Trading Platform sinnvoll w�ren. Beschreiben Sie danach die Funktionalit�ten / Verantwortlichkeiten der einzelnen Microservices � Stichwort: Business Capabilities

Detailbeschreibung der angebotenen Schnittstellen inkl. Datenaustauschformate

Detailbeschreibung der Datenhaltung � Stichwort: Decentralized Data Management

(25 Punkte)

### Aufgabe 2 (10 Punkte) (Emmanuel)
2 weitere Microservice Produktkataloge: Erstellen Sie ein Microservice, welches eine Liste von Produkten anbietet. Der Inhalt der Liste soll dabei aus einem �microservice local datastore� kommen � (Decentralized Data Management). Ersetzen Sie die hard codierten Werte im MeiShop/ProductList-Controller durch den Aufruf des soeben erstellen Services. Ein weiterer Produktkatalog-Service soll Produkte aus einem Text File auf einem FTP-Server auslesen und zur Verf�gung stellen. (10 Punkte)

### Aufgabe 3 (10 Punkte) (Thomas)
Skalierung, Ausfallssicherheit und Logging (Design for failure) f�r CreditPaymentService. Detailsbeschreibung: Publizieren Sie das Service �IEGEasyCreditCardService� mehrfach und rufen Sie die Services im �Round Robin� Stil auf. Falls es beim Aufruf eines Service zu einem Fehler kommt, soll es eine Retry-Logik geben, au�erdem soll der aufgetretene Fehler mit Hilfe eines zentralen Logging-Service (gRPC) protokolliert werden. Nach n erfolglosen Versuchen, soll das n�chste Service aufgerufen werden. Recherchieren Sie zus�tzlich nach einem geeigneten Framework und Skalierungsm�glichkeiten setzen Sie dieses gegebenenfalls ein (10 Punkte)

### Aufgabe 4 (10 Punkte) (Emanuel)
(theoretische) �berlegungen zum Einsatz von Asynchronen Kommunikationsstilen in der Handelsplattform (10 Punkte)
https://microservices.io/patterns/communication-style/messaging.html

### Aufgabe 5 (10 Punkte) (Thomas)
Schreiben Sie ein zus�tzliches �Paymentservice�. Dieses Payment-Service soll sowohl JSON, XML-Nachrichten als auch Nachrichten im Format CSV verarbeiten und erzeugen k�nnen. Orientieren Sie sich an dem Pattern - HTTP Content Negotiation in REST APIs (restfulapi.net)

(10 Punkte)

### Aufgabe 6 (10 Punkte) (Andreas)
(theoretische) �berlegungen zu einem PaymentService-Broker. Dieses Service soll zwischen Shops und Payment-Services �vermitteln�.
SOA Patterns | Compound Patterns | Service Broker | Arcitura Patterns
ZA_Deloitte_Digita_Canonical_Schemas.pdf
http://www.enterpriseintegrationpatterns.com/patterns/messaging/CanonicalDataModel.html
 
Recherchieren Sie dazu zus�tzliche Patterns

### Aufgabe 7 (10 Punkte) (Hannes)
Webhook-Subscriber: �berlegen und implementieren Sie ein m�gliches Webhook-Szenario (10 Punkte)

### Aufgabe 8 (10 Punkte) (Emmanuel)
Machen Sie sich mit dem Begriff OData vertraut. �berlegen und implementieren Sie ein m�gliches OData (Service & Client)-Szenario (10 Punkte)

### Aufgabe 9 (10 Punkte) (Hannes)
Machen Sie sich mit dem Begriff SAGA-Pattern vertraut. �berlegen und implementieren Sie ein m�gliches SAGA-Pattern Szenario(Service & Client)-Szenario 

Umgang mit Ausfallsicherheit �Stichwort: Design for failure / Resilient Software Design

(10 Punkte)

### Aufgabe 10 (10 Punkte) (Andreas)
Machen Sie sich mit dem Begriff �Open Data� vertraut und beschreiben Sie diesen in einigen wenigen S�tzen. Beschreiben Sie au�erdem m�gliche Anwendungsf�lle im Zusammenhang mit der Handelsplattform
