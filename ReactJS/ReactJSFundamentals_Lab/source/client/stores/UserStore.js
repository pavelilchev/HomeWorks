import alt from '../alt'
import AppActions from '../actions/UserActions'

class AppStore {
  constructor () {
    this.bindActions(AppActions)

    this.loggedInUserId = ''
    this.username = ''
    this.userIsLoggedIn = false
    this.roles = []
  }

  onLoginUserSuccess (user) {
    this.loggedInUserId = user._id
    this.username = user.username
    this.roles = user.roles
    this.userIsLoggedIn = true
  }

  onLoginUserFail () {
    console.log('Failed login attempt')
  }

  onLogoutUserSuccess () {
    this.loggedInUserId = ''
    this.username = ''
    this.roles = []
    this.userIsLoggedIn = false
  }
}

export default alt.createStore(AppStore)
