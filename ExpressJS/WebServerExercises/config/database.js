
const fs = require('fs')
const path = require('path')
const dbPath = path.join(__dirname, '/database.json')

let images = []
let count = 1

function getImages(){
    if(!fs.existsSync(dbPath)){
        fs.writeFileSync(dbPath, '[]')
        return []
    }

    let json = fs.readFileSync(dbPath).toString() || []
    let imgs = JSON.parse(json)
    return imgs
}

function saveImages(imgs){
    let json = JSON.stringify(imgs)
    fs.writeFileSync(dbPath, json)
}

module.exports.images = {}

module.exports.images.getAll = getImages

module.exports.images.add = (img) => {
    let imgs = getImages()
    img.id = imgs.length + 1
    imgs.push(img)
    saveImages(imgs)
}

module.exports.images.findByName = (name) => {
    return getImages().filter(p => p.name.toLowerCase().includes(name))
}