import apiClient from "@/api/instance";
import { message } from "antd";
import { HttpStatusCode } from "axios";

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
   const response = await apiClient.get(`GetTaiKhoanByEmail/${email}`);
   return response;
};

const UpdateInfoUser = async (form) => {
   const response = await apiClient.put("update-info-user", form);
   console.log("Response: ", response);

   return response;
};

export {
   changePassword,
   checkCurrentPassword,
   findAccountByEmail,
   UpdateInfoUser,
};
