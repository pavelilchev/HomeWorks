const mongoose = require('mongoose')

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'

let appointmentSchema = new mongoose.Schema({
  firstName: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  lastName: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  email: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  phone: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  reason: { type: String },
  firstChoice: { type: Date, required: REQUIRED_VALIDATION_MESSAGE },
  secondChoice: { type: Date },
  date: {type: mongoose.Schema.Types.Date, default: Date.now()}
})

let Appointment = mongoose.model('Appointment', appointmentSchema)

module.exports = Appointment
