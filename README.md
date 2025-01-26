# Locadora Agro

## Visão Geral
Este é um sistema básico para gestão de locadoras, permitindo que a gerência:
- Faça login no sistema.
- Alugue filmes para clientes.
- Controle quais filmes estão alugados e quantos estão disponíveis.
- Gere relatórios em formato CSV com a relação de filmes alugados e disponíveis.

## Como Executar o Projeto

1. **Atualizar a String de Conexão**  
   Após baixar o código-fonte, atualize a string de conexão como mostrado na imagem abaixo:  
   ![connectionString](https://github.com/user-attachments/assets/57c306ec-597b-4eae-83e4-1e5695016530)

2. **Executar os Comandos para Configurar o Banco de Dados**  
   - Rode o comando: `add-migration criarTabelasBase`
   - Em seguida, execute: `update-database`

## Detalhes do Sistema

- **Usuário Padrão**: Após a criação das tabelas, um usuário padrão será gerado automaticamente:  
  - **Usuário**: `admin`  
  - **Senha**: `admin`
- **Filmes Disponíveis**:  
  A aplicação vem com uma lista de filmes predefinida, sendo que um dos filmes possui a quantidade zerada, para demonstrar a regra de indisponibilidade de locação.

## Tecnologias Utilizadas

- Padrão de Design: **MVC**
- ORM: **Entity Framework**
- Arquitetura em Camadas (separação de dados e interface web)
- Banco de Dados: **SQL Server**
- Geração de Relatórios: **CSV**

---

Espero que você aproveite o sistema!
