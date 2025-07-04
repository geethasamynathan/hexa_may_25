import { useAuth } from "./AuthContext";
import { Navigate } from "react-router-dom";
export default function PrivateRoute({ children }) {
  const { auth } = useAuth();
  if (!auth.isLoggedIn) {
    return <Navigate to="/login" />;
  }
  return children;
}
