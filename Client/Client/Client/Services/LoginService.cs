using Client.Models;
using Client.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class LoginService: ILoginService
    {
        IServiceClient _serviceClient;
        public LoginService(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Fields must not be null");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    const string json = "http://tkw-sfr.azurewebsites.net/api/Login/LoginRequest?name={0}&password={1}";
                    var uri = string.Format(json, username, password);
                    var resultJson = await client.GetAsync(uri);
                    var userObj = resultJson.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<User>(userObj);
                    if (result == null)
                    {
                        throw new ArgumentNullException("Non-existent user");
                    }
                    else
                        return result;
                }

            }
        }

    }
}
