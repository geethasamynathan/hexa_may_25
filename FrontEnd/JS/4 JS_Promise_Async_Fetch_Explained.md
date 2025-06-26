# JavaScript Tutorial: Promises, Async/Await, and Fetch

---

## 🔹 1. What is a Promise?

A **Promise** is a JavaScript object that represents the eventual completion (or failure) of an asynchronous operation. It is useful when working with tasks like API calls, timeouts, or file loading.

### ▶ Example: `wait` function with Promise

```javascript
const wait = (ms) => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Waited " + ms + " ms");
    }, ms);
  });
};

wait(2000).then(result => console.log(result));
```

### 🧾 Explanation:
- `wait(ms)` creates a new Promise that resolves after `ms` milliseconds.
- `setTimeout()` simulates an asynchronous delay.
- `.then()` is used to handle the result once the Promise is fulfilled.

---

## 🔹 2. What is async/await?

**async/await** makes asynchronous code look and behave like synchronous code. It is built on top of Promises and simplifies chaining.

### ▶ Example using async/await

```javascript
async function callWait() {
  const message = await wait(2000);
  console.log(message);
}

callWait();
```

### 🧾 Explanation:
- `async` keyword marks the function as asynchronous.
- `await` pauses execution until the `wait()` Promise resolves.
- Easier to read and maintain than chaining `.then()` calls.

---

## 🔹 3. What is fetch()?

The **`fetch()`** API is used to make HTTP requests and returns a Promise. It's commonly used for REST API calls.

### ▶ Example with .then()

```javascript
fetch("https://jsonplaceholder.typicode.com/posts/1")
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error("Error:", error));
```

### 🧾 Explanation:
- `fetch()` makes a GET request to the URL.
- `.json()` reads the response and parses it as JSON.
- `.then()` handles success; `.catch()` handles failure.

---

## 🔹 4. Same fetch with async/await

```javascript
async function getPost() {
  try {
    const response = await fetch("https://jsonplaceholder.typicode.com/posts/1");
    const data = await response.json();
    console.log(data);
  } catch (error) {
    console.error("Error:", error);
  }
}

getPost();
```

### 🧾 Explanation:
- The `getPost()` function uses `await` to pause for the response.
- The response is then parsed using `await response.json()`.
- Wrapped in `try/catch` for error handling.

---

## 🔹 5. Real-world Login Example with fetch & async/await

```javascript
async function loginUser(credentials) {
  try {
    const response = await fetch("https://example.com/api/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(credentials)
    });

    if (!response.ok) {
      throw new Error("Login failed");
    }

    const data = await response.json();
    console.log("Logged in as:", data.username);
  } catch (err) {
    console.error(err.message);
  }
}

loginUser({ username: "admin", password: "123456" });
```

### 🧾 Explanation:
- Makes a POST request to `/api/login`.
- Sends `credentials` as JSON in the request body.
- Awaits server response, and parses JSON.
- If `response.ok` is false, throws a login error.
- Handles both success and failure cases gracefully.

---

## 🧠 Summary Table

| Concept       | What it Does                            | Best For                          |
|---------------|------------------------------------------|-----------------------------------|
| `Promise`     | Handles asynchronous operations          | Manual `.then()` chaining         |
| `async/await` | Simplifies Promise logic                 | Cleaner and more readable async  |
| `fetch()`     | Performs HTTP requests (GET/POST)        | Making API calls in the browser   |

---

### ✅ Tips:
- Use `async/await` when possible for readability.
- Always handle errors with `.catch()` or `try/catch`.
- Remember that `fetch()` by default does **not** throw errors for 4xx/5xx responses unless you check `response.ok`.

