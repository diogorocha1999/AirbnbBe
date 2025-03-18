# AirbnbAPI

Este é um projeto de API para um sistema de gestão de propriedades e reservas inspirado no Airbnb. A API permite o registo de utilizadores, gestão de propriedades e criação de reservas.

## 🚀 Funcionalidades

- **Utilizadores**:
  - Registo de novos utilizadores.
  - Login com autenticação JWT.
  - Recuperação de informações de utilizadores por ID.

- **Propriedades**:
  - Registo de propriedades.
  - Listagem de propriedades.
  - Atualização e eliminação de propriedades.

- **Reservas**:
  - Criação de reservas para propriedades.
  - Listagem de reservas por utilizador ou propriedade.

## 🛠️ Tecnologias Utilizadas

- **Backend**: ASP.NET Core 6
- **Base de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Autenticação**: JWT (JSON Web Token)
- **Documentação**: Swagger

## 📦 Estrutura do Projeto

```plaintext
AirbnbAPI/
├── AirbnbAPI/
│   ├── Business/          # Lógica de negócio (serviços)
│   ├── Controllers/       # Controladores da API
│   ├── Data/              # Modelos e DbContext
│   ├── Properties/        # Configurações do projeto
│   └── Program.cs         # Configuração inicial da aplicação
├── DatabaseScripts/       # Scripts SQL para criação da base de dados
└── README.md              # Documentação do projeto