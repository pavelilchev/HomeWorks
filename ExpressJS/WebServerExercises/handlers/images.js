const url = require('url')
const database = require('../config/database')
const fs = require('fs')
const path = require('path')
const qs = require('querystring')
const multiparty = require('multiparty');
const shortid = require('shortid');

function getReferer(req){
    let refferIndex = req.rawHeaders.indexOf('Referer')         
    return url.parse(req.rawHeaders[refferIndex + 1]).pathname || '/'
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname
    if (req.pathname === '/images/add' && req.method === 'GET'){
        let filePtah = path.normalize(
            path.join(__dirname, '../views/images/add.html'))

        fs.readFile(filePtah, (err, data) => {
            if(err){
                console.log(err)
            }

        res.writeHead(200, {
              'Content-Type' : 'text/html'
        })

       
        data = data.toString().replace('{back}', getReferer(req))
        res.write(data)
        res.end()
        })
    } else if (req.pathname === '/images/add' && req.method === 'POST'){
       let body = ''

        req.on('data', function (data) {
            body += data
            console.log(data.toString())
        });

        req.on('end', function () {
            let entry = qs.parse(body)

            fs.readFile('./views/images/add.html', (err, data) => {
                if(err){
                    console.log(err)
                }

               res.writeHead(200)
                if(entry.name === '' || entry.url === ''){
                    data = data.toString().replace('{back}', getReferer(req))
                    res.write(data)
                    res.write('<div class="error">Name and URL cannot be empty!</div>')
                    res.end()     
                    return
                }          
            
                database.images.add(entry)
                data = data.toString().replace('{back}', getReferer(req))
                res.write(data)
                res.write('<div class="success">Image is added to the album!</div>')
                res.end()   
          })
        });
    } else if (req.pathname === '/images/all' && req.method === 'GET'){
        let filePath = path.normalize(path.join(__dirname, '../views/images/all.html'))
    
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

           let content = ''
           for (let img of images){
               content += `<div class="product-card col-sm-4">               
                    <h2>${img.name}</h2>
                    <a href="/images/details/${img.id}">Details</a>
                </div>`
           }

           let html = data.toString().replace('{content}', content).replace('{back}', getReferer(req))

            res.write(html)
            res.end()
      })
    } else if (req.pathname.startsWith('/images/details/') && req.method === 'GET'){
        let id = req.pathname.replace('/images/details/', '')
        let imgs = database.images.getAll()
        let img = {}
        for (let i of imgs){
            if(i.id == id){
                img = i
                break
            }
        }

        if(!img.id){
              res.writeHead(404, {
                   'Content-Type' : 'text/plain'
               })

               res.write('404 not found!')
               res.end()
               return
        }

        fs.readFile('./views/images/details.html', (err, data) => {
            if(err){
                console.log(err)
            }

            res.writeHead(200) 
            html = `<div class="product-card col-sm-6">               
                    <h2>${img.name}</h2>
                    <img src="${img.url}" alt="${img.name}"/>
                </div>`

            data = data.toString().replace('{content}', html).replace('{back}', getReferer(req))
            res.write(data)
            res.end()  
        }) 
    } else {

    }
}
