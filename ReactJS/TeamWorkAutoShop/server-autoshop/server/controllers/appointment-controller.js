const Appointment = require('../data/Appointment')
const mailService = require('../utilities/mail-service')

module.exports = {
  add: (req, res) => {
    let appointment = req.body

    const validationResult = validateAppointmentForm(req.body)
    if (!validationResult.success) {
      return res.status(200).json({
        success: false,
        message: validationResult.message,
        errors: validationResult.errors
      })
    }

    Appointment
      .create({
        firstName: appointment.firstName,
        lastName: appointment.lastName,
        email: appointment.email,
        phone: appointment.phone,
        reason: appointment.reason,
        firstChoice: appointment.firstChoice,
        secondChoice: appointment.secondChoice,
        date: Date.now()
      })
      .then((addedAppointment) => {
        let mailOptions = addAppointmentInfo(addedAppointment)
        mailService.sendMail(mailOptions)
        return res.status(200).json({
          success: true,
          message: 'You have successfully shedule an appointment',
          appointment: addedAppointment
        })
      })
      .catch(err => {
        return res.status(200).json({
          success: false,
          message: err.message
        })
      })
  },
  all: (req, res) => {
    let option = req.query.option
    let searched = {}
    if (option === 'confirmed') {
      searched = {confirmed: true}
    } else if (option === 'unconfirmed') {
      searched = {confirmed: false}
    }
    Appointment
      .find(searched)
      .then(appointsments => {
        return res.status(200).json({
          success: true,
          message: 'Appointments loaded',
          appointsments: appointsments
        })
      })
      .catch(err => {
        return res.status(200).json({
          success: false,
          message: err.message
        })
      })
  }
}

function validateAppointmentForm (appointment) {
  let isFormValid = true
  let message = ''
  let errors = []
  if (!appointment.firstName) {
    errors.push('Please enter your First name')
  }
  if (!appointment.lastName) {
    errors.push('Please enter your Last name')
  }
  if (!appointment.email) {
    errors.push('Please enter your Email')
  }
  let mailPattern = /(.+)@(.+){2,}\.(.+){2,}/
  if (!mailPattern.test(appointment.email)) {
    errors.push('Please provide valid email address')
  }
  if (!appointment.firstChoice || new Date(appointment.firstChoice) < Date.now()) {
    errors.push('Please select valid first date')
  }
  if (new Date(appointment.secondChoice) < Date.now()) {
    errors.push('Please select valid first date')
  }

  if (errors.length > 0) {
    isFormValid = false
    message = 'Check form for errors'
  }

  return {
    success: isFormValid,
    message: message,
    errors: errors
  }
}

function addAppointmentInfo (appointment) {
  const mailOptions = {
    from: 'website@gmail.com',
    to: 'autoshop.appointments@gmail.com',
    subject: 'Online Appointment',
    text: ''
  }

  let template = `
  Appointment form on your website was submitted with the following information:

  Name: ${appointment.firstName}  ${appointment.lastName} 
  Email: ${appointment.email}
  Phone: ${appointment.phone}
  Reason: ${appointment.reason}
  First Date${appointment.firstChoice}
  Second Date${appointment.secondChoice}`

  mailOptions.text = template

  return mailOptions
}
