import { height, width } from '@mui/system';
import React from 'react';
import { useParams } from 'react-router';
import profileService from '../../services/profile.service';
import ProfileCard from './profile-card-component/ProfileCard';
import './Profile.css'
 
const Profile = async () => {
    const {username, tab} = useParams();
    const user = (await profileService.getUser(username)).data;

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard avatarUrl={user.url} username={user.username} tab={tab}/>
                </div>
                <div className="col">
                    <div style={{height: '800px', width: "10px"}}></div>
                </div>
            </div>
        </div>
    );
}

export default Profile;