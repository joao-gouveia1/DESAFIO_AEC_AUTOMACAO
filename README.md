# CapturaCursoRPA

Este projeto é uma automação desenvolvida em .NET 8 usando o padrão de arquitetura DDD (Domain-Driven Design) e Entity Framework Core com banco de dados SQLite. Ele captura dados do site https://www.alura.com.br/, busca por "RPA" na barra de pesquisa e armazena informações do curso no banco de dados local.

## Estrutura do Projeto

O projeto foi desenvolvido seguindo a separação de responsabilidades proposta pelo DDD, com as seguintes camadas principais:

- **Apresentação**: Responsável pela interface de execução da aplicação.
- **AplicaçãoRPA**: Contém os serviços que coordenam o fluxo de dados entre as camadas de domínio e infraestrutura.
- **Domínio**: Define as entidades principais, interfaces e regras de negócio.
- **Infraestrutura**: Implementa o acesso ao banco de dados, repositórios e serviços auxiliares, como a integração com Selenium para automação de navegador.

## Tecnologias Utilizadas

- **.NET 8**: Framework para a criação da automação.
- **Entity Framework Core**: ORM para gerenciar a persistência de dados com SQLite.
- **SQLite**: Banco de dados leve, embutido no projeto, sem necessidade de instalação.
- **Selenium WebDriver**: Para automação da navegação e interação com páginas web.

## Configuração do Banco de Dados

O banco de dados SQLite é criado automaticamente em tempo de execução, caso ainda não exista. O caminho e a criação são gerenciados no código usando o Entity Framework.

Para garantir que o banco de dados seja criado apenas quando necessário e que as migrações sejam aplicadas corretamente, o projeto verifica a existência do arquivo `.db` e utiliza o comando `EnsureCreated()` para garantir que o banco seja criado caso ainda não exista.

## Executando o Projeto

Para executar o projeto, o arquivo único executável se encontra em `CapturaCursoRPA.Apresentacao\Executavel`.

## Observação

- **Banco de Dados**: O arquivo `.db` será criado no diretório de execução, dentro da pasta `BancoDeDados`, que será criada em tempo de execução.
