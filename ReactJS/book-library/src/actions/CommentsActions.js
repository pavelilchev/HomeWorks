import dispatcher from '../dispatcher.js'

let commentsActions = {
  types: {
    DELETE_COMMENT: 'DELETE_COMMENT'
  },
  deleteById: (id) => {
    dispatcher.dispatch({
      type: commentsActions.types.DELETE_COMMENT,
      id: id
    })
  }
}

export default commentsActions
