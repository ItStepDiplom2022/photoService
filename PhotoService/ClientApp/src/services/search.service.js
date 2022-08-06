import axios from "axios";
import configData from "../config.json";
import images from "../components/gallery-component/images.json"

const API_URL = `${configData.SERVER_URL}search/`;


class SearchService {
    search(query = {tag:null,author:null,q:null}) {

        // return images;

        return axios.get(API_URL, {params: query})
        .then((respond) => {
            console.log(respond.data);
            return respond;
        })
        .catch((err) => {throw err.response.data})
    }

    getByFilter(filter) {

        // return [{label: filter, url: `/?tag=${filter}`},{label: filter, url: `/?author=${filter}`, avatarUrl: "https://i.pinimg.com/564x/c3/c5/a4/c3c5a4a61a8782051eb2bf2d033ef512.jpg"}]

        return axios.get(API_URL+"filter", {params:{filter}})
        .then((respond) => {
            return respond;
        })
        .catch((err) => {throw err.response.data})
    }
}

export default new SearchService()