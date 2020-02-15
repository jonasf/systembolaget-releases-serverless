import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor (props) {
        super(props);
        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }
    
    toggleNavbar () {
        this.setState({
          collapsed: !this.state.collapsed
        });
    }

    render () {
        return (
            <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white navbar-dark bg-dark border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">Systembolaget releases</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} to="/about">About</NavLink>
                        </NavItem>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
            </header>
        );
    }
}