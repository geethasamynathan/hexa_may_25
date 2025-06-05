
# Assemblies in C#

## 🟦 What is an Assembly in C#?

In **C#**, an **assembly** is the **compiled output** of your code — it is the **smallest unit of deployment**, versioning, and security in the .NET framework.

An assembly contains:
- **MSIL (Microsoft Intermediate Language)** code
- **Metadata** about types and members
- **Manifest** (information about the assembly like version, culture, public key, etc.)
- Optionally, **resources** (images, strings, etc.)

Assemblies are generated as:
- `.dll` (Dynamic Link Library) – when you build a **class library**
- `.exe` (Executable) – when you build a **console or Windows application**

---

## 🟨 Types of Assemblies in C#

### 🔹 1. Private Assembly
- Used **by a single application only**
- Stored in the application's **own folder**
- No version conflict
- Example: A utility DLL placed in `bin/Debug` of your project.

### 🔹 2. Shared Assembly
- **Global scope**: Can be used by multiple applications
- Must be **strong-named** (signed with a public/private key pair)
- Stored in **Global Assembly Cache (GAC)**
- Example: `System.Data.dll` used by multiple apps

---

## 🟩 Optional Types (Based on Structure or Purpose)

### 🔹 3. Satellite Assembly
- Stores **localized resources** (e.g., strings for different languages)
- Helps in **globalization/localization**
- Example: `MyApp.resources.fr-FR.dll` for French

### 🔹 4. Dynamic Assembly
- Created at runtime using `System.Reflection.Emit`
- Useful for **code generation or dynamic proxy** scenarios

---

## 🟣 Summary Table

| Assembly Type      | Scope           | Location        | Use Case                         |
|--------------------|------------------|------------------|----------------------------------|
| Private Assembly   | Single app        | App folder       | Internal app use                |
| Shared Assembly    | Global            | GAC              | Reuse across multiple apps      |
| Satellite Assembly | Language-specific | App/GAC folders  | Localization support            |
| Dynamic Assembly   | Runtime-generated | Memory           | Code generation, scripting      |
