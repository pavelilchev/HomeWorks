const books = [
  {id: 1, authorId: 1, title: 'It 1', author: 'Stephan King', date: '2017-06-25', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 2, authorId: 1, title: 'It 2', author: 'Stephan King', date: '2017-06-25', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 3, authorId: 2, title: 'Под Игото', author: 'Иван Вазов', date: '2017-06-24', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 4, authorId: 4, title: 'Пътеводител на галактическия стопаджия', author: 'Дъглас Адамс', date: '2017-06-23', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 5, authorId: 3, title: 'Small Gods', author: 'Terry Pratchett', date: '2017-06-22', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 6, authorId: 3, title: 'Hogfather', author: 'Terry Pratchett', date: '2017-06-24', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'},
  {id: 7, authorId: 1, title: 'Duma Ki', author: 'Stephan King', date: '2017-06-21', image: 'http://smartmobilestudio.com/wp-content/uploads/2012/06/leather-book-preview.png'}]

const comments = [
  {id: 1, bookId: 1, comment: 'Cool book'},
  {id: 2, bookId: 1, comment: 'Very Cool book'},
  {id: 3, bookId: 2, comment: 'The best book ever'}
]

const authors = [
  {id: 1, name: 'Stephan King', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'},
  {id: 2, name: 'Иван Вазов', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'},
  {id: 3, name: 'Terry Pratchett', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'},
  {id: 4, name: 'Дъглас Адамс', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'},
  {id: 5, name: 'Йордан Йовков', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'},
  {id: 6, name: 'Agatha Christie', image: 'http://www.clker.com/cliparts/d/L/P/X/z/i/no-image-icon-md.png'}
]

const data = {
  allBooks: () => {
    return new Promise((resolve, reject) => {
      resolve(books)
    })
  },
  allAuthors: () => {
    return new Promise((resolve, reject) => {
      resolve(authors)
    })
  },
  getBookById: (id) => {
    return new Promise((resolve, reject) => {
      let book = {}
      id = Number(id)
      for (let b of books) {
        if (b.id === id) {
          book = b
          break
        }
      }

      resolve(book)
    })
  },
  getAuthorById: (id) => {
    return new Promise((resolve, reject) => {
      let author = {}
      id = Number(id)
      for (let a of authors) {
        if (a.id === id) {
          author = a
          break
        }
      }

      resolve(author)
    })
  },
  getCommentsById: (bookId) => {
    return new Promise((resolve, reject) => {
      let finded = []
      bookId = Number(bookId)
      for (let c of comments) {
        if (c.bookId === bookId) {
          finded.push(c)
        }
      }

      resolve(finded)
    })
  },
  getBooksByAuthorId: (authorId) => {
    return new Promise((resolve, reject) => {
      let finded = []
      authorId = Number(authorId)
      for (let b of books) {
        if (b.authorId === authorId) {
          finded.push(b)
        }
      }

      resolve(finded)
    })
  }
}

export default data
