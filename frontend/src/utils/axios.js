import axios from "axios";

const axiosInstance = axios.create({ baseURL: "https://localhost:7162/api" });

export default axiosInstance;
