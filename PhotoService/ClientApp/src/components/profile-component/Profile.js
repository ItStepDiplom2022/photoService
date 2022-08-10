import { height, width } from '@mui/system';
import React from 'react';
import { useParams } from 'react-router';
import ProfileCard from './profile-card-component/ProfileCard';
import './Profile.css'

const Profile = () => {
    const {id, tab} = useParams();

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard userId={id} tab={tab}/>
                </div>
                <div className="col">
                    <div style={{height: '800px', width: "10px"}}></div>
                </div>
            </div>
        </div>
    );
}

export default Profile;