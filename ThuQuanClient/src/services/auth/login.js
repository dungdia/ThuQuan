import apiClient from "@/api/instance";

// Gọi API đăng nhập
const login = async (formData) => {
   const response = await apiClient.post("userlogin", formData);

   return response.data;
};

// Gọi API lấy mã OTP
const getOTP = async (email) => {
   const response = await apiClient.post(`OTP?Email=${email}`);

   return response;
};

// Gọi API lấy mã OTP và lấy mật khẩu mới
const getOTPAndNewPassword = async (email, newPassword) => {
   const response = await apiClient.post(
      `forgot-password?email=${email}&newPassword=${newPassword}`
   );

   return response;
};

export { login, getOTP, getOTPAndNewPassword };
