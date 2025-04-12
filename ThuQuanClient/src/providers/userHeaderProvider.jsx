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
         }}
      >
         {children}
      </HeaderContext.Provider>
   );
}

export { HeaderContext, UserHeaderProvider };
