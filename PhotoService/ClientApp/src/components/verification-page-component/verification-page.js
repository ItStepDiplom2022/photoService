import './../shared/shared-styles.css'
import './verification-page.css'
import React from 'react';
import { Link } from 'react-router-dom';

const VerificationPage = () => {

    return (
        <div className='authorization-page-main-content'>
            <div className='authorization-page-image-div'>
            </div>

            <div className='authorization-page-form-div'>
                <div className='verification-message'>
                    We sent you an email with instruction for verifying your email.
                    Follow it and then &nbsp;
                    <Link to='/login'>login</Link>
                </div>
            </div>
            
        </div>
    );
}

export default VerificationPage;