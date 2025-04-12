import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import slideItem_1 from "@/assets/images/slideShow/item-1.png";
import slideItem_2 from "@/assets/images/slideShow/item-2.jpg";
import slideItem_3 from "@/assets/images/slideShow/item-3.jpg";
import sildeItem_1_md from "@/assets/images/slideShow/item-1-md.png";
import sildeItem_2_md from "@/assets/images/slideShow/item-2.jpg";
import sildeItem_3_md from "@/assets/images/slideShow/item-3.jpg";
import { Image } from "antd";

// Dữ liệu slide gốc
const slideData = [
   {
      desktop: slideItem_1,
      mobile: sildeItem_1_md,
   },
   {
      desktop: slideItem_2,
      mobile: sildeItem_2_md,
   },
   {
      desktop: slideItem_3,
      mobile: sildeItem_3_md,
   },
];

// Clone thêm slide đầu để tạo hiệu ứng vòng lặp
const slideDataClone = [...slideData, slideData[0]];

export default function SlideShow() {
   const [currentIndex, setCurrentIndex] = useState(0);
   const [isTransitioning, setIsTransitioning] = useState(true);

   // Tự động chuyển slide
   useEffect(() => {
      const interval = setInterval(() => {
         setCurrentIndex((prev) => prev + 1);
      }, 3000);

      return () => clearInterval(interval);
   }, []);

   // Reset về slide đầu nếu đang ở slide clone
   useEffect(() => {
      if (currentIndex === slideData.length) {
         const timeout = setTimeout(() => {
            setIsTransitioning(false);
            setCurrentIndex(0);
         }, 500);

         const enableTransition = setTimeout(() => {
            setIsTransitioning(true);
         }, 600);
      }
   }, [currentIndex]);

   return (
      <div className="home__container">
         <div className="slideshow">
            <div
               className="slideshow__inner"
               style={{
                  transform: `translateX(-${currentIndex * 100}%)`,
                  transition: isTransitioning
                     ? "transform 0.5s ease-in-out"
                     : "none",
               }}
            >
               {slideData.length > 0 && (
                  <Image.PreviewGroup
                     preview={{ loop: true }} // dùng để xem trước khi xong vòng lặp
                     items={slideData.map((item, index) => ({
                        src: item?.desktop || "",
                        alt: `Hình ảnh số ${index + 1}`,
                     }))}
                  >
                     {slideDataClone?.map((item, index) => (
                        <div className="slideshow__item" key={index}>
                           <NavLink>
                              <picture>
                                 <source
                                    media="(max-width: 767.98px)"
                                    srcSet={item.mobile}
                                 />
                                 <Image
                                    // Phải cấu hình width, height với class .ant-image, .ant-image-img có sẵn trong Image
                                    src={item.desktop}
                                    alt={`Slide ${index + 1}`}
                                    className="slideshow__img"
                                 />
                              </picture>
                           </NavLink>
                        </div>
                     ))}
                  </Image.PreviewGroup>
               )}
            </div>

            <div className="slideshow__page">
               <span className="slideshow__num">
                  {currentIndex === slideData.length ? 1 : currentIndex + 1}
               </span>
               <span className="slideshow__slider"></span>
               <span className="slideshow__num">{slideData.length}</span>
            </div>
         </div>
      </div>
   );
}
