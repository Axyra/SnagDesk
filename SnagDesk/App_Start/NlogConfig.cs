using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SnagDesk
{
    public static class NlogConfig
    {
        public static void Configure()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget
            {
                Name = "File",
                FileName = "${basedir}/log.txt",
                Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss.fff} " +
                         "${aspnet-mvc-controller} " +
                         "${aspnet-mvc-action} " +
                         "${exception:format=toString,Data:maxInnerExceptionLevel=5}",
                FileAttributes = Win32FileAttributes.ReadOnly,
                Encoding = Encoding.Unicode
            };
            var rule = new LoggingRule("*", LogLevel.Error, target);

            config.AddTarget(target);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }
    }
}