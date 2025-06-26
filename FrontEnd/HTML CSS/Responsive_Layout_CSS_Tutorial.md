# 📘 What is CSS?

**CSS** stands for **Cascading Style Sheets**.  
It is a **stylesheet language** used to **control the presentation and layout** of HTML documents. CSS describes how HTML elements should be **displayed on screen, paper, or in other media**.

---

## 💡 Why Use CSS?

| Reason                        | Explanation                                                                 |
|------------------------------|-----------------------------------------------------------------------------|
| **Separation of concerns**   | Keeps content (HTML) and design (CSS) separate                              |
| **Reusability**              | Apply styles across multiple pages without duplicating                     |
| **Consistency**              | Ensures a uniform look and feel across your website                        |
| **Responsive Design**        | Helps create designs that adapt to different screen sizes (mobile, tablet) |
| **Ease of Maintenance**      | Easier to manage and update styles by changing just one CSS file           |

---

## 🧩 Example: Responsive Layout with Header, Footer, Main, and Aside

We’ll build this layout:

```
+----------------------------+
|         HEADER            |
+-------------+------------+
|   ASIDE     |   MAIN     |
+-------------+------------+
|         FOOTER            |
+----------------------------+
```

---

## 📄 HTML Structure

```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Responsive Layout</title>
  <link rel="stylesheet" href="styles.css">
</head>
<body>
  <header>Header</header>
  <div class="container">
    <aside>Sidebar</aside>
    <main>Main Content</main>
  </div>
  <footer>Footer</footer>
</body>
</html>
```

---

## 🎨 CSS (styles.css)

```css
/* Basic Reset */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Arial, sans-serif;
  line-height: 1.6;
}

header, footer {
  background-color: #333;
  color: white;
  text-align: center;
  padding: 1rem;
}

.container {
  display: flex;
  flex-direction: row;
  padding: 1rem;
  gap: 1rem;
}

aside {
  background-color: #f4f4f4;
  width: 25%;
  padding: 1rem;
}

main {
  background-color: #e2e2e2;
  flex: 1;
  padding: 1rem;
}

footer {
  margin-top: auto;
}

/* Responsive Design */
@media (max-width: 768px) {
  .container {
    flex-direction: column;
  }

  aside, main {
    width: 100%;
  }
}
```

---

## 🧠 Explanation

| Part         | Purpose |
|--------------|---------|
| `header`, `footer` | Top and bottom bars that remain constant across devices |
| `.container` | Uses Flexbox to arrange `aside` and `main` horizontally |
| `@media` query | When the screen is ≤ 768px, the layout stacks vertically |
| `flex: 1` | Makes main content grow to occupy the remaining space |

---

## ✅ Output Summary

- On desktop, it shows `aside` and `main` side-by-side
- On mobile, it stacks them vertically
- Header and footer span full width on all devices
