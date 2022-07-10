import './navbar.css';
import { Link } from 'react-router-dom';
import React from 'react';

export default function Navbar(){
    return (
        <nav className="navbar navbar-expand-lg navbar-dark custom-navbar">
            <div className="container-fluid">
                <div className='col-2'>
                    <Link className="navbar-brand" to="/">
                        <img src='images/camera_icon.png' alt="" width="30" height="30" className="d-inline-block align-text-top logo" />
                        <span className='project-title'>Project title</span>
                    </Link>
                </div>

                <button className="navbar-toggler ms-auto" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNavbar">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="navbar-collapse collapse" id="collapseNavbar">
                    <ul className="navbar-nav left-navbar-part">
                        <li className="nav-item">
                            <Link className="nav-link" to="/">Main</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/">About us</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/">Log in</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}