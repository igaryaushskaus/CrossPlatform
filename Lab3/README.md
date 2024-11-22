## Запуск проекту

```bash
echo "Building library..."
dotnet build ClassLibraryLab3
```

```bash
echo "Packing library..."
dotnet pack ClassLibraryLab3 -o NugetLocalRepo
```

```bash
echo "Adding NuGet source..."
dotnet nuget add source NugetLocalRepo --name LocalNuget
```

```bash
echo "Building app..."
cd ClassLibraryLab3
dotnet add package IKravchenko --source ../NugetLocalRepo
dotnet run
```
