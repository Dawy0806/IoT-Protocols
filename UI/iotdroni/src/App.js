import './App.css';
import React from 'react';
import { useState } from 'react';


function App() {
  // const [count, setCount] = useState(0)
  // const [color, setColor] = useState("#333")

  const [speed, setSpeed] = useState('')
  const [lan, setLan] = useState('')
  const [long, setLong] = useState('')
  const [altezza, setAltezza] = useState('')
  const [batteria, setBatteria] = useState('')
  const [tm, setTm] = useState('')
  const [temp, setTemp] = useState('')
  
  
  const handleChangeSpeed = event => {
    setSpeed(event.target.value);
    //console.log('speed:', event.target.value);
  };

  const handleChangeLan = event => {
    setLan(event.target.value);
    //console.log('lan:', event.target.value);
  };

  const handleChangeLong = event => {
    setLong(event.target.value);
    //console.log('long:', event.target.value);
  };

  const handleChangeAltezza = event => {
    setAltezza(event.target.value);
    //console.log('altezza:', event.target.value);
  };

  const handleChangeBatteria = event => {
    setBatteria(event.target.value);
    //console.log('batteria:', event.target.value);
  };

  const handleChangeTm = event => {
    setTm(event.target.value);
    //console.log('tm:', event.target.value);
  };

  
  const handleChangeTemp = event => {
    setTemp(event.target.value);
    //console.log('temp:', event.target.value);
  };



  return (
    
    <div className="App" style={{ widht: '100%', height: '100%' }}>
      <nav className="nav">
        <a href='7' className="site-title">
          IoT protocols | Esercizio Droni
        </a>
      </nav>

      <div className='body'>
        <div className='addDrone'>
          <div className='insert'>
            <label>Velocita: </label>
            <input type="text" className='speed' id='speed' value={speed} onChange={handleChangeSpeed}/><br></br>
            <label>Altitudine: </label>
            <input type="text" className='altitudine' id='altitudine' value={lan} onChange={handleChangeLan}/><br></br>
            <label>Longitudine: </label>
            <input type="text" className='longitudine' id='longitudine' value={long} onChange={handleChangeLong}/><br></br>
            <label>Altezza: </label>
            <input type="text" className='altezza' id='altezza' value={altezza} onChange={handleChangeAltezza}/><br></br>
            <label>Batteria: </label>
            <input type="text" className='batteria' id='batteria' value={batteria} onChange={handleChangeBatteria}/><br></br>
            <label>Temperatura motore: </label>
            <input type="text" className='tm' id='tm' value={tm} onChange={handleChangeTm}/><br></br>
            <label>Temperatura: </label>
            <input type="text" className='t' id='t' value={temp} onChange={handleChangeTemp}/><br></br>
            <input type="submit" value="Submit"/>
          </div>
        </div>

        <div className='listDroni'>
        </div>
      </div>

      {/* <div>
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

      </div> */}
      <div className="main-footer">
        <div className="container">
          <hr />
          <p className="col-sm">
            &copy;{new Date().getFullYear()} | All rights reserved |
            Terms Of Service | Privacy
          </p>
        </div>
      </div>
    </div >
  );
}

export default App;









