import apiClient from "/src/api/instance.js";
import Cookies from "js-cookie";
const getAllDataBookingHistory = async () => {
   const token = Cookies.get("accessToken");
   if (!token) {
      throw new Error("No access token found");
   }
   const response = await apiClient.get("GetPhieuDatByToken", {
      headers: {
         Authorization: `Bearer ${token}`, 
      },
   });
   return response;
};

export { getAllDataBookingHistory };
