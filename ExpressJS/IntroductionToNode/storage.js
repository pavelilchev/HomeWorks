const fs = require('fs')

let data = {}

let validateType = (obj, type) => {
    if(typeof obj !== type){
        throw new Error('Key should be a string')
    }
}

let checkKeyExist = (key) => {
     if(data.hasOwnProperty(key)){
        throw new Error('Key already exist')
    }
}

let checkKeyDontExist = (key) => {
     if(!data.hasOwnProperty(key)){
        throw new Error('Key doesn\'t exist')
    }
}

let put = (key, value) => {
    validateType(key, 'string')
    checkKeyExist(key)

    data[key] = value
}

let get = (key) => {
    validateType(key, 'string')
    checkKeyDontExist(key)

    return data[key]
}

let update = (key, value) => {
     validateType(key, 'string')
     checkKeyDontExist(key)

     data[key] = value
}

let deleteItem = (key) => {
    validateType(key, 'string')
    checkKeyDontExist(key)

    delete data[key]
}

let clear = () => {
     data = {}
}

let save = () => {
    return new Promise((resolve, reject) => {
         let json = JSON.stringify(data)
         fs.writeFile('storage.dat', json, (err) => {
             if(err){
                 reject(err)
                 return
             }

             resolve() 
         })
    })
}

let load = () => {
    return new Promise((resolve, reject) => {
        fs.readFile('storage.dat', 'utf8', (err, json) => {
            if(err){
                reject(err)
                return
            }

            data = JSON.parse(json)
            resolve()
        })
    }) 
}

module.exports = {
    put: put,
    get: get,
    update: update,
    delete: deleteItem,
    clear: clear,
    save: save,
    load: load
}