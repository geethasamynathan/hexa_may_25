import { useParams } from 'react-router-dom';
import { useState } from 'react';

const doctorData = {
  101: { name: 'Dr. Smith', department: 'Cardiology' },
  102: { name: 'Dr. Johnson', department: 'Cardiology' },
  201: { name: 'Dr. Williams', department: 'Neurology' },
  202: { name: 'Dr. Brown', department: 'Neurology' },
  301: { name: 'Dr. Davis', department: 'Orthopedics' },
  401: { name: 'Dr. Miller', department: 'Pediatrics' },
  402: { name: 'Dr. Wilson', department: 'Pediatrics' },
};

function BookAppointment() {
  const { doctorId } = useParams();
  const doctor = doctorData[doctorId];
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    date: '',
    time: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Appointment booked with ${doctor.name} on ${formData.date} at ${formData.time}`);
 
  };

  if (!doctor) {
    return <div>Doctor not found</div>;
  }

  return (
    <div>
      <h2>Book Appointment with {doctor.name}</h2>
      <p>Department: {doctor.department}</p>
      
      <form onSubmit={handleSubmit}>
        <div>
          <label>Your Name:</label>
          <input 
            type="text" 
            name="name" 
            value={formData.name} 
            onChange={handleChange} 
            required 
          />
        </div>
        <div>
          <label>Email:</label>
          <input 
            type="email" 
            name="email" 
            value={formData.email} 
            onChange={handleChange} 
            required 
          />
        </div>
        <div>
          <label>Date:</label>
          <input 
            type="date" 
            name="date" 
            value={formData.date} 
            onChange={handleChange} 
            required 
          />
        </div>
        <div>
          <label>Time:</label>
          <input 
            type="time" 
            name="time" 
            value={formData.time} 
            onChange={handleChange} 
            required 
          />
        </div>
        <button type="submit">Book Appointment</button>
      </form>
    </div>
  );
}

export default BookAppointment;