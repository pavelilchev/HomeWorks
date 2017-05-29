const http = require('http')
const handlers = require('./handlers')

const port = 3000
let environment = process.env.NODE_ENV || 'development'
const config = require('./config/config')
const database = require('./config/database.config')

database(config[environment])

http.createServer((req, res) => {
   for (let handler of handlers){
       if (!handler(req, res)){
           break
       }
   }
}).listen(port)

console.log(`Server listen on port ${port}`)