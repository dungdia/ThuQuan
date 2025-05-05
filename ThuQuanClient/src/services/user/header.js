import apiClient from "@/api/instance";
import { message } from "antd";
import { HttpStatusCode } from "axios";
import Cookies from "js-cookie";

const changePassword = async (formData) => {
   const response = await apiClient.put("change-password", formData);
   return response;
};

const checkCurrentPassword = async (formData) => {
   try {
      const response = await apiClient.post("check-password", formData);

      if (response.status === 200) {
         message.success("Mật khẩu đã đúng");
         return true; // Trả về true khi mật khẩu đúng
      } else {
         message.error("Mật khẩu không chính xác");
         return false; // Trả về false khi API không xác nhận
      }
   } catch (error) {
      if (error.status === HttpStatusCode.BadRequest) {
         message.error(
            error?.response?.data?.errors?.password ||
               "Mật khẩu không chính xác"
         );
         return false; // Trả về false khi có lỗi
      } else {
         message.error("Đã xảy ra lỗi!");
         return false;
      }
   }
};

const findAccountByEmail = async (email) => {
   const response = await apiClient.get(`GetTaiKhoanByEmail?email=${email}`);
   return response;
};

const UpdateInfoUser = async (form) => {
   const response = await apiClient.put("update-info-user", form);
   console.log("Response: ", response);

   return response;
};

const AddPhieuDat = async (form) => {
   const token = Cookies.get("accessToken");

   const response = await apiClient.post("AddPhieuDat", form, {
      headers: {
         Authorization: `Bearer ${token}`,
      },
   });
   return response;
};

const getAllDataPenalty = async () => {
   let token = Cookies.get("accessToken");

   // Đợi token nếu chưa có
   const maxRetries = 50; // Giới hạn số lần kiểm tra (50 x 100ms = 5 giây)
   let retries = 0;

   while (!token && retries < maxRetries) {
      await new Promise((resolve) => setTimeout(resolve, 100)); // Đợi 100ms
      token = Cookies.get("accessToken");
      retries++;
   }

   const response = await apiClient.get("GetPhieuPhatByToken", {
      headers: {
         Authorization: `Bearer ${token}`,
      },
   });
   return response.data;
};

export {
   changePassword,
   checkCurrentPassword,
   findAccountByEmail,
   UpdateInfoUser,
   AddPhieuDat,
   getAllDataPenalty,
};
