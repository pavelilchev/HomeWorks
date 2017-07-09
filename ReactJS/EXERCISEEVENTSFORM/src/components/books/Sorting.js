import React from 'react'

export default class Sorting extends React.Component {
  render () {
    return (
      <div className='row'>
        <div className='col-sm-4 col-centered'>
          <h4>Order by</h4>
          <select onChange={this.props.onChange} name='sortBy'>
            <option value='date'>
              Date
            </option>
            <option value='author'>
              Author
            </option>
            <option value='title'>
              Title
            </option>
          </select>
          <select onChange={this.props.onChange} name='order'>
            <option value='desc'>
              Descending
            </option>
            <option value='asc'>
              Ascending
            </option>
          </select>
        </div>
      </div>
    )
  }
}
