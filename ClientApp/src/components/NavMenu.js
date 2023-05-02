import React, { Component } from 'react';
import Navbar from 'react-bootstrap/Navbar';
import Logo from '../images/Logoheader.png';
import './NavMenu.css';

//The client app will now reflect the server configuration that is set via the global window object.
//There is no need to fire an Ajax request to load this data or somehow make it available to the index.html static asset.


<NavbarText>
    {window.SERVER_PROTOCOL}
    {window.SERVER_SCHEME}://{window.SERVER_HOST}{window.SERVER_PATH_BASE}
</NavbarText>


export class NavMenu extends Component {
    static displayName = NavMenu.name;

 /*   constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    } */

    render() {
        return (
            <header>
                <Navbar className="navbar navbar-expand-lg navbar-light bg-light">
                    <a class="navbar-brand" href="/">
                        <img src={Logo} width="500" height="140" alt="Logo"></img>
                    </a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav mr-auto">
                            <li class="nav-item active">
                                <a class="nav-link" href="/Home">Home <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="/About">About</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="/Contact">Contact</a>
                            </li>

                            <li class="nav-item">
                                <div class="dropdown">
                                    <button id="navbarDropdown" class="btn dropdown-toggle" type="button" data-bs-toggle="collapse" data-bs-target="#dropdownNavMenu">
                                        Register/Login
                                    </button>
                                    <div id="dropdownNavMenu" class="dropdown-menu" aria-labelledby="navbarDropdown">
                                        <a class="dropdown-item" href="/StudentRegister">Register</a>
                                        <a class="dropdown-item" href="/StudentLogin">Login</a>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </Navbar>
            </header>
        );
    }
}