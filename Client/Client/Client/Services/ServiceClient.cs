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

            return Guid.NewGuid().ToString();
        }
        public string Register(string username, string password, string phone, string type)
        {
            return Guid.NewGuid().ToString();
        }

        public List<Fields> Search(string filter)
        {
            List<Fields> fieldsList = FieldsSeeder.GetData();
            List<Fields> display = new List<Fields>();
            foreach(Fields item in fieldsList)
            {
                if (item.Name.Equals(filter))
                    display.Add(item);
            }

            return display;
        }

        //sa spuna da te-am inregistrat
        //exista deja un cont creat cu aceste date - TBD




    }
}