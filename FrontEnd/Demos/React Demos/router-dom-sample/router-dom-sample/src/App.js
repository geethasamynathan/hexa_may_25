import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Outlet } from "react-router-dom";
// import Layout from './components/Layout.jsx';
import Home from "./pages/Home.jsx";
import Departments from "./pages/Department.jsx";
import Doctors from "./pages/Doctors.jsx";
import BookAppointment from "./pages/BookAppointment.jsx";
import Dashboard from "./pages/Dashboard.jsx";
import NotFound from "./pages/Dashboard.jsx";
import { AuthProvider } from "./auth/AuthContext.jsx";
import DoctorDashboard from "./pages/DoctorDashboard.jsx";
import ProtectedRoute from "./auth/ProtectedRout.jsx";
import Login from "./pages/Login.jsx";
import Navbar from "./components/Navbar.jsx";
function Layout() {
  return (
    <>
      <Navbar />
      <main>
        <Outlet />
      </main>
    </>
  );
}
function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path="/departments" element={<Departments />} />
            <Route
              path="/departments/:departmentId/doctors"
              element={<Doctors />}
            />
            <Route
              path="/book-appointment/:doctorId"
              element={<BookAppointment />}
            />
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="login" element={<Login />} />
          </Route>
          <Route element={<ProtectedRoute />}>
            <Route path="/doctor-dashboard" element={<DoctorDashboard />} />
          </Route>
          <Route path="*" element={<NotFound />} />
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
