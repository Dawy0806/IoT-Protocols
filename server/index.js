// var restify = require('restify');
// var errs = require('restify-errors');
var database = require('../server/database/db.js')
var mqtt = require('mqtt')
const brokerUrl = "localhost://127.0.0.1:1883"
const topic = "droni/"
const client = mqtt.connect(brokerUrl)
var connection_message = "Connesione andata a buon fine!! CONNESSO"


//connesione 
client.on('connect', function () {
    client.subscribe(topic, function (err) {
        if (!err) {
            client.publish(topic, connection_message)

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

    if(message.toString() != connection_message)
    {
        console.log(message.toString())            

        try{
            let drone = JSON.parse(message.toString())
            await database.postDrone(drone)
        }
        catch(ex){
            console.error('json parse error')
        }
    }
    else
    {
        console.log('attesa ricezione del messaggio')
    }
})

//gestione errori
client.on('error', function(error){
    console.log(error.message)
    client.end()
})


//apro la connessione con il db direttamente da qua
// var server = restify.createServer();
// server.use(restify.plugins.bodyParser());

// server.get('/drones', function (req, res, next) {
//     res.send('List of drones: [TODO]');
//     return next();
// });

// server.get('/drones/:id', function (req, res, next) {
//     res.send('Current values for drone ' + req.params['id'] + ': [TODO]');
//     return next();
// });

// server.post('/drones/:id', async function (req, res, next) {

//     if(req.body)
//     {
//         var drone = JSON.parse(req.body);
//         await database.postDrone(drone)
//         res.send(drone);
//         res.status(200, 'Ok')
//         console.log(drone);
//         console.log("---------------------------------")
//     }
//     else
//     {
//         err =  next(errs.BadRequestError())
//         console.log(err)
//         return err
//     }
    
//     return next();
// });

// server.listen(8011, function (req, res, next) {
//     console.log('%s listening at %s', server.name, server.url);
// });