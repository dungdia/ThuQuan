import Footer from "@/layouts/users/footer";
import HeaderUser from "@/layouts/users/header";
import bookImg from "@/assets/images/book/book_img_1.jpg";
import React, { useContext, useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Button, Image, message, Modal } from "antd";
import { HeaderContext } from "@/providers/userHeaderProvider";

export default function ItemDetail() {
   const { vatDungType, setVatDungType } = useContext(HeaderContext);

   if (vatDungType === undefined || setVatDungType === undefined) {
      console.log("Context values are missing!");
   }

   const navigate = useNavigate();
   // Lấy giá trị từ bookmanager location (truyền từ trang trước đó)
   const location = useLocation();
   const { vatdung } = location.state || {};
   console.log("vat dung", vatdung);

   const [isShowModalCart, setIsShowModalCart] = useState(false);
   const [listCart, setListCart] = useState(() => {
      const listed = localStorage.getItem("listedVatDungs");
      return listed ? JSON.parse(listed) : {};
   });

   // Lấy giá trị từ HeaderContext -> HeaderUser
   const { vatDungCartContext, setVatDungCartContext } =
      useContext(HeaderContext);

   if (
      vatDungCartContext === undefined ||
      setVatDungCartContext === undefined
   ) {
      console.log("Context values are missing!");
   }

   // Hàm mở modal thêm vào giỏ hàng
   const handleShowModalCart = () => {
      setIsShowModalCart(true);
   };

   const confirmAddCart = (vatdung) => {
      const newCart = { ...listCart };
      // Kiểm tra xem sách đã được thích hay chưa
      // Nếu đã thích thì bỏ thích, ngược lại thì thêm vào danh sách thích
      if (newCart[vatdung.id]) {
         message.info("Đã có trong giỏ hàng");
         return;
      } else if (!newCart[vatdung.id] && vatdung.tinhTrang === "Chưa mượn") {
         newCart[vatdung.id] = vatdung;
         message.success("Thêm vào giỏ hàng thành công");
         setIsShowModalCart(false);
      }

      setListCart(newCart);
      setVatDungCartContext(newCart);
      localStorage.setItem("listedVatDungs", JSON.stringify(newCart));
   };

   // Hàm đóng modal thêm vào giỏ hàng
   const handleCloseModalCart = () => {
      setIsShowModalCart(false);
   };

   useEffect(() => {
      if (!vatdung) return; //tránh gọi setState khi book chưa có

      const vatdungId = vatdung.id_LoaiVatDung;
      setVatDungType(vatdungId ?? null);
   }, [vatdung]);

   // Kiểm tra có dữ liệu hay không
   if (!vatdung) return null;

   useEffect(() => {
      if (!vatdung) {
         message.error("Lỗi không thể tải dữ liệu");
         navigate("/user");
      }
   }, [vatdung]);

   return (
      <>
         {/* Modal thêm vào danh sách giỏ hàng */}
         <Modal
            title={
               <div className="title-modal">
                  Thêm{" "}
                  <strong className="title-modal-text">
                     {vatdung.tenVatDung}
                  </strong>{" "}
                  vào giỏ hàng
               </div>
            }
            open={isShowModalCart}
            onCancel={handleCloseModalCart}
            footer={
               <div className="flex-modal">
                  <Button
                     onClick={handleCloseModalCart}
                     color="danger"
                     variant="dashed"
                  >
                     Hủy
                  </Button>
                  <Button
                     onClick={() => confirmAddCart(vatdung)}
                     color="cyan"
                     variant="solid"
                  >
                     Thêm
                  </Button>
               </div>
            }
         >
            <div className="list__cart">
               <img
                  className="list__cart--img"
                  src={vatdung.hinhAnh}
                  title={vatdung.tenVatDung}
                  alt={vatdung.moTa}
               />
               <span className="list__cart--title">
                  Bạn thật sự muốn đặt
                  {vatdung.id_LoaiVatDung == 1 ? (
                     <strong className="list__cart--text">Sách</strong>
                  ) : (
                     <strong className="list__cart--text">Thiết bị</strong>
                  )}
                  này?
               </span>
            </div>
         </Modal>

         <HeaderUser />
         <div className="container item__container">
            <div className="item">
               <div className="item__img">
                  <Image
                     src={vatdung.hinhAnh}
                     alt={vatdung.tenVatDung}
                     title={vatdung.tenVatDung}
                  />
               </div>
               <div className="item__info">
                  <div className="item__info__name">{vatdung.tenVatDung}</div>
                  <div className="item__info__description">
                     <span>
                        Định dạng:
                        {vatdung.id_LoaiVatDung == 1 ? "Sách" : "Thiết bị"}
                        <br />
                        Đặc điểm:
                        {vatdung.id_LoaiVatDung == 1
                           ? "Sách, giáo trình"
                           : "Vật dụng, thiết bị"}
                        <br />
                        Mô tả: {vatdung.moTa}
                     </span>
                  </div>
                  <div className="item__info__button">
                     {vatdung.tinhTrang === "Chưa mượn" ? (
                        <button
                           onClick={handleShowModalCart}
                           className="item__info__button__booking item__info__button__booking--available"
                        >
                           Đặt hàng
                        </button>
                     ) : vatdung.tinhTrang === "Đang mượn" ? (
                        <button className="item__info__button__booking item__info__button--borrowed  ">
                           Đang mượn
                        </button>
                     ) : vatdung.tinhTrang === "Đã đặt" ? (
                        <button className="item__info__button__booking item__info__button--booked  ">
                           Đã đặt
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
