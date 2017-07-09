import React from 'react'

export default class Error extends React.Component {
  render () {
    let errors = this.props.error.map((err, index) => {
      return <li key={index}>{err}</li>
    })
    return (
      this.props.error.length === 0 ? null
      : (
        <div className='error-message text-left'>
          <ul>
            {errors}
          </ul>
        </div>
      )
    )
  }
}
