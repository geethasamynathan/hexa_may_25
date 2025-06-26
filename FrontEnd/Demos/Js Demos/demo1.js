// let x = 5;
// let y = 10;
// let z = x + y;
// console.log("x+ y= " + z);

// const name = "Hexaware";
// // name = 'Hexaware Technologies'; // This will cause an error because 'name' is a constant
// console.log("Company Name: ", name);

// age = 21;
// age >= 18 ? console.log("You are an adult.") : console.log("You are a minor.");

let fruits = ["Apple", "Banana", "Cherry"];
// for (let i = 0; i < fruits.length; i++) {
//   console.log("Fruit: " + fruits[i]);
// }

// for (let fruit of fruits) {
//   console.log("Fruit: " + fruit);
// }

// for (let fruit in fruits) {
//   console.log("Fruit: " + fruits[fruit]);
// }

// fruits.push("Mango");
// fruits.forEach(function (fruit) {
//   console.log("Fruit: " + fruit);
// });
// fruits.pop();

// console.log("After removing last fruit:\n ");

// fruits.forEach(function (fruit) {
//   console.log("Fruit: " + fruit);
// });

// add item at the beginning
fruits.unshift("Orange");
console.log("After adding Orange at the beginning:\n ");
fruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

// remove item from the beginning
fruits.shift();
console.log("After removing first fruit:\n ");
fruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

fruits.push("Mango");
fruits.push("Pineapple");
fruits.push("Grapes");
console.log("After adding Mango, Pineapple, and Grapes:\n ");
fruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

// fruits = fruits.splice(1, 3);
// console.log("After removing 3 fruits from index 2:\n ");
// fruits.forEach(function (fruit) {
//   console.log("Fruit: " + fruit);
// });

fruits.splice(1, 1, "Kiwi");
console.log("After replacing the second fruit with Kiwi:\n ");
fruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

// // Extracting a subarray from the fruits array
// subfruits = fruits.slice(1, 4);
// console.log("SubFruits from index 1 to 3:\n ");
// subfruits.forEach(function (fruit) {
//   console.log("Fruit: " + fruit);
// });

appleFruits = ["RedApple", "GreenApple", "WaterApple"];
let allfruits = fruits.concat(appleFruits);
console.log("After concatenating appleFruits:\n ");
allfruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

//indexOf
console.log("Index of 'Pineapple': " + allfruits.indexOf("Pineapple"));

//includes()
console.log("Does the array include 'Mango'? " + allfruits.includes("Mango"));

//join()
console.log("Joined fruits: " + allfruits.join(", "));

//reverse()
allfruits.reverse();
console.log("Reversed fruits: ");
allfruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

//sort()
allfruits.sort();
console.log("\nSorted fruits: \n");
allfruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});

//map()
let fruitLengths = allfruits.map(function (fruit) {
  return fruit.length;
});
console.log("Fruit lengths: " + fruitLengths.join(", "));

let prices = [2000, 4500, 7000, 7800];
let discountedPrices = prices.map(function (price) {
  return price * 0.9; // Applying a 10% discount
});
console.log("Discounted Prices: " + discountedPrices.join(", "));

//filter
let ExpensiveProducts = prices.filter((p) => p > 5000);
console.log("Expensive Products prices are: " + ExpensiveProducts.join(", "));

//find()
let firstExpensiveProduct = prices.find((p) => p > 5000);
console.log("First expensive product price is: " + firstExpensiveProduct);

//findIndex()
let firstExpensiveProductIndex = prices.findIndex((p) => p > 5000);
console.log("Index of first expensive product: " + firstExpensiveProductIndex);

//reduce()
let totalPrice = prices.reduce(
  (accumulator, currentValue) => accumulator + currentValue,
  0
);
console.log("Total price of all products: " + totalPrice);

//Every() all match
console.log(
  "All price are greater than 5000: " + prices.every((p) => p > 5000)
);

//atleast one match some()
console.log(
  "Atleast one price is greater than 7000: " + prices.some((p) => p > 7000)
);

//forEach()
prices.forEach((p) => {
  console.log(`Price  is: ${p} Rupees`);
});
