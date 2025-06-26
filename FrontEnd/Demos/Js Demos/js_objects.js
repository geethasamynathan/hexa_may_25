// const person = {
//   name: "John",
//   age: 30,
//   greet: function () {
//     console.log("Hello, my name is " + this.name);
//   },
// };
// person["city"] = "New York"; // Adding a new property
// console.log("Person Name: ", person["name"]);
// console.log("Person Age: ", person.age);
// console.log("Person City: ", person.city);
// person.greet();

// person["department"] = "IT"; // Adding another property

const employees = [
  { id: 1, name: "Akkshara", position: "Developer", salary: 50000 },
  { id: 2, name: "Vivetha Harini", position: "Designer", salary: 60000 },
  { id: 3, name: "Hariharan", position: "Manager", salary: 70000 },
  { id: 4, name: "Alhan", position: "Tester", salary: 55000 },
  { id: 5, name: "Pari", position: "HR", salary: 45000 },
  { id: 6, name: "Gokul", position: "Developer", salary: 50000 },
  { id: 7, name: "Nithya", position: "Designer", salary: 60000 },
  { id: 8, name: "Sajina", position: "Manager", salary: 70000 },
  { id: 9, name: "Raghav", position: "Tester", salary: 55000 },
  { id: 10, name: "Santo", position: "HR", salary: 45000 },
];

// const hrEmployees = employees.filter((e) => e.position === "HR");
// console.log("HR Employees: ", hrEmployees);

// const hasAccounts = employees.some((e) => e.position === "Accounts");
// console.log("Has Accounts Employee: ", hasAccounts);

// //check all employee salary greater than 30k

// //calculate total salary of all employees

// //create a new array with employee names

// // list employees based salary in ascending order

// //group employees by position
// const groupedByPosition = employees.reduce((acc, employee) => {
//   if (!acc[employee.position]) {
//     acc[employee.position] = [];
//   }
//   acc[employee.position].push(employee);
//   return acc;
// }, {});
// console.log("Grouped by Position: ", groupedByPosition);

const updatedEmployees = employees.map((employee) => {
  return employee.id === 2
    ? { ...employee, salary: employee.salary + 5000 }
    : employee;
});

// const updatedEmployees1 = employees.map((employee) => {
//   return employee.id === 2
//     ? { ...employee, salary: employee.salary + 5000 }
//     : employee;
// });
console.log("\nUpdated Employees with Salary Increment for ID 2: \n ");
updatedEmployees.forEach((employee) => {
  console.log(
    `ID: ${employee.id}, Name: ${employee.name}, Position: ${employee.position}, Salary: ${employee.salary}`
  );
});

// employees.forEach((employee) => {
//   console.log(
//     `ID: ${employee.id}, Name: ${employee.name}, Position: ${employee.position}, Salary: ${employee.salary}`
//   );
// });
