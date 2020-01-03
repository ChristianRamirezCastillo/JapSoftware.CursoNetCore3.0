using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ejemplo01.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _log;

        public ErrorController(ILogger<ErrorController> log)
        {
            _log = log;
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var _error = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExcepcionPath = _error.Path;
            ViewBag.ExcepcionMessage = _error.Error.Message;
            ViewBag.ExcepcionStackTrace = _error.Error.StackTrace;

            _log.LogError($"Traza del ERROR: {_error.Error.StackTrace}");

            return View("_Error");
        }       
    }
}