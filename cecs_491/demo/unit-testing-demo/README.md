# Unit Test Demo

## Description

Introduces unit testing concepts with the xUnit.net test framework.

## xUnit Project Setup  

1. Create a directory for test project

    > mkdir test-dir

2. Change current directy to test project

    > cd test-dir

3. User **dotnet** CLI to create the test project based on xunit template

    > dotnet new xunit

4. Begin writing unit tests

5. Execute unit tests

    > dotnet test  

## Common Scenarios

### Filtering by Traits  

```zsh
# Single
dotnet test --filter "<TraitName>=<TraitValue>"

# Multiple
dotnet test --filter "<TraitName>=<TraitValue>|<TraitName>=<TraitValue>"
```

### Ignore/Skip tests

```csharp
[Fact(Skip="Reason")]
[Theory(Skip="Reason")]
```

### Ignore/Skip entire test class

```csharp
const string SKIP_FLAG = "reason";

[Fact(Skip=SKIP_FLAG)]
```

### Enable entire test class

```csharp
const string SKIP_FLAG = null;

[Fact(Skip=SKIP_FLAG)]
```

## Activity

There is a bug in **UserProfileManagerV2.cs**. While only using the **dotnet test** command, locate and fix the bug.

To run only the tests for **UserProfileManagerV2Test.cs**:  

> dotnet test --filter "FullyQualifiedName~unit_testing_demo.UserProfileManagerV2Test"
