
# 🔗 React JS Hooks – Complete Tutorial with Real-World Examples

## 🧩 What are Hooks in React?

**Hooks** are special functions that let you “hook into” React features like state, lifecycle methods, and context from function components.

> ✅ Introduced in React 16.8 to replace class components for managing state and side-effects.

---

## 📚 List of React Hooks & Real-World Use Cases

| Category | Hook | Use |
|----------|------|-----|
| State | `useState` | Add local component state |
| Lifecycle | `useEffect` | Perform side effects (API calls, timers) |
| Context | `useContext` | Access values from `React.Context` |
| Ref | `useRef` | Access DOM or persist values across renders |
| Memoization | `useMemo` | Optimize performance for expensive calculations |
| Callback | `useCallback` | Prevent function re-creations |
| Reducer | `useReducer` | Complex state logic (alternative to Redux) |
| Imperative Handle | `useImperativeHandle` | Expose functions from child to parent via `ref` |
| Debug | `useDebugValue` | Show custom hook info in devtools |
| Layout | `useLayoutEffect` | Similar to `useEffect`, runs *before* paint |
| Defer State | `useDeferredValue` | Defer updates to non-urgent state |
| Transition | `useTransition` | Mark updates as low priority |
| Id | `useId` | Generate unique IDs |
| Sync External Store | `useSyncExternalStore` | Subscribe to external stores (Redux, etc.) |
| Insertion Effect | `useInsertionEffect` | Inject styles into DOM before layout |

---

## 🧠 Hook-by-Hook with Real-World Examples

### ✅ `useState` – Manage Component State

```jsx
import React, { useState } from 'react';

function DarkModeToggle() {
  const [dark, setDark] = useState(false);
  return (
    <div className={dark ? 'dark' : ''}>
      <button onClick={() => setDark(!dark)}>
        {dark ? 'Light Mode' : 'Dark Mode'}
      </button>
    </div>
  );
}
```

---

### ✅ `useEffect` – Perform Side Effects

```jsx
import React, { useEffect, useState } from 'react';

function WeatherWidget() {
  const [weather, setWeather] = useState(null);

  useEffect(() => {
    fetch('https://api.weatherapi.com/...')
      .then(res => res.json())
      .then(data => setWeather(data));
  }, []);

  return weather ? <p>{weather.temp}°C</p> : <p>Loading...</p>;
}
```

---

### ✅ `useContext` – Access Global Data

```jsx
const AuthContext = React.createContext();

function Dashboard() {
  const user = React.useContext(AuthContext);
  return <h1>Welcome, {user.name}</h1>;
}
```

---

### ✅ `useRef` – Access DOM or Persist Values

```jsx
function SearchBar() {
  const inputRef = useRef(null);

  useEffect(() => {
    inputRef.current.focus();
  }, []);

  return <input ref={inputRef} placeholder="Search..." />;
}
```

---

### ✅ `useMemo` – Memoize Expensive Computation

```jsx
const filteredProducts = useMemo(() => {
  return products.filter(p => p.inStock);
}, [products]);
```

---

### ✅ `useCallback` – Memoize Callback Function

```jsx
const handleClick = useCallback(() => {
  console.log('Clicked!');
}, []);
```

---

### ✅ `useReducer` – Complex State Logic

```jsx
function cartReducer(state, action) {
  switch (action.type) {
    case 'add': return [...state, action.item];
    case 'remove': return state.filter(i => i.id !== action.id);
    default: return state;
  }
}

const [cart, dispatch] = useReducer(cartReducer, []);
```

---

### ✅ `useImperativeHandle` – Custom Methods from Child

```jsx
const FancyInput = React.forwardRef((props, ref) => {
  const inputRef = useRef();

  useImperativeHandle(ref, () => ({
    focusInput() {
      inputRef.current.focus();
    }
  }));

  return <input ref={inputRef} />;
});
```

---

### ✅ `useDebugValue` – Debug Custom Hooks

```jsx
function useOnlineStatus() {
  const isOnline = navigator.onLine;
  useDebugValue(isOnline ? 'Online' : 'Offline');
  return isOnline;
}
```

---

### ✅ `useLayoutEffect` – Read layout before paint

```jsx
useLayoutEffect(() => {
  const height = ref.current.offsetHeight;
  console.log('Height:', height);
});
```

---

### ✅ `useDeferredValue` – Defer Expensive State Updates

```jsx
const deferredSearch = useDeferredValue(searchText);
const results = useMemo(() => expensiveFilter(deferredSearch), [deferredSearch]);
```

---

### ✅ `useTransition` – Background UI Updates

```jsx
const [isPending, startTransition] = useTransition();

const handleChange = (e) => {
  startTransition(() => {
    setQuery(e.target.value);
  });
};
```

---

### ✅ `useId` – Unique IDs for Accessibility

```jsx
const id = useId();
return <label htmlFor={id}><input id={id} /></label>;
```

---

### ✅ `useSyncExternalStore` – External Store Updates

```jsx
useSyncExternalStore(subscribe, getSnapshot);
```

---

### ✅ `useInsertionEffect` – Inject CSS Before Layout

```jsx
useInsertionEffect(() => {
  const style = document.createElement('style');
  style.innerHTML = `.fancy { color: red }`;
  document.head.appendChild(style);
});
```

---

## 📘 Summary Table

| Hook | Real-World Use |
|------|----------------|
| `useState` | Toggle UI, Forms |
| `useEffect` | API calls, Timers |
| `useContext` | Global state like auth/theme |
| `useRef` | Focus, DOM access |
| `useMemo` | Optimize slow computation |
| `useCallback` | Prevent child re-renders |
| `useReducer` | State with multiple actions |
| `useImperativeHandle` | Expose child methods |
| `useLayoutEffect` | DOM read-before-paint |
| `useTransition` | Smooth UI updates |
| `useId` | Accessibility IDs |
| `useDeferredValue` | Prioritize user input |
| `useDebugValue` | Custom hook info in DevTools |
| `useInsertionEffect` | Inject styles |
| `useSyncExternalStore` | Connect to Redux-style stores |
