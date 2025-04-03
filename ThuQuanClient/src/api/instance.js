import axios from "axios";
import Cookies from "js-cookie";

const apiClient = axios.create({
   baseURL: "http://localhost:3000/",
   headers: { "Content-Type": "application/json" },
   withCredentials: true, //Bắt buộc nếu backend yêu cầu cookie/token
});

apiClient.interceptors.request.use(
   (config) => {
      const token = Cookies.get("accessToken");
      if (token) {
         config.headers.Authorization = `Bearer ${token}`;
      }
      return config;
   },
   (error) => {
      return Promise.reject(error);
   }
);

export default apiClient;
