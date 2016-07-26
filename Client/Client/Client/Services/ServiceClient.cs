using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    class ServiceClient: IServiceClient
    {
        public string Login(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            //User user = new User(username, password);
            List<User> userList = UserSeeder.GetData();
            foreach(User item in userList)
                if (item.Username.Equals(username)&& item.Password.Equals(password))
                {
                    if (item.Type)
                        return "ok";
                    else
                        return "not";
                }

            return Guid.NewGuid().ToString();
        }
        public string Register(string username, string password, string phone, string type)
        {
            return Guid.NewGuid().ToString();
        }

        public List<Field> Search(string name, string city)
        {
            List<Field> fieldsList = FieldsSeeder.GetData();
            List<Field> display = new List<Field>();
            foreach (Field item in fieldsList)
            {
                if (item.Name.Equals(name) && item.City.Equals(city))
                    display.Add(item);
            }

            return display;
        }

        public List<Field> Search(string filter)
        {
            List<Field> fieldsList = FieldsSeeder.GetData();
            List<Field> display = new List<Field>();
            foreach(Field item in fieldsList)
            {
                if (item.Name.Equals(filter))
                    display.Add(item);
            }

            return display;
        }
        
    }
}