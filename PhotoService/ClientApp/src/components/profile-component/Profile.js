import { height, width } from '@mui/system';
import React from 'react';
import { useParams } from 'react-router';
import profileService from '../../services/profile.service';
import Collections from './collections-component/Collections';
import ProfileCard from './profile-card-component/ProfileCard';
import collections from './collections-component/tempfiles/collections.json'
import './Profile.css'
 
const Profile = () => {
    const {username, tab} = useParams();
    const user = { username: username};
    const collectionList = collections
    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard avatarUrl={user.url} username={user.username} tab={tab}/>
                </div>
                <div className="col">
                    {
                        tab === "collections" && (
                            <Collections items={collectionList}/>
                        )
                    }
                </div>
            </div>
        </div>
    );
}

export default Profile;