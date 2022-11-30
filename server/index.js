
var database = require('../server/database/db.js')
var mqtt = require('mqtt')
const brokerUrl = "localhost://127.0.0.1:1883"
const topic = "droni/"
const client = mqtt.connect(brokerUrl)
var isConnect = false

//connesione 
client.on('connect', function () {
    client.subscribe(topic, function (err) {
        if (!err) {
            client.publish(topic, "Connesione andata a buon fine!! CONNESSO")
            isConnect = true
            console.log('connect')
        }
        else
        {
            console.log('errore nella connesione')
        }
    })
});


//ricezione messaggi
client.on('message',  async function (topic, message) {

    if(message.toString() != null && isConnect)
    {
        console.log(message.toString())            

        let drone;
        try{
            drone = JSON.parse(message.toString())
            await database.postDrone(drone)
        }
        catch(ex){
            console.error('json parse error')
        }
        
        
    }
    else
    {
        console.log('errore nel messaggio')
    }
})

//gestione errori
client.on('error', function(error){
    console.log(error.message)
    client.end()
})


