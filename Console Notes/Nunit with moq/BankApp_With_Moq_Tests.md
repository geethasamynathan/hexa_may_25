
# 🏦 C# Real-world BankApp with Unit Testing using Moq

## 📁 Project Structure

```
BankApp/
├── Program.cs
├── Models/
│   └── Account.cs
├── Services/
│   └── IBankRepository.cs
│   └── BankService.cs
BankApp.Tests/
├── BankServiceTests.cs
```

---

## ✅ 1. Account.cs

````csharp
namespace BankApp.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
    }
}
````

---

## ✅ 2. IBankRepository.cs

````csharp
using BankApp.Models;

namespace BankApp.Services
{
    public interface IBankRepository
    {
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}
````

---

## ✅ 3. BankService.cs

````csharp
using BankApp.Models;

namespace BankApp.Services
{
    public class BankService
    {
        private readonly IBankRepository _repository;

        public BankService(IBankRepository repository)
        {
            _repository = repository;
        }

        public decimal Deposit(string accountNumber, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero");

            var acc = _repository.GetAccount(accountNumber);
            if (acc == null) throw new InvalidOperationException("Account not found");

            acc.Balance += amount;
            _repository.UpdateAccount(acc);
            return acc.Balance;
        }

        public decimal Withdraw(string accountNumber, decimal amount)
        {
            var acc = _repository.GetAccount(accountNumber);
            if (acc == null) throw new InvalidOperationException("Account not found");

            if (amount > acc.Balance) throw new InvalidOperationException("Insufficient funds");

            acc.Balance -= amount;
            _repository.UpdateAccount(acc);
            return acc.Balance;
        }
    }
}
````

---

## ✅ 4. Program.cs

````csharp
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank App running... (Tests validate functionality)");
        }
    }
}
````

---

## ✅ 5. BankServiceTests.cs (Using Moq & NUnit)

````csharp
using NUnit.Framework;
using Moq;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.Tests
{
    public class BankServiceTests
    {
        private Mock<IBankRepository> _mockRepo;
        private BankService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IBankRepository>();
            _service = new BankService(_mockRepo.Object);
        }

        [Test]
        public void Deposit_PositiveAmount_UpdatesBalance()
        {
            var acc = new Account { AccountNumber = "123", Balance = 1000 };
            _mockRepo.Setup(r => r.GetAccount("123")).Returns(acc);

            var newBalance = _service.Deposit("123", 500);

            Assert.AreEqual(1500, newBalance);
            _mockRepo.Verify(r => r.UpdateAccount(It.Is<Account>(a => a.Balance == 1500)), Times.Once);
        }

        [Test]
        public void Withdraw_SufficientFunds_UpdatesBalance()
        {
            var acc = new Account { AccountNumber = "123", Balance = 1000 };
            _mockRepo.Setup(r => r.GetAccount("123")).Returns(acc);

            var newBalance = _service.Withdraw("123", 300);

            Assert.That(newBalance, Is.EqualTo(700));
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            var acc = new Account { AccountNumber = "123", Balance = 100 };
            _mockRepo.Setup(r => r.GetAccount("123")).Returns(acc);

            Assert.Throws<InvalidOperationException>(() => _service.Withdraw("123", 200));
        }

        [Test]
        public void Deposit_InvalidAmount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _service.Deposit("123", 0));
        }

        [Test]
        public void GetAccount_ShouldReturnSameInstance()
        {
            var acc = new Account { AccountNumber = "123", Balance = 100 };
            _mockRepo.Setup(r => r.GetAccount("123")).Returns(acc);

            var result = _mockRepo.Object.GetAccount("123");

            Assert.AreSame(acc, result);
        }
    }
}
````

---

## 🧪 Moq Methods Used

| Method        | Purpose                                  |
|---------------|------------------------------------------|
| `Setup()`     | Define behavior for mocked methods       |
| `Returns()`   | Specify return values for mock methods   |
| `IsAny<T>()`  | Accept any value of type T               |
| `Verify()`    | Assert method was called with expected input |

---

## ✅ Test Coverage

- ✅ Deposit and withdraw logic (positive + negative)
- ✅ Exception handling (`InvalidOperationException`, `ArgumentException`)
- ✅ Reference equality with `AreSame`
- ✅ Conditions with `Assert.That`
- ✅ Full use of Moq framework for mocking

