import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}account/`;

class AuthService{

    signup(username,email,password){
        return axios.post(API_URL + "signup", {
            username,
            email,
            password
        }).then(()=> {
            return true
        }).catch((err)=>{
            throw err.response.data
        });
    }

    login(email, password) {
        return axios.post(API_URL + "login", {
            email,
            password
        }).then(response => {
            if (response.data.token) {
                localStorage.setItem("user", JSON.stringify(response.data));
            }
        }).catch((err)=>{
            throw err.response.data
        });
    }

    logout() {
        localStorage.removeItem("user");
    }

    isLoggedIn() {
        return JSON.parse(localStorage.getItem('user'));;
    }

    getOwnerEmail(){
        return JSON.parse(localStorage.getItem('user')).email
    }
}

export default new AuthService()