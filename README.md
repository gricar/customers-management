
# Bem-vindo ao Gerenciador de Clientes

### Descrição
> É uma aplicação Web desenvolvida em Asp.net utilizando arquitetura MVC e integrado com banco de dados SQL Server.

<details>
  <summary><strong>Principais funcionalidades</strong></summary>
  
  - API Rest para realizar o `CRUD` (Cadastrar, Visualizar, Atualizar e Remover) de clientes;
   
</details>

<details>
  <summary><strong>Executando o projeto</strong></summary>

  - É necessário ter o `Docker` e o [`Docker Compose`](https://docs.docker.com/compose) instalado em sua máquina.

  - Clone o projeto: `git clone git@github.com:gricar/customers-management.git`.

  - Entre na pasta do projeto: `cd CustomersManagement`.

  - Restaure as dependências: `dotnet restore`.
  
  - Entre na pasta do projeto: `cd Database` e execute o **script** para iniciar o Docker Compose: `docker-compose up -d --build`.
</details>
