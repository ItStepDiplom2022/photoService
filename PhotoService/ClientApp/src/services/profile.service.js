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

    getUserCollections(username) {
        return axios.get(API_URL+'collections', {params: {username}})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }

    addNewCollection(username, collectionName) {
        return axios.post(API_URL+'collections/create', {username, collectionName})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new ProfileService()