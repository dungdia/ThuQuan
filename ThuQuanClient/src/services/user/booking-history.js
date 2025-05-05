import apiClient from "/src/api/instance.js";
import Cookies from "js-cookie";
const getAllDataBookingHistory = async () => {
   let token = Cookies.get("accessToken");

   // Đợi token nếu chưa có
   const maxRetries = 50; // Giới hạn số lần kiểm tra (50 x 100ms = 5 giây)
   let retries = 0;

   while (!token && retries < maxRetries) {
      await new Promise((resolve) => setTimeout(resolve, 100)); // Đợi 100ms
      token = Cookies.get("accessToken");
      retries++;
   }

   const response = await apiClient.get("GetPhieuDatByToken", {
      headers: {
         Authorization: `Bearer ${token}`,
      },
   });
   return response.data;
};

export { getAllDataBookingHistory };
