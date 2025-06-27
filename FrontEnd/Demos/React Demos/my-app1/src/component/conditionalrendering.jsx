import React from "react";

function ConditionalRendering() {
  const employees = ["Pari", "Vivetha harini", "Dharanish", "Lokesh"];
  let isLoggedIn = false;
  const user = { username: "Tina", role: "admin" };

  const error = null;
  return (
    <div>
      {error ? (
        <p style={{ color: "red", backgroundColor: "white", fontSize: "bold" }}>
          Something went wrong. We are Working on It. Plase try after sometime
        </p>
      ) : (
        <>
          {" "}
          {isLoggedIn ? <p>Welcome Back!..</p> : <button>Login</button>}
          {employees.length == 0 ? (
            <p>No Employees Found </p>
          ) : (
            <ul>
              {employees.map((emp, index) => (
                <li key={index}>{emp}</li>
              ))}
            </ul>
          )}
          <div>
            {user.role === "admin" ? (
              <button>Manage Customer </button>
            ) : (
              <p> You have a Readonly access</p>
            )}
          </div>
        </>
      )}
    </div>
  );
}

export default ConditionalRendering;
