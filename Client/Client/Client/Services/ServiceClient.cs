using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public class ServiceClient : IServiceClient
    {
        public string Login(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Fields must not be null", nameof(username));
            //User user = new User(username, password);
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
        public string Register(string firstName, string lastName, string username, string password, string confirmPassword, bool IsOwner, string phone, string fieldName, string adress, int? length, int? width, int? price)
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
                if (length.HasValue)
                    throw new ArgumentNullException("Fields must not be null", nameof(username));
                //if (!width.HasValue)
                //    throw new ArgumentNullException("Fields must not be null", nameof(username));
                //if ()
                //    throw new ArgumentNullException("Fields must not be null", nameof(username));
            }

            return confirmPassword.Equals(password) ? "Password match" : "Password doesn't match";
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
            foreach (Field item in fieldsList)
            {
                if (item.Name.Equals(filter))
                    display.Add(item);
            }

            return display;
        }

    }
}