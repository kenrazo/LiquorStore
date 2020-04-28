import axios from "axios";

const LiquorService = () => {
  const getPaginatedData = async (
    pageSize,
    pageNumber,
    searchKeyword,
    sortColumn,
    sortOrder
  ) => {
    const params = {
      pageSize,
      pageNumber,
      searchKeyword,
      sortColumn,
      sortOrder,
    };
    const res = await axios.get("/api/liquor", { params });
    const returnObject = {
      data: res.data,
      paginationInfo: JSON.parse(res.headers.pagination),
    };
    return returnObject;
  };

  return { getPaginatedData };
};

export default LiquorService();
