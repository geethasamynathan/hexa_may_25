export default function DepartmentFilter({ departments, value, onChange }) {
  console.log(`Departments in Filter ${departments} value ={value} `);

  return (
    <div className="mb-3">
      <label className="form-label">Filter by Department</label>
      <select
        className="form-select"
        value={value}
        onChange={(e) => onChange(e.target.value)}
      >
        {departments.map((d) => (
          <option key={d} value={d}>
            {d}
          </option>
        ))}
      </select>
    </div>
  );
}
