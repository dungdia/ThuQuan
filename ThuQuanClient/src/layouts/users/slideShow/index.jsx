import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import slideItem_1 from "@/assets/images/slideShow/item-1.png";
import slideItem_2 from "@/assets/images/slideShow/item-2.jpg";
import slideItem_3 from "@/assets/images/slideShow/item-3.jpg";
import sildeItem_1_md from "@/assets/images/slideShow/item-1-md.png";
import sildeItem_2_md from "@/assets/images/slideShow/item-2.jpg";
import sildeItem_3_md from "@/assets/images/slideShow/item-3.jpg";

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

// Thêm bản sao của slide đầu vào cuối mảng
const slideDataClone = [...slideData, slideData[0]];

export default function SlideShow() {
   const [currentIndex, setCurrentIndex] = useState(0);
   const [isTransitioning, setIsTransitioning] = useState(true);

   // cập nhật vị trí hiện tại của slide
   useEffect(() => {
      const interval = setInterval(() => {
         setCurrentIndex((prev) => prev + 1);
      }, 3000);

      return () => clearInterval(interval);
   }, []);

   useEffect(() => {
      if (currentIndex === slideData.length) {
         // Đã đến slide clone, đợi animation kết thúc rồi reset về slide đầu
         setTimeout(() => {
            setIsTransitioning(false);
            setCurrentIndex(0);
         }, 500);

         // Bật lại transition sau khi reset
         setTimeout(() => {
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
               {slideDataClone.map((item, index) => (
                  <div className="slideshow__item" key={index}>
                     <NavLink>
                        <picture>
                           <source
                              media="(max-width: 767.98px)"
                              srcSet={item.mobile}
                           />
                           <img
                              src={item.desktop}
                              alt={`Slide ${index + 1}`}
                              className="slideshow__img"
                           />
                        </picture>
                     </NavLink>
                  </div>
               ))}
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
