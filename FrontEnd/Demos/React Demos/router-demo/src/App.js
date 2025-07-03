import logo from "./logo.svg";
import "./App.css";
import { BrowserRouter, Routes, Route, Outlet } from "react-router-dom";
import Home from "./pages/Home";
import ProductDetails from "./pages/ProductDetails";
import ProductList from "./pages/ProductList";
import About from "./pages/About";
import NotFound from "./pages/NotFound";
import NavBar from "./components/Navbar";
import ProtectedRoute from "./auth/ProtectedRoute";
import Dashboard from "./pages/Dashboard";
import Orders from "./pages/Orders";
import Profile from "./pages/Profile";
import Login from "./pages/Login";
import { AuthProvider } from "./auth/AuthContext";
import Products from "./pages/Products";
import AdminDashboard from "./pages/admin-dahsboard";
import StaffDashboard from "./pages/staff-dashboard";
import StudentDashboard from "./pages/student-Dashboard";
function Layout() {
  return (
    <>
      <NavBar />
      <main>
        <Outlet />
      </main>
    </>
  );
}
function App() {
  return (
    <>
      <BrowserRouter>
        <AuthProvider>
          <Routes>
            <Route element={<Layout />}>
              <Route path="/" element={<Home />} />
              <Route path="about" element={<About />} />
              {/* <Route path="products">
                <Route index element={<ProductList />} /> */}
              <Route path="products">
                <Route index element={<Products />} />
                <Route path=":id" element={<ProductDetails />} />
              </Route>

              <Route element={<ProtectedRoute />}>
                <Route path="dashboard" element={<Dashboard />} />
                <Route path="orders" element={<Orders />} />
                <Route path="profile" element={<Profile />} />
                <Route path="admin-dashboard" element={<AdminDashboard />} />
                <Route path="staff-dashboard" element={<StaffDashboard />} />
                <Route
                  path="student-dashboard"
                  element={<StudentDashboard />}
                />
              </Route>
              <Route path="login" element={<Login />} />
            </Route>
            <Route path="*" element={<NotFound />} />
          </Routes>
        </AuthProvider>
      </BrowserRouter>
    </>
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <p>
    //       Edit <code>src/App.js</code> and save to reload.
    //     </p>
    //     <a
    //       className="App-link"
    //       href="https://reactjs.org"
    //       target="_blank"
    //       rel="noopener noreferrer"
    //     >
    //       Learn React
    //     </a>
    //   </header>
    // </div>
  );
}

export default App;
