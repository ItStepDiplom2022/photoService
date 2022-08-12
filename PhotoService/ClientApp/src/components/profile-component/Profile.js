import React from 'react';
import { useParams } from 'react-router';
import MyUploads from './my-uploads-component/my-uploads-component';
import ProfileCard from './profile-card-component/ProfileCard';
import './Profile.css'

const Profile = () => {
    const { tab} = useParams();

    return (
        <div className='profile-page'>
            <div className='row'>
                <div className="col-auto fs-4">
                    <ProfileCard tab={tab}/>
                </div>
                <div className="col">
                    {
                        tab=='uploads'?<MyUploads/>:"NONE"
                    }
                </div>
            </div>
        </div>
    );
}

export default Profile;