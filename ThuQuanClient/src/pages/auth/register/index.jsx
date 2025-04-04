import React, { useEffect, useState } from "react";
import logoIcon from "@/assets/icons/logo.svg";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { Button, Form, Input, message } from "antd";
import { LockKeyhole, UserPen, UserRound } from "lucide-react";
import introRegister from "@/assets/images/auth/intro.png";
import introArrowIcon from "@/assets/icons/intro-arrow.svg";
import { initJsToggle } from "@/assets/js/header";
import { register } from "@/services/auth/register";
import { HttpStatusCode } from "axios";
import {
   handleConfirmPassword,
   handleEmailChange,
   handleNameChange,
   handlePasswordChange,
} from "@/utils/validate";
import Cookies from "js-cookie";

export default function Register() {
   const navigate = useNavigate();
   const [form] = Form.useForm();
   const [loading, setLoading] = React.useState(false);
   const nameRef = React.useRef();
   const [nameStatus, setNameStatus] = useState("");
   const [emailStatus, setEmailStatus] = useState("");
   const [passStatus, setPassStatus] = useState("");
   const [rePassStatus, setRePassStatus] = useState("");

   // Kiểm tra trạng thái đăng nhập
   useEffect(() => {
      // Lấy dữ liệu từ Cookie
      const accessToken = Cookies.get("accessToken");
      if (accessToken) {
         navigate("/user");
      }
   }, []);

   // Hàm tự focus vào trường userName
   useEffect(() => {
      if (nameRef.current) nameRef.current.focus();
   }, []);

   const onFinish = async (values) => {
      try {
         setLoading(true);
         if (values.password !== values.rePassword) {
            message.error("Mật khẩu không khớp, vui lòng thử lại!");
            return;
         }

         // Gọi API
         const response = await register(values);
         console.log("response ", response);

         if (response?.status === 200) {
            form.resetFields();
            navigate("/login");
            message.success("Đăng ký thành công");
         } else {
            message.error("Đăng ký thất bại, vui lòng thử lại!");
         }
      } catch (error) {
         if (error?.status === HttpStatusCode.BadRequest) {
            message.error(error?.response?.data);
         } else {
            message.error("Máy chủ đang gặp sự cố. Vui lòng thử lại sau!");
         }
         console.log("error: ", error);
      } finally {
         setLoading(false);
      }
   };

   useEffect(() => {
      initJsToggle();
   }, []);

   const goBackLogin = () => {
      navigate("/login");
   };

   return (
      <>
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
                  Những giá trị thương hiệu xa xỉ tốt nhất, sản phẩm chất lượng
                  cao và dịch vụ sáng tạo
               </p>
               <button
                  className="auth__intro-next d-none d-md-flex js-toggle"
                  toggle-target="#auth-content"
               >
                  <img src={introArrowIcon} alt="" />
               </button>
            </div>

            {/* Auth content */}
            <div id="auth-content" className="auth__content hide">
               <div className="auth__content-inner">
                  {/* Logo */}
                  <NavLink to="/user" className="logo auth__content-logo ">
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>
                  <h1 className="auth__heading">Đăng Ký</h1>
                  <p className="auth__desc">
                     Hãy tạo tài khoản và mua/đặt như một người chuyên nghiệp và
                     tiết kiệm tiền.
                  </p>
                  <Form
                     onFinish={onFinish}
                     form={form}
                     layout="vertical"
                     name="basic"
                     autoComplete="off"
                     requiredMark={true}
                     className="form auth__form"
                  >
                     <Form.Item
                        hasFeedback
                        validateStatus={nameStatus}
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Tên người dùng
                           </span>
                        }
                        name="userName"
                        rules={[
                           {
                              required: true,
                              message: "Tên không được để trống",
                           },
                        ]}
                     >
                        <Input
                           ref={nameRef}
                           prefix={<UserPen className="auth__form-icon icon" />}
                           placeholder="Nhập tên"
                           className="auth__content-input"
                           onChange={(e) => handleNameChange(e, setNameStatus)}
                        />
                     </Form.Item>
                     <Form.Item
                        hasFeedback
                        validateStatus={emailStatus}
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">Email</span>
                        }
                        name="email"
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
                           prefix={
                              <UserRound className="auth__form-icon icon" />
                           }
                           placeholder="Email"
                           className="auth__content-input"
                           autoComplete="email"
                           onChange={(e) =>
                              handleEmailChange(e, setEmailStatus)
                           }
                        />
                     </Form.Item>

                     <Form.Item
                        hasFeedback
                        validateStatus={passStatus}
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Mật khẩu
                           </span>
                        }
                        name="password"
                        rules={[
                           {
                              required: true,
                              message: "Mật khẩu không được để trống",
                           },
                           {
                              pattern: /^[A-Za-z0-9]{6,}$/,
                              message: "Password phải từ 6 ký tự trở lên",
                           },
                        ]}
                     >
                        <Input.Password
                           prefix={
                              <LockKeyhole className="auth__form-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                           onChange={(e) =>
                              handlePasswordChange(e, setPassStatus)
                           }
                        />
                     </Form.Item>

                     <Form.Item
                        hasFeedback
                        validateStatus={rePassStatus}
                        className="auth__form-item"
                        label={
                           <span className="auth__form-lable-input">
                              Xác nhận mật khẩu
                           </span>
                        }
                        name="rePassword"
                        rules={[
                           {
                              required: true,
                              message: "Mật khẩu không được để trống",
                           },
                           {
                              pattern: /^[A-Za-z0-9]{6,}$/,
                              message: "Password phải từ 6 ký tự trở lên",
                           },
                        ]}
                     >
                        <Input.Password
                           prefix={
                              <LockKeyhole className="auth__form-icon icon" />
                           }
                           placeholder="Mật khẩu"
                           className="auth__content-input"
                           onChange={(e) =>
                              handleConfirmPassword(
                                 e.target.value,
                                 form.getFieldValue("password"),
                                 setRePassStatus
                              )
                           }
                        />
                     </Form.Item>

                     <Form.Item label={null}>
                        <Button
                           loading={loading}
                           className="auth__form-btn-register "
                           type="primary"
                           htmlType="submit"
                        >
                           Đăng ký
                        </Button>
                     </Form.Item>
                     <div className="auth__form-btn-back-login">
                        <Link onClick={goBackLogin}>Trở về đăng nhập</Link>
                     </div>
                  </Form>
               </div>
            </div>
         </main>
      </>
   );
}
