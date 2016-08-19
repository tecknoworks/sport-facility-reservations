using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Client.Services
{
    public class ServiceClient : IServiceClient
    {
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
                    const string uriTemplate = "http://tkw-sfr.azurewebsites.net/api/Login/LoginRequest?name={0}&password={1}";
                    var uri = string.Format(uriTemplate, username, password);
                    var response = await client.GetAsync(uri);
                    var serializedUser = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<User>(serializedUser);
                    if (result == null)
                    {
                        throw new ArgumentNullException("Non-existent user");
                    }
                    else
                    {
                        return result;
                    }
                }
            }
        }

        public static User LoginFBAsync(User user)
        {
            return user;
        }


        public async Task<List<Field>> GetFieldsAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://tkw-sfr.azurewebsites.net/api/MainPage/GetFields");
                var fields = JsonConvert.DeserializeObject<List<Field>>(json);
                return fields;
            }
        }

        public async Task<User> GetUserByIdAsync(string token)
        {
            using (var client = new HttpClient())
            {
                const string json = "http://tkw-sfr.azurewebsites.net/api/Login/GetUserById/?token={0}";
                var uri = string.Format(json, token);
                var resultJson = await client.GetAsync(uri);
                var userObj = resultJson.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<User>(userObj);
                return result;
            }
        }

        public async Task<Field> GetFieldAsync(string token)
        {
            using (var client = new HttpClient())
            {
                const string json = "http://tkw-sfr.azurewebsites.net/api/MainPage/GetFieldOfOwner/?token={0}";
                var uri = string.Format(json, token);
                var resultJson = await client.GetAsync(uri);
                var fieldObj = resultJson.Content.ReadAsStringAsync().Result;
                var resultField = JsonConvert.DeserializeObject<Field>(fieldObj);
                return resultField;
            }
        }


        public async Task<List<Reservation>> GetReservedFieldsAsync(string token)
        {
            using (var client = new HttpClient())
            {
                const string json = "http://tkw-sfr.azurewebsites.net/api/Reservations/GetReservations/?token={0}";
                var uri = string.Format(json, token);
                var resultJson = await client.GetAsync(uri);
                var userObj = resultJson.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List <Reservation >> (userObj);
                return result;
            }
        }
        public async Task AddUserAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://tkw-sfr.azurewebsites.net/api/login/AddUser/", content);
                if (result.StatusCode==System.Net.HttpStatusCode.OK)
                {
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }
        public async Task AcceptRequest(int id)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(id);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("http://tkw-sfr.azurewebsites.net/api/Reservations/UpdateReservation/?id={0}", content);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                }
                else 
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }
        public async Task UpdateUserAsync(User user)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("http://tkw-sfr.azurewebsites.net/api/login/UpdateUser/", content);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }

        public async Task AddFieldAsync(Field field)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(field);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://tkw-sfr.azurewebsites.net/api/MainPage/AddField/", content);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }
        public async Task AddReservationAsync(Reservation reservation)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(reservation);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("http://tkw-sfr.azurewebsites.net/api/Reservations/AddReservations/", content);
                }catch(Exception ex)
                {

                }
            }
        }

        public string Register(string firstName, string lastName, string username, string password, string confirmPassword, bool IsOwner, string phone, string fieldName, string adress, int? length, int? width, TimeSpan startTime, TimeSpan endTime, float? price)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (String.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (String.IsNullOrWhiteSpace(confirmPassword))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (String.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            if (IsOwner)
            {
                if (String.IsNullOrWhiteSpace(fieldName))
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
                if (String.IsNullOrWhiteSpace(adress))
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
                if (!length.HasValue)
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
                if (!width.HasValue)
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
                if (endTime.Ticks <= startTime.Ticks)
                    return "End time cannot be earlier than the start time, please try again";
                if (!price.HasValue)
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
            }

            return confirmPassword.Equals(password) ? "Password match" : "Password doesn't match";
        }

        public async Task<IEnumerable<Field>> SearchAsync(string token, string name, string city)
        {
            //return FieldsSeeder.GetData().Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && x.Location.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            using (var client = new HttpClient())
            {
                const string json = "http://tkw-sfr.azurewebsites.net/api/MainPage/GetFieldBy?token={0}&name={1}&location={2}";
                var uri = string.Format(json, token, name, city);
                var resultJson = await client.GetAsync(uri);
                var userObj = resultJson.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<Field>>(userObj);
                if (result == null)
                {
                    throw new ArgumentNullException("There is no field according to given filter");
                }
                else
                {
                    return result;
                }
            }
        }

        public async Task<List<Field>> SearchAsync(string token, string city)
        {
            //return FieldsSeeder.GetData().Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            using (var client = new HttpClient())
            {
                const string json = "http://tkw-sfr.azurewebsites.net/api/MainPage/GetFieldByCity?token={0}&city={1}";
                var uri = string.Format(json, token, city);
                var resultJson = await client.GetAsync(uri);
                var userObj = resultJson.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<Field>>(userObj);
                if (result == null)
                {
                    throw new ArgumentNullException("There is no field according to given filter");
                }
                else
                {
                    return result;
                }
            }
        }


        public List<Field> Search(DateTime availability)
        {
            return FieldsSeeder.GetData().Where(x => x.Availability.Contains(availability)).ToList();
        }

        public List<Field> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}