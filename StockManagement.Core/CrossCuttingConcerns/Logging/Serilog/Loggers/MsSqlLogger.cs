using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Configuration;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
	public class MsSqlLogger : LoggerServiceBase
    {
        public MsSqlLogger()
        {
            var configuration = ServiceHelper.ServiceProvider.GetService<IConfiguration>();

            var logConfig = configuration?.GetSection("SeriLog:MsSqlConfiguration")
                .Get<MsSqlConfiguration>() ?? throw new Exception("Utilities.Messages.SerilogMessages.NullOptionsMessage");
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true };

            var seriLogConfig = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString: logConfig.ConnectionString, sinkOptions: sinkOpts)
                .CreateLogger();
            Logger = seriLogConfig;
        }
    }
}
