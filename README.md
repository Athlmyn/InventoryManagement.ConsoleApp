# Inventory Management System

## Overview

The Inventory Management System is a console-based application developed in .NET Core. The application allows users to manage their product inventory with functionalities to add, remove, update products, and adjust their inventory quantities.

## Features

1. **Add Product:** Allows the user to add a new product to the inventory. The system auto-generates the product ID to ensure uniqueness.

2. **Remove Product:** Enables the user to remove a product from the inventory by providing the product ID.

3. **Update Product:** The user can update an existing product's details like name, description, and price.

4. **Adjust Inventory:** The inventory quantity for a product can be adjusted, with the current quantity being displayed before adjustment.

5. **View Inventory:** Displays a list of all products in the inventory along with their quantities.

## Principles & Design Patterns

### Object-Oriented Programming (OOP)

This application is a demonstration of various OOP concepts:

- **Encapsulation:** Each class in the application encapsulates the data it operates on and the methods that manipulate this data. For example, `ProductService` encapsulates a list of products and provides methods to manipulate this data.

- **Inheritance:** The system demonstrates inheritance through the use of interfaces which serve as contracts for the classes implementing them.

- **Polymorphism:** Polymorphism is used throughout the system where the interfaces are used. For example, `IProductService` and `IInventoryService` could have multiple implementations.

### Don't Repeat Yourself (DRY)

The DRY principle is followed to avoid duplication of code. For example, the methods to retrieve input from the user (`GetStringInput`, `GetIntInput`, `GetDecimalInput`) are used throughout the system to avoid repeating the same input retrieval and conversion logic.

### SOLID Principles

- **Single Responsibility Principle (SRP):** Each class in the system has a single responsibility. For example, `ProductService` is responsible for managing products, and `InventoryService` is responsible for managing the inventory.

- **Open-Closed Principle (OCP):** The system is open for extension but closed for modification. New types of products or inventory services could be added without altering the existing code, by implementing the `IProductService` and `IInventoryService` interfaces.

- **Liskov Substitution Principle (LSP):** This is ensured by the use of interfaces. Any class implementing `IProductService` or `IInventoryService` can be substituted in without the system behaving any differently.

- **Interface Segregation Principle (ISP):** The system uses two small, specific interfaces (`IProductService` and `IInventoryService`) rather than one large, general interface.

- **Dependency Inversion Principle (DIP):** High-level modules (like `InventoryManager`) depend on abstractions (like `IProductService` and `IInventoryService`), not on the details of low-level modules. This is demonstrated by the use of constructor injection to provide the `ProductService` and `InventoryService` dependencies to `InventoryManager`.

## Installation & Running

To run this application, you'll need .NET Core SDK installed on your computer. Once installed, you can run the application by using the `dotnet run` command in the project directory.

---

By demonstrating usage of OOP principles, SOLID, and the DRY principle, this application provides a solid foundation for a scalable, maintainable application, impressing upon the code's clarity, extensibility, and organization.
