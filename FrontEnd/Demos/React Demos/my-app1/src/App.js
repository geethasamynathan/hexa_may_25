import logo from "./logo.svg";
import "./App.css";
import Home from "./component/Home";
import ConditionalRendering from "./component/conditionalrendering";
import TaskCard from "./component/taskcard";
import EventHandling from "./component/EventHandling";

function App() {
  let name = "Geetha";
  let age = 39;
  let isStudent = false;
  let studentNames = ["Tina", "santo", "Nithya", "Pari", "Alhan", "Gokul"];
  let studentInfo = {
    id: 1,
    name: "Fransy",
    age: 23,
    City: "Paris",
    Department: "Medical",
  };
  const tasks = [
    {
      title: "Todo Task",
      description: "Update the status",
      status: "In Progress",
    },
    {
      title: "FrontEnd Development",
      description: "Update the status",
      status: "Pending",
    },
    {
      title: "BackEnd DEvelopment",
      description: "Update the status",
      status: "Completed",
    },
  ];
  return (
    <div>
      <EventHandling />
      {/* {tasks.map((task, index) => (
        <TaskCard key={index} task={task}></TaskCard>
      ))} */}

      {/* <div className="App">
    <header className="App-header">

       <Home />
        <ConditionalRendering /> */}
      {/* <h1>Welcome to React Session</h1>
        <h2>
          My name is {name} and I am {age} years old.
        </h2>
        <p>
          {name} -{isStudent ? "is a student." : "is a trainer."}
        </p>
        <h3>Student Names:</h3>
        <ul>
          {studentNames.map((student) => (
            <li key={student}>{student}</li>
          ))}
        </ul>

        <h3> medical Student Info</h3>
        {studentInfo && (
          <div>
            <p>ID: {studentInfo.id}</p>
            <p>Name: {studentInfo.name}</p>
            <p>Age: {studentInfo.age}</p>
            <p>City: {studentInfo.City}</p>
            <p>Department: {studentInfo.Department}</p>
          </div>
        )} */}
      {/* <img src={logo} className="App-logo" alt="logo" /> */}
      {/* <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a> */}
      {/* </header> */}
    </div>
  );
}

export default App;
