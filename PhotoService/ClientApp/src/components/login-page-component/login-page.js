import './../shared/shared-styles.css'
import React from 'react';
import LoginForm from './login-form-component/login-form';

const LoginPage = () => {

    return (
        <div className='authorization-page-main-content'>
            <div className='authorization-page-image-div'>
            </div>

            <div className='authorization-page-form-div'>
                <LoginForm/>
            </div>

        </div>
    );
}

export default LoginPage;