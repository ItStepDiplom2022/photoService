import React, { useEffect } from 'react';
import { useNavigate } from 'react-router';
import './ProfileCard.css';
import defaultUserImage from './tempfiles/default-user-icon.jpg'

const ProfileCard = ({avatarUrl=defaultUserImage, username, tab="uploads"}) => {
    const navigate = useNavigate();
    const user = localStorage.getItem('user');

    const handleClick = (subpath) => {
        navigate(`/profile/${username}/${subpath}/`)
    }

    const getClassesForTab = (name) => {
        let classes = "tab";

        if(user !== null)
            classes = classes.concat(user.toLowerCase().match(username.toLowerCase()) ? " my" : "");

        classes = classes.concat(tab === name ? " selected" : "");
        return classes;
    }

    return (
        <div className='profile-card'>
            <div className="user-info-part">
                <div className="avatar-wrapper">
                    <img src={avatarUrl} height="100%" width="100%" alt="avatar"/>
                </div>
                <span id='profile-username'>{username}</span>
            </div>  
            <div className="tabs-part">
                <a className={getClassesForTab('uploads')} onClick={(e) => { e.preventDefault(); handleClick('uploads')}}>Uploads</a>
                <a className={getClassesForTab('collections')} onClick={(e) => { e.preventDefault(); handleClick('collections')}}>Collection</a>
            </div>
        </div>
    );
}

export default ProfileCard;