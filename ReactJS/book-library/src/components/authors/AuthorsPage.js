import React from 'react'
import AuthorList from './AuthorList'

export default class AuthorsPage extends React.Component {
  render () {
    return (
      <div>
        <h2>Authors</h2>
        <AuthorList count='5' hasPagination='true' sorting='true' />
      </div>
    )
  }
}
