import { NavLink } from 'react-router-dom';

function NotFound() {
  return (
    <div>
      <h1>404 - Page Not Found</h1>
      <p>The page you're looking for doesn't exist.</p>
      <NavLink to="/">Go back to home</NavLink>
    </div>
  );
}

export default NotFound;