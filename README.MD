<h1>Onion Architecture </h1>

<p> docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=admin1234@" -p 1430:1433 --name sql2 --hostname sql2 -d ` mcr.microsoft.com/mssql/server:2022-latest  </p>



<img src="https://github.com/MehrajLatifli/Onion-Architecture/blob/master/Assets/Onion%20Architecture.png" alt="Onion Architecture" width="500">

<p> Domain: Entities, Value object, Emuration, Entity Exceptions </p>

<p> Application (Repository, Service, Interface): DTO, ViewModel, Mapping, Validators, CQRS Pattern </p>

<p> Persistence: DbContext, Migrations, Configurations, Seeding, Repository Concrete class </p>

<p> Infrastructure: Other services (do not belong DB) </p>

<p> Presentation: Web app, Web API, Deskop app </p>


