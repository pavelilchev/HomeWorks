import React from 'react'
import { Link } from 'react-router-dom'

export default class Header extends React.Component {
  render () {
    return (
      <nav className='nvbar navbar-default navbar-static-top'>
        <div className='container'>
          <div className='navbar-header'>
            <button
              type='button'
              className='navbar-toggle collapsed'
              data-toggle='collapse'
              data-target='#navbar'>
              <span className='sr-only'>Toggle navigation</span>
              <span className='icon-bar' />
              <span className='icon-bar' />
              <span className='icon-bar' />
            </button>
            <Link to='/' className='navbar-brand' />
          </div>
          <div id='navbar' className='navbar-collapse collapse'>
            <ul className='nav navbar-nav'>
              <li>
                <Link to='/'> Home
                </Link>
              </li>
              <li>
                <Link to='/books/all'> Books
                </Link>
              </li>
              <li>
                <Link to='/authors/all'> Authors
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    )
  }
}
