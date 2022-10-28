var restify = require('restify');
var database = require('../server/database/db.js')

//apro la connessione con il db direttamente da qua
var server = restify.createServer();
server.use(restify.plugins.bodyParser());

// server.get('/drones', function (req, res, next) {
//     res.send('List of drones: [TODO]');
//     return next();
// });

// server.get('/drones/:id', function (req, res, next) {
//     res.send('Current values for drone ' + req.params['id'] + ': [TODO]');
//     return next();
// });

server.post('/drones/:id', async function (req, res, next) {

    var drone = JSON.parse(req.body);
    await database.postDrone(drone)
    res.send('Data received from drone [TODO]');
    console.log(drone);
    return res;
});

server.listen(8011, function (req, res, next) {

    console.log('%s listening at %s', server.name, server.url);
});