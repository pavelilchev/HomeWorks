import dispatcher from '../dispatcher.js'

let userActions = {
  actionTypes: {
    LOGIN: 'login',
    REGISTER: 'register'
  },
  login: (user) => {
    dispatcher.dispatch({
      type: userActions.actionTypes.LOGIN,
      user
    })
  },
  register: (user) => {
    dispatcher.dispatch({
      type: userActions.actionTypes.REGISTER,
      user
    })
  }
}

export default userActions
