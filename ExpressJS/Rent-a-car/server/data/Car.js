const mongoose = require('mongoose')

let carSchema = new mongoose.Schema({

})

let Car = mongoose.model('Car', carSchema)

module.exports = Car