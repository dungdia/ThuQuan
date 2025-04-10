import React, { Children, createContext, useState } from "react";

// Tạo context cho Header
const HeaderContext = createContext();
function UserHeaderProvider({ children }) {
   const [searchValue, setSearchValue] = useState("");
   // State để quản lý trạng thái thích (liked) của sách
   const [likedBooksContext, setLikedBooksContext] = useState(() => {
      const stored = localStorage.getItem("likedBooks");
      return stored ? JSON.parse(stored) : {};
   });

   return (
      <HeaderContext.Provider
         value={{
            searchValue,
            setSearchValue,
            likedBooksContext,
            setLikedBooksContext,
         }}
      >
         {children}
      </HeaderContext.Provider>
   );
}

export { HeaderContext, UserHeaderProvider };
