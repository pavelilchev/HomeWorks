const Review = require('../data/Review')
const reviewsPerPage = 7

module.exports = {
  all: (req, res) => {
    const page = parseInt(req.query.page) || 1

    Review.find({})
      .populate('author')
      .sort('-date')
      .skip(reviewsPerPage * (page - 1))
      .limit(reviewsPerPage)
      .then(reviews => {
        res.status(200).json(reviews)
      })
  },
  add: (req, res) => {
    let reviewReq = req.body

    Review
      .create({
        text: reviewReq.text,
        author: req.user._id,
        date: Date.now()
      })
      .then((addedReview) => {
        return res.status(200).json({
          success: true,
          message: 'You have successfully added review',
          review: addedReview
        })
      })
      .catch(err => {
        return res.status(200).json({
          success: false,
          message: err.message
        })
      })
  },
  count: (req, res) => {
    Review.find({})
      .then(reviews => {
        let count = {
          count: reviews.length
        }
        res.status(200).json(count)
      })
  }
}
