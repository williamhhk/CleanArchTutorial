using Serilog;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Service.Common
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult CreateHttpResponse(Func<IHttpActionResult> function)
        {
            var _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
            _logger.Information("Inside ApiControllerBase");
            IHttpActionResult response = null;
            try
            {
                response = function.Invoke();
            }
            catch (Exception ex)
            {
                response = BadRequest(ex.Message);
                _logger.Information("Something went wrong here");
            }
            return response;
        }

        protected async Task<IHttpActionResult> CreateHttpResponseAsync(Func<IHttpActionResult> function)
        {
            var _logger = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger)) as ILogger;
            _logger.Information("Inside ApiControllerBase");
            try
            {
                return await Task.FromResult(function.Invoke());
            }
            catch (Exception ex)
            {
                _logger.Information("Something went wrong here");
                return await Task.FromResult(BadRequest(ex.Message));
            }
        }

    }
}
