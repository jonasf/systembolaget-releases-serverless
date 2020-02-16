import React, { Component } from 'react';
import {
    Link
  } from "react-router-dom";
import { API_ROOT } from './Api-config';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { beverages: [] };
    
        this.getBeverages();
    }

    getBeverages(event) {
        fetch(`${API_ROOT}/getbeveragegroups`)
          .then(response => response.json())
          .then(payload => {
            this.setState({
                beverages: JSON.parse(payload.data).sort()
            });
        });
    }

    render() {
        return (
            <ul className="list-group">
                {this.state.beverages.map(beverage => (
                    <li className="list-group-item" key={beverage}>
                        <Link to={`/releases/` + encodeURIComponent(beverage)}>{beverage}</Link>
                    </li>
                ))}
            </ul>
        );
    }
}