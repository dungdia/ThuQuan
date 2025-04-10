import React, { useEffect, useState } from "react";
import HeaderUser from "./header";
import RenderBody from "./renderBody";
import Footer from "./footer";
import SlideShow from "./slideShow";
import Cookies from "js-cookie";
import { Navigate, useNavigate } from "react-router-dom";
import { UserHeaderProvider } from "@/providers/userHeaderProvider";

export default function UserLayout() {
   const navigate = useNavigate();

   // Kiểm tra trạng thái đăng nhập
   useEffect(() => {
      // Lấy dữ liệu từ Cookie
      const accessToken = Cookies.get("accessToken");
      if (!accessToken) {
         navigate("/login");
      }
   }, []);
   return (
      <>
         <UserHeaderProvider>
            <HeaderUser />
            <main className="container home">
               <SlideShow />
               <RenderBody />
            </main>
            <Footer />
         </UserHeaderProvider>
      </>
   );
}
