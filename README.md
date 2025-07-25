* src/
	* Application/      # Business logic layer (services, DTOs, interfaces, use cases).
	* Domain/           # Pure business logic (domain rules, abstractions).
	* Infrastructure/   # Infrastructure/persistence layer (EF Core, databases, external services).
	* WebAPI/           # Presentation layer (controllers, HTTP, DI configuration).

* Clean Architecture Flow:
	* Request -> Controller -> Service -> Repository -> EF Core -> PostgreSQL.