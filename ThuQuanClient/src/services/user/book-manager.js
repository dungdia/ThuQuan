import apiClient from "@/api/instance";

const getAllBooks = async (search, currentPage = 1, pageSize = 8) => {
   const response = await apiClient.get(
      `VatDung/books-paging?search=${search}&page=${currentPage}&pageSize=${pageSize}`
   );
   return response;
};

export { getAllBooks };
