
# 🧰 Jenkins Installation Guide

---

## ✅ Option 1: Install Jenkins using Docker (Recommended)

### 🔹 Step 1: Install Docker

- **Windows/Mac**: Install Docker Desktop → [https://www.docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop)
- **Linux (Ubuntu)**:
```bash
sudo apt update
sudo apt install docker.io -y
sudo systemctl enable docker
sudo systemctl start docker
```

---

### 🔹 Step 2: Run Jenkins in Docker

```bash
docker run -d \
  --name jenkins \
  -p 8080:8080 -p 50000:50000 \
  -v jenkins_home:/var/jenkins_home \
  jenkins/jenkins:lts
```

### 🔹 Step 3: Unlock Jenkins

```bash
docker exec jenkins cat /var/jenkins_home/secrets/initialAdminPassword
```

Then go to `http://localhost:8080` in your browser.

---

## ✅ Option 2: Install Jenkins on Ubuntu 22.04

```bash
sudo apt update
sudo apt install openjdk-17-jdk -y

curl -fsSL https://pkg.jenkins.io/debian/jenkins.io.key | sudo tee \
  /usr/share/keyrings/jenkins-keyring.asc > /dev/null

echo deb [signed-by=/usr/share/keyrings/jenkins-keyring.asc] \
  https://pkg.jenkins.io/debian-stable binary/ | sudo tee \
  /etc/apt/sources.list.d/jenkins.list > /dev/null

sudo apt update
sudo apt install jenkins -y

sudo systemctl enable jenkins
sudo systemctl start jenkins
```

Then visit: `http://localhost:8080`

---

## ✅ Option 3: Install Jenkins on Windows

1. Download from: [https://www.jenkins.io/download/](https://www.jenkins.io/download/)
2. Run the installer (`jenkins.msi`)
3. Jenkins will start on port `8080`

### Password Location:
```
C:\Program Files\Jenkins\secrets\initialAdminPassword
```

---

## 🔐 First-Time Password Location

| Platform | Command or Path |
|----------|------------------|
| Docker | `docker exec jenkins cat /var/jenkins_home/secrets/initialAdminPassword` |
| Ubuntu | `cat /var/lib/jenkins/secrets/initialAdminPassword` |
| Windows | `C:\Program Files\Jenkins\secrets\initialAdminPassword` |

---

## 🧪 Verify Jenkins Installation

Open in browser: [http://localhost:8080](http://localhost:8080)

If Jenkins dashboard loads, you're good to go!

---
