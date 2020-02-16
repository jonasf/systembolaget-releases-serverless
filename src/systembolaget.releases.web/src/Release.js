import React, { Component } from 'react';
import { API_ROOT } from './Api-config';

export class Release extends Component {
    static displayName = Release.name;

    constructor(props) {
        super(props);
        const { match: { params } } = this.props;
        this.state = { beverages: [], beverage: params.beverage, releasedate: params.date };
    
        this.getReleasesForDate();
    }

    getReleasesForDate(event) {
        fetch(`${API_ROOT}/getrelease?group=${this.state.beverage}&date=${this.state.releasedate}`)
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
                    <li className="list-group-item" key={beverage.ArticleNumber}>
                        {beverage.Name} {beverage.SecondaryName}, {beverage.Producer}, {beverage.VolumeMl} ml, {beverage.AlcoholContent}, {beverage.PriceIncVat} kr
                    </li>
                ))}
            </ul>
        );
    }
}