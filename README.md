# E-Commerce API

A backend E-Commerce REST API built with .NET 10, following Clean Architecture and CQRS.

Still a work in progress — I'm using this project to practice and apply backend patterns I've been learning (Clean Architecture, CQRS, caching, etc.).

---

## Tech Stack

- **.NET 10** — Minimal APIs
- **Entity Framework Core** — Data access & Migrations
- **MediatR** — CQRS implementation
- **FluentValidation** — Request validation
- **Mapster** — Object mapping
- **Redis** — Caching _(in progress)_

---

## Features

### Architecture & Patterns

- Clean Architecture (Domain, Application, Infrastructure, API layers)
- CQRS using MediatR
- Result Pattern for business error handling (instead of exceptions)
- Specification Pattern for querying
- Repository Pattern

### Cross-Cutting Concerns

- Global Exception Handling middleware
- FluentValidation integrated via MediatR Pipeline Behavior
- Auditing via EF Core Interceptors (auto-tracks created/modified fields)
- API Versioning
- Rate Limiting
- Health Checks

### API Layer

- Minimal API Endpoints
- Generic `ApiResponse<T>` wrapper for consistent responses
- Pagination support

### Data

- EF Core with Migrations
- Database Seeding

---

## Architecture

The project follows Clean Architecture, split into 4 layers:

```
Ecommerce.Domain          → Entities, Specifications, Result/Error types (no dependencies)
Ecommerce.Application     → CQRS (Queries/Handlers via MediatR), Validation, Mapping
Ecommerce.Infrastructure  → EF Core, Repositories, Query Services, Health Checks, Interceptors
Ecommerce.API             → Minimal API Endpoints, Middleware, ApiResponse wrapper
```

Each layer only depends on the ones inside it — the Domain layer doesn't know anything about EF Core, the database, or the web framework.

---

## Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server (or update the connection string for your provider)
- Redis _(optional, required once caching is finalized)_

### Setup

1. Clone the repository

   ```bash
   git clone https://github.com/menna-saed/E-commerce-API.git
   cd E-commerce-API
   ```

2. Set up your connection string using User Secrets

   ```bash
   cd Ecommerce.API
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your-connection-string-here"
   ```

3. Apply migrations

   ```bash
   dotnet ef database update
   ```

4. Run the project
   ```bash
   dotnet run
   ```

---

## Project Status
Completed:
   Redis Caching
   Authentication & Authorization (JWT)
   
Planned next:
- [ ] Unit & Integration Tests
- [ ] Docker support
- [ ] CI/CD pipeline

---

## Contact

Menna Saed https://github.com/menna-saed
