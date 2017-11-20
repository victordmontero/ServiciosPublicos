using log4net.Appender;
using ServiciosPublicos.DataAccess.Modelos;
using ServiciosPublicos.DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosPublicos.Logger
{
    public class PostgresAppender : AppenderSkeleton
    {

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            var repo = new RepositorioLog();
            repo.Agregar(new Log()
            {
                Thread = loggingEvent.ThreadName,
                Level = loggingEvent.Level.Value.ToString(),
                Message = loggingEvent.RenderedMessage,
                Date = loggingEvent.TimeStamp,
                Exception = loggingEvent.GetExceptionString(),
                Logger = loggingEvent.LoggerName,
                IP = loggingEvent.LookupProperty("IP").ToString()
            });

        }
    }
}
