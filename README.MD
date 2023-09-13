<h1>Onion Architecture </h1>

docker run --name some-PostgreSQL -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=OnionArchitecture_Db -d postgres:latest

add-migration mig_1 -Context Persistence.Contexts.APIDbContext

<img src="https://raw.githubusercontent.com/MehrajLatifli/Onion-Architecture/master/Onion%20Architecture.png?token=GHSAT0AAAAAACHP4LN3R6HOILBPM5RKEXY6ZIBAA4Q" alt="Onion Architecture" width="500">
