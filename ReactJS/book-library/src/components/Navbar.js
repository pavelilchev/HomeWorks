import React from 'react'
import { Link } from 'react-router-dom'
import Auth from './users/Auth'

export default class Navbar extends React.Component {
  render () {
    let rightMenu = ''
    Auth.isUserAuthenticated()
      ? rightMenu = (
        <ul className='nav navbar-nav navbar-right'>
          <li className='header-greeting'>
            Hello, {Auth.getUser().username}
          </li>
          <li>
            <Link to='/user/logout'> Login
            </Link>
          </li>
        </ul>)
      : rightMenu = (
        <ul className='nav navbar-nav navbar-right'>
          <li>
            <Link to='/user/register'> Register
            </Link>
          </li>
          <li>
            <Link to='/user/login'> Login
            </Link>
          </li>
        </ul>)
    return (
      <nav className='navbar navbar-default'>
        <div className='container'>
          <div className='navbar-header'>
            <button
              type='button'
              className='navbar-toggle collapsed'
              data-toggle='collapse'
              data-target='#bs-example-navbar-collapse-1'
              aria-expanded='false'>
              <span className='sr-only'>Toggle navigation</span>
              <span className='icon-bar' />
              <span className='icon-bar' />
              <span className='icon-bar' />
            </button>
            <Link className='navbar-brand' to='/'> Library
            </Link>
          </div>
          <div className='collapse navbar-collapse' id='bs-example-navbar-collapse-1'>
            <ul className='nav navbar-nav'>
              <li className='active'>
                <Link className='navbar-brand' to='/'> Home
                </Link>
              </li>
              <li>
                <Link className='navbar-brand' to='/books/all'> Books
                </Link>
              </li>
              <li>
                <Link className='navbar-brand' to='/books/add'> Add Book
                </Link>
              </li>
              <li>
                <Link className='navbar-brand' to='/authors/all'> Authors
                </Link>
              </li>
            </ul>
            {rightMenu}
          </div>
        </div>
      </nav>
    )
  }
}
