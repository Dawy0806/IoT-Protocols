const coap = require('coap')
const server = coap.createServer()
const url = 'coap://localhost/droni'


server.on('request', (res, req) => {
  res.end("risposta")
})


server.listen(() => {
  console.log("ciao")
  const req = coap.request(url)

  req.on('response', (res) => {
    res.pipe(process.stdout)
    console.log(res.payload)
    res.on('end', () => {
      process.exit(0)
      
    })
  })
})
