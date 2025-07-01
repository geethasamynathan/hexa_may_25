import React, { useState } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";

export default function LoginFormik() {
  const [successMessage, setSuccessMessage] = useState("");
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    validationSchema: Yup.object({
      email: Yup.string()
        .email("Enter a valid Email")
        .required("Email is Required"),
      password: Yup.string()
        .required("Enter password")
        .min(6, "Password must be more than 6 chrs"),
    }),
    onSubmit: (values, { resetForm }) => {
      alert("Login success");
      console.log("Form submitted");
      resetForm();
    },
  });
  return (
    <>
      <div className="container">
        <div className="card shodaw mx-auto" style={{ width: "400px" }}>
          <div className="card-body">
            <h3 className="card-title text-center mb-4">Login</h3>
            <form onSubmit={formik.handleSubmit}>
              <div className="mb-3">
                <label className="form-label">Email:</label>
                <input
                  type="text"
                  name="email"
                  className={`form-control
                     ${
                       formik.touched.email && formik.errors.email
                         ? "is-invalid"
                         : ""
                     }`}
                  placeholder="Enter your email"
                  value={formik.values.email}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                />
                {formik.touched.email && formik.errors.email && (
                  <div className="invalid-feedback">{formik.errors.email}</div>
                )}
              </div>
              <div className="mb-3">
                <label htmlFor="password" className="form-label">
                  Password:
                </label>
                <input
                  type="password"
                  name="password"
                  className={`form-control ${
                    formik.touched.password && formik.errors.password
                      ? "is-invalid"
                      : ""
                  }`}
                  placeholder="Enter the password"
                  value={formik.values.password}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                />
                {formik.touched.password && formik.errors.password && (
                  <div className="invalid-feedback">
                    {formik.errors.password}
                  </div>
                )}
              </div>
              <button type="submit" className="btn btn-primary w-100">
                Login
              </button>
              {successMessage && (
                <p className="alert alert-success mt-3"> {successMessage}</p>
              )}
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
