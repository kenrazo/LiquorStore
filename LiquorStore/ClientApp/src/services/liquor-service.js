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

  const addLiquor = (liquorName, liquorTypeId) => {
    return axios
      .post("/api/liquor", { liquorName, liquorTypeId })
      .then((res) => res)
      .catch((res) => res);
  };

  return { getPaginatedData, addLiquor };
};

export default LiquorService();
