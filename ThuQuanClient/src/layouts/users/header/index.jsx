import React, { useContext, useEffect, useRef, useState } from "react";
import { Link, NavLink, useLocation, useNavigate } from "react-router-dom";
import { initJsToggle } from "../../../assets/js/header";
import moreIcon from "@/assets/icons/more.svg";
import logoIcon from "@/assets/icons/logo.svg";
import arrowLeftIcon from "@/assets/icons/arrow-left.svg";
import searchIcon from "@/assets/icons/search.svg";
import heartIcon from "@/assets/icons/heart.svg";
import heartRedIcon from "@/assets/icons/heart-red.svg";
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
import {
   Factory,
   Mail,
   Phone,
   UserRoundCheck,
   UserRoundPen,
} from "lucide-react";
import { useForm } from "antd/es/form/Form";
import {
   changePassword,
   checkCurrentPassword,
   findAccountByEmail,
   UpdateInfoUser,
} from "@/services/user/header";
import { HttpStatusCode } from "axios";
import {
   handleConfirmPassword,
   handleNewPasswordChange,
   handlePasswordChange,
} from "@/utils/validate";
import { useDebounce } from "@/hook/useDebounce";
import { applySavedTheme, toggleDarkMode } from "@/utils/theme";
import { use } from "react";
import { HeaderContext } from "@/providers/userHeaderProvider";

export default function HeaderUser() {
   const context = useContext(HeaderContext);

   if (!context) {
      return null; // hoặc hiển thị fallback UI nào đó
   }

   const {
      searchValue,
      setSearchValue,
      likedBookContext,
      setLikeBookContext,
      likeDeviceContext,
      setLikeDeviceContext,
      vatDungType,
      setVatDungType,
   } = context;

   const navigate = useNavigate();
   const [isShowAbout, setIsShowAbout] = useState(false);
   const [form] = useForm();
   const passwordRef = useRef(null);
   const [loading, setLoading] = useState(false);
   const [isShowModalLogOut, setIsShowModalLogOut] = useState(false);
   const [isShowModalChangePassword, setIsShowModalChangePassword] =
      useState(false);
   const [isCheckedTheme, setIsCheckedTheme] = useState(false);
   const [currentPassword, setCurrentPassword] = useState("");
   const [passwordStatus, setPasswordStatus] = useState("");
   const [newPasswordStatus, setNewPasswordStatus] = useState("");
   const [confirmPasswordStatus, setConfirmPasswordStatus] = useState("");
   const [isShowInfoModal, setIsShowInfoModal] = useState(false);
   const [formInfo] = useForm();
   const [valueInfoUserName, setValueInfoUserName] = useState(null);
   const [valueInfoHoten, setValueInfoHoten] = useState(null);
   const [valueInfoEmail, setValueInfoEmail] = useState(null);
   const [valueInfoSDT, setValueInfoSDT] = useState(null);
   const [isShowModalUpdateInfo, setIsShowModalUpdateInfo] = useState(false);
   const [formUpdateInfo] = useForm();
   const userNameRef = useRef(null);
   const [account, setAccount] = useState({});
   const [baseId, setBaseId] = useState(null);
   const [isLoadingUpdateInfo, setIsLoadingUpdateInfo] = useState(false);
   const [searchValueProduct, setSearchValueProduct] = useState("");
   const [isLiked, setIsLiked] = useState(false);
   const buttonRef = useRef(null); // Ref để tham chiếu đến nút xem danh sách yêu thích
   const location = useLocation(); // kiểm tra xem có ấn vào navbar không\
   const [vatDungId, setVatDungId] = useState(1);

   if (
      searchValue === undefined ||
      setSearchValue === undefined ||
      likedBookContext === undefined ||
      setLikeBookContext === undefined ||
      likeDeviceContext === undefined ||
      setLikeDeviceContext === undefined ||
      vatDungType === undefined ||
      setVatDungType === undefined
   ) {
      console.log("Context values are missing!");
   }

   // Cập nhật searchValue khi người dùng nhập vào ô tìm kiếm
   useEffect(() => {
      setSearchValue(searchValueProduct);
   }, [searchValueProduct, setSearchValue]);

   // Lấy thông tin từ localStorage
   const accountLoggedin =
      JSON.parse(localStorage.getItem("accountLoggedin")) || {};

   // Hàm để lấy các chữ cái đầu của mỗi từ trong tên
   const getInitials = (userName) => {
      const words = userName?.split(" ");
      const initials = words?.map((word) => word.charAt(0).toUpperCase());
      return initials?.join("");
   };

   // Tự chạy khi accountLoggedin thay đổi
   useEffect(() => {
      if (accountLoggedin) {
         setValueInfoEmail(accountLoggedin.email);
         setValueInfoHoten(accountLoggedin.hoten);
         setValueInfoUserName(accountLoggedin.userName);
         setValueInfoSDT(accountLoggedin.sdt);
      }
   }, [accountLoggedin]);

   // Hàm mở modal thông tin cá nhân
   const handleShowInfoModal = async () => {
      setIsShowInfoModal(true);
      await fetchAccount();
      if (accountLoggedin) {
         formInfo.setFieldsValue(accountLoggedin);
      }
   };

   // Hàm đóng modal thông tin cá nhân
   const handleCloseInfoModal = () => {
      setIsShowInfoModal(false);
      setBaseId(null);
      setAccount(null);
   };

   // Ngăn chặn sự focus của label
   const handlePreventFocus = (e) => {
      e.preventDefault();
   };

   // Hàm mở modal cập nhật thông tin cá nhân
   const handleShowModalUpdateInfo = () => {
      setIsShowModalUpdateInfo(true);
      setIsShowInfoModal(false);

      // Lấy id từ tài khoản
      setBaseId(account.id);

      if (accountLoggedin) {
         formUpdateInfo.setFieldsValue(accountLoggedin);
      }

      setTimeout(() => {
         if (passwordRef.current) {
            passwordRef.current.focus();
         }
      }, 100);
   };

   // Hàm đóng modal cập nhật thông tin cá nhân
   const handleCloseModalUpdateInfo = () => {
      setIsShowModalUpdateInfo(false);
      setIsShowInfoModal(true);
      setBaseId(null);
   };

   // Hàm tự focus vào userName
   useEffect(() => {
      if (isShowModalUpdateInfo && userNameRef.current) {
         userNameRef.current.focus();
      }
   }, [isShowModalUpdateInfo]);

   // Hàm lấy dữ liệu từ tài khoản bởi email
   const fetchAccount = async () => {
      const response = await findAccountByEmail(accountLoggedin.email);
      setAccount(response.data);
   };

   // Hàm xử lý cập nhật thông tin
   const handleUpdateInfo = async () => {
      try {
         setIsLoadingUpdateInfo(true);

         const values = formUpdateInfo.getFieldsValue();

         const { email, hoten, sdt, userName } = values;
         const id = baseId;

         const response = await UpdateInfoUser({
            Id: id,
            UserName: userName,
            HoTen: hoten,
            Email: email,
            sdt: sdt,
         });

         if (response?.status === 200) {
            // Lưu dữ liệu mới vào localStorage
            const updatedAccount = {
               ...accountLoggedin,
               email,
               hoten,
               sdt,
               userName,
            };
            localStorage.setItem(
               "accountLoggedin",
               JSON.stringify(updatedAccount)
            );

            // Đóng modal sau khi cập nhật
            setIsShowModalUpdateInfo(false);
            setIsShowInfoModal(true);
            // Cập nhật form thông tin cá nhân
            formInfo.setFieldsValue(updatedAccount);

            // Hiển thị thông báo thành công
            message.success("Cập nhật thông tin thành công!");
         } else {
            message.error(response?.data?.message || "Cập nhật thất bại!");
         }
      } catch (error) {
         if (error?.response?.status === HttpStatusCode.BadRequest) {
            console.log("error ", error);

            message.error(error?.response?.data);
         } else {
            message.error("Đã xảy ra lỗi, vui lòng thử lại!");
         }
      } finally {
         setIsLoadingUpdateInfo(false);
      }
   };

   // Sẽ gọi mỗi khi vào trang user
   useEffect(() => {
      fetchAccount();
   }, []);

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

   // Khi component load, áp dụng theme và cập nhật state
   useEffect(() => {
      applySavedTheme();
      const savedTheme = localStorage.getItem("theme");
      setIsCheckedTheme(savedTheme === "dark");
   }, []);

   // Hàm chuyển theme sáng/tối
   const handleToggle = (e) => {
      e.stopPropagation();
      toggleDarkMode();
      setIsCheckedTheme((prev) => !prev);
   };

   // Các thành phần của DropDown của Avatar
   const items = [
      {
         label: (
            <div
               onClick={(e) => {
                  e.stopPropagation();
                  handleShowInfoModal();
               }}
            >
               Thông tin cá nhân
            </div>
         ),
         key: "0",
      },
      {
         label: (
            <div
               onClick={(e) => {
                  e.stopPropagation();
                  handleShowModalChangePassword();
               }}
            >
               Đổi mật khẩu
            </div>
         ),
         key: "1",
      },
      {
         label: (
            <>
               <label
                  htmlFor="theme"
                  onClick={(e) => e.stopPropagation()}
                  className=""
               >
                  Giao diện
               </label>
               <label onClick={(e) => e.stopPropagation()} className="switch">
                  <input
                     id="theme"
                     name="theme"
                     checked={isCheckedTheme}
                     onClick={(e) => handleToggle(e)}
                     type="checkbox"
                     readOnly
                  />
                  <span className="slider"></span>
               </label>
            </>
         ),
         key: "3",
      },
      {
         type: "divider",
      },
      {
         label: (
            <div
               onClick={(e) => {
                  e.stopPropagation(), handleShowModalLogOut();
               }}
            >
               Đăng xuất
            </div>
         ),
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

   // Hàm mở modal about
   const handleShowAbout = () => {
      setIsShowAbout(true);
   };

   // Hàm đóng modal about
   const handleCloseAbout = () => {
      setIsShowAbout(false);
   };

   // Hàm chuyển icon sang màu đỏ khi có sản phẩm yêu thích
   const handleIconColorChange = () => {
      setIsLiked(!isLiked);
   };

   // Hàm trả về màu sắc của icon yêu thích
   useEffect(() => {
      const handleClickOutside = (e) => {
         // Kiểm tra nếu người dùng nhấp ra ngoài dropdown
         if (buttonRef.current && !buttonRef.current.contains(e.target)) {
            setIsLiked(false);
         }
      };

      // Thêm sự kiện click cho document
      document.addEventListener("mousedown", handleClickOutside);

      // Cleanup: Xóa trình lắng nghe khi component bị unmount
      return () => {
         document.removeEventListener("mousedown", handleClickOutside);
      };
   }, []);

   // Hàm lấy id vật dụng khi vào trang khác
   useEffect(() => {
      if (location.pathname === "/user") {
         setVatDungId(1);
      } else if (location.pathname === "/user/device-manager") {
         setVatDungId(2);
      }
   }, [location.pathname]);

   // Các thành phần của DropDown của các sản phẩm yêu thích
   let likedVatDungLocal =
      JSON.parse(
         localStorage.getItem(
            vatDungId === 1 || vatDungType === 1 ? "likedBooks" : "likedDevices"
         )
      ) || {};

   // Mỗi khi cập nhật danh sách yêu thích thì cập nhật lại
   useEffect(() => {
      likedVatDungLocal =
         JSON.parse(
            localStorage.getItem(vatDungId == 1 ? "likedBooks" : "likedDevices")
         ) || {};
   }, [likedBookContext, likeDeviceContext, vatDungId]);

   // Cập nhật lại VatDungId khi click vào  item trong danh sách yêu thích thông qua vatDungType Context
   useEffect(() => {
      if (vatDungType !== null && vatDungId !== vatDungType) {
         setVatDungId(vatDungType);
      }
   }, [vatDungType]);

   // Lấy danh sách các sản phẩm yêu thích từ localStorage
   const favoritesDropdownItems = Object.values(likedVatDungLocal).flatMap(
      (book, index, array) => {
         const items = [
            {
               key: book.id,
               label: (
                  <Link to="/itemDetail" state={{ book }}>
                     {book.tenVatDung}
                  </Link>
               ),
            },
         ];

         // Thêm divider nếu không phải là phần tử cuối cùng
         if (index < array.length - 1) {
            items.push({ type: "divider" });
         }

         return items;
      }
   );

   // Lọc các phần tử không phải là divider
   const nonDividerItemsCount = favoritesDropdownItems.filter(
      (item) => item.type !== "divider"
   ).length;

   return (
      <>
         {/* Giao diện cập nhật thông tin cá nhân */}
         <Modal
            onCancel={handleCloseModalUpdateInfo}
            title="Cập nhật thông tin cá nhân"
            open={isShowModalUpdateInfo}
            footer={
               <div className="flex-modal">
                  <Button
                     color="danger"
                     variant="dashed"
                     onClick={handleCloseModalUpdateInfo}
                  >
                     Đóng
                  </Button>
                  <Button
                     onClick={handleUpdateInfo}
                     loading={isLoadingUpdateInfo}
                     ghost
                     type="primary"
                  >
                     Lưu
                  </Button>
               </div>
            }
         >
            <Form
               form={formUpdateInfo}
               name="Cập nhật thông tin ca nhan"
               layout="vertical"
               requiredMark={false}
               autoComplete="off"
            >
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoUserName !== null && valueInfoUserName !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div>Tên người dùng</div>}
                  name="userName"
               >
                  <Input
                     ref={userNameRef}
                     prefix={
                        <UserRoundCheck className="size-5 text-slate-600" />
                     }
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoHoten !== null && valueInfoHoten !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div>Họ và tên</div>}
                  name="hoten"
               >
                  <Input
                     prefix={<UserRoundPen className="size-5 text-slate-600" />}
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoEmail !== null && valueInfoEmail !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div>Email</div>}
                  name="email"
               >
                  <Input prefix={<Mail className="size-5 text-slate-600" />} />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoSDT !== null && valueInfoSDT !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div>Số điện thoại</div>}
                  name="sdt"
               >
                  <Input prefix={<Phone className="size-5 text-slate-600" />} />
               </Form.Item>
            </Form>
         </Modal>

         {/* Giao diện thông tin cá nhân */}
         <Modal
            onCancel={handleCloseInfoModal}
            title="Thông tin cá nhân"
            open={isShowInfoModal}
            footer={
               <div className="flex-modal">
                  <Button
                     color="danger"
                     variant="dashed"
                     onClick={handleCloseInfoModal}
                  >
                     Đóng
                  </Button>
                  <Button onClick={handleShowModalUpdateInfo} type="primary">
                     Cập nhật
                  </Button>
               </div>
            }
         >
            <Form
               form={formInfo}
               name="Thong tin ca nhan"
               layout="vertical"
               requiredMark={false}
               autoComplete="off"
            >
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoUserName !== null && valueInfoUserName !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div onClick={handlePreventFocus}>Tên người dùng</div>}
                  name="userName"
               >
                  <Input
                     prefix={
                        <UserRoundCheck className="size-5 text-slate-600" />
                     }
                     className="select-none"
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoHoten !== null && valueInfoHoten !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div onClick={handlePreventFocus}>Họ và tên</div>}
                  name="hoten"
               >
                  <Input
                     prefix={<UserRoundPen className="size-5 text-slate-600" />}
                     className="select-none"
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoEmail !== null && valueInfoEmail !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div onClick={handlePreventFocus}>Email</div>}
                  name="email"
               >
                  <Input
                     prefix={<Mail className="size-5 text-slate-600" />}
                     className="select-none"
                  />
               </Form.Item>
               <Form.Item
                  hasFeedback
                  validateStatus={
                     valueInfoSDT !== null && valueInfoSDT !== ""
                        ? "success"
                        : "error"
                  }
                  label={<div onClick={handlePreventFocus}>Số điện thoại</div>}
                  name="sdt"
               >
                  <Input
                     prefix={<Phone className="size-5 text-slate-600" />}
                     className="select-none font-normal text-red-400"
                  />
               </Form.Item>
            </Form>
         </Modal>

         {/* Giao diện đổi mật khẩu */}
         <Modal
            title="Đổi mật khẩu"
            footer={
               <div className="flex-modal">
                  <Button
                     color="danger"
                     variant="dashed"
                     onClick={handleCloseModalChangePassword}
                  >
                     Hủy
                  </Button>
                  <Button
                     onClick={confirmChangePassword}
                     loading={loading}
                     color="cyan"
                     variant="solid"
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
               <div className="flex-modal">
                  <Button
                     color="primary"
                     variant="dashed"
                     onClick={handleCloseModalLogOut}
                  >
                     Hủy
                  </Button>
                  <Button
                     onClick={handleLogOut}
                     color="danger"
                     variant="outlined"
                  >
                     Đăng xuất
                  </Button>
               </div>
            }
         >
            <p>Bạn có chắc chắn muốn đăng xuất không</p>
         </Modal>

         {/* Giao diện trang about */}
         <Modal
            width={700}
            closeIcon={false}
            title=""
            onCancel={handleCloseAbout}
            open={isShowAbout}
            footer={false}
            className="custom-modal"
         >
            <div>
               {/* Header */}
               <div className="modal-header">
                  <h1 className="modal-title">Hỗ Trợ Khách Hàng - Thư quán</h1>
               </div>

               {/* Navigation */}
               <div className="modal-nav">
                  <a href="#faq" className="modal-link">
                     Câu hỏi thường gặp
                  </a>
                  <a href="#shipping" className="modal-link">
                     Vận chuyển
                  </a>
                  <a href="#returns" className="modal-link">
                     Đổi trả và hoàn tiền
                  </a>
                  <a href="#contact" className="modal-link">
                     Liên hệ chúng tôi
                  </a>
               </div>
            </div>

            {/* FAQ Section */}
            <section id="faq" className="modal-section">
               <h2 className="section-title">Câu hỏi thường gặp</h2>
               <p>
                  <strong>1. Làm thế nào để đặt hàng?</strong>
                  <br />
                  Để đặt hàng, hãy thêm sản phẩm vào giỏ hàng và nhấp vào nút
                  "Thanh toán".
               </p>
               <p>
                  <strong>
                     2. Làm thế nào để kiểm tra trạng thái đơn hàng?
                  </strong>
                  <br />
                  Bạn có thể kiểm tra trạng thái đơn hàng trong tài khoản của
                  bạn hoặc liên hệ với chúng tôi qua trang Liên hệ.
               </p>
               <p>
                  <strong>3. Làm thế nào để thay đổi thông tin cá nhân?</strong>
                  <br />
                  Bạn có thể cập nhật thông tin cá nhân trong phần Tài khoản của
                  bạn.
               </p>
            </section>

            {/* Shipping Section */}
            <section id="shipping" className="modal-section">
               <h2 className="section-title">Thông tin Vận chuyển</h2>
               <p>
                  Chúng tôi cung cấp các tùy chọn vận chuyển nhanh chóng và đáng
                  tin cậy. Chi phí vận chuyển và thời gian giao hàng cụ thể sẽ
                  hiển thị trong quá trình thanh toán.
               </p>
               <p>
                  <strong>Phí Vận chuyển:</strong> Phí vận chuyển được tính dựa
                  trên địa chỉ giao hàng của bạn.
               </p>
               <p>
                  <strong>Thời Gian Giao Hàng:</strong> Thời gian giao hàng ước
                  tính sẽ được hiển thị trong quá trình thanh toán.
               </p>
            </section>

            {/* Returns Section */}
            <section id="returns" className="modal-section">
               <h2 className="section-title">
                  Chính sách Đổi trả và Hoàn tiền
               </h2>
               <p>
                  Chúng tôi chấp nhận đổi trả trong vòng 30 ngày kể từ ngày mua.
                  Để đổi trả, vui lòng liên hệ với chúng tôi qua trang Liên hệ.
               </p>
               <p>
                  <strong>Điều Kiện Đổi Trả:</strong> Sản phẩm phải còn nguyên
                  vẹn, chưa sử dụng và có các nhãn mác gốc.
               </p>
               <p>
                  <strong>Hoàn Tiền:</strong> Hoàn tiền sẽ được xử lý trong vòng
                  7-10 ngày làm việc sau khi nhận được sản phẩm đổi trả.
               </p>
            </section>

            {/* Contact Section */}
            <section id="contact" className="modal-section">
               <h2 className="section-title">Liên hệ chúng tôi</h2>
               <p>
                  Nếu bạn có bất kỳ câu hỏi hoặc cần hỗ trợ, hãy liên hệ với
                  chúng tôi qua email:
                  <a href="mailto:support@example.com" className="contact-link">
                     support@example.com
                  </a>
               </p>
               <p>
                  Hoặc gọi đến số điện thoại hỗ trợ của chúng tôi:
                  <strong>(123) 456-7890</strong>.
               </p>
               <p>
                  Chúng tôi cũng có thể được liên hệ qua mạng xã hội:
                  <a href="#" className="contact-link">
                     Facebook
                  </a>
                  ,{" "}
                  <a href="#" className="contact-link">
                     Twitter
                  </a>
                  .
               </p>
            </section>

            {/* Footer */}
            <div className="custom-footer">
               <p>&copy; 2023 Tên Trang Web. Bản quyền thuộc về chúng tôi.</p>
            </div>
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
                                 value={searchValueProduct}
                                 onChange={(e) =>
                                    setSearchValueProduct(e.target.value)
                                 }
                              />
                              <div className="navbar-act__separate"></div>
                              <img
                                 src={searchIcon}
                                 alt="Tìm kiếm"
                                 className="navbar-act__icon icon"
                              />
                           </button>
                        </div>

                        {/* Luot thich va lich su đặt mobile */}
                        <div className="navbar-act__group">
                           {/* DropDown các sản phẩm yêu thích mobile */}
                           <Dropdown
                              arrow
                              placement="bottomRight"
                              menu={{ items: favoritesDropdownItems }}
                              trigger={["click"]}
                              onClick={() => {
                                 if (
                                    Object.keys(likedVatDungLocal).length === 0
                                 ) {
                                    message.info(
                                       "Chưa có sản phẩm yêu thích nào"
                                    );
                                 }
                              }}
                           >
                              <button
                                 ref={buttonRef}
                                 onClick={handleIconColorChange}
                                 className="top-act__btn"
                                 style={isLiked ? { paddingLeft: "2px" } : {}}
                              >
                                 <img
                                    src={isLiked ? heartRedIcon : heartIcon}
                                    alt="Tim"
                                    className={
                                       isLiked
                                          ? "top-act__icon icon-red "
                                          : "top-act__icon icon"
                                    }
                                 />
                                 <span className="top-act__title">
                                    {nonDividerItemsCount}
                                 </span>
                              </button>
                           </Dropdown>

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
                           <a
                              href="#"
                              onClick={(e) => {
                                 e.preventDefault();
                                 handleShowAbout();
                              }}
                              className="navbar__link"
                           >
                              Liên Hệ
                           </a>
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
                        <div className="top-act__btn">
                           <input
                              type="text"
                              name=""
                              id=""
                              value={searchValueProduct}
                              onChange={(e) =>
                                 setSearchValueProduct(e.target.value)
                              }
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
                        </div>
                     </div>

                     <div className="top-act__group d-md-none">
                        {/* DropDown các sản phẩm yêu thích */}
                        <Dropdown
                           arrow
                           placement="top"
                           menu={{ items: favoritesDropdownItems }}
                           trigger={["click"]}
                           height={200}
                           onClick={() => {
                              if (Object.keys(likedVatDungLocal).length === 0) {
                                 message.info("Chưa có sản phẩm yêu thích nào");
                              }
                           }}
                        >
                           <button
                              ref={buttonRef}
                              onClick={handleIconColorChange}
                              className="top-act__btn"
                              style={isLiked ? { paddingLeft: "2px" } : {}}
                           >
                              <img
                                 src={isLiked ? heartRedIcon : heartIcon}
                                 alt="Tim"
                                 className={
                                    isLiked
                                       ? "top-act__icon icon-red "
                                       : "top-act__icon icon"
                                 }
                              />
                              <span className="top-act__title">
                                 {nonDividerItemsCount}
                              </span>
                           </button>
                        </Dropdown>

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
                           <Avatar
                              title={getInitials(accountLoggedin?.userName)}
                              className="top-act__avatar"
                           >
                              <p className="format">
                                 {getInitials(accountLoggedin?.userName)}
                              </p>
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
