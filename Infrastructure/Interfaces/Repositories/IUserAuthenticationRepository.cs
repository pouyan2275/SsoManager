using Domain.Entities;
using Infrastructure.Bases.Interfaces.Repositories;

namespace Infrastructure.Interfaces.Repositories;

public interface IUserAuthenticationRepository : IRepository<UserAuthentication>
{
}
