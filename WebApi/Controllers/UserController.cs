using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Repository;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/usuario/")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserRepository userRepository,IMapper mapper,IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("atenticacion")]
        public IActionResult Authenticate([FromBody]UserRegisterDto userRegisterDto)
        {
            var user = _userRepository.Authenticate(userRegisterDto.userName, userRegisterDto.password);

            if (user == null)
                return BadRequest(new { message = "Usuario o clave incorrecta." }
            );

            // Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.idUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new {
                idUser = user.idUser,
                name = user.name,
                lastName = user.lastName,
                username = user.userName,
                state = user.state,
                token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("registro")]
        public IActionResult Register([FromBody]UserRegisterDto userRegisterDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userRegisterDto);

            try
            {
                // save
                user = _userRepository.Create(user, userRegisterDto.password);
                userRegisterDto = _mapper.Map<UserRegisterDto>(user);
                return Ok(userRegisterDto);
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("listar")]
        public IActionResult GetAll()
        {
            var users =  _userRepository.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("obtener/{id:int}")]
        public IActionResult GetById(int id)
        {
            var user =  _userRepository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("actualizar")]
        public IActionResult Update([FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);

            try
            {
                user =  _userRepository.Update(userDto);
                userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("eliminar/{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.Delete(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
