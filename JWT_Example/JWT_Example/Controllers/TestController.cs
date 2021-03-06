using JWT_Example.Contract.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Example.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public async Task<ApiResponse> Index()
        {
            ApiResponse response = new ApiResponse()
            {
                Message = "Yetkilendirme başarılı...",
                Code = "201"
            };
            
            return response;
        }
    }
}
