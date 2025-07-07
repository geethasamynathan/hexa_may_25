
# 🔗 React JS Events – 30 Real-World Use Cases with Full Code

Each example below includes:
- ✅ Real HTML control
- ✅ Bound event function
- ✅ Realistic use case
- ✅ Fully working code

---

### 1. `onClick` – Toggle Button Text

```jsx
import React, { useState } from 'react';

function App() {
  const [text, setText] = useState("Click Me");

  const handleClick = () => {
    setText(text === "Click Me" ? "Clicked!" : "Click Me");
  };

  return <button onClick={handleClick}>{text}</button>;
}

export default App;
```

---

### 2. `onChange` – Input Field Tracking

```jsx
import React, { useState } from 'react';

function App() {
  const [input, setInput] = useState("");

  return (
    <input type="text" onChange={(e) => setInput(e.target.value)} placeholder="Type something" />
  );
}

export default App;
```

---

### 3. `onSubmit` – Form Submit

```jsx
import React, { useState } from 'react';

function App() {
  const [name, setName] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Submitted: ${name}`);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input value={name} onChange={(e) => setName(e.target.value)} />
      <button type="submit">Submit</button>
    </form>
  );
}

export default App;
```

---

### 4. `onDoubleClick` – Enable Edit Mode

```jsx
import React, { useState } from 'react';

function App() {
  const [editable, setEditable] = useState(false);

  return editable ? (
    <input defaultValue="Double-click to edit" />
  ) : (
    <p onDoubleClick={() => setEditable(true)}>Double-click to edit</p>
  );
}

export default App;
```

---

### 5. `onKeyDown` – Search on Enter

```jsx
import React from 'react';

function App() {
  const handleKeyDown = (e) => {
    if (e.key === "Enter") alert("Searching...");
  };

  return <input onKeyDown={handleKeyDown} placeholder="Press Enter to Search" />;
}

export default App;
```

---

### 6. `onFocus` – Input Highlight

```jsx
function App() {
  return <input onFocus={() => console.log("Focused")} placeholder="Focus me" />;
}

export default App;
```

---

### 7. `onBlur` – Log Blur Event

```jsx
function App() {
  return <input onBlur={() => console.log("Lost focus")} placeholder="Blur me" />;
}

export default App;
```

---

### 8. `onContextMenu` – Right Click Alert

```jsx
function App() {
  return (
    <div onContextMenu={(e) => {
      e.preventDefault();
      alert("Right click detected");
    }}>
      Right-click here
    </div>
  );
}

export default App;
```

---

### 9. `onMouseEnter` – Tooltip Show

```jsx
function App() {
  return <div onMouseEnter={() => console.log("Hovered")}>Hover over me</div>;
}

export default App;
```

---

### 10. `onMouseLeave` – Tooltip Hide

```jsx
function App() {
  return <div onMouseLeave={() => console.log("Mouse left")}>Leave me</div>;
}

export default App;
```

---

### 11. `onChange` – Select Dropdown

```jsx
function App() {
  return (
    <select onChange={(e) => alert(`Selected: ${e.target.value}`)}>
      <option value="">Select</option>
      <option value="React">React</option>
      <option value="Vue">Vue</option>
    </select>
  );
}

export default App;
```

---

### 12. `onWheel` – Log Scroll Delta

```jsx
function App() {
  return <div onWheel={(e) => console.log(e.deltaY)}>Scroll here</div>;
}

export default App;
```

---

### 13. `onCopy` – Copy Alert

```jsx
function App() {
  return <input onCopy={() => alert("Copied")} value="Copy this text" readOnly />;
}

export default App;
```

---

### 14. `onCut` – Cut Alert

```jsx
function App() {
  return <input onCut={() => alert("Cut")} defaultValue="Cut this" />;
}

export default App;
```

---

### 15. `onPaste` – Paste Alert

```jsx
function App() {
  return <input onPaste={() => alert("Pasted")} placeholder="Paste here" />;
}

export default App;
```

---

### 16. `onSelect` – Select Text

```jsx
function App() {
  return <input onSelect={() => console.log("Text selected")} defaultValue="Select me" />;
}

export default App;
```

---

### 17. `onScroll` – Detect Scroll

```jsx
function App() {
  return (
    <div onScroll={() => console.log("Scrolling")} style={{ height: 100, overflowY: 'scroll' }}>
      <div style={{ height: 300 }}>Scrollable Content</div>
    </div>
  );
}

export default App;
```

---

### 18. `onLoad` – Image Loaded

```jsx
function App() {
  return <img src="https://via.placeholder.com/150" onLoad={() => alert("Image Loaded")} alt="demo" />;
}

export default App;
```

---

### 19. `onError` – Image Load Fail

```jsx
function App() {
  return <img src="broken.jpg" onError={() => alert("Failed to load image")} alt="broken" />;
}

export default App;
```

---

### 20. `onDragStart` – Start Drag

```jsx
function App() {
  return <div draggable onDragStart={() => console.log("Dragging started")}>Drag me</div>;
}

export default App;
```

---

### 21. `onDrop` – Drop File

```jsx
function App() {
  return (
    <div
      onDrop={(e) => {
        e.preventDefault();
        alert("Dropped!");
      }}
      onDragOver={(e) => e.preventDefault()}
      style={{ height: 100, border: "1px dashed black" }}
    >
      Drop here
    </div>
  );
}

export default App;
```

---

### 22. `onDragOver` – Prevent Default

```jsx
function App() {
  return <div onDragOver={(e) => e.preventDefault()}>Drag over me</div>;
}

export default App;
```

---

### 23. `onInput` – Input Change

```jsx
function App() {
  return <input onInput={(e) => console.log("Typing", e.target.value)} />;
}

export default App;
```

---

### 24. `onInvalid` – Input Validation

```jsx
function App() {
  return (
    <form>
      <input required onInvalid={() => alert("Field required")} />
      <button>Submit</button>
    </form>
  );
}

export default App;
```

---

### 25. `onKeyUp` – Key Release

```jsx
function App() {
  return <input onKeyUp={(e) => console.log("Key released:", e.key)} />;
}

export default App;
```

---

### 26. `onMouseDown` – Before Click

```jsx
function App() {
  return <button onMouseDown={() => console.log("Mouse down")}>Press</button>;
}

export default App;
```

---

### 27. `onMouseUp` – After Click

```jsx
function App() {
  return <button onMouseUp={() => console.log("Mouse up")}>Release</button>;
}

export default App;
```

---

### 28. `onTouchStart` – Mobile Tap Start

```jsx
function App() {
  return <div onTouchStart={() => console.log("Touch started")}>Touch here</div>;
}

export default App;
```

---

### 29. `onTouchEnd` – Mobile Tap End

```jsx
function App() {
  return <div onTouchEnd={() => console.log("Touch ended")}>Touch end</div>;
}

export default App;
```

---

### 30. `onAnimationEnd` – After CSS Animation

```jsx
function App() {
  return (
    <div
      style={{
        animation: "fadein 1s"
      }}
      onAnimationEnd={() => alert("Animation Done")}
    >
      Animation Box
    </div>
  );
}

export default App;
```

---

Each program can be used inside `App.js` of your React app. You can test these individually in [CodeSandbox](https://codesandbox.io/) or in a Create React App project.
