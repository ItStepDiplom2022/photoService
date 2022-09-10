import axios from "axios";
import configData from "../config.json";

const API_URL = `${configData.SERVER_URL}comment`;

class CommentService{

    getComments(imageId){
        return axios.get(API_URL + `/${imageId}`)
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }
}

export default new CommentService()