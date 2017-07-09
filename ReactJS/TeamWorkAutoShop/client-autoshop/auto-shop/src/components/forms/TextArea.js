import React from 'react'

export default class Input extends React.Component {
  render () {
    let rows = this.props.rows || 4
    let cols = this.props.cols || 60
    return (
      <div className='form-group'>
        <label htmlFor={this.props.name} className='col-sm-4 control-label'>
          {this.props.placeholder}
        </label>
        <div className='col-sm-8'>
          <textarea
            className='form-control'
            id={this.props.name}
            name={this.props.name}
            value={this.props.value}
            placeholder={this.props.placeholder}
            onChange={this.props.onChange}
            rows={rows}
            cols={cols} />
        </div>
      </div>
    )
  }
}
