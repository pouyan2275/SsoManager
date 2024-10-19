using Application.Bases.Interfaces.IServices;
using Application.Dtos.Persons;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.IServices
{
    public interface IPersonService : IBaseService<PersonDto, PersonDtoSelect, Person>
    {
        public Task<SignInResult> Login(LoginDto loginDto, CancellationToken ct = default);

    }
}
