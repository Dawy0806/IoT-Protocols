const { Client } = require('pg')
const {query_post} = require('../query/db_query.js')


function GetConnectionDb() {
    var db = new Client({
        host: 'localhost',
        user: 'postgres',
        password: 'password',
        database: 'IOT',
        port: 5432
    })
    db.connect()
    return db
}


module.exports.getDrones = async function(){
    var db = GetConnectionDb()
    await db.query()
    db.end()
}


module.exports.postDrone = async function (drone) {
    var db = GetConnectionDb()
    await db.query(query_post.speed, [drone.speed])
            .then(res => console.log("Query effetuata con successo, Ok"))
            .catch(e => console.error(e.stack))

    await db.query(query_post.position, [drone.position[1], drone.position[0]])
            .then(res => console.log("Query effetuata con successo, Ok"))
            .catch(e => console.error(e.stack))

    await db.query(query_post.altezza, [drone.highness])
            .then(res => console.log("Query effetuata con successo, Ok"))
            .catch(e => console.error(e.stack))

    await db.query(query_post.batteria, [drone.charge])
            .then(res => console.log("Query effetuata con successo, Ok"))
            .catch(e => console.error(e.stack))
    
    await db.query(query_post.temperatura, [drone.temperature[0], drone.temperature[1]])
            .then(res => console.log("Query effetuata con successo, Ok"))
            .catch(e => console.error(e.stack))

    db.end()
}

