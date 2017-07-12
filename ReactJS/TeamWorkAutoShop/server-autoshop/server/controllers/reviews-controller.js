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
    const validationResult = validateReviewForm(reviewReq)
    if (!validationResult.success) {
      return res.status(200).json({
        success: false,
        message: validationResult.message,
        errors: validationResult.errors
      })
    }

    Review
      .create({
        text: reviewReq.text,
        author: req.user._id,
        rating: Number(reviewReq.rating),
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

function validateReviewForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  if (!payload || typeof payload.text !== 'string' || payload.text.trim().length === 0) {
    isFormValid = false
    errors.text = 'Please provide review text.'
  }

  if (!payload || typeof payload.rating !== 'string' || Number(payload.rating) < 1 || Number(payload.rating) > 5) {
    isFormValid = false
    errors.rating = 'Please provide valid rating.'
  }

  if (!isFormValid) {
    message = 'Check the form for errors.'
  }

  return {
    success: isFormValid,
    message: message,
    errors: errors
  }
}
