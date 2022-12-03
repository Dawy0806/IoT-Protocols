
var database = require('../server/database/db.js')
var mqtt = require('mqtt')
const brokerUrl = "localhost://127.0.0.1:1883"
const topic = "droni/"

const options = {
    //clean session
    clean: true
}
const client = mqtt.connect(brokerUrl, options)
var connection_message = "Connesione andata a buon fine!! CONNESSO"


//connesione 
client.on('connect', function () {
    client.subscribe(topic, function (err) {
        if (!err) {
            client.publish(topic, connection_message)

            console.log('connect')
        }
        else {
            console.log('errore nella connesione')
        }
    })
});


//ricezione messaggi
client.on('message', async function (topic, message, packet) {

    if (message.toString() != connection_message) {
        console.log(message.toString())

        try {
            let drone = JSON.parse(message.toString())
            await database.postDrone(drone)
        }
        catch (ex) {
            console.error('json parse error')
        }
    }
    else {
        console.log('attesa ricezione del messaggio')
    }
})

//gestione errori
client.on('error', function (error) {
    console.log(error.message)
    client.end()
})


