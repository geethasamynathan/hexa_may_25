import { useAuth } from "../auth/AuthContext";
function Dashboard() {
	const { user } = useAuth();

	const appointments = [
	  { id: 1, doctor: 'Dr. Smith', date: '2023-06-15', time: '10:00' },
	  { id: 2, doctor: 'Dr. Johnson', date: '2023-06-20', time: '14:30' },
	];
  
	return (
	  <div>
		<h1>{user?.username} Dashboard </h1>
		<h2>Upcoming Appointments</h2>
		{appointments.length === 0 ? (
		  <p>No upcoming appointments</p>
		) : (
		  <ul>
			{appointments.map(app => (
			  <li key={app.id}>
				<p>Doctor: {app.doctor}</p>
				<p>Date: {app.date} at {app.time}</p>
			  </li>
			))}
		  </ul>
		)}
	  </div>
	);
  }
  
  export default Dashboard;