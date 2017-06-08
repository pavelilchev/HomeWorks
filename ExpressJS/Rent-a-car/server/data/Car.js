const mongoose = require('mongoose')
const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'

let carSchema = new mongoose.Schema({
  make: {type: String, required: REQUIRED_VALIDATION_MESSAGE},
  model: {type: String, required: REQUIRED_VALIDATION_MESSAGE},
  year: {type: String, required: REQUIRED_VALIDATION_MESSAGE},
  image: {type: String, required: REQUIRED_VALIDATION_MESSAGE},
  pricePerDay: {type: Number, required: REQUIRED_VALIDATION_MESSAGE, min:0},
  date: {type: Date, default: Date.now()},
  isRented: {type: Boolean, default: false}
})

let Car = mongoose.model('Car', carSchema)

module.exports = Car
