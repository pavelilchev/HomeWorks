import React from 'react'
import RegisterForm from './RegisterForm'
import userActions from '../../actions/UserActions'
import userStore from '../../stores/UserStore'
import toastr from 'toastr'
import ErrorHelper from '../../utils/ErrorHelper'
import FormHelper from '../forms/FormHelper'

export default class RegisterPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      user: {
        name: '',
        email: '',
        password: '',
        confirmPassword: ''
      },
      errors: []
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
    FormHelper.handleInputChange.bind(this)(event, 'user')
  }

  handleSubmit (event) {
    event.preventDefault()
    let user = this.state.user
    let errors = []
    if (!user.name) {
      errors.push('Please enter your Name')
    }

    if (!user.email) {
      errors.push('Please enter your Email')
    }

    if (!user.password) {
      errors.push('Please enter your Password')
    }

    if (user.password !== user.confirmPassword) {
      errors.push('Passwords do not match')
    }

    if (errors.length > 0) {
      this.setState({errors})
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
              error={this.state.errors}
              onChange={this.handleInputChange}
              onSubmit={this.handleSubmit} />
          </div>
        </div>
      </div>
    )
  }
}
