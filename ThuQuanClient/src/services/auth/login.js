import apiClient from "@/api/instance";

// Gọi API đăng nhập
const login = async (formData) => {
   const response = await apiClient.post("userlogin", formData);

   return response.data;
};

export { login };
