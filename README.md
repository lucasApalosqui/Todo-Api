1 - Criar a pasta Todo

2 - Criar as pastas: 
	Todo.Domain, Todo.Infra, Todo.Api, Todo.Tests

3 - Criar os projetos dentro de cada pasta criada:
	Todo.Domain = dotnet new classlib
	Todo.Domain.Api = dotnet new webapi
	Todo.Domain.Infra = dotnet new classlib
	Todo.Domain.Tests = dotnet new mstest

4 - adicionar uma solution a pasta Todo:
	Todo.Domain = dotnet new sln

5 - referenciar a solution as demais pastas do projeto:
	dotnet sln add .\Todo.Domain
	dotnet sln add .\Todo.Domain.Api
	dotnet sln add .\Todo.Domain.Infra
	dotnet sln add .\Todo.Domain.Tests

6 - Dar inicio ao build do projeto: 
	dotnet build

7 - Referenciar as pastas do projeto entre si:
	Todo.Domain.Api = dotnet add reference ..\Todo.Domain, dotnet add reference ..\Todo.Domain.Infra
	Todo.Domain.Infra = dotnet add reference ..\Todo.Domain
	Todo.Domain.Tests = dotnet add reference ..\Todo.Domain


	