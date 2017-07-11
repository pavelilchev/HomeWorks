import React, { Component } from 'react'
import '../../styles//App.css'

import Navbar from './Navbar'
import Footer from './Footer'
import Routes from './Routes'

class App extends Component {
  render () {
    return (
      <div className='App'>
        <Navbar />
        <main>
          <Routes />
        </main>
        <Footer />
      </div>
    )
  }
}

export default App
