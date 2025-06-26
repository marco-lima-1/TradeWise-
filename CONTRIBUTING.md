# 🤝 Guia de Contribuição - TradeWise

## 🌳 **Estratégia de Branches**

Este projeto utiliza **Git Flow** para organizar o desenvolvimento de forma profissional e escalável.

### **🔧 Estrutura de Branches**

```
main (🟢 Produção)
├── develop (🟡 Desenvolvimento)
│   ├── feature/dashboard-implementation (🔵 Feature)
│   ├── feature/order-service (🔵 Feature)
│   ├── feature/signalr-integration (🔵 Feature)
│   └── hotfix/critical-bug-fix (🔴 Hotfix)
```

---

## 📋 **Tipos de Branches**

### **🟢 `main`** - Branch Principal
- **Propósito**: Código estável e pronto para produção
- **Proteção**: Apenas via Pull Request
- **Deploy**: Automático para produção
- **Convenção**: Sempre estável

### **🟡 `develop`** - Branch de Desenvolvimento  
- **Propósito**: Integração de novas features
- **Merge**: Features completas e testadas
- **Base**: Para criar novas feature branches
- **Testes**: CI/CD rodando automaticamente

### **🔵 `feature/*`** - Branches de Funcionalidade
- **Convenção**: `feature/nome-da-funcionalidade`
- **Base**: Criada a partir de `develop`
- **Merge**: Via Pull Request para `develop`
- **Ciclo de vida**: Deletada após merge

### **🔴 `hotfix/*`** - Correções Críticas
- **Convenção**: `hotfix/descricao-do-bug`
- **Base**: Criada a partir de `main`
- **Merge**: Para `main` E `develop`
- **Uso**: Apenas bugs críticos em produção

---

## 🚀 **Workflow de Desenvolvimento**

### **1. 🆕 Criar Nova Funcionalidade**

```bash
# 1. Atualizar develop local
git checkout develop
git pull origin develop

# 2. Criar feature branch
git checkout -b feature/dashboard-implementation

# 3. Desenvolver e fazer commits
git add .
git commit -m "✨ feat: implement dashboard with real-time charts"

# 4. Push da feature
git push -u origin feature/dashboard-implementation

# 5. Abrir Pull Request no GitHub
# develop ← feature/dashboard-implementation
```

### **2. 🔄 Finalizar Feature**

```bash  
# 1. Atualizar develop local
git checkout develop
git pull origin develop

# 2. Merge da feature (após aprovação do PR)
git merge feature/dashboard-implementation

# 3. Deletar feature branch
git branch -d feature/dashboard-implementation
git push origin --delete feature/dashboard-implementation

# 4. Push do develop atualizado
git push origin develop
```

### **3. 🎯 Release para Produção**

```bash
# 1. Criar Pull Request
# main ← develop

# 2. Após aprovação e testes, fazer merge
git checkout main
git pull origin main

# 3. Tag da versão
git tag -a v1.0.0 -m "🚀 Release v1.0.0: Dashboard e Trading System"
git push origin v1.0.0
```

### **4. 🚨 Hotfix Crítico**

```bash
# 1. Criar hotfix a partir da main
git checkout main
git pull origin main
git checkout -b hotfix/critical-auth-bug

# 2. Corrigir o bug
git add .
git commit -m "🐛 hotfix: fix critical authentication vulnerability"

# 3. Push e PR para main
git push -u origin hotfix/critical-auth-bug
# Criar PR: main ← hotfix/critical-auth-bug

# 4. Após merge, sincronizar develop
git checkout develop
git merge main
git push origin develop
```

---

## 📝 **Convenções de Commit**

### **🎨 Formato Padrão**
```
<tipo>(escopo): <descrição clara>

<corpo opcional>

<footer opcional>
```

### **🏷️ Tipos de Commit**

| Emoji | Tipo | Descrição |
|-------|------|-----------|
| ✨ | `feat` | Nova funcionalidade |
| 🐛 | `fix` | Correção de bug |
| 📚 | `docs` | Documentação |
| 🎨 | `style` | Formatação, espaços |
| ♻️ | `refactor` | Refatoração de código |
| 🚀 | `perf` | Melhoria de performance |
| ✅ | `test` | Adição de testes |
| 🔧 | `chore` | Tarefas auxiliares |
| 🔒 | `security` | Segurança |

### **📖 Exemplos de Commits**

```bash
# ✨ Nova funcionalidade
git commit -m "✨ feat(dashboard): add real-time price charts with Chart.js"

# 🐛 Correção de bug  
git commit -m "🐛 fix(orders): validate user balance before order creation"

# 📚 Documentação
git commit -m "📚 docs(api): add Swagger documentation for orders endpoint"

# ♻️ Refatoração
git commit -m "♻️ refactor(services): implement repository pattern for data access"

# 🔧 Configuração
git commit -m "🔧 chore(deps): update Entity Framework to latest version"
```

---

## ✅ **Checklist para Pull Requests**

### **🔍 Antes de Abrir o PR**

- [ ] ✅ **Código testado** localmente
- [ ] 🧪 **Testes unitários** passando
- [ ] 📱 **Interface responsiva** (se aplicável)  
- [ ] 🔒 **Sem dados sensíveis** (passwords, keys)
- [ ] 📚 **Documentação** atualizada
- [ ] 🎨 **Padrões de código** seguidos
- [ ] ♻️ **Code review** próprio feito

### **📋 Template de PR**

```markdown
# 🚀 [FEATURE] Dashboard com Gráficos em Tempo Real

## 📝 Descrição
Implementação do dashboard principal com gráficos de preços em tempo real usando Chart.js e SignalR.

## ✨ Funcionalidades Adicionadas
- [ ] Gráficos de preços em tempo real
- [ ] Integração com SignalR Hub
- [ ] Responsividade mobile
- [ ] Cache de dados com Redis

## 🧪 Como Testar
1. Execute o projeto
2. Acesse `/dashboard`
3. Verifique se os gráficos atualizam automaticamente
4. Teste em diferentes tamanhos de tela

## 📸 Screenshots
[Adicionar screenshots do dashboard]

## 🔗 Issues Relacionadas
- Closes #123
- Related to #456
```

---

## 🏆 **Boas Práticas**

### **💡 Commits**
- **Frequentes**: Commits pequenos e frequentes
- **Atômicos**: Um commit = uma alteração lógica
- **Descritivos**: Mensagens claras sobre o que foi feito
- **Emojis**: Para facilitar identificação visual

### **🌿 Branches**
- **Nomes descritivos**: `feature/user-authentication`
- **Curta duração**: Feature branches devem ser mergeadas rapidamente
- **Atualização**: Sempre atualizar com develop antes do merge
- **Limpeza**: Deletar branches após merge

### **🔄 Pull Requests**
- **Descrição detalhada**: O que, por que e como
- **Revisão**: Sempre solicitar code review
- **Testes**: Incluir evidências de testes
- **Documentação**: Atualizar docs se necessário

---

## 🎯 **Roadmap de Branches**

### **🚧 Em Desenvolvimento**
- `feature/price-service-integration`
- `feature/order-management-system`
- `feature/user-portfolio-view`

### **📋 Próximas Features**
- `feature/hangfire-background-jobs`
- `feature/redis-caching-layer`
- `feature/unit-tests-implementation`
- `feature/azure-deployment`

### **🔮 Futuras Melhorias**
- `feature/mobile-app-support`
- `feature/advanced-charting`
- `feature/notification-system`

---

## 🤝 **Code Review Guidelines**

### **👀 O que Revisar**
- [ ] **Lógica de negócio** está correta
- [ ] **Performance** não foi impactada
- [ ] **Segurança** está mantida
- [ ] **Testes** cobrem cenários importantes
- [ ] **Documentação** está atualizada
- [ ] **Padrões** do projeto seguidos

### **💬 Como Dar Feedback**
- **Construtivo**: Foque em melhorias, não problemas pessoais
- **Específico**: Aponte linhas e sugira soluções
- **Educativo**: Explique o "porquê" das sugestões
- **Reconhecimento**: Destaque pontos positivos também

---

**💡 Lembre-se**: Este Git Flow garante qualidade, rastreabilidade e trabalho em equipe eficiente!

*Desenvolvido com ❤️ para demonstrar competências de dev pleno* 