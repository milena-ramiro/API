# API
## CRUD ASP .Net Core VS19

### Sobre
* Projeto simples para cadastro de usuário, com funções básicas (Create, Update, Delete e Details).

### Orientações
* Necessário mudar a string de conexão conforme o caminho do seu banco de dados.
* Para isso, acesse o arquivo appsettings.json

```
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=SRV-DB01\\MSSQLSERVER2018;Initial Catalog=myDatabaseCrud;Integrated Security=False;User ID=sa;Password=suasenha;"
  },
  
 ```
