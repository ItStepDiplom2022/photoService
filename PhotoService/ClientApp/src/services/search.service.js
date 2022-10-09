import axios from "axios";
import configData from "../config.json";

const API_URL = `${configData.SERVER_URL}search/`;

class SearchService {

    search(query = {tag:null,author:null,q:null,last:0,count:20}) {
        return axios.get(API_URL, {params: query})
        .then((respond) => {
            return respond;
        })
        .catch((err) => {throw err.response.data})
    }

    getByFilter(filter) {
        return axios.get(API_URL+"filter", {params:{filter}})
        .then((respond) => {
            return respond;
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new SearchService()