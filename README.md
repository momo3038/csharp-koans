## CSharp Koans, for what ?
The purpose on theses Koans is pretty simple : **Discover new C# features (Langage version 7, 8 and 9)**

The goal is to fix wrong assertions in unit tests. But as you may know, *"It's about the journey, not the destination"*!. 

Assertion are not really important (But I know that seeing tests in green is pretty cool!)

## First of all : Requirements
To build the solution, run tests and fix them, you'll need [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0).

## Run the Koans
You can use your favorite IDE (VSCode, Visual Studio) tu build and run unit tests.

Another convenient way is to execute dotnet commands in command line.

```bash
dotnet test
```

If you want to run specific Koan (Koans number is defined in class attribute and class name).

```bash
dotnet test --filter Koans="1"
```

if you want to re-run unit test on every file modification

```bash
dotnet watch test --filter Koans="1"
```

