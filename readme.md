## Prerequisites
* .NET 5
* Docker (optionaly for databases)

## How to use

[![NuGet Badge](https://buildstats.info/nuget/NightBaker.ProjectTemplate)](https://www.nuget.org/packages/NightBaker.ProjectTemplate/)


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