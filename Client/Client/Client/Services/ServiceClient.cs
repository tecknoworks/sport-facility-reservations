﻿using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Client.Services
{
    public class ServiceClient : IServiceClient
    {
        public string Login(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            }
            List<User> userList = UserSeeder.GetData();
            foreach (User item in userList)
            {
                if (item.Username.Equals(username) && item.Password.Equals(password))
                {
                    if (item.Type)
                        return "ok";
                    else
                        return "not";
                }
            }
            return "Non-existent user";
        }


        public async Task<List<Field>> GetFieldsAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://tkw-sfr.azurewebsites.net/api/tmp/GetFields");
                //var json = await client.GetStringAsync("http://tkw-sfr.azurewebsites.net/api/tmp/Login/?userName=" + username + "&password=" + password);
                var fields = JsonConvert.DeserializeObject<List<Field>>(json);
                return fields;
            }
        }

        public string Register(string firstName, string lastName, string username, string password, string confirmPassword, bool IsOwner, string phone, string fieldName, string adress, int? length, int? width, DateTime startTime, DateTime endTime, float? price)
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
                //if (endTime.TimeOfDay <= startTime.TimeOfDay)
                //    return "End time cannot be earlier than the start time, please try again";
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