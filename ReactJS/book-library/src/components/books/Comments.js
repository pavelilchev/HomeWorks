import React from 'react'

export default class Comments extends React.Component {
  render () {
    let comments = this.props.comments.map(c => {
      return (
        <li key={c.id}>
          {c.text}
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
