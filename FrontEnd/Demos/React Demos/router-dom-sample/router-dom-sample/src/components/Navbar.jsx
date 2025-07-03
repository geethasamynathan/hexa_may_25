import { NavLink, useNavigate } from 'react-router-dom';
import { useAuth } from '../auth/AuthContext';
function Navbar(){

  const navigate=useNavigate();
const {user,logout}=useAuth();
const handleLogout=() =>{
  logout();
  navigate("/");
}
  return (
    <nav>
      <ul>
        <li><NavLink to="/">Home</NavLink></li>
        <li><NavLink to="/departments">Departments</NavLink></li>
        {user?(
          <>
          <li><NavLink to="/doctor-dashboard"> Doctor  Dashboard</NavLink></li>
          <li><button onClick={handleLogout}>Logout</button></li>
          </>
        ):(
        <li><NavLink to="/login">Login</NavLink></li>)
}
      </ul>
    </nav>
  );
}

export default Navbar;