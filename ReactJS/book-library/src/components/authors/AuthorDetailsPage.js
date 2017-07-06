import React from 'react'
import { Link } from 'react-router-dom'
import authorsStore from '../../stores/AuthorsStore'
import booksStore from '../../stores/BooksStore'

export default class AuthorDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      author: {},
      books: []
    }
  }

  componentDidMount () {
    let id = this.props.match.params.id
    authorsStore
      .getById(id)
      .then(author => {
        this.setState({author})

        booksStore.getByAuthorName(author.name)
          .then(books => {
            this.setState({books})
          })
      })
  }

  render () {
    let author = this.state.author
    let books = this.state.books.map(b => {
      return (
        <li key={b.id}>
          <Link to={`/books/${b.id}`}>
          {b.title}
          </Link>
        </li>)
    })
    return (
      <div className='text-left'>
        Name: <b>{author.name}</b>
        <h3>Books:</h3>
        <ol>
          {books}
        </ol>
      </div>
    )
  }
}
