using JWT_Example.Contract.RequestModel;
using JWT_Example.Contract.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JWT_Example.Web.APIService
{
    public class UserAPIService
    {
        private readonly HttpClient _httpClient;
        public UserAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserResponseModel>> GetUser()
        {
            List<UserResponseModel> userList;
            var response = await _httpClient.GetAsync("login/users");
            if (response.IsSuccessStatusCode)
            {
                userList = JsonConvert.DeserializeObject<List<UserResponseModel>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                userList = null;
            }
            return userList;
        }
        public async Task<string> GotoView()
        {
            UserRequestModel model = new UserRequestModel()
            {
                Email = "t@t.com",
                Password = "1234"
            };
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var response = await _httpClient.PostAsync("login/login", new StringContent(jsonBody));
            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<TokenResponseModel>(await response.Content.ReadAsStringAsync());
                
            }
            else
            {
                
            }
            return "success";
        }
    }
}
