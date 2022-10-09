import axios from "axios";
import configData from "../config.json";
import authHeader from './auth.header';

const API_URL = `${configData.SERVER_URL}collection/`;

class CollectionService{

    addToCollection(username,imageId,collectionName){
        return axios.post(API_URL+'image',{
            username,imageId,collectionName
        }, { 
            headers: authHeader() 
        })
        .then((promise)=> {
            return promise
        }).catch((err)=>{
            throw err.response.data
        });
    }

    getUserCollections(username,publicOnly) {
        return axios.get(API_URL, {params: {username, publicOnly}})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }

    addNewCollection(username, collectionName,isPublic) {
        return axios.post(API_URL, {username, collectionName, isPublic},{ 
            headers: authHeader() 
        })
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new CollectionService()