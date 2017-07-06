import dispatcher from '../dispatcher.js'

let authorsActions = {
  types: {
    DELETE: 'DELETE'
  },
  deleteById: (id) => {
    dispatcher.dispatch({
      type: authorsActions.types.DELETE,
      id: id
    })
  }
}

export default authorsActions
