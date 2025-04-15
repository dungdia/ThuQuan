import React, { useContext, useEffect, useState } from "react";
import heartIcon from "@/assets/icons/heart.svg";
import heartRedIcon from "@/assets/icons/heart-red.svg";
import starIcon from "@/assets/icons/star.svg";
import { Link, useNavigate } from "react-router-dom";
import { message, Spin } from "antd";
import { getAllDevices } from "@/services/user/device-manager";
import { useDebounce } from "@/hook/useDebounce";
import { HeaderContext } from "@/providers/userHeaderProvider";

export default function DeviceManager() {
   const navigate = useNavigate();
   const [loading, setLoading] = useState(false);
   const [devices, setDevices] = useState([]);
   const [pageSize, setPageSize] = useState(8);
   const [currentPage, setCurrentPage] = useState(1);
   const [totalElements, setTotalElements] = useState(0);

   // State để quản lý trạng thái thích (liked) của thiết bị
   const [likedDevices, setLikedDevices] = useState(() => {
      const stored = localStorage.getItem("likedDevices");
      return stored ? JSON.parse(stored) : {};
   });

   // Lấy giá trị từ HeaderContext -> HeaderUser
   const {
      searchValue,
      setSearchValue,
      likeDeviceContext,
      setLikeDeviceContext,
   } = useContext(HeaderContext);

   if (
      searchValue === undefined ||
      setSearchValue === undefined ||
      likeDeviceContext === undefined ||
      setLikeDeviceContext === undefined
   ) {
      // console.log("Context values are missing!");
   }

   const debounceSearch = useDebounce(searchValue, 800);

   const fetchDevices = async () => {
      try {
         setLoading(true);

         const response = await getAllDevices(
            debounceSearch,
            currentPage,
            pageSize
         );

         // Render tất cả sản phẩm
         setDevices(response.data.items);

         // Lấy ra tổng số bảng ghi
         setTotalElements(response.data.totalItems);
      } catch (error) {
         message.error("Lỗi không tải được dữ liệu thiết bị!");
      } finally {
         setLoading(false);
      }
   };

   // Chỉ chạy khi một trong các giá trị thay đổi
   useEffect(() => {
      fetchDevices();
   }, [debounceSearch, currentPage, pageSize]);

   // Chỉ chạy khi vào trang user
   useEffect(() => {
      fetchDevices();
   }, []);

   // Hàm chuyển trang
   const handleChangePage = (currentPage, pageSize) => {
      // Cập nhật lại trang hiện tại
      setCurrentPage(currentPage);
      // Cập nhật lại số lượng sản phẩm trên 1 trang
      setPageSize(pageSize);
   };

   // Hàm lấy dữ liệu từ các thiết bị
   const handleGetDataDevice = (vatdung) => {
      // Lấy từ dữ liệu device rồi qua trang itemDetail
      navigate("/itemDetail", { state: { vatdung } });
   };

   // Hàm lấy số ngẫu nhiên
   const getRandomRating = () => {
      return (Math.random() * 2 + 3).toFixed(1);
   };

   const toggleLike = (device) => {
      const newLikedDevices = { ...likedDevices };
      // Kiểm tra xem thiết bị đã được thích hay chưa
      // Nếu đã thích thì bỏ thích, ngược lại thì thêm vào danh sách thích
      if (newLikedDevices[device.id]) {
         delete newLikedDevices[device.id];
      } else {
         newLikedDevices[device.id] = device;
      }
      setLikedDevices(newLikedDevices);
      setLikeDeviceContext(newLikedDevices);
      localStorage.setItem("likedDevices", JSON.stringify(newLikedDevices));
   };

   return (
      <>
         <Spin spinning={loading}>
            <div className="row row-cols-4 row-cols-lg-2 row-cols-sm-1 g-3">
               {devices?.map((device) => (
                  <div key={device.id} className="col">
                     <article className="device-card">
                        <div className="device-card__img-wrap">
                           <Link
                              to="#"
                              onClick={(e) => {
                                 e.preventDefault();
                                 handleGetDataDevice(device);
                              }}
                           >
                              <img
                                 src={device.hinhAnh}
                                 alt={device.tenVatDung}
                                 className="device-card__thumb"
                              />
                           </Link>
                           <button
                              className={`like-btn device-card__like-btn ${
                                 likedDevices[device.id]
                                    ? "like-btn--liked"
                                    : ""
                              }`}
                              onClick={() => toggleLike(device)}
                           >
                              <img
                                 src={heartIcon}
                                 alt=""
                                 className="like-btn__icon icon"
                              />
                              <img
                                 src={heartRedIcon}
                                 alt=""
                                 className="like-btn__icon--liked "
                              />
                           </button>
                        </div>
                        <h3
                           title={device.tenVatDung}
                           className="device-card__title format w-text"
                        >
                           <Link
                              to="#"
                              onClick={(e) => {
                                 e.preventDefault();
                                 handleGetDataDevice(device);
                              }}
                           >
                              {device.tenVatDung}
                           </Link>
                        </h3>
                        <p
                           title={device.moTa}
                           onClick={(e) => {
                              e.preventDefault();
                              handleGetDataDevice(device);
                           }}
                           className="device-card__author format"
                        >
                           {device.moTa}
                        </p>
                        <div
                           onClick={(e) => {
                              e.preventDefault();
                              handleGetDataDevice(device);
                           }}
                           className="device-card__row"
                        >
                           <span
                              className={`device-card__price ${
                                 device.tinhTrang === "Chưa mượn"
                                    ? "device-card__price--available"
                                    : device.tinhTrang === "Đang mượn"
                                    ? "device-card__price--borrowed"
                                    : device.tinhTrang === "Đã đặt"
                                    ? "device-card__price--booked"
                                    : "device-card__price--broken"
                              }`}
                           >
                              {device.tinhTrang}
                           </span>
                           <img
                              src={starIcon}
                              alt=""
                              className="device-card__star"
                           />
                           <span className="device-card__score">
                              {device.tinhTrang === "Bị hỏng"
                                 ? "0"
                                 : getRandomRating()}
                           </span>
                        </div>
                     </article>
                  </div>
               ))}

               {totalElements <= 8 ? (
                  ""
               ) : (
                  <div className="device-card__pagenation-devices">
                     <Pagination
                        className="device-card__pagination"
                        showSizeChanger
                        total={totalElements}
                        showTotal={(total, range) =>
                           `${range[0]}-${range[1]} of ${total} items`
                        }
                        onChange={handleChangePage}
                        defaultPageSize={pageSize}
                        defaultCurrent={currentPage}
                        pageSizeOptions={[8, 16, 32, 64, 100]}
                     />
                  </div>
               )}
            </div>
         </Spin>
      </>
   );
}
