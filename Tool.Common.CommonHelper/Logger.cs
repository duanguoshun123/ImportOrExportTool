using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Common.CommonHelper
{
    public class Logger
    {
        private static log4net.ILog Log { get; set; }

        private static StackTrace Trace { get; set; }
        #region Critical

        public static void Critical(object message, Exception ex)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Fatal(message, ex);
        }

        public static void Critical(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Fatal(message);
        }

        public static void CriticalFormat(string format, params object[] args)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.FatalFormat(format, args);
        }

        #endregion Critical

        #region Error

        public static void Error(object message, Exception ex)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Error(message, ex);
        }

        public static void Error(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Error(message);
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.ErrorFormat(format, args);
        }

        #endregion Error

        #region Warn

        public static void Warn(object message, Exception ex)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Warn(message, ex);
        }

        public static void Warn(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Warn(message);
        }

        public static void WarnFormat(string format, params object[] args)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.WarnFormat(format, args);
        }

        #endregion Warn

        #region Info

        public static void Info(Exception ex, object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Info(message, ex);
        }

        public static void Info(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Info(message);
        }

        public static void Info(string format, params object[] args)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.InfoFormat(format, args);
        }

        #endregion Info

        #region Debug

        public static void Debug(object message, Exception ex)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Debug(message, ex);
        }

        public static void Debug(object message)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.Debug(message);
        }

        public static void DebugFormat(string format, params object[] args)
        {
            Trace = new StackTrace();
            Log = log4net.LogManager.GetLogger(string.Format("{0}.{1}", Trace.GetFrame(1).GetMethod().ReflectedType, Trace.GetFrame(1).GetMethod().Name));
            Log.DebugFormat(format, args);
        }

        #endregion Debug

        //清理日志文件
        public static void CleanLogs(int days)
        {
            try
            {
                string logFilePath = "Logs";
                if (!Directory.Exists(logFilePath)) return;
                DirectoryInfo folder = new DirectoryInfo(logFilePath);
                foreach (FileInfo file in folder.GetFiles("*.txt"))
                {
                    if (!File.Exists(file.FullName)) continue;
                    if (file.CreationTime < DateTime.Now.AddDays(-1 * days))
                        File.Delete(file.FullName);
                }
            }
            catch (Exception ex)
            {
                Logger.Info("清理日志报错", ex.ToString());
            }
        }
    }
}
