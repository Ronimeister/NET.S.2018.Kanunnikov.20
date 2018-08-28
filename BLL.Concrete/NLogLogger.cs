using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class than implement logger functionality using NLog
    /// </summary>
    public class NLogLogger : ILogger
    {
        #region Constants and readonly fields
        private const string LOGGER_FILE_NAME = "log.txt";

        private readonly NLog.Logger _logger;
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="NLogLogger"/> class
        /// </summary>
        public NLogLogger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = LOGGER_FILE_NAME };

            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }
        #endregion

        #region Public API
        /// <summary>
        /// Log debug data
        /// </summary>
        /// <param name="message">info message</param>
        public void Debug(string message) => _logger.Debug(message);

        /// <summary>
        /// Log error data
        /// </summary>
        /// <param name="message">info message</param>
        public void Error(string message) => _logger.Error(message);

        /// <summary>
        /// Log fatal data
        /// </summary>
        /// <param name="message">info message</param>
        public void Fatal(string message) => _logger.Fatal(message);

        /// <summary>
        /// Log info data
        /// </summary>
        /// <param name="message">info message</param>
        public void Info(string message) => _logger.Info(message);

        /// <summary>
        /// Log warn data
        /// </summary>
        /// <param name="message">info message</param>
        public void Warn(string message) => _logger.Warn(message);
        #endregion
    }
}
