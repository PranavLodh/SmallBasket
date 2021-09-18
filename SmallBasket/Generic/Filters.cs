using Logger;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallBasket.Generic
{
    public class Filters: ActionFilterAttribute,IExceptionFilter
    {
        private ILog log;
        public Filters()
        {
            log = Log.GetInstance;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            log.LogInformation("OnActionExecuted" + Convert.ToString(context));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            log.LogInformation("Controller :" + Convert.ToString(context.Controller)+ " Content :" + JsonConvert.SerializeObject(context.ActionArguments));                        
        }

        public void OnException(ExceptionContext context)
        {
            try
            {
                
                log.LogException("OnException" + JsonConvert.SerializeObject(context.Exception));
            }
            catch(Exception e)
            {
                log.LogException("Inside Catch Block of OnException" + Convert.ToString(e));
            }
            
        }
    }
}
