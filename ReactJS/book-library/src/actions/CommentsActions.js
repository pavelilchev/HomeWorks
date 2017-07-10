import dispatcher from '../dispatcher.js'

let commentsActions = {
  types: {
    DELETE_COMMENT: 'DELETE_COMMENT',
    ADD_COMMENT: 'ADD_COMMENT'
  },
  deleteById: (id) => {
    dispatcher.dispatch({
      type: commentsActions.types.DELETE_COMMENT,
      id: id
    })
  },
  add: (comment, bookId) => {
    dispatcher.dispatch({
      type: commentsActions.types.ADD_COMMENT,
      comment,
      bookId
    })
  }
}

export default commentsActions
