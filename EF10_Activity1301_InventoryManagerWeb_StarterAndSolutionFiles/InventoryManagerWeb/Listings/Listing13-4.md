# Listing 13-4: The Build Step

In this step, the project is built and tested to make sure there are no problems with the code and tests are passing.

## The YAML

The build and test step validates the code.

```yml
name: Build App and Run Tests

on:
  workflow_call:

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 10.x

      - name: Restore dependencies
        run: dotnet restore
        working-directory: ./InventoryManagerWeb

      - name: Build
        run: dotnet build --configuration Release --no-restore
        working-directory: ./InventoryManagerWeb

      - name: Run Tests
        run: dotnet test --no-build --verbosity normal
        working-directory: ./EF10_InventoryManagerUnitTests
```  