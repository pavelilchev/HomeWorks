const Review = require('../data/Review')
const reviewsPerPage = 7

module.exports = {
  all: (req, res) => {
    const page = parseInt(req.query.page) || 1

    Review.find({published: true})
      .populate('author', 'username')
      .sort('-date')
      .skip(reviewsPerPage * (page - 1))
      .limit(reviewsPerPage)
      .then(reviews => {
        res.status(200).json(reviews)
      })
  },
  getReview: (req, res) => {
    let id = req.params.id
    Review
      .findById(id)
      .populate('author', 'username')
      .then(review => {
        if (!review) {
          return res.status(200).json({
            success: false,
            message: "This review dosen't exist"
          })
        }

        return res.status(200).json({
          success: true,
          message: 'You have successfully loaded review',
          review: review
        })
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
  },
  allSelected: (req, res) => {
    let searched = {}
    if (req.query.options !== 'all') {
      searched = {published: req.query.options === 'published'}
    }

    Review.find(searched)
      .populate('author', 'username')
      .then(reviews => {
        return res.status(200).json({
          success: true,
          message: 'You have successfully loaded selected reviews',
          reviews: reviews
        })
      })
      .catch(err => {
        return res.status(200).json({
          success: false,
          message: err.message
        })
      })
  },
  deleteReview: (req, res) => {
    let id = req.params.id
    Review
      .findByIdAndRemove(id)
      .then(review => {
        if (!review) {
          return res.status(200).json({
            success: false,
            message: "This review dosen't exist"
          })
        }

        return res.status(200).json({
          success: true,
          message: 'You have successfully delete review',
          review: review
        })
      })
  },
  edit: (req, res) => {
    let reviewReq = req.body

    Review
      .findById(reviewReq._id)
      .then(review => {
        if (!review) {
          return res.status(200).json({
            success: false,
            message: "This review dosen't exist"
          })
        }

        review.text = reviewReq.text || review.text
        review.rating = reviewReq.rating || review.rating
        review.published = reviewReq.published

        review
          .save()
          .then(review => {
            return res.status(200).json({
              success: true,
              message: 'You have successfully edit review',
              review: review
            })
          })
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
