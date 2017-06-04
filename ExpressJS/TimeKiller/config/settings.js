const path = require('path')

let rootPath = path.normalize(path.join(__dirname, '/../../'))

module.exports = {
  development: {
    rootPath: rootPath,
    db: 'mongodb://localhost:27017/TimeKillerDb',
    //db: 'mongodb://admin:ORexvfSzqyszRu3y@timekiller-shard-00-00-yonhe.mongodb.net:27017,timekiller-shard-00-01-yonhe.mongodb.net:27017,timekiller-shard-00-02-yonhe.mongodb.net:27017/TimeKiller?ssl=true&replicaSet=TimeKiller-shard-0&authSource=admin',
    port: 6969
  },
  production: {
    port: process.env.PORT,
    rootPath: rootPath,
    db: 'mongodb://admin:ORexvfSzqyszRu3y@timekiller-shard-00-00-yonhe.mongodb.net:27017,timekiller-shard-00-01-yonhe.mongodb.net:27017,timekiller-shard-00-02-yonhe.mongodb.net:27017/TimeKiller?ssl=true&replicaSet=TimeKiller-shard-0&authSource=admin'
  }
}
