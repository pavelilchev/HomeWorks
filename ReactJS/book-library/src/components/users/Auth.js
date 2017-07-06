class Auth {
  static authenticateUser (token) {
    window.localStorage.setItem('token', token)
  }

  static saveUser (user) {
    window.localStorage.setItem('user', JSON.stringify(user))
  }

  static isUserAuthenticated () {
    return window.localStorage.getItem('token') !== null
  }

  static deauthenticateUser () {
    window.localStorage.removeItem('token')
  }

  static getUser () {
    let userJson = window.localStorage.getItem('user')
    return JSON.parse(userJson)
  }

  static getToken () {
    return window.localStorage.getItem('token')
  }

  static removeUser () {
    window.localStorage.removeItem('user')
  }
}

export default Auth
