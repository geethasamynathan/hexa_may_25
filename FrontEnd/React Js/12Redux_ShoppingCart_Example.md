# 🛒 Redux in React JS 18: Real-World Example - Shopping Cart

This example demonstrates a complete React 18 + Redux setup for a simple shopping cart.

---

## 📁 File Structure

```
redux-cart-app/
├── public/
├── src/
│   ├── components/
│   │   ├── ProductList.jsx
│   │   ├── Cart.jsx
│   ├── redux/
│   │   ├── store.js
│   │   ├── cartSlice.js
│   ├── App.js
│   ├── index.js
├── package.json
```

---

## 1️⃣ Install Dependencies

```bash
npm install @reduxjs/toolkit react-redux
```

---

## 2️⃣ Create Redux Store

### 🔹 `src/redux/store.js`

```js
import { configureStore } from '@reduxjs/toolkit';
import cartReducer from './cartSlice';

const store = configureStore({
  reducer: {
    cart: cartReducer,
  },
});

export default store;
```

---

## 3️⃣ Create Cart Slice

### 🔹 `src/redux/cartSlice.js`

```js
import { createSlice } from '@reduxjs/toolkit';

const cartSlice = createSlice({
  name: 'cart',
  initialState: {
    items: [],
  },
  reducers: {
    addToCart(state, action) {
      state.items.push(action.payload);
    },
    removeFromCart(state, action) {
      state.items = state.items.filter(item => item.id !== action.payload);
    },
  },
});

export const { addToCart, removeFromCart } = cartSlice.actions;
export default cartSlice.reducer;
```

---

## 4️⃣ Provide Redux Store

### 🔹 `src/index.js`

```js
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { Provider } from 'react-redux';
import store from './redux/store';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Provider store={store}>
    <App />
  </Provider>
);
```

---

## 5️⃣ Create Product List Component

### 🔹 `src/components/ProductList.jsx`

```js
import React from 'react';
import { useDispatch } from 'react-redux';
import { addToCart } from '../redux/cartSlice';

const products = [
  { id: 1, name: 'T-Shirt', price: 499 },
  { id: 2, name: 'Jeans', price: 999 },
  { id: 3, name: 'Shoes', price: 1499 },
];

export default function ProductList() {
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Products</h2>
      {products.map(product => (
        <div key={product.id} style={{ borderBottom: '1px solid #ccc' }}>
          <h4>{product.name}</h4>
          <p>₹{product.price}</p>
          <button onClick={() => dispatch(addToCart(product))}>Add to Cart</button>
        </div>
      ))}
    </div>
  );
}
```

---

## 6️⃣ Create Cart Component

### 🔹 `src/components/Cart.jsx`

```js
import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { removeFromCart } from '../redux/cartSlice';

export default function Cart() {
  const cartItems = useSelector(state => state.cart.items);
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Cart</h2>
      {cartItems.length === 0 ? (
        <p>Cart is empty</p>
      ) : (
        cartItems.map(item => (
          <div key={item.id}>
            <span>{item.name} - ₹{item.price}</span>
            <button onClick={() => dispatch(removeFromCart(item.id))}>Remove</button>
          </div>
        ))
      )}
    </div>
  );
}
```

---

## 7️⃣ App Component

### 🔹 `src/App.js`

```js
import React from 'react';
import ProductList from './components/ProductList';
import Cart from './components/Cart';

function App() {
  return (
    <div style={{ display: 'flex', justifyContent: 'space-around', padding: 20 }}>
      <ProductList />
      <Cart />
    </div>
  );
}

export default App;
```

---

## ✅ Output

- Add products to the cart.
- View and remove items in the cart.
- Global state is managed via Redux.

---

## 🧠 Summary

- Redux Toolkit simplifies Redux logic.
- React 18 works smoothly with Redux using `Provider`, `useDispatch`, and `useSelector`.

This is a foundational pattern used in real-world apps like:
- E-commerce
- Booking systems
- Admin dashboards