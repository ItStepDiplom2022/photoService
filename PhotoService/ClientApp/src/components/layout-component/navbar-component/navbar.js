import './navbar.css';
import { Link } from 'react-router-dom';
import React from 'react';
import SearchIcon from '@mui/icons-material/Search';

export default function Navbar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-dark custom-navbar">
            <div className="container-fluid">

                <div className='col-2'>
                    <Link className="navbar-brand" to="/">
                        <img src='images/camera_icon.png' alt="" width="30" height="30" className="d-inline-block align-text-top logo" />
                        <span className='project-title'>Photo service</span>
                    </Link>
                </div>

                <button className="navbar-toggler ms-auto" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNavbar">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="navbar-collapse collapse col-8" id="collapseNavbar">
                    <ul className="navbar-nav left-navbar-part">
                        <li className="nav-item">
                            <Link className="nav-link nav-link-custom" to="/">Main</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link nav-link-custom" to="/">About us</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link nav-link-custom" to="/">Log in</Link>
                        </li>
                    </ul>
                </div>

                <div className="input-group mb-3 search-field">
                    <input type="text" className="form-control" placeholder="Search..." aria-label="Search" />
                    <div className="input-group-append">
                        <button className="btn btn-primary" type="button">
                            <SearchIcon/>
                        </button>
                    </div>
                </div>

            </div>
        </nav>
    );
}