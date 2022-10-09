import axios from "axios";
import configData from "../config.json";

const API_URL = `${configData.SERVER_URL}account/`;

class AuthService{

    getUser(username) {
        return axios.get(API_URL, {params: {username}})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }

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

    getCurrentUserEmail(){
        return JSON.parse(localStorage.getItem('user')).email
    }

    getCurrentUserUsername(){
        return JSON.parse(localStorage.getItem('user'))?.username 
    }
}

export default new AuthService()