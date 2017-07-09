import React from 'react'
import Input from '../forms/Input'
import TextArea from '../forms/TextArea'
import Error from '../common/Error'
import SubmitInput from '../forms/SubmitInput'

export default class AppointmentForm extends React.Component {
  render () {
    let appointment = this.props.appointment
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          type='text'
          name='firstName'
          placeholder='First Name'
          value={appointment.firstName}
          onChange={this.props.onChange} />
        <Input
          type='text'
          name='lastName'
          placeholder='Last Name'
          value={appointment.lastName}
          onChange={this.props.onChange} />
        <Input
          type='email'
          name='email'
          placeholder='Email'
          value={appointment.email}
          onChange={this.props.onChange} />
        <Input
          type='text'
          name='phone'
          placeholder='Phone'
          value={appointment.phone}
          onChange={this.props.onChange} />
        <TextArea
          name='reason'
          placeholder='Reason'
          value={appointment.reason}
          onChange={this.props.onChange} />
        <Input
          type='date'
          name='firstChoice'
          placeholder='First Date'
          value={appointment.firstChoice}
          onChange={this.props.onChange} />
        <Input
          type='date'
          name='secondChoice'
          placeholder='Second Date'
          value={appointment.secondChoice}
          onChange={this.props.onChange} />
        <SubmitInput value='Submit' />
        <div className='row'>
          <div className='col-md-offset-4 col-md-8'>
            <Error error={this.props.errors} />
          </div>
        </div>
      </form>
    )
  }
}
