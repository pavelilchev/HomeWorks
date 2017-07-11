import React from 'react'
import Input from '../forms/Input'
import SubmitInput from '../forms/SubmitInput'
import Error from '../common/Error'

export default class LoginForm extends React.Component {
  render () {
    let user = this.props.user
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          name='email'
          placeholder='Email'
          value={user.email}
          onChange={this.props.onChange} />
        <Input
          type='password'
          name='password'
          placeholder='Password'
          value={user.password}
          onChange={this.props.onChange} />
        <SubmitInput value='Login' />
        <Error error={this.props.error} />
      </form>
    )
  }
}
