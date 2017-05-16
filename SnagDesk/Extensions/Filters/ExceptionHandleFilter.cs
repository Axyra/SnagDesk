using System.Web.Http.Filters;
using NLog;

namespace SnagDesk.Extensions.Filters
{
    public class ExceptionHandleFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ExceptionHandleFilter()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Fatal(actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
    }
}