import $ from 'jquery'

let users = []
let books = [
  {id: 1, title: 'Book 1', author: 'Author 1', authorId: 1, date: '2017-07-06', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 69.69},
  {id: 2, title: 'Book 2', author: 'Author 1', authorId: 1, date: '2017-07-03', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 59.69},
  {id: 3, title: 'Book 3', author: 'Author 2', authorId: 2, date: '2017-07-02', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 9.69},
  {id: 4, title: 'Book 4', author: 'Author 2', authorId: 2, date: '2017-06-24', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 169.69},
  {id: 5, title: 'Book 5', author: 'Author 3', authorId: 3, date: '2017-06-20', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 62.69},
  {id: 6, title: 'Book 6', author: 'Author 4', authorId: 4, date: '2017-06-15', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 63.69},
  {id: 7, title: 'Book 7', author: 'Author 5', authorId: 5, date: '2017-06-13', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 12.69},
  {id: 8, title: 'Book 8', author: 'Author 5', authorId: 5, date: '2017-06-05', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 36.69},
  {id: 9, title: 'Book 9', author: 'Author 5', authorId: 5, date: '2017-06-04', img: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png', description: 'Some description', price: 82.69}
]

let comments = [
  {id: 1, bookId: 1, text: 'Some cool comment 1'},
  {id: 2, bookId: 1, text: 'Some cool comment 2'},
  {id: 3, bookId: 1, text: 'Some cool comment 3'},
  {id: 4, bookId: 2, text: 'Some cool comment 4'},
  {id: 5, bookId: 2, text: 'Some cool comment 5'}
]

let authors = [
  {id: 1, name: 'Author 1', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 2, name: 'Author 2', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 3, name: 'Author 3', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 4, name: 'Author 4', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 5, name: 'Author 5', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 6, name: 'Author 6', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 7, name: 'Author 7', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 8, name: 'Author 8', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 9, name: 'Author 9', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 10, name: 'Author 10', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'},
  {id: 11, name: 'Author 11', img: 'http://unicode.org/reports/tr51/images/other/person-bw.png'}
]

let data = {
  loginUser: (user) => {
    return new Promise((resolve, reject) => {
      let existingUser = users.find(function (u) {
        if (u.username === user.username && u.password === user.password) {
          return u
        }

        return false
      })

      if (existingUser) {
        resolve({
          success: true,
          message: 'Successfully logged in',
          token: 'dfsdfmnsdfmclkdfsa1f1fg2f1gdfg',
          user: user
        })
      } else {
        resolve({
          success: false,
          message: 'Wrong username or password'
        })
      }
    })
  },
  registerUser: (user) => {
    return new Promise((resolve, reject) => {
      let existingUser = users.find(function (u) {
        if (u.username === user.username) {
          return u
        }

        return false
      })

      if (existingUser) {
        resolve({
          success: false,
          message: 'Username already exist'
        })
      } else {
        users.push(user)
        resolve({
          success: true,
          message: 'Successfully registered'
        })
      }
    })
  },
  allBooks: () => {
    return new Promise((resolve, reject) => {
      resolve(books.slice(0))
    })
  },
  getBookById: (id) => {
    return new Promise((resolve, reject) => {
      resolve(books.find(b => b.id === Number(id)))
    })
  },
  getCommentsByBookId: (bookId) => {
    return new Promise((resolve, reject) => {
      let result = []
      for (let c of comments) {
        if (c.bookId === bookId) {
          result.push(c)
        }
      }

      resolve(result)
    })
  },
  allAuthors: () => {
    return new Promise((resolve, reject) => {
      resolve(authors.slice(0))
    })
  },
  getAuthorById: (id) => {
    return new Promise((resolve, reject) => {
      resolve(authors.find(a => a.id === Number(id)))
    })
  },
  getBooksByAuthorName: (authorName) => {
    return new Promise((resolve, reject) => {
      let result = []
      for (let b of books) {
        if (b.author === authorName) {
          result.push(b)
        }
      }

      resolve(result)
    })
  },
  deleteBookById: (id) => {
    return new Promise((resolve, reject) => {
      books = $.grep(books, function (b) {
        return b.id !== Number(id)
      })

      resolve('Done')
    })
  },
  deleteAuthorById: (id) => {
    return new Promise((resolve, reject) => {
      authors = $.grep(authors, function (b) {
        return b.id !== Number(id)
      })

      resolve('Done')
    })
  },
  deleteCommentById: (id) => {
    return new Promise((resolve, reject) => {
      comments = $.grep(comments, function (b) {
        return b.id !== Number(id)
      })

      resolve('Done')
    })
  }
}

export default data
