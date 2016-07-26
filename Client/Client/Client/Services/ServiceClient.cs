using Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public class ServiceClient: IServiceClient
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
        public string Register(string username, string password, string confirmPassword)// string phone, int type, string sport, string nameSports, string adress, int lungime, int latime, DateTime startTime, DateTime stopTime, int price)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrEmpty(password)|| String.IsNullOrWhiteSpace(confirmPassword) ) //|| String.IsNullOrEmpty(phone) || type.Equals(null) || String.IsNullOrEmpty(sport) || String.IsNullOrWhiteSpace(nameSports) || String.IsNullOrEmpty(adress)|| lungime.Equals(null) || latime.Equals(null) || startTime.Equals(null)|| stopTime.Equals(null) || price.Equals(null))
                throw new ArgumentNullException("Fields must not be null", nameof(username));

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