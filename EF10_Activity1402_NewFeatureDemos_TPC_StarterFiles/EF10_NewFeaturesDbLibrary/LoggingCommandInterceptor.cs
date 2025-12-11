namespace EF10_NewFeaturesDbLibrary;

using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class LoggingCommandInterceptor : DbCommandInterceptor
{
    private readonly ILogger<LoggingCommandInterceptor> _logger;

    public LoggingCommandInterceptor(ILogger<LoggingCommandInterceptor> logger)
    {
        _logger = logger;
    }

    public override InterceptionResult<DbCommand> CommandCreating(
        CommandCorrelatedEventData eventData,
        InterceptionResult<DbCommand> result)
    {
        _logger.LogInformation("Creating command for context {Context}", eventData.Context?.GetType().Name);
        return base.CommandCreating(eventData, result);
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result)
    {
        _logger.LogInformation("Executing NonQuery: {CommandText}", command.CommandText);
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Executing NonQueryAsync: {CommandText}", command.CommandText);
        return await base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }
}

