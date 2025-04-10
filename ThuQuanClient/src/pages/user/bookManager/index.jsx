import React, { useContext, useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import heartIcon from "@/assets/icons/heart.svg";
import heartRedIcon from "@/assets/icons/heart-red.svg";
import starIcon from "@/assets/icons/star.svg";
import bookItem_1 from "@/assets/images/book/item-1.png";
import bookItem_2 from "@/assets/images/book/item-2.png";
import bookItem_3 from "@/assets/images/book/item-3.png";
import bookItem_4 from "@/assets/images/book/item-4.png";
import { getAllBooks } from "@/services/user/book-manager";
import { HeaderContext } from "@/providers/userHeaderProvider";
import { useDebounce } from "@/hook/useDebounce";
import { message, Pagination, Spin } from "antd";

export default function BookManager() {
   const navigate = useNavigate();
   const [books, setBooks] = useState([]);
   const [loading, setLoading] = useState(false);
   const [pageSize, setPageSize] = useState(8);
   const [currentPage, setCurrentPage] = useState(1);
   const [totalElements, setTotalElements] = useState(0);

   // State để quản lý trạng thái thích (liked) của sách
   const [likedBooks, setLikedBooks] = useState(() => {
      const stored = localStorage.getItem("likedBooks");
      return stored ? JSON.parse(stored) : {};
   });

   // Lấy giá trị từ HeaderContext -> HeaderUser
   const {
      searchValue,
      setSearchValue,
      likedBooksContext,
      setLikedBooksContext,
   } = useContext(HeaderContext);

   if (
      searchValue === undefined ||
      setSearchValue === undefined ||
      likedBooksContext === undefined ||
      setLikedBooksContext === undefined
   ) {
      console.log("Context values are missing!");
   }
   // Mong muốn khi sử dụng custome hook useDebounce (delay khi search)
   const debounceSearch = useDebounce(searchValue, 800);

   const fetchBooks = async () => {
      try {
         setLoading(true);
         const response = await getAllBooks(
            debounceSearch,
            currentPage,
            pageSize
         );

         // Render tất cả sản phẩm
         setBooks(response.data.items);

         // Lấy ra tổng số bảng ghi
         setTotalElements(response.data.totalItems);
      } catch (error) {
         message.error("Lỗi không tải được dữ liệu sách!");
      } finally {
         setLoading(false);
      }
   };

   // Chỉ chạy khi một trong các giá trị thay đổi
   useEffect(() => {
      fetchBooks();
   }, [debounceSearch, currentPage, pageSize]);

   // Lấy chạy khi vào trang user
   useEffect(() => {
      fetchBooks();
   }, []);

   // Hàm lấy dữ liệu từ các sách
   const handleGetDataBook = (book) => {
      // Lấy dữ liệu book rồi qua trang itemDetail
      navigate("/itemDetail", { state: { book } });
   };

   // Hàm chuyển trang
   const handleChangePage = (currentPage, pageSize) => {
      // Cập nhật lại trang hiện tại
      setCurrentPage(currentPage);
      // Cập nhật lại số lượng sản phẩm trên 1 trang
      setPageSize(pageSize);
   };

   // Hàm lấy ngẫu nhiên rating
   const getRandomRating = () => {
      return (Math.random() * 2 + 3).toFixed(1); // từ 3.0 đến 5.0
   };

   const toggleLike = (book) => {
      const newLikedBooks = { ...likedBooks };
      // Kiểm tra xem sách đã được thích hay chưa
      // Nếu đã thích thì bỏ thích, ngược lại thì thêm vào danh sách thích
      if (newLikedBooks[book.id]) {
         delete newLikedBooks[book.id];
      } else {
         newLikedBooks[book.id] = book;
      }
      setLikedBooks(newLikedBooks);
      setLikedBooksContext(newLikedBooks); // Cập nhật likedBooksContext trong HeaderContext
      localStorage.setItem("likedBooks", JSON.stringify(newLikedBooks));
   };

   return (
      <>
         <Spin spinning={loading}>
            <div className="row row-cols-4 row-cols-lg-2 row-cols-sm-1 g-3">
               {/* Book card 1 */}
               {books?.map((book) => (
                  <div key={book.id} className="col">
                     <article className="book-card">
                        <div className="book-card__img-wrap">
                           <Link
                              to="#"
                              onClick={(e) => {
                                 e.preventDefault();
                                 handleGetDataBook(book);
                              }}
                           >
                              <img
                                 src={book.hinhAnh}
                                 alt=""
                                 className="book-card__thumb"
                              />
                           </Link>
                           <button
                              className={`like-btn book-card__like-btn ${
                                 likedBooks[book.id] ? "like-btn--liked" : ""
                              }`}
                              onClick={() => toggleLike(book)}
                           >
                              <img
                                 src={heartIcon}
                                 alt=""
                                 className="like-btn__icon icon"
                              />
                              <img
                                 src={heartRedIcon}
                                 alt=""
                                 className="like-btn__icon--liked"
                              />
                           </button>
                        </div>
                        <h3 className="book-card__title">
                           <Link
                              to="#"
                              onClick={(e) => {
                                 e.preventDefault();
                                 handleGetDataBook(book);
                              }}
                           >
                              {book.tenVatDung}
                           </Link>
                        </h3>
                        <p
                           onClick={(e) => {
                              e.preventDefault();
                              handleGetDataBook(book);
                           }}
                           className="book-card__author"
                        >
                           {book.moTa}
                        </p>
                        <div
                           onClick={(e) => {
                              e.preventDefault();
                              handleGetDataBook(book);
                           }}
                           className="book-card__row"
                        >
                           <span
                              className={`book-card__price ${
                                 book.tinhTrang === "Chưa mượn"
                                    ? "book-card__price--available"
                                    : book.tinhTrang === "Đang mượn"
                                    ? "book-card__price--borrowed"
                                    : "book-card__price--broken"
                              }`}
                           >
                              {book.tinhTrang}
                           </span>
                           <img
                              src={starIcon}
                              alt=""
                              className="book-card__star"
                           />
                           <span className="book-card__score">
                              {book.tinhTrang === "Bị hỏng"
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
                  <div className="book-card__pagenation-books">
                     <Pagination
                        className="book-card__pagination"
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
