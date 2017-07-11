import React from 'react'
import RegisterForm from './RegisterForm'
import userActions from '../../actions/UserActions'
import userStore from '../../stores/UserStore'
import toastr from 'toastr'
import ErrorHelper from '../../utils/ErrorHelper'

export default class RegisterPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      user: {
        username: '',
        firstName: '',
        lastName: '',
        password: '',
        confirmPassword: ''
      },
      error: []
    }

    this.handleInputChange = this.handleInputChange.bind(this)
    this.handleSubmit = this.handleSubmit.bind(this)
    this.handleUserRegister = this.handleUserRegister.bind(this)

    userStore.on(
      userStore.events.REGISTER,
      this.handleUserRegister)
  }

  componentWillUnmount () {
    userStore.removeListener(
      userStore.events.REGISTER,
      this.handleUserRegister)
  }

  handleUserRegister (data) {
    if (!data.success) {
      let error = []
      if (data.errors) {
        error = ErrorHelper.parse(data.errors)
      } else {
        error.push(data.message)
      }
      this.setState({error})
    } else {
      toastr.success(data.message)
      this.props.history.push('/users/login')
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
      error.push('Please enter username')
    }

    if (!user.firstName) {
      error.push('Please enter your First Name')
    }

    if (!user.lastName) {
      error.push('Please enter your Last Name')
    }

    if (!user.password) {
      error.push('Please enter your Password')
    }

    if (user.password !== user.confirmPassword) {
      error.push('Passwords do not match')
    }

    if (error.length > 0) {
      this.setState({error})
      return
    }

    userActions.register(this.state.user)
  }

  render () {
    return (
      <div className='container'>
        <div className='row'>
          <div className='col-sm-8 col-md-6'>
            <h2 className='text-left'>Register</h2>
            <RegisterForm
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
