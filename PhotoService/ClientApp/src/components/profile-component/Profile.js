import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import Collections from './collections-component/Collections';
import ProfileCard from './profile-card-component/ProfileCard';
import './Profile.css'
import MyUploads from './my-uploads-component/my-uploads';
import authService from '../../services/auth.service';
import { useSearchParams } from 'react-router-dom';
import ViewCollection from './collections-component/view-collection-component/ViewCollection';
import NotFound from '../shared/not-found-component/NotFound';
 
const Profile = () => {
    const {username, tab="uploads"} = useParams();
    const [user, setUser] = useState({isLoaded: false});
    const currentUserUsername = authService.getCurrentUserUsername();

    const [searchParams, setSearchParams] = useSearchParams();


    const fetchUser = async (username) => {
        const data = {...((await authService.getUser(username)).data), isLoaded: true}
        setUser(data);
    }

    useEffect(() => {
        fetchUser(username)
    }, [username])

    return (
        <div className='profile-page'>
            <div className="profileCard">
                <ProfileCard user={user} tab={tab} isCurrentUserProfile={currentUserUsername?.toLowerCase() === username.toLowerCase()}/>
            </div>
            <div className="profile-content">
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
                {
                    tab !== "uploads" && tab !== "collections" &&
                    (<NotFound/>)
                }
            </div>
        </div>
    );
}

export default Profile;