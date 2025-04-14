import Footer from "@/layouts/users/footer";
import HeaderUser from "@/layouts/users/header";
import bookImg from "@/assets/images/book/book_img_1.jpg";
import React, { useContext, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Image, message } from "antd";
import { HeaderContext } from "@/providers/userHeaderProvider";

export default function ItemDetail() {
   const { vatDungType, setVatDungType } = useContext(HeaderContext);

   if (vatDungType === undefined || setVatDungType === undefined) {
      console.log("Context values are missing!");
   }

   const navigate = useNavigate();
   // Lấy giá trị từ bookmanager location (truyền từ trang trước đó)
   const location = useLocation();
   const { book } = location.state || {};

   useEffect(() => {
      if (!book) return; //tránh gọi setState khi book chưa có

      const vatdungId = book.id_LoaiVatDung;
      setVatDungType(vatdungId ?? null);
   }, [book]);

   // Kiểm tra có dữ liệu hay không
   if (!book) return null;

   useEffect(() => {
      if (!book) {
         message.error("Lỗi không thể tải dữ liệu");
         navigate("/user");
      }
   }, [book]);

   return (
      <>
         <HeaderUser />
         <div className="container item__container">
            <div className="item">
               <div className="item__img">
                  <Image
                     src={book.hinhAnh}
                     alt={book.tenVatDung}
                     title={book.tenVatDung}
                  />
               </div>
               <div className="item__info">
                  <div className="item__info__name">{book.tenVatDung}</div>
                  <div className="item__info__description">
                     <span>
                        Định dạng: {book ? "Sách" : "Thiết bị"} <br />
                        Đặc điểm:
                        {book ? "Sách, giáo trình" : "Vật dụng, thiết bị"}
                        <br />
                        Mô tả: {book.moTa}
                     </span>
                  </div>
                  <div className="item__info__button">
                     {book.tinhTrang === "Chưa mượn" ? (
                        <button className="item__info__button__booking item__info__button__booking--available">
                           Đặt hàng
                        </button>
                     ) : book.tinhTrang === "Đang mượn" ? (
                        <button className="item__info__button__booking item__info__button--borrowed  ">
                           Đang mượn
                        </button>
                     ) : (
                        <button className="item__info__button__booking item__info__button--broken  ">
                           Bị hỏng
                        </button>
                     )}
                  </div>
               </div>
            </div>
         </div>
         <Footer />
      </>
   );
}
