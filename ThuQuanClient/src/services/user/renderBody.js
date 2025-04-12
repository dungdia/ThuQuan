import apiClient from "@/api/instance";

const getVatDung = async (loaiVatDung) => {
   const response = await apiClient(
      `VatDung/three-books?loaiVatDung=${loaiVatDung}`
   );
   return response;
};

export { getVatDung };
