import axios from "axios";
import configData from "../config.json";

const API_URL = `${configData.SERVER_URL}profile/`;

class ProfileService {
    getUser(username) {
        return axios.get(API_URL+'user', {params: {username}})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }

    getUserCollections(username,publicOnly) {
        return axios.get(API_URL+'collections', {params: {username, publicOnly}})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }

    addNewCollection(username, collectionName,isPublic) {
        return axios.post(API_URL+'collections/create', {username, collectionName, isPublic})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new ProfileService()