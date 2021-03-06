using JWT_Example.Contract.RequestModel;
using JWT_Example.Contract.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            var result = new ApiResponse();
            UserRequestModel model = new UserRequestModel()
            {
                Email = "t@2t.com",
                Password = "1234"
            };
            //Metoda parametre ile gitme, Encoding ve format belirtmeyi unutma!!
            var stringContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login/login", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<TokenResponseModel>(await response.Content.ReadAsStringAsync());

                if (token != null)
                {


                    //metoda token ile gitme.
                    _httpClient.DefaultRequestHeaders.Authorization
                             = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                }

                var response2 = await _httpClient.GetAsync("test");

                if (response2.IsSuccessStatusCode)
                {

                    result = JsonConvert.DeserializeObject<ApiResponse>(await response2.Content.ReadAsStringAsync());
                }
                else
                {
                    result.Message = "Yetkiniz bulunmamaktadır, Token başarısız";
                }
                return result.Message;
            }
            else
            {
                result.Message = "işlem başarısız";
            }
            return result;
        }
    }
}
