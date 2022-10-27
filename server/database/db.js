const { Client } = require('pg')



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


modeule.exports.getDrones = async function(){
    var db = GetConnectionDb()
    await db.query()
    db.end()
}


module.exports.postDrone = async function (drone) {
    var db = GetConnectionDb()
    await db.query('INSERT into Prova VALUES ($1);', [drone.Value])
    db.end()
}

