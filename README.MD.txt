docker run --name some-PostgreSQL -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=OnionArchitecture_Db -d postgres:latest

add-migration mig_1 -Context Persistence.Contexts.APIDbContext