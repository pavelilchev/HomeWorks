const nodemailer = require('nodemailer')

const transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'autoshop.appointments@gmail.com',
    pass: 's0m3S3cret!'
  }
})

module.exports = {
  sendMail: (mailOptions) => {
    transporter.sendMail(mailOptions, function (error, info) {
      if (error) {
        console.log(error)
      } else {
        console.log('Email sent: ' + info.response)
      }
    })
  }
}
