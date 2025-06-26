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

fruits.forEach(function (fruit) {
  console.log("Fruit: " + fruit);
});
