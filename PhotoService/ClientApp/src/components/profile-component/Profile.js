import React from 'react';
import { useParams } from 'react-router';
import MyUploads from './my-uploads-component/my-uploads';
import ProfileCard from './profile-card-component/ProfileCard';
import './Profile.css'

const Profile = () => {
    const { userName,tab} = useParams();

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard username={userName} tab={tab}/>
                </div>
                <div className="col">
                    {
                        tab=='uploads'?<MyUploads userName={userName}/>:"NONE"
                    }
                </div>
            </div>
        </div>
    );
}

export default Profile;