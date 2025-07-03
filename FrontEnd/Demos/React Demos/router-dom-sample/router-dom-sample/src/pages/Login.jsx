import { useState } from "react";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

function Login() {
  const navigate = useNavigate();
  const { login } = useAuth();
  const [formdata, setFormData] = useState({
    username: "",
    password: "",
  });
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    const result = login(formdata);
    if (!result.ok) {
      setError(result.message);
      return;
    }

    const routesByRole = {
      doctor: "/doctor-dashboard",
      user: "/dashboard",
    };

    navigate(routesByRole[result.role], { replace: true });
  };

  const handleChange = (e) => {
    setFormData({
      ...formdata,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <div className="container">
      <h2>Login form</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label className="form-label">Username:</label>
          <input
            type="text"
            id="username"
            name="username"
            onChange={handleChange}
            required
            className="form-control"
            value={formdata.username}
          />
        </div>
        <div className="form-group">
          <label className="form-label">Password:</label>
          <input
            type="text"
            id="password"
            name="password"
            onChange={handleChange}
            required
            className="form-control"
            value={formdata.password}
          />
        </div>
        <button className="btn btn-primary" type="submit">
          Login
        </button>
      </form>
    </div>
  );
}

export default Login;
