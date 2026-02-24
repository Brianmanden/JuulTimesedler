c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE>dotnet watch
dotnet watch 🔥 Hot reload enabled. For a list of supported edits, see https://aka.ms/dotnet/hot-reload.
dotnet watch 💡 Press Ctrl+R to restart.
dotnet watch 🔨 Building c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj ...
dotnet watch 🔨 Build succeeded: c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj
dotnet watch ⚠ c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj : warning NU1902: Package 'Umbraco.Cms' 16.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-54mj-vcvj-q3v5
dotnet watch ⚠ c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj : warning NU1902: Package 'Umbraco.Cms' 16.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-54mj-vcvj-q3v5
dotnet watch ⚠ c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj : warning NU1902: Package 'Umbraco.Cms' 16.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-54mj-vcvj-q3v5
dotnet watch ⚠ c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj : warning NU1902: Package 'Umbraco.Cms' 16.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-54mj-vcvj-q3v5
Using launch settings from c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\Properties\launchSettings.json...
[18:37:21 INF] Acquiring MainDom.
[18:37:21 INF] Acquired MainDom.
[18:37:22 INF] Starting recurring background jobs hosted services
[18:37:22 INF] Starting background hosted service for OpenIddictCleanupJob
[18:37:22 INF] Starting background hosted service for HealthCheckNotifierJob
[18:37:22 INF] Starting background hosted service for LogScrubberJob
[18:37:22 INF] Starting background hosted service for ContentVersionCleanupJob
[18:37:22 INF] Starting background hosted service for ScheduledPublishingJob
[18:37:22 INF] Starting background hosted service for TempFileCleanupJob
[18:37:22 INF] Starting background hosted service for TemporaryFileCleanupJob
[18:37:22 INF] Starting background hosted service for InstructionProcessJob
[18:37:22 INF] Starting background hosted service for TouchServerJob
[18:37:22 INF] Starting background hosted service for WebhookFiring
[18:37:22 INF] Starting background hosted service for WebhookLoggingCleanup
[18:37:22 INF] Starting background hosted service for ReportSiteJob
[18:37:22 INF] Completed starting recurring background jobs hosted services
[18:37:22 WRN] The ASP.NET Core developer certificate is not trusted. For information about trusting the ASP.NET Core developer certificate, see https://aka.ms/aspnet/https-trust-dev-cert
[18:37:22 INF] Now listening on: https://localhost:44371
[18:37:22 INF] Now listening on: http://localhost:5284
[18:37:22 INF] Application started. Press Ctrl+C to shut down.
[18:37:22 INF] Hosting environment: Development
[18:37:22 INF] Content root path: c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE
dotnet watch ⚠ msbuild: [Failure] Msbuild failed when processing the file 'c:\PROJEKTER\JuulTimesedler\JuulTimesedler_BE\JuulTimesedler_BE.csproj' with message: Package 'Umbraco.Cms' 16.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-54mj-vcvj-q3v5
[18:37:53 INF] Checking if FilePermissionsStep requires execution
[18:37:53 INF] Running FilePermissionsStep
[18:37:53 INF] Finished FilePermissionsStep
[18:37:53 INF] Checking if TelemetryIdentifierStep requires execution
[18:37:53 INF] Running TelemetryIdentifierStep
[18:37:53 ERR] Couldn't update config files with a telemetry site identifier
System.Text.Json.JsonReaderException: The JSON object contains a trailing comma at the end which is not supported in this mode. Change the reader options. LineNumber: 31 | BytePositionInLine: 0.
   at System.Text.Json.ThrowHelper.ThrowJsonReaderException(Utf8JsonReader& json, ExceptionResource resource, Byte nextByte, ReadOnlySpan`1 bytes)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenUntilAfterAllCommentsAreSkipped(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextToken(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenOrRollback(Byte marker)
   at System.Text.Json.Utf8JsonReader.ReadSingleSegment()
   at System.Text.Json.Utf8JsonReader.Read()
   at System.Text.Json.JsonDocument.Parse(ReadOnlySpan`1 utf8JsonSpan, JsonReaderOptions readerOptions, MetadataDb& database, StackRowStack& stack)
   at System.Text.Json.JsonDocument.ParseUnrented(ReadOnlyMemory`1 utf8Json, JsonReaderOptions readerOptions, JsonTokenType tokenType)
   at System.Text.Json.JsonDocument.ParseAsyncCoreUnrented(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
   at System.Text.Json.Nodes.JsonNode.ParseAsync(Stream utf8Json, Nullable`1 nodeOptions, JsonDocumentOptions documentOptions, CancellationToken cancellationToken)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.GetJsonNodeAsync(JsonConfigurationProvider provider)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.CreateOrUpdateConfigValueAsync(String itemPath, Object value)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.SetGlobalIdAsync(String id)
   at Umbraco.Cms.Core.Telemetry.SiteIdentifierService.TryCreateSiteIdentifier(Guid& createdGuid)
[18:37:53 INF] Finished TelemetryIdentifierStep
[18:37:53 INF] Checking if DatabaseConfigureStep requires execution
[18:37:53 INF] Running DatabaseConfigureStep
[18:37:53 ERR] Encountered an unexpected error when running the install steps
System.Text.Json.JsonReaderException: The JSON object contains a trailing comma at the end which is not supported in this mode. Change the reader options. LineNumber: 31 | BytePositionInLine: 0.
   at System.Text.Json.ThrowHelper.ThrowJsonReaderException(Utf8JsonReader& json, ExceptionResource resource, Byte nextByte, ReadOnlySpan`1 bytes)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenUntilAfterAllCommentsAreSkipped(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextToken(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenOrRollback(Byte marker)
   at System.Text.Json.Utf8JsonReader.ReadSingleSegment()
   at System.Text.Json.Utf8JsonReader.Read()
   at System.Text.Json.JsonDocument.Parse(ReadOnlySpan`1 utf8JsonSpan, JsonReaderOptions readerOptions, MetadataDb& database, StackRowStack& stack)
   at System.Text.Json.JsonDocument.ParseUnrented(ReadOnlyMemory`1 utf8Json, JsonReaderOptions readerOptions, JsonTokenType tokenType)
   at System.Text.Json.JsonDocument.ParseAsyncCoreUnrented(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
   at System.Text.Json.Nodes.JsonNode.ParseAsync(Stream utf8Json, Nullable`1 nodeOptions, JsonDocumentOptions documentOptions, CancellationToken cancellationToken)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.GetJsonNodeAsync(JsonConfigurationProvider provider)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.SaveConnectionStringAsync(String connectionString, String providerName)
   at Umbraco.Cms.Infrastructure.Migrations.Install.DatabaseBuilder.ConfigureDatabaseConnection(DatabaseModel databaseSettings, Boolean isTrialRun)
   at Umbraco.Cms.Infrastructure.Installer.Steps.DatabaseConfigureStep.ExecuteAsync(InstallData model)
   at Umbraco.Cms.Core.Services.Installer.InstallService.RunStepsAsync(InstallData model)
   at Umbraco.Cms.Core.Services.Installer.InstallService.InstallAsync(InstallData model)
[18:37:53 ERR] An unhandled exception has occurred while executing the request.
System.Text.Json.JsonReaderException: The JSON object contains a trailing comma at the end which is not supported in this mode. Change the reader options. LineNumber: 31 | BytePositionInLine: 0.
   at System.Text.Json.ThrowHelper.ThrowJsonReaderException(Utf8JsonReader& json, ExceptionResource resource, Byte nextByte, ReadOnlySpan`1 bytes)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenUntilAfterAllCommentsAreSkipped(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextToken(Byte marker)
   at System.Text.Json.Utf8JsonReader.ConsumeNextTokenOrRollback(Byte marker)
   at System.Text.Json.Utf8JsonReader.ReadSingleSegment()
   at System.Text.Json.Utf8JsonReader.Read()
   at System.Text.Json.JsonDocument.Parse(ReadOnlySpan`1 utf8JsonSpan, JsonReaderOptions readerOptions, MetadataDb& database, StackRowStack& stack)
   at System.Text.Json.JsonDocument.ParseUnrented(ReadOnlyMemory`1 utf8Json, JsonReaderOptions readerOptions, JsonTokenType tokenType)
   at System.Text.Json.JsonDocument.ParseAsyncCoreUnrented(Stream utf8Json, JsonDocumentOptions options, CancellationToken cancellationToken)
   at System.Text.Json.Nodes.JsonNode.ParseAsync(Stream utf8Json, Nullable`1 nodeOptions, JsonDocumentOptions documentOptions, CancellationToken cancellationToken)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.GetJsonNodeAsync(JsonConfigurationProvider provider)
   at Umbraco.Cms.Infrastructure.Configuration.JsonConfigManipulator.SaveConnectionStringAsync(String connectionString, String providerName)
   at Umbraco.Cms.Infrastructure.Migrations.Install.DatabaseBuilder.ConfigureDatabaseConnection(DatabaseModel databaseSettings, Boolean isTrialRun)
   at Umbraco.Cms.Infrastructure.Installer.Steps.DatabaseConfigureStep.ExecuteAsync(InstallData model)
   at Umbraco.Cms.Core.Services.Installer.InstallService.RunStepsAsync(InstallData model)
   at Umbraco.Cms.Core.Services.Installer.InstallService.InstallAsync(InstallData model)
   at Umbraco.Cms.Api.Management.Controllers.Install.SetupInstallController.Setup(CancellationToken cancellationToken, InstallRequestModel installData)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResourceFilter>g__Awaited|25_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResourceExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeFilterPipelineAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Umbraco.Cms.Web.Common.Middleware.BasicAuthenticationMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Umbraco.Cms.Api.Management.Middleware.BackOfficeExternalLoginProviderErrorMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Session.SessionMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Session.SessionMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at StackExchange.Profiling.MiniProfilerMiddleware.Invoke(HttpContext context) in C:\projects\dotnet\src\MiniProfiler.AspNetCore\MiniProfilerMiddleware.cs:line 112
   at Umbraco.Cms.Web.Common.Middleware.UmbracoRequestMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Umbraco.Cms.Web.Common.Middleware.UmbracoRequestMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Umbraco.Cms.Web.Common.Middleware.PreviewAuthenticationMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Umbraco.Cms.Web.Common.Middleware.UmbracoRequestLoggingMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
   at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddlewareImpl.<Invoke>g__Awaited|10_0(ExceptionHandlerMiddlewareImpl middleware, HttpContext context, Task task)
[18:39:16 INF] Application is shutting down...
dotnet watch 🛑 Shutdown requested. Press Ctrl+C again to force exit.
[18:39:16 INF] Stopping (environment)
[18:39:16 INF] Released (environment)
[18:39:16 INF] Queued Hosted Service is stopping.
[18:39:16 INF] Stopping recurring background jobs hosted services
[18:39:16 INF] Stopping background hosted service for OpenIddictCleanupJob
[18:39:16 INF] Stopping background hosted service for HealthCheckNotifierJob
[18:39:16 INF] Stopping background hosted service for LogScrubberJob
[18:39:16 INF] Stopping background hosted service for ContentVersionCleanupJob
[18:39:16 INF] Stopping background hosted service for ScheduledPublishingJob
[18:39:16 INF] Stopping background hosted service for TempFileCleanupJob
[18:39:16 INF] Stopping background hosted service for TemporaryFileCleanupJob
[18:39:16 INF] Stopping background hosted service for InstructionProcessJob
[18:39:16 INF] Stopping background hosted service for TouchServerJob
[18:39:16 INF] Stopping background hosted service for WebhookFiring
[18:39:16 INF] Stopping background hosted service for WebhookLoggingCleanup
[18:39:16 INF] Stopping background hosted service for ReportSiteJob
[18:39:16 INF] Completed stopping recurring background jobs hosted services
dotnet watch ⌚ [JuulTimesedler_BE (net9.0)] Exited