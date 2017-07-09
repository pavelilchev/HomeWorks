import React, { Component } from 'react'
import '../styles//App.css'

import Navbar from './common/Navbar'
import Footer from './common/Footer'
import Routes from './common/Routes'

class App extends Component {
  render () {
    return (
      <div className='App'>
        <Navbar />
        <main>
          <div className='container'>
            <Routes />
          </div>
        </main>
        <Footer />
      </div>
    )
  }
}

export default App
