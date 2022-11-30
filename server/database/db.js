const { Client } = require('pg')
const { query_post } = require('../query/db_query.js')


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


module.exports.getDrones = async function () {
    var db = GetConnectionDb()
    await db.query()
    db.end()
}

module.exports.postDrone = async function (drone) {
    if (drone == undefined || drone == null) {
        return;
    } 
    else {
        var db = GetConnectionDb()

        try {
            await db.query(query_post.speed, [drone.speed])
            await db.query(query_post.position, [drone.position[1], drone.position[0]])
            await db.query(query_post.altezza, [drone.highness])
            await db.query(query_post.batteria, [drone.charge])
            await db.query(query_post.temperatura, [drone.temperature[0], drone.temperature[1]])

            console.log("Query effetuata con successo, OK")

        } catch (err) {

            console.log(err.stack)
        } finally {
            db.end()
        }
    }
}

