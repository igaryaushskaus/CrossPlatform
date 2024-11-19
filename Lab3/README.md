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
![image](https://github.com/user-attachments/assets/ddf43a81-79e8-448b-85a2-28e65720b12d)
![image](https://github.com/user-attachments/assets/b884a2aa-0551-47da-980e-d628abacf8ba)
![image](https://github.com/user-attachments/assets/ebee8a3d-0fdb-477d-8fe4-6e6678ca3365)
![image](https://github.com/user-attachments/assets/eb9149bb-eb44-4d81-8abe-8dc1cf002f86)
