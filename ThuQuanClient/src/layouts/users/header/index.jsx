import React, { useEffect, useState } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { initJsToggle } from "../../../assets/js/header";
import moreIcon from "@/assets/icons/more.svg";
import logoIcon from "@/assets/icons/logo.svg";
import arrowLeftIcon from "@/assets/icons/arrow-left.svg";
import searchIcon from "@/assets/icons/search.svg";
import heartIcon from "@/assets/icons/heart.svg";
import orderIcon from "@/assets/icons/order.svg";
import avatarImage from "@/assets/images/avatar.jpg";
import { Avatar, Button, Dropdown, Modal, Space } from "antd";
import Cookies from "js-cookie";

export default function HeaderUser() {
   const navigate = useNavigate();
   const [isShowModalLogOut, setIsShowModalLogOut] = useState(false);

   // Lấy thông tin từ localStorage
   const accountLoggedin =
      JSON.parse(localStorage.getItem("accountLoggedin")) || {};

   // Hàm để lấy các chữ cái đầu của mỗi từ trong tên
   const getInitials = (userName) => {
      const words = userName?.split(" ");
      const initials = words?.map((word) => word.charAt(0).toUpperCase());
      return initials?.join("");
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
         label: <div>Đổi mật khẩu</div>,
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
