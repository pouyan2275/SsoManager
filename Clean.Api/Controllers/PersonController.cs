using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsoManager.Server.Bases.Controllers;

namespace SsoManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : CrudController<PersonDto, PersonDtoSelect, Person>
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _repository;

        public PersonController(IPersonService personService, IPersonRepository repository) : base(personService)
        {
            _personService = personService;
            _repository = repository;
        }
    }
}
