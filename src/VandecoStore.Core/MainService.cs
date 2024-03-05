using VandecoStore.Core.Notifications;

namespace VandecoStore.Core
{
    public abstract class MainService
    {
        private readonly INotificator _notificator;

        protected MainService(INotificator notificator) {
            _notificator = notificator;
        }

        protected void HandleError(string message)
        {
            _notificator.Handle(new(message));
        }
    }
}
