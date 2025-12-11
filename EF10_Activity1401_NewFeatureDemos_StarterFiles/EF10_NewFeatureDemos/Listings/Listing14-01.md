using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Data.Common;

public class LoggingCommandInterceptor : DbCommandInterceptor
{
    private readonly ILogger<LoggingCommandInterceptor> _logger;

    public LoggingCommandInterceptor(ILogger<LoggingCommandInterceptor> logger)
    {
        _logger = logger;
    }

    private void LogCommand(string operation, DbCommand command, DbContext? context)
    {
        var contextName = context?.GetType().Name ?? "UnknownContext";
        var contextId = context?.ContextId.ToString() ?? "NoContextId";

        _logger.LogInformation(
            "{Operation} command for {Context} (Id={ContextId})",
            operation, contextName, contextId);

        _logger.LogDebug("SQL: {CommandText}", command.CommandText);

        foreach (DbParameter param in command.Parameters)
        {
            _logger.LogDebug("  {ParamName} = {ParamValue}", param.ParameterName, param.Value);
        }
    }

    public override InterceptionResult<DbCommand> CommandCreating(
            CommandCorrelatedEventData eventData, 
            InterceptionResult<DbCommand> result)
    {
        _logger.LogDebug("About to create a command for {Context}",
            eventData.Context?.GetType().Name);

        // Let EF continue normally
        return base.CommandCreating(eventData, result);
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result)
    {
        LogCommand("Executing NonQuery", command, eventData.Context);
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        LogCommand("Executing NonQueryAsync", command, eventData.Context);
        return await base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        LogCommand("Executing Reader", command, eventData.Context);
        return base.ReaderExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        LogCommand("Executing ReaderAsync", command, eventData.Context);
        return await base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<object> ScalarExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result)
    {
        LogCommand("Executing Scalar", command, eventData.Context);
        return base.ScalarExecuting(command, eventData, result);
    }

    public override async ValueTask<InterceptionResult<object>> ScalarExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result,
        CancellationToken cancellationToken = default)
    {
        LogCommand("Executing ScalarAsync", command, eventData.Context);
        return await base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    }
}