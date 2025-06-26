# 🎨 CSS3 Properties – A Detailed Tutorial with Real-World Examples

CSS3 introduced a wide range of new features that enhance the design, animation, layout, and responsiveness of web pages. This tutorial covers major CSS3 properties with examples and real-world use cases.

---

## 📌 1. Box Shadow

### 🔹 Property:
```css
box-shadow: h-offset v-offset blur spread color;
```

### 🔹 Use:
Adds shadow to elements, commonly used for cards, modals, buttons.

### ✅ Example:
```css
.card {
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}
```

### 🧠 Real-world:
Used to create elevation for UI cards in dashboards and material design.

---

## 📌 2. Border Radius

### 🔹 Property:
```css
border-radius: 10px;
```

### 🔹 Use:
Rounds the corners of elements.

### ✅ Example:
```css
.button {
  border-radius: 8px;
}
```

### 🧠 Real-world:
Buttons and input boxes in modern UI use rounded corners for aesthetics.

---

## 📌 3. Transition

### 🔹 Property:
```css
transition: property duration ease;
```

### 🔹 Use:
Smooth animation when properties change.

### ✅ Example:
```css
.box {
  transition: background-color 0.3s ease;
}
.box:hover {
  background-color: skyblue;
}
```

### 🧠 Real-world:
Smooth hover effects on buttons, menus, and images.

---

## 📌 4. Transform

### 🔹 Property:
```css
transform: scale(), rotate(), translate(), skew();
```

### 🔹 Use:
Changes the shape, size, and orientation of an element.

### ✅ Example:
```css
.image:hover {
  transform: scale(1.1);
}
```

### 🧠 Real-world:
Zooming in on images when hovered.

---

## 📌 5. Flexbox

### 🔹 Property:
```css
display: flex;
flex-direction, justify-content, align-items;
```

### ✅ Example:
```css
.container {
  display: flex;
  justify-content: space-between;
}
```

### 🧠 Real-world:
Used in header layouts, navigation bars, and responsive sections.

---

## 📌 6. Media Queries

### 🔹 Property:
```css
@media (max-width: 768px) {
  .container {
    flex-direction: column;
  }
}
```

### 🔹 Use:
Make website responsive based on device screen size.

### 🧠 Real-world:
Responsive menus, layout stacks on mobile, grid changes.

---

## 📌 7. Opacity

### 🔹 Property:
```css
opacity: 0.5;
```

### 🔹 Use:
Make elements semi-transparent.

### 🧠 Real-world:
Background overlays, disabled button effects.

---

## 📌 8. Animation

### 🔹 Property:
```css
@keyframes move { from { left: 0; } to { left: 100px; } }
animation: move 2s infinite;
```

### 🧠 Real-world:
Banners, loaders, pop-up notifications.

---

## 📌 9. Gradient Background

### 🔹 Property:
```css
background: linear-gradient(to right, red, yellow);
```

### 🧠 Real-world:
Attractive section headers, cards, and backgrounds.

---

## 📌 10. Custom Fonts

### 🔹 Property:
```css
@font-face {
  font-family: 'MyFont';
  src: url('myfont.woff');
}
```

### 🧠 Real-world:
Brand-specific fonts for web applications and branding.

---

## ✅ Conclusion

CSS3 allows developers to build visually appealing and responsive interfaces. With features like Flexbox, transitions, animations, and gradients, you can significantly enhance the user experience of modern web apps.

Would you like practical HTML + CSS examples for each of these in a project folder?
