import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import Data from '../data/Data'
import reviewsActions from '../actions/ReviewsActions'

class ReviewsStore extends EventEmitter {
  all (page) {
    return new Promise((resolve, reject) => {
      Data
        .getAllReviews(page)
        .then(response => {
          resolve(response)
        })
    })
  }

  count () {
    return new Promise((resolve, reject) => {
      Data
        .getReviewsCount()
        .then(response => {
          resolve(response)
        })
    })
  }

  create (review) {
    Data
      .addReview(review)
      .then(response => {
        this.emit(this.events.REVIEW_ADDED, response)
      })
  }

  getAll (options) {
    Data
      .getSelectedReviews(options)
      .then(response => {
        this.emit(this.events.SELECTED_REVIEWS_LOADED, response)
      })
  }

  deleteById (id) {
    Data
      .deleteReviewById(id)
      .then(response => {
        this.emit(this.events.REVIEW_DELETED, response)
      })
  }

  getById (id) {
    Data
      .getReviewById(id)
      .then(response => {
        this.emit(this.events.REVIEW_LOADED, response)
      })
  }

  edit (review) {
    Data
      .editReview(review)
      .then(response => {
        this.emit(this.events.REVIEW_EDITED, response)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case reviewsActions.actionTypes.CREATE:
        this.create(action.review)
        break
      case reviewsActions.actionTypes.DELETE_REVIEW:
        this.deleteById(action.id)
        break
      case reviewsActions.actionTypes.GET_BY_ID:
        this.getById(action.id)
        break
      case reviewsActions.actionTypes.EDIT_REVIEW:
        this.edit(action.review)
        break
      default:
        break
    }
  }
}

let reviewsStore = new ReviewsStore()
reviewsStore.events = {
  REVIEW_ADDED: 'review_added',
  SELECTED_REVIEWS_LOADED: 'selected_reviews_loaded',
  REVIEW_DELETED: 'review_deleted',
  REVIEW_LOADED: 'review_loaded',
  REVIEW_EDITED: 'review_edited'
}

dispatcher.register(reviewsStore.handleAction.bind(reviewsStore))
export default reviewsStore
