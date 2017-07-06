import React from 'react'

export default class Input extends React.Component {
  render () {
    return (
      <div className='form-group'>
        <div className='col-sm-offset-4 col-sm-8 text-left'>
          <input
            type='submit'
            className='btn btn-primary'
            value={this.props.value} />
        </div>
      </div>
    )
  }
}
