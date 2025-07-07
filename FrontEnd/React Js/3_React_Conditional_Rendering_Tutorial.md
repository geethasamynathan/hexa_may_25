
# 🏢 Real-World React Example: Conditional Rendering

This React example demonstrates **conditional rendering** using:

- ✅ Simple data (boolean, string)
- ✅ Array of objects
- ✅ Nested objects
- ✅ Role-based view (Admin/User)
- ✅ Component-level conditions

---

## 📘 Scenario: Employee Dashboard

The app simulates a small employee dashboard. It conditionally renders different content based on:

- Logged-in status
- Employee type (admin/user)
- Department data
- Project assignment

---

## ✅ `App.js` – Full Code

```jsx
import React from "react";

function App() {
  const isLoggedIn = true; // Simple boolean flag
  const userRole = "admin"; // Role-based condition

  const employee = {
    name: "Gopi Suresh",
    age: 32,
    role: "admin",
    isActive: true,
    department: {
      name: "Engineering",
      location: "Chennai"
    },
    projects: [
      { id: 1, title: "React Migration", status: "Completed" },
      { id: 2, title: "New Dashboard", status: "In Progress" }
    ]
  };

  const showWelcome = () => {
    if (!isLoggedIn) return <p>Please log in to continue.</p>;

    return (
      <div>
        <h2>Welcome, {employee.name}!</h2>
        {employee.isActive ? (
          <p>Status: Active</p>
        ) : (
          <p>Status: Inactive</p>
        )}
      </div>
    );
  };

  return (
    <div style={{ padding: "20px", fontFamily: "Arial" }}>
      <h1>🏢 Employee Dashboard</h1>

      {/* ✅ Login Conditional */}
      {showWelcome()}

      {/* ✅ Role-based rendering */}
      {userRole === "admin" && (
        <div style={{ border: "1px solid green", padding: "10px", marginTop: "10px" }}>
          <h3>Admin Panel</h3>
          <p>You have admin privileges.</p>
        </div>
      )}

      {/* ✅ Department info (nested object) */}
      {employee.department ? (
        <div style={{ marginTop: "20px" }}>
          <h3>Department Info</h3>
          <p>
            {employee.department.name} Department - Located in {employee.department.location}
          </p>
        </div>
      ) : (
        <p>No department assigned.</p>
      )}

      {/* ✅ Project List (array of objects) */}
      <div style={{ marginTop: "20px" }}>
        <h3>Projects</h3>
        {employee.projects.length > 0 ? (
          <ul>
            {employee.projects.map((proj) => (
              <li key={proj.id}>
                {proj.title} -{" "}
                {proj.status === "Completed" ? (
                  <span style={{ color: "green" }}>✅ {proj.status}</span>
                ) : (
                  <span style={{ color: "orange" }}>⏳ {proj.status}</span>
                )}
              </li>
            ))}
          </ul>
        ) : (
          <p>No projects assigned.</p>
        )}
      </div>
    </div>
  );
}

export default App;
```

---

## ✅ Concepts Covered

| Type | Example |
|------|---------|
| **Simple data** | `isLoggedIn`, `userRole`, `employee.isActive` |
| **Array of objects** | `employee.projects.map(...)` |
| **Nested object** | `employee.department.name` |
| **Conditional rendering with ternary** | `condition ? A : B` |
| **Role-based view** | `userRole === 'admin' && <AdminPanel />` |

---

## 📘 Bonus: Expand to Component State

Simulate loading and error conditions like:

```jsx
const [loading, setLoading] = useState(true);
const [error, setError] = useState(null);
const [data, setData] = useState(null);

if (loading) return <p>Loading...</p>;
if (error) return <p>Error occurred: {error}</p>;
if (!data) return <p>No data available</p>;
```
