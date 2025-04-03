import React, { useEffect, useRef, useState } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { initJsToggle } from "../../../assets/js/header";
import moreIcon from "@/assets/icons/more.svg";
import logoIcon from "@/assets/icons/logo.svg";
import arrowLeftIcon from "@/assets/icons/arrow-left.svg";
import searchIcon from "@/assets/icons/search.svg";
import heartIcon from "@/assets/icons/heart.svg";
import orderIcon from "@/assets/icons/order.svg";
import avatarImage from "@/assets/images/avatar.jpg";
import {
   Avatar,
   Button,
   Dropdown,
   Form,
   Input,
   message,
   Modal,
   Space,
} from "antd";
import Cookies from "js-cookie";
import { Factory } from "lucide-react";
import { useForm } from "antd/es/form/Form";
import { changePassword, checkCurrentPassword } from "@/services/user/header";
import { HttpStatusCode } from "axios";
import {
   handleConfirmPassword,
   handleNewPasswordChange,
   handlePasswordChange,
} from "@/utils/validate";
import { useDebounce } from "@/hook/useDebounce";

export default function HeaderUser() {
   const navigate = useNavigate();
   const [form] = useForm();
   const passwordRef = useRef(null);
   const [loading, setLoading] = useState(false);
   const [isShowModalLogOut, setIsShowModalLogOut] = useState(false);
   const [isShowModalChangePassword, setIsShowModalChangePassword] =
      useState(false);
   const [currentPassword, setCurrentPassword] = useState("");
   const [passwordStatus, setPasswordStatus] = useState("");
   const [newPasswordStatus, setNewPasswordStatus] = useState("");
   const [confirmPasswordStatus, setConfirmPasswordStatus] = useState("");

   // Lấy thông tin từ localStorage
   const accountLoggedin =
      JSON.parse(localStorage.getItem("accountLoggedin")) || {};

   // Hàm để lấy các chữ cái đầu của mỗi từ trong tên
   const getInitials = (userName) => {
      const words = userName?.split(" ");
      const initials = words?.map((word) => word.charAt(0).toUpperCase());
      return initials?.join("");
   };

   // Hàm mở modal đổi mật khẩu
   const handleShowModalChangePassword = () => {
      setPasswordStatus("");
      setNewPasswordStatus("");
      setConfirmPasswordStatus("");
      setIsShowModalChangePassword(true);
      form.resetFields();
      setTimeout(() => {
         if (passwordRef.current) {
            passwordRef.current.focus();
         }
      }, 100);
   };

   // Hàm tự focus vào đổi mật khẩu
   useEffect(() => {
      if (isShowModalChangePassword && passwordRef.current) {
         passwordRef.current.focus();
      }
   }, [isShowModalChangePassword]);

   // Hàm mở modal đổi mật khẩu
   const handleCloseModalChangePassword = () => {
      setPasswordStatus("");
      setNewPasswordStatus("");
      setConfirmPasswordStatus("");
      setIsShowModalChangePassword(false);
      form.resetFields();
   };

   // Hàm xác nhận đổi mật khẩu
   const confirmChangePassword = async () => {
      try {
         // Lấy dữ liệu từ form
         const values = await form.validateFields();
         const { Password, NewPassword, ConfirmNewPassword } = values;
         setLoading(true);

         // Kiểm tra nếu ConfirmNewPassword không khớp với NewPassword
         if (NewPassword !== ConfirmNewPassword) {
            message.error("Mật khẩu xác thực không đúng");
            return;
         }
         // Lấy email từ local
         const email = accountLoggedin.email;

         const isCurrentPasswordCorrect = await checkCurrentPassword({
            email,
            Password,
         });

         if (!isCurrentPasswordCorrect) {
            message.error(error.response.data);
            return;
         }

         // Gửi yêu cầu đổi mật khẩu
         const response = await changePassword({
            email,
            Password,
            NewPassword,
         });

         if (response) {
            message.success("Đổi mật khẩu thành công!");
            handleCloseModalChangePassword(); // Đóng modal sau khi đổi mật khẩu thành công
            setPasswordStatus("");
            setNewPasswordStatus("");
            setConfirmPasswordStatus("");
            setIsShowModalChangePassword(false);
            form.resetFields();
         } else {
            message.error("Đổi mật khẩu thất bại, vui lòng thử lại!");
         }
      } catch (error) {
         if (error?.status === HttpStatusCode.BadRequest) {
            message.error(error.response.data);
         }
      } finally {
         setLoading(false);
      }
   };

   // Hàm mở modal xác nhận đăng xuất
   const handleShowModalLogOut = () => {
      setIsShowModalLogOut(true);
   };

   // Hàm đóng modal xác nhận đăng xuất
   const handleCloseModalLogOut = () => {
      setIsShowModalLogOut(false);
   };

   // Hàm xác nhận đăng xuất tài khoản\
   const handleLogOut = () => {
      // Xóa token khỏi Cookie
      Cookies.remove("accessToken");
      // Xóa dữ liệu từ localStorage
      localStorage.removeItem("accountLoggedin");
      // Chuyển hướng và trang đăng nhập
      navigate("/login");
   };

   // Các thành phần của DropDown của Avatar
   const items = [
      {
         label: <div>Thông tin cá nhân</div>,
         key: "0",
      },
      {
         label: <div onClick={handleShowModalChangePassword}>Đổi mật khẩu</div>,
         key: "1",
      },
      {
         label: <div>Giao diện</div>,
         key: "3",
      },
      {
         type: "divider",
      },
      {
         label: <div onClick={handleShowModalLogOut}>Đăng xuất</div>,
         key: "4",
      },
   ];

   // Sử dụng useDebounce để debounce giá trị password
   const debouncedPassword = useDebounce(currentPassword, 800);

   // Hàm xử lý onChangePassword
   const handlePasswordChange = async (e) => {
      const password = e.target.value;
      setCurrentPassword(password);
   };

   // Hàm kiểm tra xem nhập passowrd giống với password của email muốn đổi mk chưa
   useEffect(() => {
      const checkPassword = async () => {
         if (!debouncedPassword || !accountLoggedin?.email) return;

         try {
            const formData = {
               email: accountLoggedin.email,
               password: debouncedPassword,
            };

            // Gọi API kiểm tra mật khẩu
            const isPasswordCorrect = await checkCurrentPassword(formData);

            if (isPasswordCorrect) {
               setPasswordStatus("success");
            } else {
               setPasswordStatus("error");
            }
         } catch (error) {
            setPasswordStatus("error");
         }
      };

      checkPassword();
   }, [debouncedPassword]);

   // hàm cho mobile
   useEffect(() => {
      initJsToggle();
   }, []);

   // Chuyển qua trang đăng ký tài khoản
   const handleNextPageResgiter = () => {
      navigate("/register");
   };

   // Chuyển qua trang đăng nhập tài khoản
   const handleNextPageLogin = () => {
      navigate("/login");
   };

   return (
      <>
         {/* Giao diện đổi mật khẩu */}

         <Modal
            footer={
               <div className="flex justify-end gap-2">
                  <Button onClick={handleCloseModalChangePassword}>Hủy</Button>
                  <Button
                     onClick={confirmChangePassword}
                     loading={loading}
                     type="primary"
                     danger
                  >
                     Lưu
                  </Button>
               </div>
            }
            onCancel={handleCloseModalChangePassword}
            open={isShowModalChangePassword}
         >
            <Form
               form={form}
               layout="vertical"
               name="basic"
               requiredMark={false}
            >
               <Form.Item
                  hasFeedback
                  validateStatus={passwordStatus}
                  label="Mật khẩu"
                  name="Password"
                  rules={[
                     {
                        required: true,
                        message: "Mật khẩu không được để trống",
                     },
                     {
                        pattern: /^[A-Za-z0-9]{6,100}$/,
                        message: "Mật khẩu phải có 6-100 ký tự",
                     },
                  ]}
               >
                  <Input.Password
                     ref={passwordRef}
                     onChange={handlePasswordChange}
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={newPasswordStatus}
                  label="Mật khẩu mới"
                  name="NewPassword"
                  rules={[
                     {
                        required: true,
                        message: "Mật khẩu không được để trống",
                     },
                     {
                        pattern: /^[A-Za-z0-9]{6,100}$/,
                        message: "Mật khẩu mới phải có 6-100 ký tự",
                     },
                  ]}
               >
                  <Input.Password
                     onChange={(e) =>
                        handleNewPasswordChange(
                           e.target.value,
                           setNewPasswordStatus
                        )
                     }
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={confirmPasswordStatus}
                  label="Xác nhận mật khẩu mới"
                  name="ConfirmNewPassword"
                  rules={[
                     {
                        required: true,
                        message: "Mật khẩu không được để trống",
                     },
                     {
                        pattern: /^[A-Za-z0-9]{6,100}$/,
                        message:
                           "Xác nhận mật phải phải trùng với mật khẩu mới",
                     },
                  ]}
               >
                  <Input.Password
                     onChange={(e) =>
                        handleConfirmPassword(
                           e.target.value,
                           form.getFieldValue("NewPassword"),
                           setConfirmPasswordStatus
                        )
                     }
                  />
               </Form.Item>
            </Form>
         </Modal>

         {/* Giao diện đăng xuất */}
         <Modal
            onClose={handleCloseModalLogOut}
            title="Xác nhận đăng xuất"
            onCancel={handleCloseModalLogOut}
            open={isShowModalLogOut}
            footer={
               <div>
                  <Button onClick={handleCloseModalLogOut}>Hủy</Button>
                  <Button onClick={handleLogOut} danger type="primary">
                     Đăng xuất
                  </Button>
               </div>
            }
         >
            <p>Bạn có chắc chắn muốn đăng xuất không</p>
         </Modal>

         <header className="header">
            <div className="container">
               {" "}
               <div className="top_bar">
                  {/* More tablet */}
                  <button
                     className="top_bar__more d-none d-lg-block js-toggle"
                     toggle-target="#navbar"
                  >
                     <img
                        src={moreIcon}
                        alt="more"
                        className="top-bar__more-icon icon"
                     />
                  </button>

                  {/* Logo */}
                  <NavLink to={"/user"} className="logo">
                     <img src={logoIcon} alt="Thư quán" className="logo__img" />
                     <h1 className="logo__title">Thư quán</h1>
                  </NavLink>

                  {/* Navbar */}
                  <nav id="navbar" className="navbar hide">
                     {/* Nut tro ve mobile */}
                     <button
                        className="navbar__close-btn js-toggle"
                        toggle-target="#navbar"
                     >
                        <img src={arrowLeftIcon} alt="back" />
                     </button>

                     {/* action mobile */}
                     <div className="navbar-act">
                        {/* Tim kiem mobile */}
                        <div className="navbar-act__group navbar-act__group--single">
                           <button className="navbar-act__btn">
                              <input
                                 type="text"
                                 name=""
                                 id=""
                                 placeholder="Tìm kiếm ..."
                                 className="navbar-act__search-field"
                              />
                              <div className="navbar-act__separate"></div>
                              <img
                                 src={searchIcon}
                                 alt="Tìm kiếm"
                                 className="navbar-act__icon icon"
                              />
                           </button>
                        </div>

                        {/* Luot thich va lich su dat mobile */}
                        <div className="navbar-act__group">
                           <button className="navbar-act__btn">
                              <img
                                 src={heartIcon}
                                 alt="Tim"
                                 className="navbar-act__icon icon"
                              />
                              <span className="navbar-act__title">03</span>
                           </button>

                           <div className="navbar-act__separate"></div>

                           <button className="navbar-act__btn">
                              <img
                                 src={orderIcon}
                                 alt="Đơn phiếu đặt"
                                 className="navbar-act__icon icon"
                              />
                           </button>
                        </div>
                     </div>

                     <ul className="navbar__list">
                        <li>
                           <NavLink end to="/user" className="navbar__link">
                              Sách
                           </NavLink>
                        </li>
                        <li>
                           <NavLink
                              to="/user/device-manager"
                              className="navbar__link"
                           >
                              Thiết Bị
                           </NavLink>
                        </li>
                        <li>
                           <NavLink
                              to="/booking-history"
                              className="navbar__link"
                           >
                              Lịch Sử Đặt
                           </NavLink>
                        </li>
                        <li>
                           <NavLink to="/user/contact" className="navbar__link">
                              Liên Hệ
                           </NavLink>
                        </li>
                     </ul>
                  </nav>

                  {/* Navbar overlay */}
                  <div
                     className="navbar__overlay js-toggle"
                     toggle-target="#navbar"
                  ></div>

                  {/* Actions */}
                  <div className="top-act">
                     <div className="top-act__group d-md-none top-act__group--single">
                        <button className="top-act__btn">
                           <input
                              type="text"
                              name=""
                              id=""
                              placeholder="Tìm kiếm ..."
                              className="top-act__search-field "
                           />
                           <div className="top-act__separate"></div>
                           <img
                              src={searchIcon}
                              alt="Tìm kiếm"
                              className="top-act__icon icon"
                           />
                           <span className="top-act__title"></span>
                        </button>
                     </div>

                     <div className="top-act__group d-md-none">
                        <button className="top-act__btn">
                           <img
                              src={heartIcon}
                              alt="Tim"
                              className="top-act__icon icon"
                           />
                           <span className="top-act__title">03</span>
                        </button>

                        <div className="top-act__separate"></div>

                        <button className="top-act__btn">
                           <img
                              src={orderIcon}
                              alt="Đơn phiếu đặt"
                              className="top-act__icon icon"
                           />
                        </button>
                     </div>

                     <div className="top-act__user">
                        <Dropdown
                           arrow
                           placement="bottomRight"
                           menu={{ items }}
                           trigger={["click"]}
                        >
                           <Avatar className="top-act__avatar">
                              {getInitials(accountLoggedin?.userName)}
                           </Avatar>
                        </Dropdown>

                        {/* <img
                           src={avatarImage}
                           alt="Ảnh đại diện"
                           className="top-act__avatar"
                        /> */}
                     </div>

                     {/* <div className="top-act__group--account">
                        <Link
                           onClick={handleNextPageLogin}
                           className="btn btn--text d-md-none"
                        >
                           Sign In
                        </Link>
                        <Link
                           onClick={handleNextPageResgiter}
                           className="top-act__sign-up btn btn--primary "
                        >
                           Sign Up
                        </Link>
                     </div> */}
                  </div>
               </div>
            </div>
         </header>
      </>
   );
}
