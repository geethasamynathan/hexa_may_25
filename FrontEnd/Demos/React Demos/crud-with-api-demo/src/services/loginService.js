import axiosins from "./axiosInstance";

export const login = async (username, password) => {
  try {
    const response = await axiosins.post("/Auth/login", {
      username,
      password,
    });
    const { token } = response.data;

    localStorage.setItem("token", token);
    localStorage.setItem("username", username);

    return response.data;
  } catch (err) {
    throw new Error(error.response?.data?.message || "Login Failed");
  }
};

export const logout = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("username");
};

export const isAuthenticated = () => {
  return !!localStorage.getItem("token");
};
