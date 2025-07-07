
# 🎨 Real-World Styling in React Component

This example demonstrates how to apply styles in various ways inside a React component:

- ✅ Inline styles
- ✅ Conditional styles
- ✅ External CSS file
- ✅ Dynamic class names
- ✅ CSS transitions

---

## 🌐 Scenario: Task Status Card

A task card that:
- Changes color based on status (`Pending`, `In Progress`, `Completed`)
- Applies dynamic and conditional styles
- Uses a combination of inline styles and CSS classes

---

## ✅ `TaskCard.js`

```jsx
import React from 'react';
import './TaskCard.css'; // External CSS file

function TaskCard({ task }) {
  // ✅ 1. Inline style object
  const cardStyle = {
    border: "1px solid #ddd",
    borderRadius: "8px",
    padding: "15px",
    marginBottom: "10px",
    boxShadow: "0 2px 5px rgba(0,0,0,0.1)",
  };

  // ✅ 2. Conditional styling logic
  const statusColor = {
    Pending: "#ffc107",        // yellow
    "In Progress": "#17a2b8",  // blue
    Completed: "#28a745",      // green
  };

  // ✅ 3. Dynamic class assignment
  const statusClass = task.status.toLowerCase().replace(" ", "-");

  return (
    <div className="task-container">
      <div className={`task-card ${statusClass}`} style={cardStyle}>
        <h3>{task.title}</h3>
        <p>{task.description}</p>

        {/* Inline style + conditional background */}
        <p style={{ color: statusColor[task.status], fontWeight: "bold" }}>
          Status: {task.status}
        </p>
      </div>
    </div>
  );
}

export default TaskCard;
```

---

## ✅ `TaskCard.css`

```css
.task-container {
  max-width: 400px;
  margin: auto;
}

.task-card {
  transition: 0.3s ease-in-out;
}

.task-card:hover {
  transform: scale(1.03);
}

/* ✅ Conditional class styling */
.pending {
  background-color: #fffbe6;
}

.in-progress {
  background-color: #e6f7ff;
}

.completed {
  background-color: #e6ffed;
}
```

---

## ✅ `App.js`

```jsx
import React from 'react';
import TaskCard from './TaskCard';

function App() {
  const task = {
    title: "Finalize Report",
    description: "Complete the quarterly performance report and share with team.",
    status: "In Progress" // Try: Pending, Completed
  };
 const task1 = {
    title: "Todo Task",
    description: "Update the status",
    status: "In Progress",
  };
  const task2 = {
    title: "FrontEnd Development",
    description: "Update the status",
    status: "Pending",
  };
  const task3 = {
    title: "BackEnd DEvelopment",
    description: "Update the status",
    status: "Completed",
  };
  return (
    <div>
      <TaskCard task={task1} />
      <TaskCard task={task2} />
      <TaskCard task={task3} />
     </div>
  );
}

export default App;
```

---

## ✅ Concepts Covered

| Feature             | Method                                 |
|---------------------|----------------------------------------|
| Inline styling       | `style={cardStyle}`                   |
| Conditional styles   | Using a JS object and dynamic mapping |
| Dynamic class names  | Template strings like `className={...}` |
| CSS file styling     | `import './TaskCard.css'`             |
| CSS transitions      | `:hover` effects in external CSS      |

---

## 📁 Folder Structure

```
src/
│
├── App.js
├── TaskCard.js
├── TaskCard.css
```

Now let us change the above code without Repeating the <taskCard/> 3 times

