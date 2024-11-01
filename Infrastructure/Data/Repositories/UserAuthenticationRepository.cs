using Domain.Entities;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;

public class UserAuthenticationRepository : Repository<UserAuthentication>, IUserAuthenticationRepository
{
    public UserAuthenticationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
