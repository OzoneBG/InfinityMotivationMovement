namespace IMM.Web.Controllers.Base
{
    using System;
    using System.Diagnostics;
    using IMM.Web.ViewModels;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    public abstract class BaseController : Controller
    {
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if(exceptionFeature != null)
            {
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                Exception exceptionThatOccurred = exceptionFeature.Error;

                //Get logger from DI
                /*var log = new LoggerConfiguration()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();*/
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}