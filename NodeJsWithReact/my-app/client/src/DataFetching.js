import React, { useState, useEffect } from "react"
import axios from 'axios'


function DataFetching() {
    const [employees, setEmployees] = useState([])

    useEffect(() => {
        axios.get('http://localhost:3000')
            .then(res => {
                console.log(res.data)

            })
            .catch(err => {
                console.log(err)
            })
    })

    return (
        <div>
            <ul>
                {
                    employees.map(employee => (<li key={employee.EMPLOYEE_ID}>test</li>))
                }
            </ul>
        </div>
    )
}

export default DataFetching