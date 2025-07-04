import axios from "./axiosInstance";

export const getAllProducts = async () => {
  try {
    const response = await axios.get("/Products/all");
    return response.data;
  } catch (err) {
    console.error("Error Fetching Products", err);
    throw err;
  }
};
