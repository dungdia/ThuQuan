import axios from "axios";

const apiClient = axios.create({
   baseURL: "http://localhost:3000/",
   headers: { "Content-Type": "application/json" },
});

// apiClient.interceptors.request.use(
//    (config) => {
//       const accessToken = `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwianRpIjoiZTBlODAzMGUtOGM4NS00MDQ4LTk4MjItYThlYWYwNmIyNTFhIiwiZXhwIjoxNzQzNTYwMjgyLCJpc3MiOiJZb3VyQXBwIiwiYXVkIjoiWW91ckFwcCJ9.tmVY7cSeJjvo0kYAyLz1kkYm2cZrVUbMvIptgvDck60`;
//       config.headers.Authorization = accessToken;
//       return config;
//    },
//    (error) => {
//       return Promise.reject(error);
//    }
// );

export default apiClient;
