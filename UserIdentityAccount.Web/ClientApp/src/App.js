import React, {Component} from 'react';
import './custom.css';
import RegisterForm from "./components/User/RegisterForm";
import DataTable from "./components/Table/DataTable";

export default class App extends Component {
    static displayName = App.name;

    
    
    render() {
        return (
          <div style={{marginTop:"16%",marginLeft:"30%"}}>
            {/*<RegisterForm/>*/}
              <DataTable/>
          </div>
        );
    }
}
