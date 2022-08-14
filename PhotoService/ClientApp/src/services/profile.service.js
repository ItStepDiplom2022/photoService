import axios from "axios";
import configData from "../config.json";

const API_URL = `${configData.SERVER_URL}profile/`;


class ProfileService {
    getUser(username) {
        return axios.get(API_URL+'', {username})
        .then((respond) => {
            return respond
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new ProfileService()