import React, { Children, createContext, useState } from "react";

// Tạo context cho Header
const HeaderContext = createContext();
function UserHeaderProvider({ children }) {
   const [searchValue, setSearchValue] = useState("");
   // State để quản lý trạng thái thích (liked) của sách
   const [likedBookContext, setLikeBookContext] = useState(() => {
      const stored = localStorage.getItem("likedBooks");
      return stored ? JSON.parse(stored) : {};
   });
   // State để quản lý trạng thái thích (liked) của thiết bị
   const [likedDeviceContext, setLikeDeviceContext] = useState(() => {
      const stored = localStorage.getItem("likedDevices");
      return stored ? JSON.parse(stored) : {};
   });

   // Lấy loại vật dụng
   const [vatDungType, setVatDungType] = useState(null);

   // State để quản lý dữ liệu giỏ hàng
   const [vatDungCartContext, setVatDungCartContext] = useState(() => {
      const listed = localStorage.getItem("listedVatDungs");
      return listed ? JSON.parse(listed) : {};
   });

   console.log("vatDungCartContext: ", vatDungCartContext);
   

   // Thêm handlers để lưu các hàm như handleShowModalUpdateInfo
   const [handlers, setHandlers] = useState({});

   return (
      <HeaderContext.Provider
         value={{
            searchValue,
            setSearchValue,
            likedBookContext,
            setLikeBookContext,
            likedDeviceContext,
            setLikeDeviceContext,
            vatDungType,
            setVatDungType,
            vatDungCartContext,
            setVatDungCartContext,
            handlers,
            setHandlers,
         }}
      >
         {children}
      </HeaderContext.Provider>
   );
}

export { HeaderContext, UserHeaderProvider };
