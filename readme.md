## Prerequisites
Now works only in Visual Studio 2019 preview and dotnet 5 preview sdk

## How to use

* Install template
```cmd
    dotnet new --install NightBaker.ProjectTemplate::0.1.0
```
* You should see 
![dotnet new templates](/docs/images/readme/dotnet-new-templates.png)

* Create new project 
```cmd 
dotnet new CleanBlazor  -n <ProjectName>
```
* Run and create databases with docker (or just use your databases)
```cmd
cd docker
docker-compose up
```
* Finally, run app