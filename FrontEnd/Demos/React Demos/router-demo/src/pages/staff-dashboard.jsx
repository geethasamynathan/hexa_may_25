import { useAuth } from "../auth/AuthContext";

export default function StaffDashboard() {
  const { user } = useAuth();
  return (
    <>
      console.log(`user : ${user.username}`)
      <h2>Welcome to Staff Dashboard</h2>
      <p>Hello, {user?.username}</p>
    </>
  );
}
