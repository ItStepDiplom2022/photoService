import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import profileService from '../../services/profile.service';
import Collections from './collections-component/Collections';
import ProfileCard from './profile-card-component/ProfileCard';
import collections from './collections-component/tempfiles/collections.json'
import './Profile.css'
import MyUploads from './my-uploads-component/my-uploads';
import authService from '../../services/auth.service';
 
const Profile = () => {
    const {username, tab="uploads"} = useParams();
    const [user, setUser] = useState({});
    //const user = { username: username };
    const ownerName = authService.getOwnerUsername();

    const fetchUser = async (username) => {
        setUser((await profileService.getUser(username)).data);
        console.log(user);
    }

    useEffect(() => {
        fetchUser(username)
    }, [])

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard user={user} tab={tab} isOwnerProfile={ownerName?.toLowerCase() === username.toLowerCase()}/>
                </div>
                <div className="col">
                    {
                        tab === "collections" && (
                            <Collections username={user.username}/>
                        )
                    }
                    {
                        tab === "uploads" && (
                            <MyUploads userName={username}/>
                        )
                    }
                </div>
            </div>
        </div>
    );
}

export default Profile;