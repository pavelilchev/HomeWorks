const mongoose = require('mongoose')
const Car = mongoose.model('Car')
const errorHandler = require('../utilities/error-handler')

module.exports = {
  addGet: (req, res) => {
    res.render('cars/add')
  },
  addPost: (req, res) => {
    let carReq = req.body

    let car = {
      make: carReq.make,
      model: carReq.model,
      year: carReq.year,
      image: carReq.url,
      pricePerDay: carReq.pricePerDay
    }

    Car.create(car)
      .then(car => {
        res.redirect('/cars/all')
      })
      .catch(err => {
        let message = errorHandler.handleMongooseError(err)
        res.locals.globalError = message
        res.render('cars/add', carReq)
      })
  },
  all: (req, res) => {
    let search = req.query.search
    let page = Number(req.query.page) || 1
    let carPerPage = 2

    let query = Car.find({isRented: false})
    if (search) {
      query = query.where('make').regex(new RegExp(search, 'i'))
        .where('model').regex(new RegExp(search, 'i'))
    }

    query
      .sort('-date')
      .skip(carPerPage * (page - 1))
      .limit(carPerPage)
      .then(cars => {
        res.render('cars/all', {
          cars: cars,
          hasPrevPage: page > 1,
          hasNextPage: cars.length > 0,
          prevPage: page - 1,
          nextPage: page + 1,
          search: search
        })
      })
      .catch(error => {
        console.log(error)
      })
  },
  rent: (req, res) => {
    let userId = req.user._id
    let carId = req.params.id
    let days = parseInt(req.body.days)

    Car
      .findById(carId)
      .then(car => {
        if (car.isRented) {
          res.locals.globalError = 'Car is already rented!'
          res.render('cars/all')
          return
        }

        Renting
          .create({
            user: userId,
            car: carId,
            days: days,
            totalPrice: car.pricePerDay * days
          })
          .then(renting => {
            car.isRented = true
            car
              .save()
              .then(car => {
                res.redirect('/users/me')
              })
          })
          .catch(err => {

          })
      })
      .catch(err => {
        let message = errorHandler.handleMongooseError(err)
        res.locals.globalError = message
        res.render('cars/all')
      })
  }
}
