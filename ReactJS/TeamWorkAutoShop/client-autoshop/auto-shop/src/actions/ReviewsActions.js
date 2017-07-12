import dispatcher from '../dispatcher.js'

let reviewsActions = {
  actionTypes: {
    CREATE: 'CREATE',
    DELETE_REVIEW: 'DELETE_REVIEW',
    GET_BY_ID: 'GET_BY_ID',
    EDIT_REVIEW: 'EDIT_REVIEW'
  },
  create: (review) => {
    dispatcher.dispatch({
      type: reviewsActions.actionTypes.CREATE,
      review: review
    })
  },
  deleteById: (id) => {
    dispatcher.dispatch({
      type: reviewsActions.actionTypes.DELETE_REVIEW,
      id: id
    })
  },
  getById: (id) => {
    dispatcher.dispatch({
      type: reviewsActions.actionTypes.GET_BY_ID,
      id: id
    })
  },
  editReview: (review) => {
    dispatcher.dispatch({
      type: reviewsActions.actionTypes.EDIT_REVIEW,
      review: review
    })
  }
}

export default reviewsActions
