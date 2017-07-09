import React from 'react'

export default class AppointmentSelect extends React.Component {
  render () {
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <select onChange={this.props.onChange}>
          <option value='unconfirmed'>
            Unconfirmed
          </option>
          <option value='confirmed'>
            Confirmed
          </option>
          <option value='all'>
            All
          </option>
        </select>
        <input type='submit' value='Get Appointments' />
      </form>
    )
  }
}
