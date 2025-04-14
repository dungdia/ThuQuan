import apiClient from "@/api/instance";

const getAllDevices = async (search, currentPage = 1, pageSize = 8) => {
   const response = await apiClient(
      `VatDung/devices-paging?search=${search}&page=${currentPage}&pageSize=${pageSize}`
   );
   return response;
};

export { getAllDevices };
