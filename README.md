# Conclusão do Desafio Back-end PicPay

## Introdução

Segue a entrega do desafio proposto, onde foi desenvolvido um sistema RESTful para transferências financeiras entre usuários e lojistas. O projeto atende aos requisitos estabelecidos, conforme detalhado abaixo.

---

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** PostgreSQL
- **ORM:** Entity Framework Core

---

## Funcionalidades Implementadas

- **Cadastro de Usuários e Lojistas:**  
  - Validação de CPF/CNPJ e e-mails únicos.  

- **Transferências:**  
  - Validação de saldo suficiente antes da transferência.  
  - Consulta ao serviço autorizador externo antes de finalizar a transferência (API autorizadora).  
  - Implementação de transações no banco de dados para garantir consistência dos dados.  

- **Notificações:**  
  - Integração com a API de notificações externa.  
  - Tratamento de falhas no envio de notificações para garantir a entrega.

---
