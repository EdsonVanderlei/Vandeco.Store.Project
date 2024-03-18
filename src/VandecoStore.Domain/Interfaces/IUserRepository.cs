using VandecoStore.Domain.Entities;

namespace VandecoStore.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsWithSameMail(string mail);
        Task<bool> ExistsWithSameDocument(string documentNumber);
        Task<User> GetUserWithCart(Guid Id);
    }
}
