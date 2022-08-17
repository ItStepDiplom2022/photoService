import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import './ProfileCard.css';

const ProfileCard = ({avatarUrl="https://icon-library.com/images/default-user-icon/default-user-icon-8.jpg", username, userId=1, tab="uploads"}) => {
    const navigate = useNavigate();
    const [selectedTab, setSelectedTab] = useState("uploads")

    const handleClick = (subpath) => {
        setSelectedTab(subpath)
        navigate(`/profile/${username}/${subpath}/`)
    }
    
    useEffect(() => { 
        navigate(`/profile/${username}/${selectedTab}/`)
     }, []);

    return (
        <div className='profile-card'>
            <div className="user-info-part">
                <div className="avatar-wrapper">
                    <img src={avatarUrl} height="100%" width="100%" alt="avatar"/>
                </div>
                <span id='profile-username'>{username}</span>
            </div>  
            <div className="tabs-part">
                <a className={selectedTab==='uploads'?'tab my selected':'tab my'} onClick={(e) => { e.preventDefault(); handleClick('uploads')}}>Uploads</a>
                <a className={selectedTab==='collections'?'tab my selected':'tab my'} onClick={(e) => { e.preventDefault(); handleClick('collections')}}>Collection</a>
            </div>
        </div>
    );
}

export default ProfileCard;