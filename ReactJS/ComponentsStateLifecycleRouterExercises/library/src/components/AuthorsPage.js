import React from 'react'
import ReactPaginate from 'react-paginate'
import Author from './sub-components/Author'
import Data from '../database/Data'

export default class AuthorsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      authors: [],
      page: 1,
      itemPerPage: 5,
      pageCount: 0
    }

    this.handlePageClick = this.handlePageClick.bind(this)
    this.loadAuthors = this.loadAuthors.bind(this)
  }

  componentDidMount () {
    this.loadAuthors()
  }

  loadAuthors () {
    Data.allAuthors()
      .then(authors => {
        let skip = this.state.itemPerPage * (this.state.page - 1)
        this.setState({
          authors: authors.slice(skip, skip + this.state.itemPerPage),
          pageCount: Math.ceil(authors.length / this.state.itemPerPage)
        })
      })
  }

  handlePageClick (data) {
    this.setState({page: data.selected + 1}, () => {
      this.loadAuthors()
    })
  }

  render () {
    let authors = this.state.authors.map((author, index) => {
      return <Author key={author.id} author={author} />
    })

    return (
      <div className='container'>
        <div className='row'>
          {authors}
        </div>
        <div className='row'>
          <ReactPaginate
            previousLabel={'previous'}
            nextLabel={'next'}
            breakLabel={<a href=''>...</a>}
            breakClassName={'break-me'}
            pageCount={this.state.pageCount}
            marginPagesDisplayed={2}
            pageRangeDisplayed={5}
            onPageChange={this.handlePageClick}
            containerClassName={'pagination'}
            subContainerClassName={'pages pagination'}
            activeClassName={'active'} />
        </div>
      </div>
    )
  }
}
