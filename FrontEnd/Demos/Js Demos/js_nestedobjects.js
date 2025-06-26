const products = [
  {
    id: 101,
    name: "Wireless Mouse",
    category: "Electronics",
    price: 799,
    stock: 15,
    rating: 4.5,
    tags: ["computer", "accessory"],
    seller: { name: "TechWorld", location: "Bangalore" },
  },
  {
    id: 102,
    name: "Bluetooth Headphones",
    category: "Electronics",
    price: 1999,
    stock: 0,
    rating: 4.2,
    tags: ["audio", "bluetooth"],
    seller: { name: "SoundMax", location: "Mumbai" },
  },
  {
    id: 103,
    name: "Yoga Mat",
    category: "Fitness",
    price: 499,
    stock: 25,
    rating: 4.8,
    tags: ["exercise", "health"],
    seller: { name: "FitStore", location: "Chennai" },
  },
  {
    id: 104,
    name: "Running Shoes",
    category: "Footwear",
    price: 2999,
    stock: 8,
    rating: 4.0,
    tags: ["fitness", "outdoor"],
    seller: { name: "FitStore", location: "Chennai" },
  },
  {
    id: 105,
    name: "LED Monitor",
    category: "Electronics",
    price: 8999,
    stock: 4,
    rating: 4.7,
    tags: ["display", "computer"],
    seller: { name: "ScreenPro", location: "Delhi" },
  },
];

//get the products with stock greater than 0

const inStockProducts = products.filter((product) => product.stock > 0);

console.log("Products in Stock:");
inStockProducts.forEach((product) => {
  console.log(
    `ID: ${product.id}, Name: ${product.name}, Stock:${product.stock}, Price: ₹${product.price}`
  );
});

const topRatedProducts = products.reduce((max, p) =>
  p.rating > max.rating ? p : max
);
console.log("\nTop Rated Product:");
console.log(`ID: ${topRatedProducts.id}, Name: ${topRatedProducts.name}, 
    Rating: ${topRatedProducts.rating}`);
