using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VandecoStore.Core.Notifications;

namespace VandecoStore.Core
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificator _notificator;

        public MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult CustomResponse(object? obj = null)
        {
            if (_notificator.HasNotification())
            {
                return BadRequest(new
                {
                    errors = _notificator.GetAllNotifications().Select(p => p.Message).ToList()
                });
            }
            return Ok(new
            {
                data = obj,
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(p => p.Errors).ToList();
                foreach (var error in errors)
                {
                    _notificator.Handle(new(error.ErrorMessage ?? error.Exception.Message));
                }
            }
            return CustomResponse();
        }
    }
}
