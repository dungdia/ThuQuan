import apiClient from "@/api/instance";

const register = async (formData) => {
   const response = await apiClient.post("userRegister", formData);
   return response;
};

export { register };
