import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Route
} from "react-router-dom";
import { Layout } from './Layout';
import { Home } from './Home';
import { About } from './About';
import { ReleasesForBeverage } from './ReleasesForBeverage';
import { Release } from './Release';
import './App.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Router>
        <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/about' component={About} />
            <Route exact path='/releases/:beverage' component={ReleasesForBeverage} />
            <Route exact path='/release/:beverage/:date' component={Release} />
        </Layout>
      </Router>
    );
  }
}
