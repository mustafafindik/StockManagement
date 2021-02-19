﻿using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace StockManagement.Core.CrossCuttingConcerns.Logging.Serilog
{
    /// <summary>
    /// Base Olarak Kullanılan Sınıf Bu FileLogger, MsSqlLogger..
    /// </summary>
    public abstract class LoggerServiceBase
    {
        public ILogger Logger;
        public void Verbose(string message) => Logger.Verbose(message);
        public void Fatal(string message) => Logger.Fatal(message);
        public void Info(string message) => Logger.Information(message);
        public void Warn(string message) => Logger.Warning(message);
        public void Debug(string message) => Logger.Debug(message);
        public void Error(string message) => Logger.Error(message);
    }
}
