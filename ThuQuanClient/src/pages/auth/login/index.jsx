import React, { useEffect, useRef, useState } from "react";
import logoIcon from "@/assets/icons/logo.svg";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { Button, Form, Input, message, Modal } from "antd";
import { LockKeyhole, UserPen, UserRound } from "lucide-react";
import introRegister from "@/assets/images/auth/intro.png";
import introArrowIcon from "@/assets/icons/intro-arrow.svg";
import { initJsToggle } from "@/assets/js/header";
import Cookies from "js-cookie";
import { HttpStatusCode } from "axios";
import { login } from "@/services/auth/login";
import { decryptData, encryption, encryptPassword } from "@/utils/cryptoJS";
import bcrypt from "bcryptjs";
import { handleEmailChange, handlePasswordChange } from "@/utils/validate";

// Cú pháp lưu cookie và lấy cookie

export default function Register() {
   const navigate = useNavigate();
   const [isShowForgotPassword, setIsShowForgotPassword] = useState(false);
   const [formEmail] = Form.useForm(); // Form cho email
   const emailRefForgotPass = useRef(null);
   const [isLoadingForgotPass, setIsLoadingForgotPass] = useState(false);
   const [rememberAccount, setRememberAccount] = useState(false);
   const [valueEmail, setValueEmail] = useState("");
   const [valuePass, setValuePass] = useState("");
   const [form] = Form.useForm(); // Form cho đăng nhập
   const emailRef = useRef(null);
   const [loading, setLoading] = useState(false);
   const [passStatus, setPassStatus] = useState("");
   const [emailStatus, setEmailStatus] = useState("");

   // Tự focus vào email khi vào trang login và tự động điền giá trị nếu trong localStorage đã có savedAccount khi nhấn "Nhớ tài khoản"
   useEffect(() => {
      const savedAccount = JSON.parse(localStorage.getItem("savedAccount"));
      if (savedAccount) {
         // Giải mã email và password trước khi điền vòa form
         const decryptedEmail = decryptData(savedAccount.Email);
         setValueEmail(decryptedEmail);

         const beforeEncryption = sessionStorage.getItem("beforeEncryption");
         // So sánh mật khẩu đã mã hóa (beforeEncryption.current) với mật khẩu lưu trong savedAccount
         bcrypt
            .compare(beforeEncryption, savedAccount.Password)
            .then((isPasswordCorrect) => {
               if (isPasswordCorrect) {
                  // Giải mã mật khẩu sau khi xác nhận đúng mật khẩu
                  const decryptedPassword = decryptData(beforeEncryption);
                  setValuePass(decryptedPassword);
                  // Cập nhật giá trị vào form
                  form.setFieldsValue({
                     Email: decryptedEmail,
                     Password: decryptedPassword,
                  });
               } else {
                  form.setFieldsValue({
                     Email: decryptedEmail,
                     Password: "", // Đảm bảo mật khẩu không bị hiển thị
                  });
               }
            })
            .catch((error) => {
               // Cập nhật giá trị vào form
               form.setFieldsValue({
                  Email: decryptedEmail,
                  Password: "",
               });
            });
         setRememberAccount(true); //Đặt trạng thái checkbox về true
      }
      if (emailRef.current) {
         emailRef.current.focus(); // Tự động focus vào ô email
      }
   }, []);

   // Kiểm tra xem người dùng đã đăng nhập chưa, nếu rồi thì quay lại trang người dùng
   useEffect(() => {
      // Kiểm tra token từ cookie
      const accessToken = Cookies.get("accessToken");

      if (accessToken) {
         navigate("/user");
      }
   }, []);

   // Hàm đăng nhập
   const onFinish = async (values) => {
      try {
         setLoading(true);
         // Gọi API
         const response = await login(values);

         // Dùng destructuring để lấy ra các key của object
         const { accessToken, ...filtedData } = response;

         // Lưu token lên cookie hoặc local
         Cookies.set("accessToken", accessToken, {
            expires: 1,
            secure: true,
            sameSite: "strict",
         });

         // Lưu thông tin cá nhân của tài khoản đã đăng nhập lên localStorage
         localStorage.setItem("accountLoggedin", JSON.stringify(filtedData));

         if (rememberAccount) {
            // Mã hóa email
            const encryptedEmail = encryption(values.Email);
            // Mã hóa mật khẩu nhẹ
            const lightEncryption = encryption(values.Password);
            // Lưu giá trị beforeEncryption vào sessionStorage
            sessionStorage.setItem("beforeEncryption", lightEncryption);
            //Mã hóa mật khẩu trước trở nên mạnh hơn khi gửi tới localStorage
            const encryptedPassword = await encryptPassword(lightEncryption);
            // Lưu vào localStorage khi nhấn nhớ tài khoản
            localStorage.setItem(
               "savedAccount",
               JSON.stringify({
                  Email: encryptedEmail, // Lưu email đã mã hóa
                  Password: encryptedPassword, // Lưu mật khẩu đã mã hóa
               })
            );
         } else {
            // Xóa khỏi localStorage và sessionStorage
            localStorage.removeItem("savedAccount");
            sessionStorage.removeItem("beforeEncryption");
         }

         // Hiển thị thông báo đăng nhập thành công và chuyển trang
         message.success("Đăng nhập thành công", 1, () => {
            navigate("/user");
         });
      } catch (error) {
         if (error?.status === HttpStatusCode.BadRequest) {
            console.log("error ", error);

            message.error(error?.response?.data || "Có sự cố xảy ra!");
         } else {
            message.error("Máy chủ đang gặp sự cố. Vui lòng thử lại sau!");
         }
      } finally {
         setLoading(false);
      }
   };

   // Gọi lại handleEmailChange khi dữ liệu email thay đổi hoặc handlePasswordChange khi dữ liệu mật khẩu thay đổi
   useEffect(() => {
      if (valueEmail) {
         handleEmailChange({ target: { value: valueEmail } }, setEmailStatus);
      }
      if (valuePass) {
         handlePasswordChange({ target: { value: valuePass } }, setPassStatus);
      }
   }, [valueEmail, valuePass]);

   // Hàm mở quên mật khẩu
   const handleForgotPassword = () => {
      setIsShowForgotPassword(true);
      formEmail.resetFields();
      setTimeout(() => {
         if (emailRefForgotPass.current) {
            emailRefForgotPass.current.focus();
         }
      }, 100);
   };

   // Hàm đóng quên mật khẩu
   const handleCloseForgotPassword = () => {
      setIsShowForgotPassword(false);
      formEmail.resetFields();
   };

   // Hàm đóng mở chuyển trạng thái transition
   useEffect(() => {
      initJsToggle();
   }, []);

   // Hàm qua trang register
   const goBackRegister = () => {
      navigate("/register");
   };

   const goBackToHome = () => {
      navigate("/user");
   };

   return (
      <>
         {/* Giao diện quên mật khẩu */}
         <Modal
            open={isShowForgotPassword}
            onCancel={handleCloseForgotPassword}
            footer={
               <div className="flex justify-end gap-2">
                  <Button onClick={handleCloseForgotPassword}>Đóng</Button>
                  <Button type="primary" loading={isLoadingForgotPass}>
                     Gửi
                  </Button>
               </div>
            }
         >
            <Form
               form={formEmail}
               requiredMark={false}
               layout="vertical"
               autoComplete="off"
            >
               <Form.Item
                  label={<div className="font-bold">Email</div>}
                  name="email"
                  rules={[
                     {
                        required: true,
                        message: "email không được bỏ trống",
                     },
                     {
                        pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                        message: "email không hợp lệ",
                     },
                  ]}
               >
                  <Input
                     placeholder="Nhập Email"
                     autoComplete="email"
                     ref={emailRefForgotPass}
                  />
               </Form.Item>
            </Form>
         </Modal>

         <main className="auth">
            {/* Auth intro */}
            <div className="auth__intro">
               {/* Logo */}
               <NavLink className="logo auth__intro-logo d-none d-md-flex">
                  <img src={logoIcon} alt="Thư quán" className="logo__img" />
                  <h1 className="logo__title">Thư quán</h1>
               </NavLink>
               <img
                  src={introRegister}
                  alt="intro"
                  className="auth__intro-img"
               />

               <p className="auth__intro-text">
                  Chào mừng bạn quay lại để đăng nhập. Là khách hàng quay lại,
                  bạn có thể truy cập vào tất cả thông tin đã lưu trước đó.
               </p>
               <button
                  className="auth__intro-next d-none d-md-flex js-toggle"
                  toggle-target="#auth-content-login"
               >
                  <img src={introArrowIcon} alt="" />
               </button>
            </div>
            {/* Auth content */}
            <div id="auth-content-login" className="auth__content-login hide">
               <div className="auth__content-login-inner">
                  {/* Logo */}
                  <NavLink
                     to="/user"
                     className="logo auth__content-login-logo "
                  >
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>
                  <h1 className="auth__heading">Đăng nhập</h1>
                  <p className="auth__desc">
                     Chào mừng bạn quay lại để đăng nhập. Là khách hàng quay
                     lại, bạn có thể truy cập vào tất cả thông tin đã lưu trước
                     đó.
                  </p>
                  <Form
                     form={form}
                     onFinish={onFinish}
                     layout="vertical"
                     name="basic"
                     autoComplete="off"
                     requiredMark={true}
                     className="form auth__form-login"
                  >
                     <Form.Item
                        hasFeedback
                        validateStatus={emailStatus}
                        className="auth__form-login-item"
                        label={
                           <span className="auth__form-login-lable-input">
                              Email
                           </span>
                        }
                        name="Email"
                        rules={[
                           {
                              required: true,
                              message: "Email không được để trống",
                           },
                           {
                              pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                              message: "Email không hợp lệ",
                           },
                        ]}
                     >
                        <Input
                           ref={emailRef}
                           prefix={
                              <UserRound className="auth__form-login-icon icon" />
                           }
                           placeholder="Email"
                           className="auth__content-input"
                           autoComplete="email"
                           value={valueEmail}
                           onChange={(e) =>
                              handleEmailChange(e, setEmailStatus)
                           }
                        />
                     </Form.Item>

                     <Form.Item
                        hasFeedback
                        validateStatus={passStatus}
                        className="auth__form-login-item"
                        label={
                           <span className="auth__form-lable-input">
                              Mật khẩu
                           </span>
                        }
                        name="Password"
                        rules={[
                           {
                              required: true,
                              message: "Mật khẩu không được để trống",
                           },
                           {
                              pattern: /^[A-Za-z0-9]{6,100}$/,
                              message: "Password phải có 6-100 ký tự",
                           },
                        ]}
                     >
                        <Input.Password
                           prefix={
                              <LockKeyhole className="auth__form-login-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                           value={valuePass}
                           onChange={(e) =>
                              handlePasswordChange(e, setPassStatus)
                           }
                        />
                     </Form.Item>

                     <Form.Item>
                        <div className="auth__form-login-act">
                           <Link
                              onClick={handleForgotPassword}
                              className="auth__form-login-act-forgot"
                           >
                              Quên mật khẩu
                           </Link>
                           <div className="auth__form-login-act-remember">
                              <Input
                                 id="auth__form-login-act-remember-input"
                                 className="auth__form-login-act-remember-input"
                                 type="checkbox"
                                 checked={rememberAccount}
                                 onChange={(e) =>
                                    setRememberAccount(e.target.checked)
                                 }
                              />
                              <label
                                 htmlFor="auth__form-login-act-remember-input"
                                 className="auth__form-login-act-remember-label"
                              >
                                 <p className="auth__form-login-act-remember-text">
                                    Nhớ mật khẩu
                                 </p>
                              </label>
                           </div>
                        </div>
                     </Form.Item>

                     <Form.Item label={null}>
                        <Button
                           className="auth__form-btn-login "
                           type="primary"
                           htmlType="submit"
                           loading={loading}
                        >
                           Đăng nhập
                        </Button>
                     </Form.Item>
                     <div className="auth__form-btn-back-register">
                        <Link onClick={goBackRegister}>Đăng kí tài khoản</Link>
                     </div>
                  </Form>
               </div>
            </div>
         </main>
      </>
   );
}
