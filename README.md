# 🗝️ .NET Keys

<details>
  <summary>Show/hide folder structure</summary>

<!-- readme-tree start -->

```
.
└── .github
    └── workflows

2 directories
```

<!-- readme-tree end -->

</details>

A simple .NET library with a collection of common assymetric and symmetric key models.

## Prerequisites

- [.NET](https://dotnet.microsoft.com/en-us/)

## 🚀 Getting Started

To get started, you can install the packages from NuGet.

```bash
# For the Age key model
dotnet add package Devantler.Keys.Age
```

If you need to create a new key model, you can install the `Core` package from NuGet. This package includes the base classes and interfaces for creating new key models.

```bash
dotnet add package Devantler.Keys.Core
```

## Usage

The library currently supports the following key models:

- [Age](#the-age-key-model)

### The Age Key Model

The Age key model is a simple key model that represents an Age key. To create a new Age key, you can use the `AgeKey` class.

```csharp
// Creating an Age key.
var ageKey = new AgeKey();

// Creating an Age key from values.
var ageKey = new AgeKey("public-key", "private-key");

// Creating an Age key from values with a custom creation date.
var ageKey = new AgeKey("public-key", "private-key", new DateTime(2024, 12, 31));

// Creating an Age key from an existing key file.
var ageKey = new AgeKey("path/to/key/file.age");

// Creating an Age key from an existing key file with a custom creation date.
var ageKey = new AgeKey("path/to/key/file.age", new DateTime(2024, 12, 31));
```
