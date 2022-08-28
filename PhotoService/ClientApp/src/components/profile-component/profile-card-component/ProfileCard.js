import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import './ProfileCard.css';
import defaultUserImage from './tempfiles/default-user-icon.jpg'

const ProfileCard = ({user={avatarUrl: defaultUserImage}, tab="uploads", isOwnerProfile=false}) => {
    const navigate = useNavigate();
    console.log(user);

    const handleClick = (subpath) => {
        if(user.isLoaded)
            navigate(`/profile/${user.userName}/${subpath}/`)
    }

    const getClassesForTab = (name) => {
        let classes = "tab";
        classes = classes.concat(isOwnerProfile ? " my" : "");
        classes = classes.concat(tab === name ? " selected" : "");
        return classes;
    }

    return (
        <>
            {
                user.isLoaded && (
                    <div className='profile-card'>
                        <div className="user-info-part">
                            <div className="avatar-wrapper">
                                <img src={user.avatarUrl} height="100%" width="100%" alt="avatar"/>
                            </div>
                            <span id='profile-username'>{user.userName}</span>
                        </div>  
                        <div className="tabs-part">
                            <a className={getClassesForTab('uploads')} onClick={(e) => { e.preventDefault(); handleClick('uploads')}}>Uploads</a>
                            <a className={getClassesForTab('collections')} onClick={(e) => { e.preventDefault(); handleClick('collections')}}>Collection</a>
                        </div>
                    </div>
                )
            }
        </>
    );
}

export default ProfileCard;