var mongoose = require('mongoose')
mongoose.Promise = global.Promise 
const connectionString = 'mongodb://localhost:27017/MongoDbExerciseDB'

module.exports = () => {
    mongoose.connect(connectionString)

    let database = mongoose.connection    

    database.once('open', (err) => {
        if(err){
            console.log(err)
            return
        }

        console.log('Connected!')
    })

    database.on('error', (err) => {
        console.log(err)
    })

    require('../models/image')    
    require('../models/tag')    
}