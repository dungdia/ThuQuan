// Hàm kiểm tra định dạng của Tên
const validateName = (value) => {
   const regex =
      /^[a-zA-ZÀÁẠÃẢẶẴẲẮẰÁĂÂẤẪẨẬẦÃÈẼẺẸÉÊẾỀỄỆỂÌÍỈỊIỢỠỚỜỞÕỌỎÒÓỔỖỐỒỘÔÕƯỨỪỰỮỬỤŨỦÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊƠàáạảãèéẹẻẽìíịỉĩòóọỏõùúụủũơớờợởỡăắằặẳẵâấầậẩẫêếềệểễđĩọỏốồộổỗồờớợởẽẹẻếìíùúụũưữựửữữýỳỵỷỹ ]+$/;
   return regex.test(value);
};

// Hàm kiểm tra định dạng của userName
const validateUserName = (value) => {
   const regex =
      /^[a-zA-ZÀÁẠÃẢẶẴẲẮẰÁĂÂẤẪẨẬẦÃÈẼẺẸÉÊẾỀỄỆỂÌÍỈỊIỢỠỚỜỞÕỌỎÒÓỔỖỐỒỘÔÕƯỨỪỰỮỬỤŨỦÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÊƠàáạảãèéẹẻẽìíịỉĩòóọỏõùúụủũơớờợởỡăắằặẳẵâấầậẩẫêếềệểễđĩọỏốồộổỗồờớợởẽẹẻếìíùúụũưữựửữữýỳỵỷỹ \d ]+$/;
   return regex.test(value);
};

// Hàm kiểm tra định dạng email
const validateEmail = (email) => {
   const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Regex kiểm tra email
   return emailRegex.test(email);
};

// Hàm xử lý email
const handleEmailChange = (e, setEmailStatus) => {
   const email = e.target.value;
   // Cập nhật trạng thái validate
   if (!email) {
      setEmailStatus(""); // Reset trạng thái nếu input rỗng
   } else if (validateEmail(email)) {
      setEmailStatus("success"); // Email hợp lệ
   } else {
      setEmailStatus("error"); // Email không hợp lệ
   }
};

// Hàm kiểm tra định dạng của password
const validatePassword = (password) => {
   const regex = /^[A-Za-z0-9]{6,}$/;
   return regex.test(password);
};

// Hàm xử lý name
const handleNameChange = (e, setNameStatus) => {
   const name = e.target.value;
   // Cập nhật trạng thái validate
   if (!name) {
      setNameStatus(""); // Reset trạng thái nếu input rỗng
   } else if (validateName(name)) {
      setNameStatus("success"); // Tên hợp lệ
   } else {
      setNameStatus("error"); // Tên không hợp lệ
      console.log("Lỗi");
   }
};

// Hàm xử lý userName
const handleUserNameChange = (e, setNameStatus) => {
   const name = e.target.value;
   // Cập nhật trạng thái validate
   if (!name) {
      setNameStatus(""); // Reset trạng thái nếu input rỗng
   } else if (validateUserName(name)) {
      setNameStatus("success"); // Tên hợp lệ
   } else {
      setNameStatus("error"); // Tên không hợp lệ
      console.log("Lỗi");
   }
}

// Hàm xử lý password
const handlePasswordChange = (e, setPassStatus) => {
   const password = e.target.value;
   if (!password) {
      setPassStatus("");
   } else if (validatePassword(password)) {
      setPassStatus("success");
   } else {
      setPassStatus("error");
   }
};

// Hàm xử lý onChangeNewPassword
const handleNewPasswordChange = (value, setNewPasswordStatus) => {
   if (!value) {
      setNewPasswordStatus("error");
   } else if (value.length >= 6) {
      setNewPasswordStatus("success");
   } else {
      setNewPasswordStatus("error");
   }
};

// Hàm xử lý confirmPassword
const handleConfirmPassword = (
   confirmPassword,
   newPassword,
   setConfirmPasswordStatus
) => {
   if (!confirmPassword) {
      setConfirmPasswordStatus(""); // Reset trạng thái nếu input rỗng
   } else if (confirmPassword === newPassword) {
      setConfirmPasswordStatus("success"); // Mật khẩu xác nhận khớp
   } else {
      setConfirmPasswordStatus("error"); // Mật khẩu xác nhận không khớp
   }
};

export {
   handleNameChange,
   handleUserNameChange,
   handleConfirmPassword,
   handleEmailChange,
   handlePasswordChange,
   handleNewPasswordChange,
   validateEmail,
   validateName,
   validatePassword,
};
