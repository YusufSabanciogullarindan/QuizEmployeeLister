import React, { useState, useEffect } from "react"
import "./App.css" // Added some styling
import axios from 'axios'
import DataFetching from "./DataFetching"

function App() {
  return (
    <div className='App'>
      <DataFetching />
    </div>
  )
}



export default App