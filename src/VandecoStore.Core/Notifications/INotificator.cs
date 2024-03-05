namespace VandecoStore.Core.Notifications
{
    public interface INotificator
    {
        void Handle(Notification notification);
        bool HasNotification();
        List<Notification> GetAllNotifications();
        void ClearNotifications();
    }
}