import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import profileService from '../../services/profile.service';
import Collections from './collections-component/Collections';
import ProfileCard from './profile-card-component/ProfileCard';
import collections from './collections-component/tempfiles/collections.json'
import './Profile.css'
import MyUploads from './my-uploads-component/my-uploads';
import authService from '../../services/auth.service';
import { useSearchParams } from 'react-router-dom';
import ViewCollection from './collections-component/view-collection-component/ViewCollection';
 
const Profile = () => {
    const {username, tab="uploads"} = useParams();
    const [user, setUser] = useState({isLoaded: false});
    //const user = { username: username };
    const ownerName = authService.getOwnerUsername();

    const [searchParams, setSearchParams] = useSearchParams();


    const fetchUser = async (username) => {
        const data = {...((await profileService.getUser(username)).data), isLoaded: true}
        setUser(data);
    }

    useEffect(() => {
        fetchUser(username)
    }, [username])

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard user={user} tab={tab} isOwnerProfile={ownerName?.toLowerCase() === username.toLowerCase()}/>
                </div>
                <div className="col">
                    {
                        tab === "collections" && (
                            searchParams.get('collectionName')
                            ?
                            <ViewCollection collectionName={searchParams.get('collectionName')} username = {username}/>
                            :
                            <Collections username={username}/>
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