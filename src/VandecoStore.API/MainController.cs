using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VandecoStore.Core
{
    [ApiController]
    public class MainController : ControllerBase
    {

        public MainController()
        {
        }

        protected ActionResult CustomResponse(object? obj = null)
        {
     
            return Ok(new
            {
                data = obj,
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        { 
            return CustomResponse();
        }
    }
}
