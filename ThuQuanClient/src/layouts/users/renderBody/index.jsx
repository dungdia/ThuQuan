import React, { useEffect, useState } from "react";
import { Link, Outlet, useLocation, useNavigate } from "react-router-dom";
import categoryItem_1 from "@/assets/images/category/item-1.png";
import categoryItem_2 from "@/assets/images/category/item-2.png";
import categoryItem_3 from "@/assets/images/category/item-3.png";
import filterIcon from "@/assets/icons/filter.svg";
import { getVatDung } from "@/services/user/renderBody";
import { Spin } from "antd";

export default function RenderBody() {
   const navigate = useNavigate();
   const [vatDungs, setVatDungs] = useState([]);
   const [categoryId, setCategoryId] = useState(1);
   const [loading, setLoading] = useState(false);
   const location = useLocation();

   const fetchVatDung = async () => {
      try {
         setLoading(true);
         const response = await getVatDung(categoryId);

         setVatDungs(response.data);
      } catch (error) {
         console.log("error ", error);
      } finally {
         setLoading(false);
      }
   };

   // Hàm lấy id category khi vào trang khác
   useEffect(() => {
      if (location.pathname === "/user") {
         setCategoryId(1);
      } else if (location.pathname === "/user/device-manager") {
         setCategoryId(2);
      }
   }, [location.pathname]);

   // Lấy chạy khi  vào trang user hoặc user/device-manager
   useEffect(() => {
      fetchVatDung();
   }, [categoryId]);

   // Hàm lấy dữ liệu từ các sách
   const handleGetDataBook = (vatdung) => {
      // Lấy dữ liệu book rồi qua trang itemDetail
      navigate("/itemDetail", { state: { vatdung } });
   };

   return (
      <>
         <Spin spinning={loading}>
            <div>
               {/* browse books / devices */}
               <section className="home__container">
                  <div className="home__row">
                     <h2 className="home__heading">Duyệt Danh Mục</h2>
                  </div>
                  <div className="home__cate row row-cols-3 row-cols-md-1">
                     {/* Category Item  */}
                     {vatDungs?.map((vatDung) => (
                        <div
                           onClick={(e) => {
                              e.preventDefault();
                              handleGetDataBook(vatDung);
                           }}
                           className="col"
                           key={vatDung.id}
                        >
                           <Link>
                              <article className="cate-item">
                                 <img
                                    src={vatDung.hinhAnh}
                                    alt={vatDung.tenVatDung}
                                    className="cate-item__thumb"
                                 />
                                 <div className="cate-item__info">
                                    <h3
                                       title={vatDung.tenVatDung}
                                       className="cate-item__title format"
                                    >
                                       {vatDung.tenVatDung}
                                    </h3>
                                    <p
                                       title={vatDung.moTa}
                                       className="cate-item__desc line-clamp line-2"
                                    >
                                       {vatDung.moTa}
                                    </p>
                                 </div>
                              </article>
                           </Link>
                        </div>
                     ))}
                  </div>
               </section>

               {/* Duyệt sách , thiết bị, lịch sử đặt */}
               <section className="home__container">
                  <div className="home__row">
                     <h2 className="home__heading">
                        Chào Mừng{" "}
                        <strong className="home__heading-name">Đức</strong> Đến
                        Thư Quán
                     </h2>
                     {/* <button className="filter-btn">
                     Filter
                     <img
                        src={filterIcon}
                        alt="filter"
                        className="filter-btn__icon icon"
                     />
                  </button> */}
                     {/* <div className="filter">
                     <h3 className="filter__heading">
                        Filter
                     </h3>
                     <form action="" className="filter__form">
                        <div className="filter__row">
                           <div className="filter__col"></div>
                           <div className="filter__col"></div>
                           <div className="filter__col"></div>
                        </div>
                     </form>
                  </div> */}
                  </div>
                  <Outlet />
               </section>
            </div>
         </Spin>
      </>
   );
}
