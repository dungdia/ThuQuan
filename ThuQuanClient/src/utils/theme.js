// Hàm để bật/tắt chế độ dark mode
const toggleDarkMode = () => {
   const htmlElement = document.documentElement;
   const isDarkMode = htmlElement.classList.contains("dark");

   if (isDarkMode) {
      htmlElement.classList.remove("dark");
      localStorage.setItem("theme", "light");
   } else {
      htmlElement.classList.add("dark");
      localStorage.setItem("theme", "dark");
   }
};

// Hàm để kiểm tra và áp dụng chế độ dark mode khi tải trang
const applySavedTheme = () => {
   const savedTheme = localStorage.getItem("theme");
   if (savedTheme === "dark") {
      document.documentElement.classList.add("dark"); 
   } else {
      document.documentElement.classList.remove("dark"); 
   }
};

// Gọi hàm áp dụng chế độ dark mode khi tải trang
applySavedTheme();

export { toggleDarkMode };
