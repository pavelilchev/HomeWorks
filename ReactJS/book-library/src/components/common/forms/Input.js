import React from 'react'

export default class Input extends React.Component {
  render () {
    let type = this.props.type || 'text'
    return (
      <div className='form-group'>
        <label htmlFor={this.props.name} className='col-sm-4 control-label'>{this.props.placeholder}</label>
        <div className='col-sm-8'>
          <input
            type={type}
            className='form-control'
            id={this.props.name}
            name={this.props.name}
            value={this.props.value}
            placeholder={this.props.placeholder}
            onChange={this.props.onChange} />
        </div>
      </div>
    )
  }
}
