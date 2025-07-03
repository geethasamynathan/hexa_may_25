import { NavLink } from 'react-router-dom';

const departments = [
  { id: 1, name: 'Cardiology' },
  { id: 2, name: 'Neurology' },
  { id: 3, name: 'Orthopedics' },
  { id: 4, name: 'Pediatrics' },
];

function Departments() {
  return (
    <div>
      <h1>Our Departments</h1>
      <ul>
        {departments.map(dept => (
          <li key={dept.id}>
            <NavLink to={`/departments/${dept.id}/doctors`}>{dept.name}</NavLink>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Departments;