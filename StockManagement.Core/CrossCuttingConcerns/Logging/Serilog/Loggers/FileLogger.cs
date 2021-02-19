using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Configuration;
using StockManagement.Core.Utilities.IoC;

namespace StockManagement.Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger()
        {
            var configuration = ServiceHelper.ServiceProvider.GetService<IConfiguration>();

            var logConfig = configuration?.GetSection("SeriLog:FileLogConfiguration")
                .Get<FileLogConfiguration>() ?? throw new Exception("NullOptionsMessage");

            var logFilePath = $"{Directory.GetCurrentDirectory() + logConfig.FolderPath}.txt";

            Logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }

    }
}