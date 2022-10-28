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
    await db.query(query_post.speed, [drone.speed], (err, res) => {console.log(err.message)})
    await db.query(query_post.position, [drone.position[1], drone.position[0]], (err, res) => {console.log(err.message)})
    await db.query(query_post.altezza, [drone.highness], (err, res) => {console.log(err.message)})
    await db.query(query_post.batteria, [drone.charge], (err, res) => {console.log(err.message)})
    await db.query(query_post.temperatura, [drone.temperature[0], drone.temperature[1]], (err, res) => {console.log(err.message)})
    db.end()
}

