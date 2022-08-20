import './navbar.css';
import { Link } from 'react-router-dom';
import React from 'react';
import authService from '../../../services/auth.service';
import SearchBar from '../../search-bar-component/SearchBar';


export default function Navbar({isLoggedIn, onLoggedChange, username}) {

    function logoutHadler(e) {
        authService.logout();
        onLoggedChange()
    }

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

                <div className="navbar-collapse collapse col-auto" id="collapseNavbar">
                    <ul className="navbar-nav left-navbar-part">
                        <li className="nav-item">
                            <Link className="nav-link nav-link-custom" to="/">Main</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link nav-link-custom" to="/">About us</Link>
                        </li>
                        {
                            isLoggedIn ?
                                <>
                                    <li className="nav-item">
                                        <Link className="nav-link nav-link-custom" to={'profile/'+username}>My profile</Link>
                                    </li>
                                    <li className="nav-item">
                                        <Link className="nav-link nav-link-custom" to="/login" onClick={logoutHadler}>Log out</Link>
                                    </li>
                                </>
                                :
                                <li className="nav-item">
                                    <Link className="nav-link nav-link-custom" to="/login">Log in</Link>
                                </li>
                        }
                    </ul>
                </div>

                <div className="mb-3 search-field justify-content-end col-3">
                    <SearchBar />
                </div>

            </div>
        </nav>
    );
}