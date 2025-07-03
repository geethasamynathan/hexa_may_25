Create a new folder with the name of services.
Within the service create a new file with the name of employeeservice.js 

employeeService.js
```jsx
let _employees = [
  { id: 1, name: "Hariharan", department: "Engineering", salary: 45000 },
  { id: 2, name: "Keerthiswaran", department: "HR", salary: 42000 },
  { id: 3, name: "Lokesh", department: "Finance", salary: 48000 },
  { id: 4, name: "Santo", department: "Engineering", salary: 44000 },
];

export const employeeService = {
  getAll() {
    return _employees;
  },

  add(emp) {
    const newEmp = { ...emp, id: _employees.length + 1 };
    _employees.push(newEmp);
    return newEmp;
  },

  remove(id) {
    const _initialLength = _employees.length;
    _employees = _employees.filter((e) => e.id == id);
    return _employees.length !== _initialLength;
  },
};

```

## Create a new folder with the name of components within the
components folder  
Create a new file with the name of 

EmployeeDashboard.jsx
## Departmentfilter.Jsx
```jsx
export default function DepartmentFilter({ departments, value, onChange }) {
  return (
    <div className="mb-3">
      <label className="form-label">Filter by Department</label>
      <select
        className="form-select"
        value={value}
        onChange={(e) => onChange(e.target.value)}
      >
        {departments.map((dept, idx) => (
          <option key={idx} value={dept}>
            {dept}
          </option>
        ))}
      </select>
    </div>
  );
}

```
## EmployeeRow.jsx
```jsx
export default function EmployeeRow({ emp, onDelete }) {
  return (
    <tr>
      <td>{emp.id}</td>
      <td>{emp.name}</td>
      <td>{emp.department}</td>
      <td>{emp.salary}</td>
      <td>
        <button onClick={() => onDelete(emp.id)} className="btn btn-danger">
          Delete
        </button>
      </td>
    </tr>
  );
}

```

## EmployeeTable.jsx
```jsx
import EmployeeRow from "./EmployeeRow";

export default function EmployeeTable({ employees, onDelete }) {
  return (
    <table className="table table-striped">
      <thead className="table-dark">
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Department</th>
          <th>Salary</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {employees.length ? (
          employees.map((emp) => (
            <EmployeeRow key={emp.id} emp={emp} onDelete={onDelete} />
          ))
        ) : (
          <tr>
            <td colSpan="5" className=" text-center text-muted">
              No Employees Found
            </td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

```

# EmployeeForm.jsx
```jsx
export default function EmployeeRow({ emp, onDelete }) {
  return (
    <tr>
      <td>{emp.id}</td>
      <td>{emp.name}</td>
      <td>{emp.department}</td>
      <td>{emp.salary}</td>
      <td>
        <button onClick={() => onDelete(emp.id)} className="btn btn-danger">
          Delete
        </button>
      </td>
    </tr>
  );
}

```

# EmployeeDashboard.jsx
```jsx
import { useMemo, useState, useEffect } from "react";
import { employeeService } from "../services/employeeService";
import DepartmentFilter from "./DepartmentFilter";
import EmployeeTable from "./EmployeeTable";
import EmployeeForm from "./Employeeform";
import { wait } from "@testing-library/user-event/dist/utils";

export default function EmployeeDashboard() {
  const [employees, setEmployees] = useState([]);
  const [filterDept, setFilterDept] = useState("All");
  const [error, setError] = useState("");

  useEffect(() => {
    employeeService
      .getAll()
      .then(setEmployees)
      .catch(() => setError("Unable to load the Employees"));
  }, []);

  // useMemo
  const departments = useMemo(
    () => ["All", ...new Set(employees.map((e) => e.department))],
    [employees]
  );

  const filtered = useMemo(
    () =>
      filterDept === "All"
        ? employees
        : employees.filter((e) => e.department === filterDept),
    [employees, filterDept]
  );

  const totalSalary = useMemo(
    () => filtered.reduce((sum, emp) => sum + emp.salary, 0),
    [filtered]
  );

  const handleAdd = async (emp) => {
    try {
      const added = await employeeService.add(emp);
      setEmployees((prev) => [...prev, added]);
    } catch {
      setError("Failed to add new Employee");
    }
  };

  const handleDelete = async (id) => {
    try {
      await employeeService.remove(id);
      setEmployees((prev) => prev.filter((e) => e.id !== id));
    } catch {
      setError("Unable to Delete ");
    }
  };
  console.log(`filterDept ${filterDept} `);
  return (
    <div className="container py-4">
      <h2 className="mb-3">Employee Dashboard</h2>

      {error && <div className="alert alert-danger">{error}</div>}
      <DepartmentFilter
        departments={departments}
        value={filterDept}
        onChange={setFilterDept}
      />

      <EmployeeTable employees={filtered} onDelete={handleDelete} />

      <p className="fw-bold">Total Salary : {totalSalary}</p>

      <EmployeeForm onAdd={handleAdd} />
    </div>
  );
}

```