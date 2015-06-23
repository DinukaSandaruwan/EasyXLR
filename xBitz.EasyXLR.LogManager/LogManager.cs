using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.LogManager
{
    public class LogManager : ILogger
    {
        #region Member Variables

        private const string UserID = "UserID";
        private const string Locations = "Locations";
        private readonly static Type _thisClassFullName = typeof(LogManager);

        //To hold based details
        private ILog stringLog;

        #endregion

        #region Constructors

        public LogManager(System.Type type)
        {
            try
            {
                //Hold logger type information
                stringLog = log4net.LogManager.Exists(type.FullName);

                if (stringLog == null)
                {
                    stringLog = log4net.LogManager.GetLogger(type.FullName);
                }
                //Store the Locations details in the file
                MDC.Set(Locations, stringLog.Logger.Name);
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Public Methods

        #region ILogger DebugFormat Implementation

        /// <summary>
        /// Write the debug details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        // <param name="message">String message to log</param>
        /// <param name="param">Param object for the string message</param>
        public void DebugFormat(Context context, string message, params object[] param)
        {
            try
            {
                //checking the level 
                if (stringLog.IsDebugEnabled)
                {
                    //set the username for logfile
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Debug,
                        message, param, null, context));
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Write the debug details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="exception">Exception to log</param>
        public void DebugFormat(Context context, Exception exception)
        {
            try
            {
                if (stringLog.IsDebugEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Debug,
                        exception.Message, null, exception, context));
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region  ILogger ErrorFormat Implementation

        /// <summary>
        /// Write the  Error details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="message">String message to log</param>
        /// <param name="param">Param object for the string message</param>
        public void ErrorFormat(Context context, string message, params object[] param)
        {
            try
            {
                if (stringLog.IsErrorEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Error,
                        message, param, null, context));
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ErrorFormat(Context context, string message, Exception exception)
        {
            try
            {
                if (stringLog.IsErrorEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Error,
                        message + Environment.NewLine + Environment.NewLine + "***" + exception.Message, null, exception, context));
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Write the Error details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="exception">Exception to log</param>
        public void ErrorFormat(Context context, Exception exception)
        {
            try
            {
                if (stringLog.IsErrorEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Error,
                        exception.Message, null, exception, context));
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region ILogger InfoFormat Implementation

        /// <summary>
        /// Write the information into log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="message">String message to log</param>
        /// <param name="param">Param object for the string message</param>
        public void InfoFormat(Context context, string message, params object[] param)
        {
            try
            {
                if (stringLog.IsInfoEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Info,
                        message, param, null, context));
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Write the information in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="exception">Exception to log</param>
        public void InfoFormat(Context context, Exception exception)
        {
            try
            {
                if (stringLog.IsInfoEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Info,
                        exception.Message, null, exception, context));
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region ILogger WarnFormat Implementation

        /// <summary>
        /// Write the warning details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="message">String message to log</param>
        /// <param name="param">Param object for the string message</param>
        public void WarnFormat(Context context, string message, params object[] param)
        {
            try
            {
                if (stringLog.IsWarnEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Warn,
                        message, param, null, context));
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Write the warning details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="exception">Exception to log</param>
        public void WarnFormat(Context context, Exception exception)
        {
            try
            {
                if (stringLog.IsWarnEnabled)
                {
                    stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Warn,
                        exception.Message, null, exception, context));
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region ILogger FatalFormat Implementation

        /// <summary>
        /// Write the  fatal details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="message">String message to log</param>
        /// <param name="param">Param object for the string message</param>
        public void FatalFormat(Context context, string message, params object[] param)
        {
            try
            {
                stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Fatal,
                    message, param, null, context));
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Write the fatal details in the log file
        /// </summary>
        /// <param name="context">User information</param>
        /// <param name="exception">Exception to log</param>
        public void FatalFormat(Context context, Exception exception)
        {
            try
            {
                stringLog.Logger.Log(ConstructLoggingEvent(log4net.Core.Level.Fatal,
                    exception.Message, null, exception, context));
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Used internally to construct logging events.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel"/> for the logging event.</param>
        /// <param name="message">The message for the logging event.</param>
        /// <param name="ex">The exception for the logging event.</param>
        /// <param name="context">Context to get the user name</param>
        /// <param name="param">parameters for message string formatting</param>
        /// <returns>The log4net logging event that represents the newly
        /// created log entry.</returns>
        private log4net.Core.LoggingEvent ConstructLoggingEvent(log4net.Core.Level level,
            string message, object[] param, Exception ex, Context context)
        {


            if (context != null)
                log4net.MDC.Set(UserID, context.UserID);
            if (null != param)
                message = string.Format(message, param);
            // create logging event for this log entry
            LoggingEvent le = new LoggingEvent(_thisClassFullName,
                stringLog.Logger.Repository, stringLog.Logger.Name, level, message, ex);
            // do we have an exception that we need to handle?
            if (ex != null)
            {

            }
            return le;
        }
        #endregion

    }
}
