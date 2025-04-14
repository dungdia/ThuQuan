// Bật/tắt dark mode
const toggleDarkMode = () => {
   const html = document.documentElement;
   const isDarkMode = html.classList.contains("dark");

   if (isDarkMode) {
      html.classList.remove("dark");
      localStorage.setItem("theme", "light");
   } else {
      html.classList.add("dark");
      localStorage.setItem("theme", "dark");
   }
};

// Áp dụng theme lưu từ localStorage
const applySavedTheme = () => {
   const savedTheme = localStorage.getItem("theme");
   const html = document.documentElement;

   if (savedTheme === "dark") {
      html.classList.add("dark");
   } else {
      html.classList.remove("dark");
   }
};

export { toggleDarkMode, applySavedTheme };
