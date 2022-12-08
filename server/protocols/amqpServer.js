var amqp = require('amqplib/callback_api');
var db = require('../database/db.js')


amqp.connect('amqp://localhost', function(error0, connection) {
    if (error0) {
        throw error0;
    }
    connection.createChannel(function(error1, channel) {
        if (error1) {
            throw error1;
        }

        var queue = 'droni';  

        channel.assertQueue(queue, {
            durable: false
        });


        channel.consume(queue, async function(msg) {
            console.log(msg.content.toString());
            var drone = JSON.parse(msg.content.toString())
            await db.postDrone(drone)

        }, {
            noAck: true
        });
    });
});

//collegarsi  redis parte server anche(DIO CANE)
//redis progetto nuovo
//parte server gestisce le code, raccolta dati code broker
//es: 1 coda raccoglie tutte esalva in db (js)