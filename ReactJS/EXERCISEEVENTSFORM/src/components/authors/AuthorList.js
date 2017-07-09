import React from 'react'
import authorsStore from '../../stores/AuthorsStore'
import Author from './Author'
import ReactPaginate from 'react-paginate'

export default class AuthorList extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      authors: [],
      perPage: 5,
      offset: 0,
      pageCount: 0,
      sort: {
        order: 'asc'
      }
    }
  }

  componentDidMount () {
    this.getAuthors()
  }

  getAuthors () {
    authorsStore.getAll()
      .then(authors => {
        let pageCount = Math.ceil(authors.length / this.state.perPage)
        this.setState({pageCount: pageCount})
        authors = this.sortAuthors(authors)
        authors = authors.splice(this.state.offset, this.props.count)
        this.setState({authors})
      })
  }

  sortAuthors (authors) {
    if (this.state.sort.order === 'asc') {
      return authors.sort(function (a, b) {
        return a.name.localeCompare(b.name)
      })
    } else {
      return authors.sort(function (a, b) {
        return b.name.localeCompare(a.name)
      })
    }
  }

  handlePageClick (data) {
    let selected = data.selected
    let offset = Math.ceil(selected * this.state.perPage)

    this.setState({offset: offset}, this.getAuthors())
  }

  handleCriteriaChnage (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let sort = this.state.sort
    sort[field] = value
    this.setState({sort})
    this.getAuthors()
  }

  render () {
    let authors = this.state.authors.map(b => {
      return <Author key={b.id} author={b} />
    })
    let paging = null
    if (this.props.hasPagination === 'true') {
      paging = (
        <ReactPaginate
          previousLabel={'previous'}
          nextLabel={'next'}
          breakLabel={<a href=''>...</a>}
          breakClassName={'break-me'}
          pageCount={this.state.pageCount}
          marginPagesDisplayed={2}
          pageRangeDisplayed={5}
          onPageChange={this.handlePageClick.bind(this)}
          containerClassName={'pagination'}
          subContainerClassName={'pages pagination'}
          activeClassName={'active'} />)
    }

    return (
      <div>
        <div className='row'>
          <div className='col-sm-4 col-centered'>
            <select onChange={this.handleCriteriaChnage.bind(this)} name='order'>
              <option value='desc'>
                Descending
              </option>
              <option value='asc'>
                Ascending
              </option>
            </select>
          </div>
        </div>
        <div className='row authors-wrapper'>
          {authors}
        </div>
        {paging}
      </div>
    )
  }
}
