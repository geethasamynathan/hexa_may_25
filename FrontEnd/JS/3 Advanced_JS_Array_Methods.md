# Advanced JavaScript (ES6+) Array Methods — Definitions & Real‑World Examples

Below is a single **e‑commerce product dataset** used to illustrate every method.

```javascript
const products = [
  { id: 1, name: "Wireless Mouse",     price:  799, inStock: true,  quantity: 12 },
  { id: 2, name: "Mechanical Keyboard",price: 2499, inStock: true,  quantity:  5 },
  { id: 3, name: "USB-C Cable",        price:  299, inStock: false, quantity:  0 },
  { id: 4, name: "HD Webcam",          price: 1399, inStock: true,  quantity:  7 },
  { id: 5, name: "Laptop Stand",       price:  999, inStock: true,  quantity: 10 },
];
```

| # | Method | Definition | Example | Typical Output |
|---|--------|------------|---------|----------------|
| 1 | **`map(callback)`** | Returns a **new array** where each element is the result of the callback. | ```js const names = products.map(p => p.name);``` | `["Wireless Mouse","Mechanical Keyboard","USB-C Cable","HD Webcam","Laptop Stand"]` |
| 2 | **`filter(callback)`** | Returns a **new array** containing only elements for which the callback is `true`. | ```js const under1k = products.filter(p => p.price < 1000);``` | objects with id 1, 3, 5 |
| 3 | **`reduce(callback, initial)`** | Iterates left‑to‑right, **accumulating** a single value. | ```js const value = products.reduce((sum,p)=>sum+p.price*p.quantity,0);``` | `₹38478` |
| 4 | **`find(callback)`** | Returns the **first element** that satisfies the callback or `undefined`. | ```js const webcam = products.find(p => p.id === 4);``` | `{ id:4, name:"HD Webcam", … }` |
| 5 | **`findIndex(callback)`** | Returns the **index** of the first match or `-1`. | ```js const idx = products.findIndex(p => !p.inStock);``` | `2` |
| 6 | **`some(callback)`** | Returns **`true`** if **any** element matches. | ```js const anyOut = products.some(p => !p.inStock);``` | `true` |
| 7 | **`every(callback)`** | Returns **`true`** only if **all** elements match. | ```js const allCheap = products.every(p => p.price < 3000);``` | `true` |
| 8 | **`forEach(callback)`** | Runs callback for **each** element (side‑effects); returns `undefined`. | ```js products.forEach(p => console.log(p.name));``` | *(logs five lines)* |
| 9 | **`flatMap(callback)`** | Maps each element and flattens one level. | ```js const tags = products.flatMap(p => [p.id, p.name]);``` | `[1,"Wireless Mouse",2,"Mechanical Keyboard",…]` |
| – | **`findAll`** | *Not native; use `filter` for “all” matches.* | — | — |

> **Why no real `findAll`?**  
> Native JavaScript only needs `filter`; libraries sometimes add `findAll`.

---

## Quick Recap

- **Transform** ➜ `map`, `flatMap`  
- **Select some** ➜ `filter`  
- **Locate first / index** ➜ `find`, `findIndex`  
- **Check any / all** ➜ `some`, `every`  
- **Accumulate** ➜ `reduce`  
- **Side effects** ➜ `forEach`

---

### Next Steps

Need more advanced topics (Promises, async/await, Fetch API) or another format? Just let me know!
