import logo from './logo.svg';
import './App.css';
import React, { useState } from 'react';



function App() {
  const [count, setCount] = useState(0)
  const [color, setColor] = useState("#333")
  return (
    <div className="App">
      <nav className="nav">
        <a href='7' className="site-title">
          IoT protocols | Esercizio Droni
        </a>
      </nav>
      <div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>non cliccare assolutamente</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div><div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>

        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
        <div className='row'>
          <ul>descrizione</ul>
          <button className='button' ></button>
        </div>
      </div>
      <div className='container-map'>

      </div>
      <div className="main-footer">
        <div className="container">
          <hr />
          <p className="col-sm">
            &copy;{new Date().getFullYear()} | All rights reserved |
            Terms Of Service | Privacy
          </p>
        </div>
      </div>
    </div>
  );
}

export default App;












/*
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
       */