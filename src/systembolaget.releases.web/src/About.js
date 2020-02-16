import React, { Component } from 'react';

export class About extends Component {
    static displayName = About.name;

    render() {
        return (
            <div>
                <h1>Om</h1>
                <p>Den här sidan ger en enkel översikt över alla nyheter på Systembolaget.</p>
                <p>Systembolagets <a href="https://www.systembolaget.se/api/" target="_blank">öppna API</a> används som datakälla.</p>
            </div>
        );
    }
}