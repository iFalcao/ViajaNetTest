# ViajaNetTest

Esse aplicativo possui uma WebApi .NET Core 2.2 servindo arquivos estáticos e um Console App funcionando como Consumer
de uma Queue do RabbitMQ. Utilizamos 2 DataProviders: SQLServer e um arquivo CSV (utilizando o CsvHelper). 
Siga os passos abaixo para executar ambos os projetos.


## Rodando o projeto

Passos iniciais:

1. Verifique se possui o .NET Core 2.2 SDK instalado, caso não possua deve baixar através desse [link](https://dotnet.microsoft.com/download/dotnet-core/2.2).

    - você pode verificar se possui o .net core instalado com o comando `dotnet --version`
2. Verifique se possui o SQLServer instalado configurado para localhost. Acesse o [link](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) e baixe o SQL Server 2017 Developer.
   
3. Verifique se possui o RabbitMQ (e Erlang) instalado localmente, caso não possua acesse o [link](https://www.rabbitmq.com/install-windows.html) e prossiga com a instalação.
   Não se esqueça de baixar o Erlang através do [link.](http://www.erlang.org/downloads)

4. Abra um terminal na pasta que deseja clonar o projeto e rode o seguinte comando: `git clone https://github.com/iFalcao/ViajaNetTest`.

Agora que você tem tudo baixado localmente, vamos rodar ambos os projetos. 
Para isso você deve abrir 2 instâncias de terminais diferentes, uma deve estar no projeto WebAPi (ViajaNet) e o outro
terminal deve estar no projeto Console (RobotQueueConsumer).

#### Rodando a API

Para rodar a API, execute os seguintes comandos:

```terminal
$ dotnet ef database update
$ dotnet watch run
```

#### Rodando o Consumer do RabbitMQ

Para rodar o projeto console, execute o seguinte comando:

```terminal
$ dotnet run
```

## Acessando

Abra o browser e navegue até as páginas: 
- `http://localhost:5000/home.html`
- `http://localhost:5000/checkout.html`
- `http://localhost:5000/landing.html` 
- `http://localhost:5000/confirmation.html`

Verifique no terminal que está rodando a aplicação do console as novas visitas inseridas nos bancos e o arquivo `csvDb.csv` criado 
no root do projeto da WebApi. Acesse o SQL Server Management Studio, conecte na instância localhost e rode o comando abaixo para 
verificar os novos registros criados.
```sql
USE ViajaNet
GO
SELECT * FROM Visits
GO
```
