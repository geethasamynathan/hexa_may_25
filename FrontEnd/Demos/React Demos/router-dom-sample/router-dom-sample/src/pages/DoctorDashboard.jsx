
import { useAuth } from "../auth/AuthContext";
export default function DoctorDashboard({ name }) {
  const { user } = useAuth();
  return (
    <>
      <h2> Welcome To {user?.username} Dashboard</h2>
    </>
  );
}
