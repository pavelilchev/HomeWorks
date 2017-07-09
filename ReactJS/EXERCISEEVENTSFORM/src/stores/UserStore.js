import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import userActions from '../actions/UserActions'
import data from '../data/Data'

class UserStore extends EventEmitter {
  login (user) {
    data.loginUser(user)
    .then(respone => {
      this.emit(this.events.LOGGEDIN, respone)
    })
  }

  register (user) {
    data.registerUser(user)
    .then(response => {
      this.emit(this.events.REGISTER, response)
    })
  }

  handleAction (action) {
    switch (action.type) {
      case userActions.actionTypes.LOGIN:
        this.login(action.user)
        break
      case userActions.actionTypes.REGISTER:
        this.register(action.user)
        break
      default: break
    }
  }
}

let userStore = new UserStore()
userStore.events = {
  LOGGEDIN: 'loggedin_user',
  REGISTER: 'register_user'
}

dispatcher.register(userStore.handleAction.bind(userStore))
export default userStore
