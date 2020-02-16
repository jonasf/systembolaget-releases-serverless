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
                beverages: JSON.parse(payload.data).sort(this.compare)
            });
        });
    }

    compare(a, b) {
        if ( a.Name < b.Name ){
            return -1;
        }
        if ( a.Name > b.Name ){
            return 1;
        }
        return 0;
    }

    render() {
        return (
            <div>
                <h1>Nytt i {this.state.beverage} {this.state.releasedate}</h1>
                <ul className="list-group">
                    {this.state.beverages.map(beverage => (
                        <li className="list-group-item" key={beverage.ArticleNumber}>
                            <span className="font-weight-bold">{beverage.Name} {beverage.SecondaryName}</span> <span className="font-weight-light">({beverage.Type})</span><br/>
                            <span className="font-weight-normal">{beverage.AlcoholContent}, {beverage.VolumeMl} ml, {beverage.PriceIncVat} kr ({beverage.ProductRangeAbbreviation})</span><br/>
                            <span className="small">{beverage.Producer}, {beverage.OriginCountry}</span><br/> 
                        </li>
                    ))}
                </ul>
            </div>
        );
    }
}