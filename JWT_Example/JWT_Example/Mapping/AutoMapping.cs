using AutoMapper;
using JWT_Example.Contract.ResponseModel;
using JWT_Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Example.Mapping
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserResponseModel>();
        }
    }
}
