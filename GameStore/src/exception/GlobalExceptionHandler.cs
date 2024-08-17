using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace exception;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> loggerInjected) : IExceptionHandler
{
  private readonly ILogger<GlobalExceptionHandler> logger = loggerInjected;

  public async ValueTask<bool> TryHandleAsync(
  HttpContext httpContext,
  Exception exception,
  CancellationToken cancellationToken)
  {
    var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
    logger.LogError(
      exception,
      "Could not process a request on machine {MachineName}. TraceId: {traceId}",
      Environment.MachineName,
      traceId
    );

    await Results.Problem(
      title: "",
      statusCode: StatusCodes.Status500InternalServerError,
      extensions: new Dictionary<string, object?> {
        {"traceId", traceId}
      }
    ).ExecuteAsync(httpContext);
    return true;
  }

  private static (int statusCode, string title) MapException(Exception exception)
  {
    return exception switch
    {
      _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
    };
  }
}