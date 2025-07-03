import { useParams, NavLink } from 'react-router-dom';

const departmentDoctors = {
  1: [
    { id: 101, name: 'Dr. Smith', specialty: 'Cardiologist' },
    { id: 102, name: 'Dr. Johnson', specialty: 'Cardiac Surgeon' },
  ],
  2: [
    { id: 201, name: 'Dr. Williams', specialty: 'Neurologist' },
    { id: 202, name: 'Dr. Brown', specialty: 'Neurosurgeon' },
  ],
  3: [
    { id: 301, name: 'Dr. Davis', specialty: 'Orthopedic Surgeon' },
  ],
  4: [
    { id: 401, name: 'Dr. Miller', specialty: 'Pediatrician' },
    { id: 402, name: 'Dr. Wilson', specialty: 'Pediatric Cardiologist' },
  ],
};

function Doctors() {
  const { departmentId } = useParams();
  const doctors = departmentDoctors[departmentId] || [];

  return (
    <div>
      <h2>Doctors in this Department</h2>
      <ul>
        {doctors.map(doctor => (
          <li key={doctor.id}>
            <div>
              <h3>{doctor.name}</h3>
              <p>{doctor.specialty}</p>
              <NavLink to={`/book-appointment/${doctor.id}`}>Book Appointment</NavLink>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Doctors;