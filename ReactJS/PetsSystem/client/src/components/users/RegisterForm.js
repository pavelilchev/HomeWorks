import React from 'react'
import Input from '../forms/Input'
import SubmitInput from '../forms/SubmitInput'
import Error from '../common/Error'

export default class RegisterForm extends React.Component {
  render () {
    let user = this.props.user
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          name='name'
          placeholder='Name'
          value={user.name}
          onChange={this.props.onChange} />
        <Input
          type='email'
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
        <Input
          type='password'
          name='confirmPassword'
          placeholder='Confirm Password'
          value={user.confirmPassword}
          onChange={this.props.onChange} />
        <SubmitInput value='Register' />
        <Error error={this.props.error} />
      </form>
    )
  }
}
