import React, { Component } from 'react';
import {
    Link
  } from "react-router-dom";
import { API_ROOT } from './Api-config';

export class ReleasesForBeverage extends Component {
    static displayName = ReleasesForBeverage.name;

    constructor(props) {
        super(props);
        const { match: { params } } = this.props;
        this.state = { releases: [], beverage: params.beverage };
    
        this.getReleasesForBeverage();
    }

    getReleasesForBeverage(event) {
        fetch(`${API_ROOT}/getreleasesbygroup?group=${this.state.beverage}`)
          .then(response => response.json())
          .then(payload => {
            this.setState({
                releases: JSON.parse(payload.data).sort()
            });
          });
      }

    render() {
        return (
            <ul className="list-group">
                {this.state.releases.map(release => (
                    <li className="list-group-item d-flex justify-content-between align-items-center" key={release.date}>
                        <Link to={`/release/${this.state.beverage}/` + encodeURIComponent(release.date)}>{release.date}</Link>
                        <span className="badge badge-primary badge-pill">{release.count}</span>
                    </li>
                ))}
            </ul>
        );
    }
}