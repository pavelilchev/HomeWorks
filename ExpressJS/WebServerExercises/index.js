const http = require('http')
const handlers = require('./handlers/index')
const port = 5000

http
.createServer((req, res) => {
    for(let handler of handlers){
        if(!handler(req, res)){
            break;
        }
    }
})
.listen(port)

console.log(`Server runin' at port ${port}`)