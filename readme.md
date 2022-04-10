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

## Standart onion vs blazor onion

![blazor onion](/docs/images/readme/clean-blazor.png)

As you can see, we want to share enums and exceptions from domain layer, DTOs from application layer with blazor project.
Therefore, we've added extra DTO class library for each layer.

## Domain

### IAggregateRoot

	Interface stands for defining [aggregate root](https://martinfowler.com/bliki/DDD_Aggregate.html).
	Therefore, IRepository can work only with aggregates as well as IUnitOfWork.
	
### Entity
	
	Any domain object is entity. Entity has ability to raise events.
	
### Domain event
	
	Domain event implements INotification abstraction from Mediatr. Finally, we use mediator to publish and hand such events.
	We have two abstractions of event (INotification) : IPreSaveEvent and IPostSaveEvent for providing more managable behaviour.
	For more details, refer to Persistence layer section.
	
### Value object
	
	[Value object](https://medium.com/swlh/value-objects-to-the-rescue-28c563ad97c6#:~:text=In%20DDD%2C%20value%20objects%20differ,attributes%20and%20should%20be%20immutable.)
 is immutable object with ovverided equality methods, so they are compared by property values.
	