# 📊 Executive Sales Analytics API

Uma API RESTful robusta desenvolvida em C# (.NET 10) projetada para atuar como um motor de inteligência de vendas. A aplicação ingere dados transacionais, aplica regras de negócios via LINQ para sanitização e fornece endpoints agregados consumidos por um Dashboard executivo (HTML5/Chart.js).

## 🚀 Tecnologias Utilizadas

* **Backend:** C# com ASP.NET Core Web API (.NET 10)
* **Arquitetura:** Padrão MVC e N-Tier (Controllers, Services, Models/DTOs)
* **Tratamento de Dados:** LINQ (Language Integrated Query)
* **Injeção de Dependência:** Nativa do ASP.NET Core
* **Frontend/Dashboard:** HTML5, CSS3, JavaScript (Vanilla API Fetch)
* **Visualização de Dados:** Chart.js

## 📁 Estrutura do Projeto

* `Controllers/`: Camada de exposição HTTP (Endpoints).
* `Services/`: Camada contendo a interface e implementação das regras de negócio e cálculo de KPIs.
* `Models/`: Modelagem de dados brutos e Data Transfer Objects (DTOs) de saída.
* `View/`: Dashboard executivo que consome a API em tempo real.

## ⚙️ Como Executar o Projeto Localmente

### 1. Pré-requisitos
* [Visual Studio 2026](https://visualstudio.microsoft.com/) (ou superior) com o workload de desenvolvimento Web/ASP.NET.
* [.NET 10.0 SDK](https://dotnet.microsoft.com/) instalado.

### 2. Rodando o Backend (API)
1. Clone este repositório:
   ```bash
   git clone [https://github.com/SEU_USUARIO/SalesAnalytics.Api.git](https://github.com/SEU_USUARIO/SalesAnalytics.Api.git)
   ```
2. Abra a solução do projeto (`.sln` ou `.csproj`) no Visual Studio 2026.
3. Pressione `F5` ou clique em **Iniciar** para rodar a API.
4. O servidor Kestrel subirá na sua porta local (geralmente `http://localhost:5194`). Anote essa porta.

### 3. Rodando o Frontend (Dashboard)
1. Navegue até a pasta `View/` do projeto.
2. Abra o arquivo `index.html` em qualquer navegador web.
3. *Nota:* Se a porta do seu servidor ASP.NET for diferente de `5194`, abra o arquivo `index.html` no seu editor de código e atualize a constante `API_BASE_URL` no script JavaScript com a porta correspondente.

## 📡 Endpoints Disponíveis

A API possui endpoints de acesso público (CORS habilitado para execução local):

* **`GET /api/analytics/summary`**
  Retorna o resumo executivo, ignorando vendas canceladas:
  * Faturamento Total
  * Total de Pedidos
  * Ticket Médio

* **`GET /api/analytics/by-category`**
  Retorna a totalização e a porcentagem de vendas agrupadas por categoria de produto (usado para alimentar o gráfico do Dashboard).

## 🧹 Manutenção do Repositório (Troubleshooting)

### Limpeza de Arquivos de Build no Git
Caso os arquivos temporários de compilação do Visual Studio (pastas `bin/` e `obj/`) sejam enviados acidentalmente para o repositório remoto, o repositório pode ficar desnecessariamente pesado. 

Para limpar o cache do Git e remover essas pastas do rastreamento sem apagar os arquivos da sua máquina local, siga os passos abaixo no terminal:

1. **Limpe o cache das pastas ignoradas:**
   ```bash
   git rm -r --cached bin/
   git rm -r --cached obj/
   ```

2. **Crie o commit de correção:**
   ```bash
   git commit -m "chore: remove pastas bin e obj do rastreio do git"
   ```

3. **Envie a atualização para o GitHub:**
   ```bash
   git push origin master
   ```

> **Aviso:** Certifique-se de que o seu arquivo `.gitignore` (padrão para projetos .NET) está configurado corretamente na raiz do projeto para evitar que essas pastas sejam rastreadas novamente nos próximos commits.

---
📝 **Licença**
Distribuído sob a Licença MIT.