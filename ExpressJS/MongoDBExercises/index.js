const instanodeDb = require('./instanode-db')
const database = require('./config/database.config')
database()

instanodeDb.saveImage({ url: 'https://i.ytimg.com/vi/tntOCGkgt98/maxresdefault.jpg', description: 'such cat much wow', tags: ['cat', 'kitty', 'cute', 'catstagram'] })

instanodeDb.findByTag('cat')
  .then((imgs) => {
    console.log(imgs)
  })

let minDate = new Date('2016-05-29T19:08:09.015Z')
let maxDate = new Date()
instanodeDb
  .filter({after: null, before: null, results: 2})
  .then((imgs) => {
    console.log(imgs)
  })
  .catch(err => {
    console.log(err)
  })
