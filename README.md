# AlgoLib

C# algorithms & data-structures — beginner to expert.

AlgoLib is a collection of algorithm and data-structure implementations in C#, organized for learning, experimentation, and reuse. The repository contains a core library with implementations, a console project with demos, and a tests project.

## Repository layout

- src/
  - AlgoLib.Core/ — library containing algorithm implementations (Problems folder).
  - AlgoLib.Console/ — console/demo application to run example algorithms.
  - AlgoLib.Tests/ — unit tests for the library.

## Requirements

- .NET SDK (recommended: .NET 9.0 or newer)

## Quick start

Clone and build:

git clone https://github.com/PrateekDotnetETRM/AlgoLib.git
cd AlgoLib
dotnet build

Run tests:

dotnet test

Run the console demo:

dotnet run --project src/AlgoLib.Console

## Using the library in your project

You can reference the library project directly from another project in the same solution:

dotnet add <YourProject>.csproj reference src/AlgoLib.Core/AlgoLib.Core.csproj

Then in code:

// Example (replace with actual types / methods from the library)
using AlgoLib.Core;

class Program
{
    static void Main()
    {
        // Replace the following with actual algorithm/API from AlgoLib.Core
        // var result = SomeAlgorithm.Run(new int[] { 3, 1, 2 });
        // Console.WriteLine(string.Join(',', result));
    }
}

## Tests

The repository includes a Tests project (src/AlgoLib.Tests). Run all tests with:

dotnet test

Consider expanding test coverage to include edge cases (null/empty inputs, large inputs, boundary values).

## Contributing

- Please open issues for bugs or feature requests.
- Add unit tests for bug fixes or new algorithms.
- Follow consistent formatting and enable nullable reference types for safer APIs.
- Add XML docs for public APIs so consumers know expected behavior and edge cases.

## License

No LICENSE file is present in the repository. Add a LICENSE file to make the intended licensing explicit.

## Notes / Recommendations

- Core algorithm implementations are under src/AlgoLib.Core/Problems — ensure public APIs validate inputs (null checks, argument validation) and document expected complexity.
- Keep demos in AlgoLib.Console focused and small; rely on unit tests for correctness verification.
- Consider adding CI (build + tests) and benchmarks to track performance regressions.

Owner / Maintainer: PrateekDotnetETRM
