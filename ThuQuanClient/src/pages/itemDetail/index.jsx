import Footer from "@/layouts/users/footer";
import HeaderUser from "@/layouts/users/header";
import bookImg from "@/assets/images/book/book_img_1.jpg";
import React from "react";

export default function ItemDetail() {
    return <>
        <HeaderUser/>
        <div className="container item__container">
            <div className="item">
                <div className="item__img">
                    <img src={bookImg} alt="" srcset="" />
                </div>
                <div className="item__info">
                    <div className="item__info__name">PHÁP LUẬT VỀ ĐẢM BẢO THỰC HIỆN NGHĨA VỤ (2025)</div>
                    <div className="item__info__description">
                        <span>
                        Mã học liệu: C67B (2025) <br />
                        Tác giả: Nguyễn Ngọc Điện (chủ biên) <br />
                        Tác quyền: Trường Đại học Mở TP.HCM <br />
                        Nhà xuất bản: Đại học Quốc gia TPHCM <br />
                        Năm xuất bản: 2025 <br />
                        Số trang: 266 <br />
                        Định dạng: Sách <br />
                        Tái bản: <br />
                        Tên môn học: <br />
                        Đặc điểm: Giáo trình <br />
                        Năm XB đầu tiên: 2023 <br />
                        Năm XB mới nhất: 2025 <br />
                        </span>
                    </div>
                    <div className="item__info__button">
                        <button className="item__info__button__booking">Đặt ngay</button>
                    </div>
                </div>
            </div>
        </div>
        <Footer/>
    </>
}