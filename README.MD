<h1>Onion Architecture </h1>

<p> docker run --name some-PostgreSQL -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=OnionArchitecture_Db -d postgres:latest </p>

<p> Scaffold-DbContext "Host=localhost;Port=5432;Database=OnionArchitecture_Db;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Entities\Models </p>


<img src="https://github.com/MehrajLatifli/Onion-Architecture/Assets/blob/master/Onion%20Architecture.png" alt="Onion Architecture" width="500">

<p> Domain: Entities, Value object, Emuration, Entity Exceptions </p>

<p> Application (Repository, Service, Interface): DTO, ViewModel, Mapping, Validators, CQRS Pattern </p>

<p> Persistence: DbContext, Migrations, Configurations, Seeding, Reository Concrete class </p>

<p> Infrastructure: Other services </p>

<p> Presentation: Web app, Web API, Deskop app </p>


