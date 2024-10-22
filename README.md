# Task Manager API

API para gerenciamento de tarefas.

## Documentação do Projeto

### Índice

1. [Introdução](#introdução)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Configuração do Projeto](#configuração-do-projeto)
4. [Estrutura do Projeto](#estrutura-do-projeto)
5. [Endpoints da API](#endpoints-da-api)
   - [Login](#login)
   - [User](#user)
   - [Task](#task)

---

### Introdução

O **TaskManager** é uma API robusta para o gerenciamento de usuários e tarefas, utilizando autenticação baseada em tokens JWT. O projeto foi desenvolvido com uma arquitetura que segue os princípios de **Clean Architecture**, **Domain-Driven Design (DDD)**, e **SOLID**, além de utilizar **Design Patterns** como **Repository** e **Dependency Injection**, garantindo uma estrutura altamente manutenível, de baixo acoplamento e testável, com flexibilidade e independência de frameworks específicos.

### Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **AutoMapper**
- **JWT (JSON Web Token) para autenticação**
- **BCrypt para criptografia de senhas**

---

### Configuração do Projeto

1. **Clonar o Repositório:**

   ```bash
   git clone https://github.com/usuario/taskmanager.git
   cd taskmanager
   ```

2. **Configurar o Banco de Dados:**

   No arquivo appsettings.json, defina a string de conexão para o PostgreSQL:

   ```json
   "ConnectionStrings": {
   "PostgresConnection": "Host=localhost;Database=TaskManagerDb;Username=usuario;Password=senha"
   }
   ```

3. **Rodar as Migrações:**

   Para aplicar as migrações do banco de dados, rode o seguinte comando dentro do diretório TaskManager.Infrastructure:

   ```bash
   dotnet ef database update
   ```

4. **Executar o Projeto:**

   ```bash
   dotnet run
   ```

---

### Estrutura do Projeto

O projeto está dividido nas seguintes camadas principais:

- TaskManager.Application:
  Contém os casos de uso, mapeamento de AutoMapper, e injeções de dependências.

- TaskManager.Communication:
  Define os modelos de requisições e respostas que trafegam entre o cliente e a API.

- TaskManager.Domain:
  Contém as entidades e interfaces que representam as regras de negócio.

- TaskManager.Infrastructure:
  Implementa o acesso a dados, repositórios, e outros serviços de infraestrutura como criptografia e geração de tokens.

---

### Endpoints da API

### Login

1. **Fazer Login**

   - URL: `/taskmanager-api/login/sign-in`

   - Método: **_POST_**

   - Requisição:

     ```json
     {
       "email": "string",
       "password": "string"
     }
     ```

   - Respostas:

     200: **_OK_**

     ```json
     {
       "name": "string",
       "token": "string"
     }
     ```

     401: **_Unauthorized_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

2. **Obter Usuário Logado**

   - URL: `/taskmanager-api/login/get-profile`

   - Método: **_GET_**

   - Respostas:

     200: **_OK_**

     ```json
     {
       "name": "string",
       "email": "string"
     }
     ```

---

### Task

1. **Cadastrar Tarefa**

   - URL: `/api/tasks/register`

   - Método: **_POST_**

   - Requisição:

     ```json
     {
       "title": "string",
       "description": "string",
       "category": "string",
       "isCompleted": true
     }
     ```

   - Respostas:

     201: **_Created_**

     ```json
     {
       "id": 0,
       "title": "string"
     }
     ```

     400: **_Bad Request_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

2. **Listar Todas as Tarefas**

   - URL: `/taskmanager-api/task/get-all`

   - Método: **_GET_**

   - Respostas:

     200: **_Created_**

     ```json
     {
       "id": 0,
       "title": "string",
       "description": "string",
       "isCompleted": true,
       "category": "string",
       "createdAt": "2024-10-20T06:26:49.542Z",
       "updatedAt": "2024-10-20T06:26:49.542Z"
     }
     ```

     204: **_No Content_**

3. **Obter Tarefa**

   - URL: `taskmanager-api/task/get-by/{id}`

   - Método: **_PUT_**

   - Respostas:

     200: **_OK_**

     ```json
     {
       "id": 0,
       "title": "string",
       "description": "string",
       "isCompleted": true,
       "category": "string",
       "createdAt": "2024-10-20T06:27:58.680Z",
       "updatedAt": "2024-10-20T06:27:58.680Z"
     }
     ```

     204: **_Not Found_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

4. **Atualizar Tarefa**

   - URL: `/taskmanager-api/task/update/{id}`

   - Método: **_PUT_**

   - Requisição:

     ```json
     {
       "title": "string",
       "description": "string",
       "category": "string",
       "isCompleted": true
     }
     ```

   - Respostas:

     204: **_No Content_**

     400: **_Bad Request_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

     404: **_Not Found_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

5. **Deletar Tarefa**

   - URL: `/taskmanager-api/task/delete/{id}`

   - Método: **_DELETE_**

   - Respostas:

     204: **_No Content_**

     404: **_Not Found_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

---

### User

1. **Cadastrar Usuário**

   - URL: `/taskmanager-api/users/register`

   - Método: **_POST_**

   - Requisição:

     ```json
     {
       "name": "string",
       "email": "string",
       "password": "string"
     }
     ```

   - Respostas:

     201: **_Created_**

     ```json
     {
       "name": "string",
       "token": "string"
     }
     ```

     400: **_Bad Request_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

2. **Atualizar Usuário**

   - URL: `/taskmanager-api/user/update`

   - Método: **_PUT_**

   - Requisição:

     ```json
     {
       "name": "string",
       "email": "string"
     }
     ```

   - Respostas:

     204: **_No Content_**

     400: **_Bad Request_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

3. **Mudar Senha**

   - URL: `/taskmanager-api/users/change-password`

   - Método: **_PUT_**

   - Requisição:

     ```json
     {
       "password": "string",
       "newPassword": "string"
     }
     ```

   - Respostas:

     204: **_No Content_**

     400: **_Bad Request_**

     ```json
     {
       "errorMessages": ["string"]
     }
     ```

4. **Deletar Usuário Logado**

   - URL: `/taskmanager-api/user/delete`

   - Método: **_DELETE_**

   - Respostas:

     204: **No Content**

---

## Conclusão

Esta documentação fornece os detalhes necessários para clonar, configurar e rodar o projeto, além de descrever todos os endpoints disponíveis na API, com exemplos de requisições e respostas.
