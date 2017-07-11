import React from 'react'

export default class Select extends React.Component {
  render () {
    let options = this.props.options.map(o => {
      return (
        <option key={o} value={o}>
          {o}
        </option>
      )
    })

    return (
      <div className='form-group'>
        <label htmlFor={this.props.name} className='col-sm-4 control-label'>
          {this.props.placeholder}
        </label>
        <div className='col-sm-8'>
          <select
            id={this.props.name}
            name={this.props.name}
            onChange={this.props.onChange}
            className='form-control'>
            <option value='Please select'>
              Please select
            </option>
            {options}
          </select>
        </div>
      </div>
    )
  }
}
