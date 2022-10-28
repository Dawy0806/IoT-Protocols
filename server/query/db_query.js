

var query_post = {
    speed : 'INSERT into Speed(Velocita, IdDrone) VALUES ($1, 1);',
    position : 'INSERT into Position(Longitudine, Latitudine, IdDrone) VALUES ($1, $2, 1);',
    altezza : 'INSERT into Altezza(Altezza, IdDrone) VALUES ($1, 1);',
    batteria : 'INSERT into Batteria(Batteria, IdDrone) VALUES ($1, 1);',
    temperatura : 'INSERT into Temperature(Temperature_motore, Temperature_processore, IdDrone) VALUES ($1, $2, 1);'
}
 
module.exports = {query_post}