import './../shared/shared-styles.css'
import React from 'react';
import SignupForm from './signup-form-component/signup-form';

const SignupPage = () => {

    return (
        <div className='authorization-page-main-content'>
            <div className='authorization-page-image-div'>
            </div>

            <div className='authorization-page-form-div'>
                <SignupForm/>
            </div>
        </div>
    );
}

export default SignupPage;