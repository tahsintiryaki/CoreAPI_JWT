using System;
using System.Collections.Generic;
using System.Text;

namespace JWT_Example.Contract.ResponseModel
{
    public class UserResponseModel
    {

        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
