# 📈 TradeWise - Plataforma Inteligente de Trading Pessoal

> **Sistema completo de simulação de trading desenvolvido para demonstrar habilidades full-stack com foco em arquiteturas robustas e tecnologias modernas.**

[![.NET](https://img.shields.io/badge/.NET-9.0-purple)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-Latest-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)](https://www.microsoft.com/sql-server)
[![SignalR](https://img.shields.io/badge/SignalR-Real--time-green)](https://dotnet.microsoft.com/apps/aspnet/signalr)
[![Redis](https://img.shields.io/badge/Redis-Cache-orange)](https://redis.io/)

## 🎯 **Visão Geral**

**TradeWise** é uma plataforma completa de simulação de trading que permite aos usuários:
- 📊 **Visualizar cotações em tempo real** de criptomoedas
- 🛒 **Executar ordens** de compra e venda com validações reais
- 💼 **Gerenciar portfólios** e acompanhar performance
- 📈 **Analisar históricos** e relatórios detalhados
- ⚡ **Receber notificações** em tempo real sobre mudanças de preço

### 🚀 **Por que este projeto?**

Desenvolvido com o objetivo de demonstrar **competências de desenvolvedor pleno**, aplicando:
- **Arquitetura limpa** e padrões de design
- **Processamento assíncrono** e background jobs
- **Integração com APIs externas** (CoinGecko)
- **Real-time communication** com SignalR
- **Caching estratégico** com Redis
- **Testes automatizados** robustos
- **Git Flow profissional** com branches estruturadas

---

## 🛠️ **Stack Tecnológica**

### **Backend**
- **.NET 9 MVC** - Framework principal
- **C#** - Linguagem de desenvolvimento
- **Entity Framework Core** - ORM e mapeamento de dados
- **ASP.NET Identity** - Autenticação e autorização
- **SignalR** - Comunicação em tempo real
- **Hangfire** - Background jobs e tarefas agendadas
- **RabbitMQ** - Sistema de mensageria
- **Redis** - Cache distribuído

### **Frontend**
- **Razor Pages** - Server-side rendering
- **Bootstrap 5** - Framework CSS responsivo
- **Chart.js** - Gráficos interativos
- **JavaScript ES6+** - Interatividade do cliente
- **SignalR Client** - Conexão real-time

### **Banco de Dados**
- **SQL Server** - Banco principal
- **PostgreSQL** - Suporte alternativo
- **Migrations** - Versionamento do schema

### **Integrações**
- **CoinGecko API** - Cotações de criptomoedas
- **Binance API** - Dados de mercado (opcional)

### **Desenvolvimento**
- **Git Flow** - Estratégia de branches profissional
- **Conventional Commits** - Padronização de commits
- **Pull Requests** - Code review obrigatório
- **Azure DevOps** - CI/CD (planejado)

---

## 🏗️ **Arquitetura do Sistema**

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Frontend      │    │   Controllers   │    │   Services      │
│   (Razor/JS)    │◄──►│   (MVC)        │◄──►│   (Business)    │
└─────────────────┘    └─────────────────┘    └─────────────────┘
                                ▲                       ▲
                                │                       │
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   SignalR Hub   │    │   Background    │    │   External APIs │
│   (Real-time)   │    │   Jobs (Hangfire│    │   (CoinGecko)   │
└─────────────────┘    └─────────────────┘    └─────────────────┘
                                ▲
                                │
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Redis         │    │   Database      │    │   RabbitMQ      │
│   (Cache)       │    │   (SQL Server)  │    │   (Messages)    │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

---

## 🌳 **Git Flow Strategy**

Este projeto segue um **Git Flow profissional** com branches estruturadas:

### **Branches Principais**
- **`main`** 🟢 - Código de produção, sempre estável
- **`develop`** 🟡 - Branch de desenvolvimento e integração

### **Branches de Funcionalidade**
- **`feature/*`** 🔵 - Novas funcionalidades
- **`hotfix/*`** 🔴 - Correções críticas de produção

### **Workflow de Exemplo**
```bash
# Criar nova funcionalidade
git checkout develop
git checkout -b feature/dashboard-implementation

# Desenvolver e commitar
git commit -m "✨ feat(dashboard): add real-time price charts"

# Abrir Pull Request: develop ← feature/dashboard-implementation
```

📚 **Veja o [CONTRIBUTING.md](CONTRIBUTING.md) para o guia completo!**

---

## ✨ **Funcionalidades Principais**

### 🔐 **Sistema de Autenticação**
- [x] Registro e login com ASP.NET Identity
- [x] Perfis de usuário (Admin/User)
- [x] Controle de acesso baseado em roles
- [x] Sessões seguras com cookies

### 📊 **Dashboard Interativo**
- [x] Gráficos de preços em tempo real
- [x] Visão geral da carteira
- [x] Ordens ativas e históricas
- [x] Estatísticas de performance

### 🛒 **Sistema de Ordens**
- [x] Ordens de compra e venda
- [x] Validação de saldo e ativos
- [x] Processamento assíncrono
- [x] Estados: Pendente, Executada, Cancelada

### 💼 **Gestão de Portfólio**
- [x] Visualização de ativos
- [x] Cálculo de P&L em tempo real
- [x] Histórico de transações
- [x] Relatórios detalhados

### ⚡ **Recursos Avançados**
- [x] Updates de preço em tempo real (SignalR)
- [x] Cache inteligente de cotações (Redis)
- [x] Jobs de reconciliação (Hangfire)
- [x] Processamento de filas (RabbitMQ)
- [x] Integração com APIs externas

---

## 📱 **Screenshots**

### Dashboard Principal
*[Screenshot em desenvolvimento]*

### Interface de Trading
*[Screenshot em desenvolvimento]*

### Gestão de Portfólio
*[Screenshot em desenvolvimento]*

---

## 🚀 **Como Executar**

### **Pré-requisitos**
- .NET 9 SDK
- SQL Server ou PostgreSQL
- Redis Server
- RabbitMQ Server (opcional)

### **Configuração**

1. **Clone o repositório**
```bash
git clone https://github.com/marco-lima-1/TradeWise.git
cd TradeWise
```

2. **Configure a connection string**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TradeWiseDB;Trusted_Connection=true;",
    "Redis": "localhost:6379"
  }
}
```

3. **Execute as migrations**
```bash
cd TradeWise.Web
dotnet ef database update
```

4. **Execute o projeto**
```bash
dotnet run
```

5. **Acesse a aplicação**
```
https://localhost:5001
```

---

## 🗃️ **Estrutura do Projeto**

```
TradeWise/
├── 📁 TradeWise.Web/           # Projeto principal MVC
│   ├── 📁 Controllers/         # Controllers MVC
│   ├── 📁 Views/              # Views Razor
│   ├── 📁 Models/             # Modelos de domínio
│   ├── 📁 Services/           # Lógica de negócio
│   ├── 📁 Data/               # DbContext e configurações
│   ├── 📁 Hubs/               # SignalR Hubs
│   ├── 📁 Jobs/               # Background Jobs
│   └── 📁 wwwroot/            # Assets estáticos
├── 📁 TradeWise.Tests/        # Testes unitários
├── 📁 scripts/                # Scripts de banco
├── 📄 README.md               # Documentação
├── 📄 CONTRIBUTING.md         # Guia de contribuição
└── 📄 LICENSE                 # Licença MIT
```

---

## 🧪 **Testes**

```bash
# Executar todos os testes
dotnet test

# Executar com coverage
dotnet test --collect:"XPlat Code Coverage"
```

### **Cobertura Atual**
- [x] Testes de unidade para Services
- [x] Testes de integração para Controllers
- [x] Mocks para APIs externas
- [x] Testes de validação de modelos

---

## 📈 **Roadmap**

### **Fase 1 - Fundação** ✅
- [x] Setup inicial do projeto
- [x] Configuração de banco de dados
- [x] Sistema de autenticação
- [x] Modelos de domínio
- [x] Git Flow implementado

### **Fase 2 - Core Features** 🚧
- [x] Integração com CoinGecko API
- [ ] Sistema de ordens completo
- [ ] Dashboard com gráficos
- [ ] SignalR para real-time

### **Fase 3 - Advanced** 📋
- [ ] Background jobs com Hangfire
- [ ] Cache Redis
- [ ] Sistema de mensageria
- [ ] Testes automatizados

### **Fase 4 - Polish** 📋
- [ ] UI/UX refinado
- [ ] Performance optimization
- [ ] Documentação completa
- [ ] Deploy para produção

---

## 🎯 **Objetivos de Aprendizado**

Este projeto foi desenvolvido para demonstrar:

✅ **Arquitetura Limpa**: Separação clara de responsabilidades  
✅ **Design Patterns**: Repository, Service, Factory patterns  
✅ **Real-time**: SignalR para comunicação bidirecional  
✅ **Background Processing**: Hangfire para jobs assíncronos  
✅ **Caching**: Redis para performance  
✅ **Message Queues**: RabbitMQ para desacoplamento  
✅ **Testing**: Testes unitários e de integração  
✅ **External APIs**: Integração robusta com APIs terceiras  
✅ **Git Flow**: Workflow profissional de desenvolvimento  
✅ **Documentation**: Documentação técnica completa  

---

## 🤝 **Contribuições**

Este é um projeto pessoal para fins de aprendizado e demonstração de habilidades. 

Para contribuir, siga nosso [Guia de Contribuição](CONTRIBUTING.md) que inclui:
- Convenções de commit
- Estratégia de branches
- Templates de Pull Request
- Code review guidelines

---

## 📞 **Contato**

**Marco Lima** - Desenvolvedor Full Stack
- 💼 **LinkedIn**: [Seu perfil LinkedIn]
- 📧 **Email**: [seu-email]
- 🌐 **Portfolio**: [seu-site]

---

## 📄 **Licença**

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

**⭐ Se este projeto te ajudou de alguma forma, considere dar uma estrela!**

---

*Desenvolvido com ❤️ para demonstrar competências de desenvolvimento full-stack focado em backend robusto.* 