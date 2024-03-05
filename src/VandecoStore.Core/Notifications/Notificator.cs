namespace VandecoStore.Core.Notifications
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;

        public Notificator()
        {
            _notifications = [];
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Count != 0;
        }

        public List<Notification> GetAllNotifications()
        {
            return _notifications;
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }
    }
}
