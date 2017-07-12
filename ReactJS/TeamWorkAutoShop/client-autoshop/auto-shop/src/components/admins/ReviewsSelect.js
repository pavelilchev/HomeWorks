import React from 'react'

export default class ReviewsSelect extends React.Component {
  render () {
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <select onChange={this.props.onChange}>
          <option value='all'>
            All
          </option>
          <option value='unpublished'>
            Unpublished
          </option>
          <option value='published'>
            Published
          </option>
        </select>
        <input type='submit' value='Get Reviews' />
      </form>
    )
  }
}
