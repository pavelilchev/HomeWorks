import React from 'react'
import { Link } from 'react-router-dom'
import UserMenu from './UserMenu'

export default class Navbar extends React.Component {
  render () {
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
            <Link className='navbar-brand' to='/'>
            <img src={require('../../images/logo.png')} alt='AutoShop Logo' />
            </Link>
          </div>
          <div className='collapse navbar-collapse' id='bs-example-navbar-collapse-1'>
            <ul className='nav navbar-nav' id='menu-links'>
              <li className='active'>
                <Link className='navbar-brand' to='/'> Home
                </Link>
              </li>
              <li>
                <Link className='navbar-brand' to='/reviews/all'> Reviews
                </Link>
              </li>
            </ul>
            <UserMenu />
          </div>
        </div>
      </nav>
    )
  }
}
