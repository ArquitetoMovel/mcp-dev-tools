---
applyTo: '**/*.cs'
---
# Boas Práticas .NET

## Coding standards, domain knowledge, and preferences that AI should follow.

- Use `var` when the type is obvious from the right-hand side of the assignment.
- Prefer `IEnumerable<T>` over `ICollection<T>` or `List<T>` when returning collections from methods.
- Use `async` and `await` for asynchronous programming to avoid blocking the main thread.
- Use `StringBuilder` for concatenating strings in loops or when building large strings.
- Use `using` statements for disposable resources to ensure proper cleanup.
- Prefer `LINQ` for querying collections instead of traditional loops when appropriate.
- Use `nameof` operator to get the name of a variable, type, or member insteadthan hardcoding strings.
- Use `??` operator for null-coalescing to provide default values when dealing with nullable types.
- Use `??=` operator to assign a value only if the variable is null.
- Use `switch` expressions for concise and readable conditional logic.
- Use `IAsyncEnumerable<T>` for asynchronous streaming of data.
- Use `CancellationToken` for methods that support cancellation of asynchronous operations.
- Use `Task.Run` for CPU-bound operations to offload work to a background thread.
- Use `ConfigureAwait(false)` in library code to avoid deadlocks in UI applications.
- Use `IServiceCollection` for dependency injection in ASP.NET Core applications.
- Use `ILogger<T>` for logging instead of `Console.WriteLine` or other direct output methods.
- Use `HttpClient` with `IHttpClientFactory` to manage HTTP requests and avoid socket exhaustion.
- Use `JsonSerializer` for JSON serialization and deserialization instead of `Newtonsoft.Json` unless specific features are needed.
- Use `DataAnnotations` for model validation in ASP.NET Core applications.
- Use `FluentValidation` for more complex validation scenarios.
- Use `IOptions<T>` for configuration settings in ASP.NET Core applications.