
# React 18 – Class Component Example

## ✅ Basic Class Component in React

```jsx
import React, { Component } from 'react';

class Welcome extends Component {
  constructor(props) {
    super(props);
    // Initializing state
    this.state = {
      name: 'Student',
      count: 0
    };
  }

  handleClick = () => {
    // Updating state
    this.setState({ count: this.state.count + 1 });
  };

  render() {
    return (
      <div style={{ textAlign: 'center', marginTop: '20px' }}>
        <h1>Hello, {this.state.name}!</h1>
        <p>You clicked {this.state.count} times.</p>
        <button onClick={this.handleClick}>Click Me</button>
      </div>
    );
  }
}

export default Welcome;
```

---

## 🔍 Explanation

| Section | Description |
|--------|-------------|
| `class Welcome extends Component` | Defines a React class component named `Welcome`. |
| `constructor(props)` | Initializes state and binds methods (if needed). |
| `this.state` | Holds internal data (e.g., `name`, `count`). |
| `this.setState` | Updates state and triggers re-render. |
| `render()` | Returns JSX to be rendered on the screen. |

---

## ✅ Usage in App.js

```jsx
import React from 'react';
import Welcome from './Welcome';

function App() {
  return (
    <div>
      <Welcome />
    </div>
  );
}

export default App;
```

---

## 📌 Notes

- React 18 still supports **class components**, although function components with **hooks** (like `useState`, `useEffect`) are now preferred.
- You can use lifecycle methods like:
  - `componentDidMount`
  - `componentDidUpdate`
  - `componentWillUnmount`
