const url = require('url')
const fs = require('fs')
const path = require('path')
const database = require('../config/database')
const qs = require('querystring')

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname

    if(req.pathname === '/' && req.method === 'GET'){
        let filePath = path.normalize(
            path.join(__dirname, '../views/home/min/index.html'))
    
       fs.readFile(filePath, (err, data) => {
           if(err){
               console.log(err)
               res.writeHead(404, {
                   'Content-Type' : 'text/plain'
               })

               res.write('404 not found!')
               res.end()
               return
           }

           res.writeHead(200, {
                'Content-Type' : 'text/html'
           })

           let images = database.images.getAll()
           let queryData = qs.parse(url.parse(req.url).query)
           if(queryData.query){
               images = database.images.findByName(queryData.query)
           }

           let content = ''
           for (let img of images){
               content +=
               `<div class="product-card col-sm-4">               
                    <h2>${img.name}</h2>
                    <img class="product-img" src="${img.url}">
                    <a href="/images/details/${img.id}">Details</a>
                </div>`
           }

           let html = data.toString().replace('{content}', content)

            res.write(html)
            res.end()
       })     
    } else {
        return true
    }
}