import './signup-form.css';
import '../../shared/shared-styles.css'
import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import authService from '../../../services/auth.service';
import { Alert, Snackbar } from '@mui/material';


const SignupForm = ({ onLoggedChange }) => {

    const initialData = { username: '', email: '', password: '', passwordConfirm: '' }
    const [userData, setUserData] = useState(initialData)
    const [passwordsMatch, setPasswordsMatch] = useState(true)
    const [snackBarOptions, setSnackBarOptions] = useState({ isOpen: false, severity: 'success', message: '' })

    const navigate = useNavigate()

    //handles ALL changes in the form
    const handleChange = (e) => {
        const { name, value } = e.target
        setUserData({ ...userData, [name]: value })
    }

    const handleSubmit = (event) => {
        event.preventDefault();

        if (!validatePassword()) {
            setPasswordsMatch(false)
            return
        } else
            setPasswordsMatch(true)
        setSnackBarOptions({ isOpen: true, severity: 'info', message: "Wait a second..." })

        authService.signup(userData.username, userData.email, userData.password)
            .then(() => {
                return navigate('/verify')
            })
            .catch(error => {
                setSnackBarOptions({ isOpen: true, severity: 'error', message: error })
            })
    }

    const handleSnackBarClose = (event) => {
        setSnackBarOptions({ isOpen: false, severity: 'error' })
    };

    const validatePassword = () => {
        return userData.password === userData.passwordConfirm
    }

    return (
        <>
            <form onSubmit={handleSubmit} className='authorization-form'>
                <div className='center-div'>
                    <h2 className='authorization-form-heading'>Welcome</h2>
                    <h5>In order to register please fill the form</h5>

                    <input type='text' className='form-control' placeholder='Username' name='username' onChange={handleChange} required />
                    <input type='email' className='form-control' placeholder='Email' name='email' onChange={handleChange} required />
                    <input type='password' className='form-control' placeholder='Password' name='password' onChange={handleChange} required minLength={5} />
                    <input type='password' className='form-control' placeholder='Confirm password' name='passwordConfirm' onChange={handleChange} required minLength={5} />
                    <p className={`${!passwordsMatch ? 'error-message' : 'invisible'}`}>Passwords should match!!!</p>

                    <button type='submit' className='btn btn-success'>Sign up</button>
                    <span>Already have an account?&nbsp;
                        <Link to='/login'>Log in</Link>
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

export default SignupForm;