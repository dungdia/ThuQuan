import HeaderUser from "@/layouts/users/header";
import { Button, Input, message, Modal, Table } from "antd";
import React, { useEffect, useMemo, useState } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import { getAllDataBookingHistory } from "@/services/user/booking-history";
import { useDebounce } from "@/hook/useDebounce";

export default function BookingHistory() {
   const navigate = useNavigate();
   const [isLoading, setIsLoading] = useState(false);
   const [dataItem, setDataIten] = useState([]);
   const [searchText, setSearchText] = useState("");
   const [filteredData, setFilteredData] = useState([]);
   const [isShowModalDetail, setIsShowModalDetail] = useState(false);
   const [baseId, setBaseId] = useState(null);
   const [accessToken, setAccessToken] = useState(Cookies.get("accessToken"));

   // Lấy dữ liệu người dùng từ local
   const accountLoggedin = useMemo(() => {
      const acc = localStorage.getItem("accountLoggedin");
      return acc ? JSON.parse(acc) : {};
   }, []);

   // Lấy accessToken từ cookie
   useEffect(() => {
      const waitForToken = async () => {
         let token = Cookies.get("accessToken");
         const maxRetries = 50; // Số lần thử tối đa
         let retries = 0; // Biến đếm số lần thử

         while (!token && retries < maxRetries) {
            await new Promise((resolve) => setTimeout(resolve, 100)); // Chờ 100ms trước khi thử lại
            token = Cookies.get("accessToken"); // Cập nhật giá trị token
            retries++; // Tăng biến đếm số lần thử
         }

         if (token) {
            setAccessToken(token); // Cập nhật accessToken nếu có
         } else {
            console.error("Không tìm thấy accessToken sau khi đợi.");
         }
      };
      waitForToken(); // Gọi hàm chờ token
   }, []);

   useEffect(() => {
      if (!accessToken) {
         navigate("/login");
      }
   }, [accessToken, navigate]);

   const columns = [
      {
         title: "Họ và tên",
         dataIndex: "HoTen",
         key: "HoTen",
         render: (_, item) => (
            <p title={accountLoggedin?.hoten} className="format format-width">
               {accountLoggedin?.hoten}
            </p>
         ),
      },
      {
         title: "Số điện thoại",
         dataIndex: "sdt",
         key: "sdt",
      },
      {
         title: "Ngày mượn",
         key: "NgayDat",
         dataIndex: "NgayDat",
      },
      {
         title: "Tên vật dụng",
         key: "tenVatDung",
         dataIndex: "tenVatDung",
         render: (_, item) => (
            <p title={item.tenVatDung} className="format format-width">
               {item.tenVatDung}
            </p>
         ),
      },
      {
         title: "Hành động",
         key: "action",
         render: (_, item) => (
            <div className="gap-modal">
               <Button
                  onClick={() => handleShowModalDetail(item.id)}
                  color="danger"
                  variant="filled"
               >
                  Xem
               </Button>
            </div>
         ),
      },
   ];

   // Hàm lấy dữ liệu phiếu đặt
   const fetchBookingHistory = async () => {
      try {
         setIsLoading(true);
         if (!accessToken) return; // Nếu không có accessToken thì không fetch

         const response = await getAllDataBookingHistory();
         if (response) {
            setDataIten(response);
            message.success("Tải dữ liệu thành công!!");
         } else {
            message.error("Không có dữ liệu!!");
         }
      } catch (error) {
         console.log("Error: ", error);
      } finally {
         setIsLoading(false);
      }
   };

   // Hàm chạy mỗi khi có accessToken
   useEffect(() => {
      if (accessToken) {
         fetchBookingHistory(); // Gọi hàm lấy dữ liệu phiếu đặt
      }
   }, [accessToken]);

   const data = useMemo(() => {
      return (
         dataItem?.flatMap((item, index) =>
            item.chiTietPhieuDatList.map((detail, index) => ({
               id: item.id,
               key: `${item.id}-${index}`,
               HoTen: accountLoggedin?.hoten || "Chưa cập nhật",
               sdt: accountLoggedin?.sdt || "Chưa cập nhật",
               NgayDat: new Date(item.ngayDat).toLocaleDateString("vi-VN"),
               tenVatDung: detail.vatDung.tenVatDung,
            }))
         ) || []
      );
   }, [dataItem]);

   const debounceSearch = useDebounce(searchText, 800);

   useEffect(() => {
      if (!debounceSearch) {
         setFilteredData(data); // nếu không nhập gì thì hiển thị toàn bộ
      } else {
         const lowerSearch = debounceSearch.toLowerCase();
         const filtered = data.filter(
            (item) =>
               item.tenVatDung.toLowerCase().includes(lowerSearch) ||
               item.NgayDat.toLowerCase().includes(lowerSearch)
         );
         setFilteredData(filtered);
      }
   }, [debounceSearch, data]);

   // Hàm mở modal xem chi tiết phiếu đặt
   const handleShowModalDetail = (id) => {
      setIsShowModalDetail(true);

      // Lấy id phiếu đặt
      setBaseId(id);
   };

   // Hàm đóng modal xem chi tiết phiếu đặt
   const handleCloseModalDetail = (id) => {
      setIsShowModalDetail(false);

      // Reset id
      setBaseId(null);
   };

   // Lấy ra vật dụng theo id từ trong dataItem
   const foundVatDung = dataItem?.find((item) => item.id === baseId)
      ?.chiTietPhieuDatList?.[0]?.vatDung;

   // Hàm đặt lại vật dụng qua trang itemDetail
   const handleBookedAgain = (vatdung) => {
      // Lấy dữ liệu book rồi qua trang itemDetail
      navigate("/itemDetail", { state: { vatdung } });

      setIsShowModalDetail(false);
      // Reset lại id
      setBaseId(null);
   };
   return (
      <>
         {/* Giao diện chi tiết phiếu mượn */}
         <Modal
            title={`Chi tiết phiếu mượn ngày ${new Date(
               dataItem.find((item) => item.id === baseId)?.ngayDat
            ).toLocaleDateString("vi-VN")}`}
            open={isShowModalDetail}
            onCancel={handleCloseModalDetail}
            footer={
               <div className="flex-modal">
                  <Button
                     onClick={handleCloseModalDetail}
                     color="danger"
                     variant="dashed"
                  >
                     Đóng
                  </Button>
                  <Button
                     onClick={(e) => {
                        e.preventDefault();
                        handleBookedAgain(foundVatDung);
                     }}
                     color="cyan"
                     variant="filled"
                  >
                     Đặt lại
                  </Button>
               </div>
            }
         >
            {foundVatDung && (
               <div className="list__detail">
                  <img
                     className="list__detail--img"
                     src={foundVatDung.hinhAnh}
                     title={foundVatDung.tenVatDung}
                     alt={foundVatDung.moTa}
                  />
                  <span className="list__detail--title">
                     <p className="list__detail--title-text-name format format-width">
                        {`Tên: ${foundVatDung.tenVatDung}`}
                     </p>

                     <p className="list__detail--title-text-desc format format-width">
                        {`Mô tả: ${foundVatDung.moTa}`}
                     </p>
                     <p
                        className={`list__detail--title-text-status ${
                           foundVatDung.tinhTrang === "Chưa mượn"
                              ? ""
                              : foundVatDung.tinhTrang === "Đang mượn"
                              ? "list__detail--title-text-status-borrowed"
                              : foundVatDung.tinhTrang === "Đã đặt"
                              ? "list__detail--title-text-status-booked"
                              : "list__detail--title-text-status-broken"
                        }`}
                     >
                        {`Tình trạng: ${foundVatDung.tinhTrang}`}
                     </p>
                  </span>
               </div>
            )}
         </Modal>

         <HeaderUser />
         <div className="container ">
            <div className="booking__history">
               <div className="flex-modal-2">
                  <Input.Search
                     className="input-search"
                     placeholder="Nhập tên vật dụng hoặc ngày (dd/mm/yyyy)"
                     allowClear
                     onChange={(e) => setSearchText(e.target.value)}
                     style={{ marginBottom: 16 }}
                  />
                  <Button
                     color="cyan"
                     variant="solid"
                     onClick={fetchBookingHistory}
                     className="btn-reload"
                  >
                     Tải lại
                  </Button>
               </div>
               <Table
                  loading={isLoading}
                  columns={columns}
                  dataSource={filteredData}
                  pagination={
                     filteredData.length > 5
                        ? {
                             pageSize: 5,
                             showQuickJumper: true,
                             showSizeChanger: false,
                             showTotal: (total, range) =>
                                `${range[0]}-${range[1]} trong tổng ${total} vật dụng`,
                          }
                        : false
                  }
               />
            </div>
         </div>
      </>
   );
}
