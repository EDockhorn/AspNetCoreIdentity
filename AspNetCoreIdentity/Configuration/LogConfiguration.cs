using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Text;

namespace AspNetCoreIdentity.Configuration
{
    public static class LogConfiguration
    {
        public static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Listeners.Add(new RequestLogsApiListener
            (
                new Application(configuration["KissLog.OrganizationId"], configuration["KissLog.ApplicationId"])
            )
            { ApiUrl = configuration["KissLog.ApiUrl"] });
        }
        public static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            options.Options.AppendExceptionDetails((Exception ex) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ex is System.NullReferenceException nullRefException)
                        sb.AppendLine("Important: check for null references");

                    return sb.ToString();
                });

            // KissLog internal logs
            options.InternalLog = (message) => Debug.WriteLine(message);

            LogConfiguration.RegisterKissLogListeners(options, configuration);
        }
    }
}
