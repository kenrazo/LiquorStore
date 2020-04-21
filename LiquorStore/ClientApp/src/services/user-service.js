import axios from "axios";

const userService = () => {
  const authenticate = (username, password) => {
    return axios
      .post("/api/user/authenticate", {
        username,
        password,
      })
      .then((res) => res)
      .catch((res) => res);
  };

  return {
    authenticate,
  };
};

export default userService();
