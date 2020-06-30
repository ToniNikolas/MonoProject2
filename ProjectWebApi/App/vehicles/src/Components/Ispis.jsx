import React, { Component } from 'react'
import Axios from 'axios'

class Ispis extends Component {
    constructor(props) {
        super(props)

        this.state = {
            pohrana : []
                 
        }
    }
    componentDidMount()
    {
Axios.get('https://localhost:44361/api/vehiclemake/getall')
.then(response =>
    {console.log(response); 
        this.setState({pohrana : response.data});})
.catch(error =>{
        console.log(error)});
    }

    render() {
        const {pohrana} = this.state;
        return (
            <div>
{ pohrana.map(p => <div key={p.id}>{p.name}</div>)}
               
            </div>
        )
    }
}

export default Ispis
