
# 🌐 React.js Tutorial

## 🧠 What is React.js?

**React.js** is a **JavaScript library** used to build **user interfaces (UI)**, particularly **single-page applications** (SPAs). It was developed by **Facebook** and is maintained by **Meta and a community of developers**.

### 🔑 Key Features

| Feature                | Description                                                |
|------------------------|------------------------------------------------------------|
| **Component-Based**    | UI is broken into reusable pieces called components.       |
| **Virtual DOM**        | React uses a lightweight copy of the DOM to update UI efficiently. |
| **Declarative**        | You describe what UI should look like, and React takes care of updating it. |
| **Unidirectional Data Flow** | Data flows in one direction, making code easier to debug. |

### 📍 Use Cases

- Building dashboards
- E-commerce sites
- Blogs and portfolios
- Admin panels
- Any web app needing dynamic, interactive UI

---

## 🛠️ How to Set Up a React Application (Step-by-Step)

You can create a React app in two popular ways:

### ✅ Method 1: Using **Create React App (CRA)**

**Step 1:** Install Node.js  
Download from: https://nodejs.org/

Verify installation:
```bash
node -v
npm -v
```

**Step 2:** Create React App:
```bash
npx create-react-app my-app
```

**Step 3:** Navigate to the app folder:
```bash
cd my-app
```

**Step 4:** Start development server:
```bash
npm start
```

Browser opens: `http://localhost:3000`

---

### ✅ Method 2: Manual Setup (Advanced)

**Steps:**
```bash
mkdir react-app
cd react-app
npm init -y
npm install react react-dom
```

Manual setup with Webpack and Babel required  
(Not recommended for beginners)

---

## 🗂️ Folder Structure (CRA)

```
my-app/
├── node_modules/
├── public/
│   └── index.html
├── src/
│   ├── App.js
│   ├── index.js
├── package.json
```

- `index.js`: React entry point  
- `App.js`: Main component  
- `public/index.html`: Template where React is mounted

---

## 🧪 Quick Demo (Edit `App.js`)

```jsx
function App() {
  return (
    <div>
      <h1>Hello, React!</h1>
      <p>Welcome to your first React app.</p>
    </div>
  );
}
```

Save and browser updates automatically.

---

## 📦 Common NPM Commands

| Command             | Purpose                              |
|---------------------|--------------------------------------|
| `npm start`         | Run the app in development mode      |
| `npm run build`     | Create optimized production build    |
| `npm test`          | Run test suite                       |
| `npm install <pkg>` | Add third-party libraries            |

---

## 🧰 Commonly Used React Tools

- **React Router** – Routing for SPAs
- **Redux / Context API** – State management
- **Axios / Fetch** – API requests
- **Bootstrap / Material UI** – Styling

---

Happy coding with React! 🚀
