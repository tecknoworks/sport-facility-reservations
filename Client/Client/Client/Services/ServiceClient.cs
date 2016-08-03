﻿using Client.Services.Interfaces;
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
                    {
                        return result;
                    }
                }

            }
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
        public async Task<List<Reservation>> GetReservedFieldsAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://tkw-sfr.azurewebsites.net/api/tmp/GetReservations ");
                var reservedFields = JsonConvert.DeserializeObject<List<Reservation>>(json);
                return reservedFields;
            }
        }
        public async Task AddUserrAsync(User user)
        {
            using (var client = new HttpClient())
            {
                //var json = JsonConvert.SerializeObject(user);
                //HttpContent httpContent = new StringContent(json);
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept
                //      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var response = await client.PostAsync(new Uri("http://tkw-sfr.azurewebsites.net/api/login/AddUser/"), httpContent);

                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://tkw-sfr.azurewebsites.net/api/login/AddUser/", content);
              
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
                if (endTime.Ticks<= startTime.Ticks)
                    return "End time cannot be earlier than the start time, please try again";
                if (!price.HasValue)
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
            }

            return confirmPassword.Equals(password) ? "Password match" : "Password doesn't match";
        }

        public List<Field> Search(string name, string city)
        {
            return FieldsSeeder.GetData().Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && x.Location.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Field> Search(string name)
        {
            return FieldsSeeder.GetData().Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Field> Search(DateTime availability)
        {
            return FieldsSeeder.GetData().Where(x => x.Availability.Contains(availability)).ToList();
        }
    }
}