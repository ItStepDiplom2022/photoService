import '../../shared/shared-styles.css'
import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const LoginForm = () => {

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')


    function onEmailChange(e) {
        setEmail(e.target.value);
    }

    function onPasswordChange(e) {
        setPassword(e.target.value);
    }

    const handleSubmit = (e) => {
        //just a mock
        e.preventDefault();
        alert(`You entered ${email}, ${password}`)
    }

    return (
        <>
            <form onSubmit={handleSubmit} className='authorization-form'>
                <div className='center-div'>
                    <h2 className='authorization-form-heading'>Welcome</h2>

                    <input type='email' className='form-control' placeholder='Email' onChange={onEmailChange} required />
                    <input type='password' className='form-control' placeholder='Password' onChange={onPasswordChange} required minLength={5} />

                    <button type='submit' className='btn btn-success'>Log in</button>
                    <span>Don`t have an account yet?&nbsp;
                        <Link to='/signup'>Register</Link>
                    </span>
                </div>
            </form>
        </>
    );
}

export default LoginForm;