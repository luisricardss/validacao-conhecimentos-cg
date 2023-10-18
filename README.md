# Portal de Validação de Conhecimento

## 1 - Ambiente

O ambiente do portal é composto por um único serviço de banco de dados em **SQLServer**.

### 1.1 - Configurando SQLServer
1. Inicialmente, utilizamos o SQLServer localDB. Você pode baixá-lo [aqui](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16).
2. Após o download, instale e execute o serviço SQLServer (SQLEXPRESS).

3. Existe outra maneira de usar o SQLServer, que envolve o uso de uma instância no Docker. Para isso, utilize o arquivo 'docker/development-sql-server.yml'.
   **Atenção:** Se optar por usar o Docker, certifique-se de ajustar o arquivo 'appsettings.Development.json' com as credenciais corretas.

- Execute o seguinte comando:
 ```
 docker-compose -f development-sql-server.yml up -d
```

### 1.2 - Executando em Debug
Com o SQLServer em execução, basta iniciar a solução utilizando os projetos WebApp e API, e estará pronta para executar.

### 1.3 - Executando no Docker
Tanto a API quanto o WebApp possuem arquivos 'DOCKERFILE' funcionais. 
Se desejar executar o projeto diretamente no Docker, sem a necessidade de usar o VS Code ou VS Studio, utilize o arquivo 'docker/validacao-cg-docker-development.yml'.

- Execute o seguinte comando:
 ```
 docker-compose -f validacao-cg-docker-development.yml up -d
```

## 2 - Atualizar bando de dados
1. No Visual Studio, definir o projeto 'ValidacaoConhecimentoCG.API' como projeto de inicialização e realizar o build da solução.
2. Abrir o Package Manager Console e definir o projeto de destino como 'ValidacaoConhecimentoCG.API'.
3. No Package Manager Console, atualizar/criar o banco de dados com o comando update-database.
4. No Package Manager Console, para criar um nova migration usar o comando add-migration {NomeMigration}.