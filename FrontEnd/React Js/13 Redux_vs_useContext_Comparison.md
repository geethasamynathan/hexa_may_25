
### 📘 Redux vs useContext in React

---

## 🔍 Difference Between Redux and useContext

| Feature                      | **Redux**                                                                 | **useContext**                                              |
|-----------------------------|---------------------------------------------------------------------------|-------------------------------------------------------------|
| **Purpose**                 | Full-fledged state management tool                                        | Simple way to pass data deeply without prop drilling        |
| **Global State**           | Handles complex global state                                              | Works for small, simple global data                         |
| **Middleware Support**     | Yes (e.g., Redux Thunk, Redux Saga for async actions)                    | No middleware support                                       |
| **DevTools Support**       | Yes (Redux DevTools)                                                      | No                                                          |
| **Boilerplate**            | More boilerplate (actions, reducers, store setup)                        | Minimal setup                                               |
| **Performance Optimization** | Highly optimized with selectors (e.g., `reselect`)                        | Re-renders all consumers on context change                  |
| **Data Flow**              | Strict, predictable, unidirectional                                        | Less control over state mutations                           |
| **Ideal Use Case**         | Large-scale apps with complex state logic                                 | Small apps, theme switching, auth status, locale, etc.      |

---

## ✅ When to Use `useContext`

Use `useContext` when:
- You have a **small application**
- The state is **not too dynamic or complex**
- You want to share simple values like:
  - Dark/light theme
  - Logged-in user info
  - Language preferences

### 🔸 Example: AuthContext using `useContext`

```jsx
// AuthContext.js
import React, { createContext, useContext, useState } from "react";

const AuthContext = createContext();

export function AuthProvider({ children }) {
  const [user, setUser] = useState(null);

  const login = (userInfo) => setUser(userInfo);
  const logout = () => setUser(null);

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => useContext(AuthContext);
```

```jsx
// AnyComponent.js
import React from "react";
import { useAuth } from "./AuthContext";

function Dashboard() {
  const { user, logout } = useAuth();

  return (
    <div>
      <h2>Welcome, {user.name}</h2>
      <button onClick={logout}>Logout</button>
    </div>
  );
}
```

---

## ✅ When to Use Redux

Use Redux when:
- You need to manage **large or deeply nested state**
- There is **complex interaction between components**
- You need **time travel debugging**, **middleware**, or **predictable state**
- You have many components that rely on the **same global state** and it changes often

### 🔸 Real-World Example: Shopping Cart using Redux

#### 1. `store.js`

```js
import { configureStore } from "@reduxjs/toolkit";
import cartReducer from "./cartSlice";

export const store = configureStore({
  reducer: {
    cart: cartReducer,
  },
});
```

#### 2. `cartSlice.js`

```js
import { createSlice } from "@reduxjs/toolkit";

const cartSlice = createSlice({
  name: "cart",
  initialState: [],
  reducers: {
    addToCart(state, action) {
      state.push(action.payload);
    },
    removeFromCart(state, action) {
      return state.filter(item => item.id !== action.payload);
    }
  }
});

export const { addToCart, removeFromCart } = cartSlice.actions;
export default cartSlice.reducer;
```

#### 3. `ProductList.js`

```js
import React from "react";
import { useDispatch } from "react-redux";
import { addToCart } from "./cartSlice";

function ProductList() {
  const dispatch = useDispatch();

  const handleAdd = (product) => {
    dispatch(addToCart(product));
  };

  return (
    <div>
      <h2>Products</h2>
      <button onClick={() => handleAdd({ id: 1, name: "Phone" })}>
        Add Phone
      </button>
    </div>
  );
}
```

#### 4. `Cart.js`

```js
import React from "react";
import { useSelector } from "react-redux";

function Cart() {
  const cartItems = useSelector(state => state.cart);

  return (
    <div>
      <h2>Cart</h2>
      {cartItems.map(item => (
        <div key={item.id}>{item.name}</div>
      ))}
    </div>
  );
}
```

---

## 🧠 Summary: Which to Use?

| Scenario                                 | Recommended |
|------------------------------------------|-------------|
| Auth system, theme toggle                | useContext  |
| Multi-step form, basic language switch   | useContext  |
| Shopping cart, notifications, API state | Redux       |
| Real-time dashboard with filters         | Redux       |
