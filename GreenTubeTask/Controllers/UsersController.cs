using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreenTubeTask.Models;
using GreenTubeTask.Models.Dtos;
using GreenTubeTask.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenTubeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username))
            {
                return BadRequest("Username not provided.");
            }

            if (await userRepository.UsernameExists(userDto.Username))
            {
                return BadRequest("User with provided username already exists.");
            }

            User user = mapper.Map<User>(userDto);
            await userRepository.Register(user);

            return Ok(user.Id);
        }

        [HttpGet("balance/{guid}", Name = nameof(GetBalance))]
        public async Task<IActionResult> GetBalance(string guid)
        {
            User user = await userRepository.GetUserByGuidAsync(guid);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Wallet.Balance);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersForTesting()
        {
            List<User> users = await userRepository.GetUsers();

            List<UserDto> response = users.Select(mapper.Map<User, UserDto>).ToList();

            return Ok(response);
        }
    }
}