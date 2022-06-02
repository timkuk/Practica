import axiosApi from "../util/api.axios";

async function get(url: string, params?: URLSearchParams) {
    return await axiosApi.get(url,  params);
}

async function post(url: string, body: {}) {
    return await axiosApi.post(url,  body);
}

const ApiService = {
    get,
    post
}

export default ApiService;