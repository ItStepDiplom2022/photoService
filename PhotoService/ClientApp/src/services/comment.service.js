import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}comment/`;

class CommentService{

    getComments(imageId){
        return axios.get(API_URL + `${imageId}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    postCommentToImage(username,comment,imageId){
        return axios.post(API_URL,{
            username,comment,imageId
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

export default new CommentService()