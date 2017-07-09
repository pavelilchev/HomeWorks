import React from 'react'
import commentsActions from '../../actions/CommentsActions'

export default class Comments extends React.Component {
  delete (event) {
    commentsActions.deleteById(event.target.value)
  }

  edit (event) {

  }

  render () {
    let comments = this.props.comments.map(c => {
      return (
        <li key={c.id}>
          {c.text}
          <button className='btn btn-primary' value={c.id} onClick={this.edit.bind(this)}>
            Edit
          </button>
          <button className='btn btn-danger' value={c.id} onClick={this.delete.bind(this)}>
            Delete
          </button>
        </li>)
    })

    return (
      <div className='row'>
        <ul>
          {comments}
        </ul>
      </div>
    )
  }
}
