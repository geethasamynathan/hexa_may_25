
# 🔗 Event Binding in React JS – 30 Detailed Examples

Event binding in React allows you to respond to user interactions such as clicks, changes, key presses, and more. React handles events using camelCase syntax and JSX.

---

## ✅ Basic Syntax

```jsx
<button onClick={handleClick}>Click Me</button>
```

---

## 🔁 30 Event Binding Use Cases

Each example uses a specific React event and a function to demonstrate it.

---

### 1. Button Click Event

```jsx
<button onClick={() => alert('Button Clicked!')}>Click Me</button>
```

---

### 2. Function with Argument

```jsx
<button onClick={() => handleClick('Hello')}>Greet</button>
```

---

### 3. Input Change

```jsx
<input type="text" onChange={(e) => console.log(e.target.value)} />
```

---

### 4. Checkbox Toggle

```jsx
<input type="checkbox" onChange={(e) => setChecked(e.target.checked)} />
```

---

### 5. Form Submission

```jsx
<form onSubmit={(e) => { e.preventDefault(); alert("Form Submitted"); }}>
```

---

### 6. Key Press Event

```jsx
<input onKeyPress={(e) => console.log(e.key)} />
```

---

### 7. Mouse Enter

```jsx
<div onMouseEnter={() => console.log("Mouse Entered")} />
```

---

### 8. Mouse Leave

```jsx
<div onMouseLeave={() => console.log("Mouse Left")} />
```

---

### 9. Double Click

```jsx
<button onDoubleClick={() => alert("Double Clicked!")}>Double Click</button>
```

---

### 10. Focus Input

```jsx
<input onFocus={() => console.log("Focused")} />
```

---

### 11. Blur Input

```jsx
<input onBlur={() => console.log("Blurred")} />
```

---

### 12. Select Text

```jsx
<input onSelect={() => console.log("Text Selected")} />
```

---

### 13. Right Click Context Menu

```jsx
<div onContextMenu={(e) => {
  e.preventDefault();
  alert("Right click detected!");
}} />
```

---

### 14. Scroll Event

```jsx
<div onScroll={() => console.log("Scrolling...")} />
```

---

### 15. Copy Event

```jsx
<input onCopy={() => alert("Copied!")} />
```

---

### 16. Paste Event

```jsx
<input onPaste={() => alert("Pasted!")} />
```

---

### 17. Cut Event

```jsx
<input onCut={() => alert("Cut!")} />
```

---

### 18. Drag Start

```jsx
<div draggable onDragStart={() => console.log("Dragging started")} />
```

---

### 19. Drag Over

```jsx
<div onDragOver={(e) => {
  e.preventDefault();
  console.log("Dragging over...");
}} />
```

---

### 20. Drop Event

```jsx
<div onDrop={(e) => {
  e.preventDefault();
  console.log("Dropped!");
}} />
```

---

### 21. Wheel Scroll

```jsx
<div onWheel={(e) => console.log("Wheel scrolled", e.deltaY)} />
```

---

### 22. Input onChange with State

```jsx
const [name, setName] = useState("");

<input onChange={(e) => setName(e.target.value)} value={name} />
```

---

### 23. Select Dropdown Change

```jsx
<select onChange={(e) => alert(e.target.value)}>
  <option value="red">Red</option>
  <option value="blue">Blue</option>
</select>
```

---

### 24. Image Load

```jsx
<img src="img.jpg" onLoad={() => console.log("Image Loaded")} />
```

---

### 25. Error Handling for Image

```jsx
<img src="img.png" onError={() => alert("Failed to load image")} />
```

---

### 26. Window Resize Listener (useEffect)

```jsx
useEffect(() => {
  const handleResize = () => console.log("Resized!");
  window.addEventListener("resize", handleResize);
  return () => window.removeEventListener("resize", handleResize);
}, []);
```

---

### 27. Toggle Visibility with Button

```jsx
const [show, setShow] = useState(false);

<button onClick={() => setShow(!show)}>Toggle</button>
{show && <p>Now you see me</p>}
```

---

### 28. Conditional Button Disable

```jsx
const [input, setInput] = useState("");

<input onChange={(e) => setInput(e.target.value)} />
<button disabled={!input}>Submit</button>
```

---

### 29. Counter Buttons

```jsx
const [count, setCount] = useState(0);

<button onClick={() => setCount(count + 1)}>+</button>
<button onClick={() => setCount(count - 1)}>-</button>
<p>Count: {count}</p>
```

---

### 30. Submit on Enter

```jsx
<input onKeyDown={(e) => {
  if (e.key === "Enter") alert("Enter pressed");
}} />
```

---

## ✅ Summary

React events are:
- Named in **camelCase** (`onClick`, `onChange`)
- Passed as **function references** or **arrow functions**
- Can be bound inline or to defined functions
- Work with **all HTML elements**

You can apply event binding for UI interactivity, form handling, real-time updates, and more.

---
