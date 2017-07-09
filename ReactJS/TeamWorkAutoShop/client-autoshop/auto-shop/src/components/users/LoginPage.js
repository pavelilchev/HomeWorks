import React from 'react'
import LoginForm from './LoginForm'
import userActions from '../../actions/UserActions'
import userStore from '../../stores/UserStore'
import toastr from 'toastr'
import Auth from './Auth'

export default class LoginPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      user: {
        username: '',
        password: ''
      },
      error: []
    }

    this.handleInputChange = this.handleInputChange.bind(this)
    this.handleSubmit = this.handleSubmit.bind(this)
    this.handleUserLogin = this.handleUserLogin.bind(this)

    userStore.on(
      userStore.events.LOGGEDIN,
      this.handleUserLogin)
  }

  componentWillUnmount () {
    userStore.removeListener(
      userStore.events.LOGGEDIN,
      this.handleUserLogin)
  }

  handleUserLogin (data) {
    if (!data.success) {
      let error = []
      error.push(data.message)
      this.setState({error})
    } else {
      Auth.authenticateUser(data.token)
      Auth.saveUser(data.user)
      toastr.success(data.message)
      this.props.history.push('/')
    }
  }

  handleInputChange (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let user = this.state.user
    user[field] = value
    this.setState({user})
  }

  handleSubmit (event) {
    event.preventDefault()
    let user = this.state.user
    let error = []
    if (!user.username) {
      error.push('Please enter your username')
    }

    if (!user.password) {
      error.push('Please enter your password')
    }

    if (error.length > 0) {
      this.setState({error})
      return
    }

    userActions.login(this.state.user)
  }

  render () {
    return (
      <div className='container'>
        <div className='row'>
          <div className='col-sm-8 col-md-6'>
            <h2 className='text-left'>Login</h2>
            <LoginForm
              user={this.state.user}
              error={this.state.error}
              onChange={this.handleInputChange}
              onSubmit={this.handleSubmit} />
          </div>
        </div>
      </div>
    )
  }
}
