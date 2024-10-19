﻿using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Personal.Server.Bases.Controllers;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace SsoManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : BaseController<PersonDto, PersonDtoSelect, Person>
    {
        private readonly SignInManager<Person> _signInManager;
        private readonly IUserStore<Person> _userStore;
        private readonly UserManager<Person> _userManager;
        private readonly LinkGenerator _linkGenerator;
        private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
        private readonly IEmailSender _emailSender;
        private readonly IPersonService _personService;
        private readonly IPersonRepository _repository;

        public PersonController(SignInManager<Person> signInManager,
            IUserStore<Person> userStore,
            UserManager<Person> userManager,
            LinkGenerator linkGenerator,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
            IEmailSender emailSender,
            IPersonService personService,
            IPersonRepository repository) : base(personService)
        {
            _signInManager = signInManager;
            _userStore = userStore;
            _userManager = userManager;
            _linkGenerator = linkGenerator;
            _bearerTokenOptions = bearerTokenOptions;
            _emailSender = emailSender;
            _personService = personService;
            _repository = repository;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Register(RegisterDto registerDto, CancellationToken ct = default)
        {
            var result = await _personService.Register(registerDto,ct);

            if (!result.Succeeded)
                return BadRequest(result);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginDto loginDto, CancellationToken ct = default)
        {
            var result = await _personService.Login(loginDto, ct);
            if (!result.Succeeded)
                return BadRequest(result);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto dto,CancellationToken ct = default)
        {
            var result = await _personService.ResetPassword(dto,ct);
            if (!result.Succeeded)
                return BadRequest(result);
            return Ok();
        }
    }
}
