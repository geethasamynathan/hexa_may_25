import React from "react";
import "./taskcard.css";
export default function TaskCard({ task }) {
  const cardStyle = {
    border: "1px solid blue",
    borderRadius: "5px",
    padding: "15px",
    marginBottom: "10px",
    boxshadow: "0 2px 5px rgba(0,0,0,0.2)",
  };

  const statusColor = {
    Pending: "#FFFF00",
    "In Progress": "#0000FF",
    Completed: "#008000",
  };
  //   const taskContainer = {
  //     width: "400px",
  //   };

  //   const taskCard = {
  //     transition: "0.3s ease-in-out",
  //   };
  //Dynamically assign the class
  const statusClass = task.status.toLowerCase().replace(" ", "-");
  return (
    <div className="taskContainer">
      <div className={`taskCard ${statusClass}`} style={cardStyle}>
        <h3>{task.title}</h3>
        <p>{task.description}</p>
        <p
          style={{
            color: statusColor[task.status],
            fontWeight: "bold",
            color: "white",
          }}
        >
          Status : {task.status}
        </p>
      </div>
    </div>
  );
}
