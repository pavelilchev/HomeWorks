import React, { Component } from 'react'
import '../styles//App.css'

import Navbar from './Navbar'
import Routes from './Routes'

class App extends Component {
  render () {
    return (
      <div className='App'>
        <Navbar />
        <div className='container'>
          <Routes />
        </div>
      </div>
    )
  }
}

export default App
