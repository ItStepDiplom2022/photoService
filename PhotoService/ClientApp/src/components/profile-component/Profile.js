import React from 'react';
import { useParams } from 'react-router';
import profileService from '../../services/profile.service';
import Collections from './collections-component/Collections';
import ProfileCard from './profile-card-component/ProfileCard';
import collections from './collections-component/tempfiles/collections.json'
import './Profile.css'
 
const Profile = () => {
    const {username, tab} = useParams();
    // const user = profileService.getUser(username);
    const user = { username: username };
    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard avatarUrl={user.url} username={user.username} tab={tab}/>
                </div>
                <div className="col">
                    {
                        tab === "collections" && (
                            <Collections username={user.username}/>
                        )
                        tab === "uploads" && (
                            <MyUploads userName={userName}/>
                        )
                    }
                </div>
            </div>
        </div>
    );
}

export default Profile;