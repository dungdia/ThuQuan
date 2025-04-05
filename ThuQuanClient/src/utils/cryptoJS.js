import CryptoJS from "crypto-js";
const secretKey = "your-secret-key"; // Chìa khóa bí mật để mã hóa
import bcrypt from "bcryptjs"; // Nhớ import bcryptjs

// Hàm mã hóa mật khẩu siêu mạnh không thể giải mã nó
const encryptPassword = async (password) => {
   try {
      const salt = await bcrypt.genSalt(10); // Tạo salt với 10 vòng lặp
      const hashedPassword = await bcrypt.hash(password, salt); // Băm mật khẩu với salt
      return hashedPassword;
   } catch (error) {
      console.error("Lỗi khi mã hóa mật khẩu:", error);
      throw new Error("Không thể mã hóa mật khẩu");
   }
};

// Hàm mã hóa
const encryption = (data) => {
   try {
      if (!data) {
         throw new Error("Dữ liệu cần mã hóa không tồn tại");
      }
      return CryptoJS.AES.encrypt(data, secretKey).toString();
   } catch (error) {
      console.error("Lỗi khi mã hóa dữ liệu:", error);
      throw new Error("Không thể mã hóa dữ liệu");
   }
};

// Hàm giải mã
const decryptData = (encryptedData) => {
   try {
      if (!encryptedData) {
         throw new Error("Dữ liệu cần giải mã không tồn tại");
      }

      const bytes = CryptoJS.AES.decrypt(encryptedData, secretKey);
      const decryptedData = bytes.toString(CryptoJS.enc.Utf8);

      if (!decryptedData) {
         throw new Error("Dữ liệu giải mã không hợp lệ");
      }

      return decryptedData;
   } catch (error) {
      console.error("Lỗi khi giải mã dữ liệu:", error);
      return null; // Trả về null nếu giải mã thất bại
   }
};

export { encryption, decryptData, encryptPassword };
