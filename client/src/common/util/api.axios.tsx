import axios, {AxiosError, AxiosRequestConfig, AxiosResponse} from "axios";
import { EndpointsConstants } from "../constants/endpointsConstants";
import {store} from "../store/configureStore";
import {Pagination} from "../../advertisement/components/pagination";

axios.defaults.baseURL = EndpointsConstants.Base.BASE_URL;
axios.defaults.withCredentials = true;

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use((config: AxiosRequestConfig) => {
    if (config.headers === undefined) {
        config.headers = {};
    }
    const token = store.getState().account.user?.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
});

axios.interceptors.response.use(response => {
    const pagination = response.headers['pagination'];
    if (pagination) {
        response.data = new Pagination(response.data, JSON.parse(pagination));
        return response;
    }
    return response;
});

function get(url: string, params?: URLSearchParams) {
    return axios.get(url, {params}).then(responseBody);
}

function post(url: string, body: {}){
    return axios.post(url, body).then(responseBody);
}

function put(url: string, body: {}){
    return axios.put(url, body).then(responseBody);
}

function remove(url: string){
    return axios.delete(url).then(responseBody);
}

function postFormData(url: string, data: FormData){
    return axios.post(url, data, { headers: {'Content-type': 'multipart/form-data'}}).then(responseBody)
}

function putFormData(url: string, data: FormData){
    return axios.put(url, data, {headers: {'Content-type': 'multipart/form-data'}}).then(responseBody)
}

const agent = {
    get,
    post,
    put,
    remove,
    postFormData,
    putFormData
}

export default agent;