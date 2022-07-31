import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}image/`;

class ImageService{

    getImage(id){
        return axios.get(API_URL + `${id}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }
}

export default new ImageService()