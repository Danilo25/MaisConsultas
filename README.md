
# 🩺 MaisConsultas - Sistema de Agendamento Médico

Este projeto é uma aplicação web completa para gerenciamento de agendamentos médicos, desenvolvida como parte de um teste prático para vaga de Desenvolvedor Frontend.

Inclui uma interface clara e responsiva, comunicação com API REST (mockada via backend C#) e suporte completo via Docker.

---

## 📌 Funcionalidades Implementadas

### ✅ Backend (.NET Core)
- Cadastro e listagem de especialidades
- Cadastro e listagem de convênios
- Definição de disponibilidade de médicos por dia/horário
- Listagem de horários disponíveis

### ✅ Frontend (HTML, CSS e JavaScript)
- Cadastro de especialidades e convênios
- Visualização de especialidades e convênios disponíveis
- Visualização de horários disponíveis

---

## 🧰 Tecnologias Utilizadas

- .NET Core (C#)
- HTML5 + CSS3
- JavaScript Puro (ES6+)
- Docker + Docker Compose

---

## 🗂 Estrutura do Projeto

```
MaisConsultas/
├── Backend/                   # API REST em .NET Core
│   ├── Controllers/           # Endpoints da API
│   ├── Models/                # Modelos de dados
│   ├── Program.cs
│   ├── Startup.cs
│   └── MAISCONSULTAS.API.csproj
│
├── Frontend/                 # Interface Web
│   ├── componentes/pages/     # Páginas HTML modulares
│   ├── componentes/           # Sidebar reutilizável
│   ├── css/                   # Estilos personalizados
│   ├── js/api/                # Integração com API
│   ├── js/pages/              # Scripts de páginas
│   ├── js/utils/              # Utilitários JS
│   ├── index.html             # Página principal
│   └── Dockerfile
│
├── docker-compose.yml         # Orquestração com Docker
└── README.md
```

---

## 🚀 Executando o Projeto

### ✅ Pré-requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### 🔧 Subir com Docker

```bash
git clone https://github.com/seu-usuario/maisconsultas.git
cd maisconsultas
docker-compose up --build
```

Acesse a aplicação em:  
🔗 `http://localhost:8080` (Frontend)  
🔗 `http://localhost:5000/swagger` (API .NET com Swagger)

---

## 👨‍⚕️ Como Utilizar a Aplicação

1. Acesse o Dashboard.
2. Cadastre Especialidades e Convênios.
3. Defina as disponibilidades dos médicos.
4. Consulte horários disponíveis com base na data/especialidade.
5. Realize agendamentos de consultas.
6. Visualize ou marque consultas como atendidas.
