
# React JS Forms Tutorial – From Simple to Advanced (with Validation)

---

## 🧩 Level 1: Basic Form – Text Input + Button

### ✅ Objective: Capture name input and display on submit

```jsx
import React, { useState } from 'react';

function App() {
  const [name, setName] = useState('');
  const [submittedName, setSubmittedName] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (name.trim() === '') {
      alert('Name is required');
    } else {
      setSubmittedName(name);
    }
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Simple Form</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Enter your name: 
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="John Doe"
          />
        </label>
        <button type="submit">Submit</button>
      </form>
      {submittedName && <p>Hello, {submittedName}!</p>}
    </div>
  );
}

export default App;
```

---

## 🧩 Level 2: Multiple Fields + Basic HTML5 Validation

### ✅ Objective: Capture name, email, and age with required validation

```jsx
import React, { useState } from 'react';

function App() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    age: ''
  });

  const handleChange = (e) => {
    setFormData({...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Submitted:\nName: ${formData.name}\nEmail: ${formData.email}\nAge: ${formData.age}`);
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Basic Form with HTML5 Validation</h2>
      <form onSubmit={handleSubmit}>
        <input
          name="name"
          value={formData.name}
          onChange={handleChange}
          placeholder="Name"
          required
        /><br /><br />
        <input
          name="email"
          type="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Email"
          required
        /><br /><br />
        <input
          name="age"
          type="number"
          value={formData.age}
          onChange={handleChange}
          placeholder="Age"
          required
        /><br /><br />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default App;
```

---

## 🧩 Level 3: Form with Custom Validation Logic

### ✅ Objective: Validate password length and matching confirm password

```jsx
import React, { useState } from 'react';

function App() {
  const [form, setForm] = useState({ password: '', confirmPassword: '' });
  const [error, setError] = useState('');

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (form.password.length < 6) {
      setError("Password must be at least 6 characters");
    } else if (form.password !== form.confirmPassword) {
      setError("Passwords do not match");
    } else {
      setError('');
      alert('Password validated successfully');
    }
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Custom Password Validation</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="password"
          name="password"
          placeholder="Password"
          value={form.password}
          onChange={handleChange}
        /><br /><br />
        <input
          type="password"
          name="confirmPassword"
          placeholder="Confirm Password"
          value={form.confirmPassword}
          onChange={handleChange}
        /><br /><br />
        {error && <p style={{ color: 'red' }}>{error}</p>}
        <button type="submit">Validate</button>
      </form>
    </div>
  );
}

export default App;
```

---

## 🧩 Level 4: React Form with Dropdown, Radio, and Checkbox

### ✅ Objective: Collect user preferences using different input types

```jsx
import React, { useState } from 'react';

function App() {
  const [form, setForm] = useState({
    gender: '',
    language: 'English',
    terms: false,
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setForm({ ...form, [name]: type === 'checkbox' ? checked : value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!form.terms) {
      alert("You must accept terms");
      return;
    }
    alert(JSON.stringify(form, null, 2));
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Form with Dropdown, Radio, and Checkbox</h2>
      <form onSubmit={handleSubmit}>
        <div>
          Gender:
          <label><input type="radio" name="gender" value="Male" onChange={handleChange} /> Male</label>
          <label><input type="radio" name="gender" value="Female" onChange={handleChange} /> Female</label>
        </div><br />
        <div>
          Preferred Language:
          <select name="language" onChange={handleChange} value={form.language}>
            <option>English</option>
            <option>Hindi</option>
            <option>Tamil</option>
          </select>
        </div><br />
        <label>
          <input
            type="checkbox"
            name="terms"
            checked={form.terms}
            onChange={handleChange}
          />
          I agree to terms and conditions
        </label><br /><br />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default App;
```

---

## 🧩 Level 5: Advanced Form with Validation Library – Formik + Yup

### ✅ Objective: Use industry-standard validation with Formik and Yup

🧱 Install Dependencies:

```bash
npm install formik yup
```

```jsx
import React from 'react';
import { useFormik } from 'formik';
import * as Yup from 'yup';

const validationSchema = Yup.object({
  fullName: Yup.string().required('Required'),
  email: Yup.string().email('Invalid Email').required('Required'),
  age: Yup.number().min(18, 'Must be 18+').required('Required'),
});

function App() {
  const formik = useFormik({
    initialValues: { fullName: '', email: '', age: '' },
    validationSchema,
    onSubmit: (values) => alert(JSON.stringify(values, null, 2)),
  });

  return (
    <div style={{ padding: '20px' }}>
      <h2>Advanced Form using Formik + Yup</h2>
      <form onSubmit={formik.handleSubmit}>
        <div>
          <input
            name="fullName"
            placeholder="Full Name"
            onChange={formik.handleChange}
            value={formik.values.fullName}
          />
          {formik.errors.fullName && <p style={{ color: 'red' }}>{formik.errors.fullName}</p>}
        </div>
        <div>
          <input
            name="email"
            type="email"
            placeholder="Email"
            onChange={formik.handleChange}
            value={formik.values.email}
          />
          {formik.errors.email && <p style={{ color: 'red' }}>{formik.errors.email}</p>}
        </div>
        <div>
          <input
            name="age"
            type="number"
            placeholder="Age"
            onChange={formik.handleChange}
            value={formik.values.age}
          />
          {formik.errors.age && <p style={{ color: 'red' }}>{formik.errors.age}</p>}
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default App;
```
