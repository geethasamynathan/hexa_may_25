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
export const addProduct = async (product) => {
  const res = await axios.post("/products/create", product);
  return res.data;
};

export const updateProduct = async (id, product) => {
  const res = await axios.put(`/products/update/${id}`, product);
  return res.data;
};
