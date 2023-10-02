using log4net;
using System.Reflection;
namespace MyEhealth.Infrastructure.Repositories.Logger
{
    public interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message, Exception? ex = null);
    }

    public class Logger : ILogger
    {
        private readonly ILog _logger;
        public Logger()
        {
            this._logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        public void Debug(string message)
        {
            this._logger?.Debug(message);
        }
        public void Info(string message)
        {
            this._logger?.Info(message);
        }
        public void Error(string message, Exception? ex = null)
        {
            this._logger?.Error(message, ex?.InnerException);
        }
    }
}
//using log4net;
//using log4net.Core;
//using log4net.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyEhealth.Infrastructure.Repositories.Logger
//{
//    public class LoggerUtility : ILogger
//    {
//        private readonly ILog _logger;

//        public string Name => throw new NotImplementedException();

//        public ILoggerRepository Repository => throw new NotImplementedException();

//        public LoggerUtility()
//        {
//            this._logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
//        }

//        public void Debug(string message)
//        {
//            this._logger?.Debug(message);
//        }
//        public void Info(string message)
//        {
//            this._logger?.Info(message);
//        }
//        public void Error(string message, Exception? ex = null)
//        {
//            this._logger?.Error(message, ex?.InnerException);
//        }

//        public void Log(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
//        {
//            throw new NotImplementedException();
//        }

//        public void Log(LoggingEvent logEvent)
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsEnabledFor(Level level)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
