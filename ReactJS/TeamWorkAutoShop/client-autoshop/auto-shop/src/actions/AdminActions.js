import dispatcher from '../dispatcher.js'

let adminActions = {
  actionTypes: {
    SOME: 'SOME'
  },
  some: (user) => {
    dispatcher.dispatch({
      type: adminActions.actionTypes.SOME,
      user: user
    })
  }
}

export default adminActions
