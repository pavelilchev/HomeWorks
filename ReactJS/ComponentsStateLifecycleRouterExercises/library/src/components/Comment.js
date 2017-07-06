import React from 'react'

export default class BooksDetail extends React.Component {
  render () {
    return (
      <div className='single-comment'>
        <p>{this.props.comment.comment}</p>
      </div>
    )
  }
}
