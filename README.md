# IoT-Protocols-MQTT
## Desc:
Stabilita connessione Mqtt 👍
<br> Payload e Topic per ciascun comando (Acceso/Spento/Torna a casa) = 
<br> Retain flag = (implementato, uso anche nell'interfaccia web per aggiornare la posizione per esempio) Abilita il broker a memorizzare l'ultimo messaggio ricevuto, di defoult è a false perché utilizzarlo utilizza molte risorse, può tornare utile in caso io voglia sapere appena mi connetto qual'era l'ultima posizione del drone

<br> Implementare invio / ricezione dei comandi
<br> Creazione pagina web statica che comunica in http con il server. Il server reinvia il comando ai droni tramite mqtt.
<br> Aggiungere bottoni Accendi drone
<br> Aggiungere bottoni Spegni drone
<br> Aggiungere bottoni Richiama base drone

<br> Last Will and Testament (implementato perche se c'e una disconnessione del client per motivi sconosciuti almeno possiamo sapere su un topic dedicato )
