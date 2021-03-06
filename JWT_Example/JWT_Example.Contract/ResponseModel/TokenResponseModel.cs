using System;
using System.Collections.Generic;
using System.Text;

namespace JWT_Example.Contract.ResponseModel
{
    public class TokenResponseModel
    {

        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
