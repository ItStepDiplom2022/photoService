import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}like/`;

class LikeService{

    getIfIsLiked(userName, imageId){
        return axios.get(API_URL + 'isLiked/', { 
            params: {userName, imageId},
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    like(userName, imageId){
        return axios.post(API_URL,{
            userName, imageId
        }, { 
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    dislike(userName, imageId){
        return axios.post(API_URL+"dislike",{
            userName, imageId
        }, { 
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }
}

export default new LikeService()