import HeaderUser from "@/layouts/users/header";
import { Space, Table, Tag } from "antd";
import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";

export default function BookingHistory() {
   const navigate = useNavigate();

   // Kiểm tra trạng thái đăng nhập
   useEffect(() => {
      const accessToken = Cookies.get("accessToken");
      if (!accessToken) {
         navigate("/login");
      }
   }, []);

   const columns = [
      {
         title: "Họ và tên",
         dataIndex: "HoTen",
         key: "HoTen",
         render: (text) => <a>{text}</a>,
      },
      {
         title: "Đồ đã mượn",
         dataIndex: "VatDung",
         key: "VatDung",
      },
      {
         title: "Tình trạng",
         dataIndex: "TinhTrang",
         key: "TinhTrang",
      },
      {
         title: "Ngày mượn",
         key: "NgayDat",
         dataIndex: "NgayDat",
         render: (_, { tags }) => <></>,
      },
      { title: "Chi tiết", key: "" },
   ];
   const data = [
      {
         key: "1",
         HoTen: "Cai Lon",
      },
      {
         key: "2",
         HoTen: "Cai Lon",
      },
      {
         key: "3",
         HoTen: "Cai Lon",
      },
   ];

   return (
      <>
         <HeaderUser />

         <div className="container">
            <Table columns={columns} dataSource={data} />
         </div>
      </>
   );
}
