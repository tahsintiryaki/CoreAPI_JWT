using AutoMapper;
using JWT_Example.Contract.RequestModel;
using JWT_Example.Contract.ResponseModel;
using JWT_Example.DbContexts;
using JWT_Example.DTO;
using JWT_Example.Entities;
using JWT_Example.TokenClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly AppDbContext _context;
        readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public LoginController(AppDbContext content, IConfiguration configuration, IMapper mapper)
        {
            _context = content;
            _configuration = configuration;
            _mapper = mapper;
        }

        //[HttpPost("[action]")]
        [HttpPost("[action]")]
        public async Task<bool> Create([FromForm] User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpGet("[action]")]
        public List<UserResponseModel> Users()
        {
            var users = _context.User.ToList();

            return _mapper.Map<List<UserResponseModel>>(users);
        }


        [HttpPost("[action]")]
        public async Task<Token> Login([FromForm] UserRequestModel userLogin)
        {
            User user = _context.User.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreatedToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
}
