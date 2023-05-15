# RectanglesDemo
Small web api application that provides generating rectangles and search for entries where some point falls into

# Build project
Execute the next command in the root folder
```dotnet build```

# Run tests
Execute the next command in the root folder
```dotnet test```
There will be failed tests from automation project, since it's not finished

# Run api locally
Execute the next command in the root folder
```dotnet run --project .\src\RectanglesDemo.Api\RectanglesDemo.Api.csproj```
api is accessible http://localhost:5295/swagger/index.html. Please user with login/password admin/admin111 for basic authentication

# Run api in docker
Execute the next command in the root folder
```
docker-compose build
docker-compose up
 ```
When container is up, api is accessible http://localhost:8080/swagger/index.html. Please user with login/password admin/admin111 for basic authentication

# Notes
Api automation tests project is not finished, it's some kine of template for futher deveopment.
