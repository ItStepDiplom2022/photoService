import React, { useEffect } from 'react';
import { useNavigate } from 'react-router';
import './ProfileCard.css';

const ProfileCard = ({avatarUrl="https://icon-library.com/images/default-user-icon/default-user-icon-8.jpg", username="Username1", userId=1, tab="uploads"}) => {
    const navigate = useNavigate();

    const handleClick = (subpath) => {
        navigate(`/profile/${userId}/${subpath}/`)
    }
    
    useEffect(() => { console.log(userId); }, []);

    return (
        <div className='profile-card'>
            <div className="user-info-part">
                <div className="avatar-wrapper">
                    <img src={avatarUrl} height="100%" width="100%" alt="avatar"/>
                </div>
                <span id='profile-username'>{username}</span>
            </div>  
            <div className="tabs-part">
                <a className='tab my' onClick={(e) => { e.preventDefault(); handleClick('uploads')}}>Uploads</a>
                <a className='tab selected my' onClick={(e) => { e.preventDefault(); handleClick('collections')}}>Collection</a>
            </div>
        </div>
    );
}

export default ProfileCard;