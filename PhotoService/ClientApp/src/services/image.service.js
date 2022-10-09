import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}image`;

class ImageService{

    getImage(id){
        return axios.get(API_URL + `/${id}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    getImagesByUserEmail(email){
        return axios.get(API_URL + `/email/${email}`, { 
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    getImagesByUserName(userName){
        return axios.get(API_URL + `/userName/${userName}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    getImagesByColection(userName,collectionName){
        return axios.get(API_URL + `/collection/${userName}?collectionName=${collectionName}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    postImage(title,description,hashtags,imageBase64,userEmail){
        return axios.post(API_URL,{
            title,description,hashtags,imageBase64,userEmail
        }, { 
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    async convertImageToBase64(file){
        return new Promise((resolve, reject) => {
            const fileReader = new FileReader();
            fileReader.readAsDataURL(file);

            fileReader.onload = () => {
                resolve(fileReader.result);
            };

            fileReader.onerror = (error) => {
                reject(error);
            };
        });
    };
}

export default new ImageService()