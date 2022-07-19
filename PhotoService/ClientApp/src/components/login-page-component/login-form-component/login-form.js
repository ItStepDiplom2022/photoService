import '../../shared/shared-styles.css'
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import AuthService from "../../../services/auth.service";
import { Alert, Snackbar } from '@mui/material';

const LoginForm = ({onLoggedChange}) => {

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const [snackBarOptions, setSnackBarOptions] = useState({ isOpen: false, severity: 'success', message: '' })
    const navigate = useNavigate()


    function onEmailChange(e) {
        setEmail(e.target.value);
    }

    function onPasswordChange(e) {
        setPassword(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault()
        AuthService.login(email, password)
        .then(() => {
                onLoggedChange()
                return navigate('/')
            })
        .catch(error=>{
            setSnackBarOptions({ isOpen: true, severity: 'error', message: error })
        })
    }

    const handleSnackBarClose = (event) => {
        setSnackBarOptions({ isOpen: false, severity: 'error' })
    };

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

            <Snackbar open={snackBarOptions.isOpen} autoHideDuration={5000} onClose={handleSnackBarClose} anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}>
                <Alert severity={snackBarOptions.severity} sx={{ width: '100%' }} onClose={handleSnackBarClose} variant="filled">
                    {snackBarOptions.message}
                </Alert>
            </Snackbar>
        </>
    );
}

export default LoginForm;