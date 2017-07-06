import React from 'react'
import Data from '../database/Data'
import Book from './sub-components/Book'

export default class AuthorDetails extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      author: {},
      books: []
    }
  }

  componentDidMount () {
    let id = this.props.match.params.id
    Data.getAuthorById(id)
      .then(author => {
        this.setState({
          author: author
        })
      })

    Data.getBooksByAuthorId(id)
      .then(books => {
        this.setState({
          books: books
        })
      })
  }

  render () {
    let author = this.state.author
    let books = this.state.books.map((book, index) => {
      return <Book key={book.id} book={book} />
    })
    return (
      <div className='col-md-6'>
        <div className='single-author'>
          <h3>{author.name}</h3>
          <img src={author.image} alt={author.name} />
        </div>
        <div className='author-books'>
          <h3>Books:</h3>
          {books}
        </div>
      </div>
    )
  }
}
