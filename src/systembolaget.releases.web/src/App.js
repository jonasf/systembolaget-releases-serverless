import React, { Component } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import { Layout } from './Layout';
import { Home } from './Home';
import { About } from './About';
import './App.css';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Router>
        <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/about' component={About} />
        </Layout>
      </Router>
    );
  }
}
