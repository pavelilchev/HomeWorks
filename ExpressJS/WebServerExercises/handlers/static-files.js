const url = require('url')
const fs = require('fs')
const path = require('path')

function getContentType(url){
    let result = ''

    if(url.endsWith('.css')){
        result = 'text/css'
    } else if(url.endsWith('.js')){
         result = 'text/javascript'
    } else if(url.endsWith('.jpg') || url.endsWith('.jpeg')){
        result = 'image/jpeg'
     } else if(url.endsWith('.png') ){
        result = 'image/png'
    }

    return result
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname
    if (req.pathname.startsWith('/content/') && req.method === 'GET'){
        let filePath = path.normalize(
            path.join(__dirname, `..${req.pathname}`))

    fs.readFile(filePath, (err, data) => {
        let type = getContentType(req.pathname)
        if(err || type === ''){
             res.writeHead(404, {
                   'Content-Type' : 'text/plain'
               })

               res.write('Resource not found!')
               res.end()
               return
        }

        res.writeHead(200, {
              'Content-Type' : type
        })

        res.write(data)
        res.end()
    })
    } else {
        return true
    }
}