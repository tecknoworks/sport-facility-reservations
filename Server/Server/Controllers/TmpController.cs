using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Server.Controllers
{
    public class TmpController : ApiController
    {

        public class Reservations
        {
            public string FieldName { get; set; }
            public DateTime Hour { get; set; }
        }

        List<User> users = new List<User>
            {
            new User{ID=1, Name="Carson", Password="clock",UserName="userName1"},
            new User{ID=2, Name="Carson1", Password="clock1",UserName="userName2"},
            new User{ID=3, Name="Carson2", Password="clock2",UserName="userName3"},
            new User{ID=3, Name="Carson3", Password="clock3",UserName="userName4"},
            new User{ID=3, Name="Carson4", Password="clock4",UserName="userName5"},
            new User{ID=3, Name="Carson5", Password="clock5",UserName="userName6"},
            new User{ID=3, Name="Carson6", Password="clock6",UserName="userName7"},
            };
        List<Field> fields = new List<Field>
            {
            new Field{ID=1, Name="ClujArena", Location="Cluj",Type="fotbal",
                Availability =new List<DateTime> { new DateTime(2016,04,12),
                                                   new DateTime(2016,04,12) } },
            new Field{ID=2, Name="Terapia", Location="Cluj",Type="fotbal"},
            new Field{ID=3, Name="ClubTransilvania", Location="Cluj",Type="tenis"},
            new Field{ID=4, Name="WinnerSportsClub", Location="Cluj",Type="tenis"},
            };
        List<Reservations> reservations = new List<Reservations>
            {
            new Reservations { FieldName="ClujArena" ,Hour = new DateTime(2016,8,10,12,00,00) },
            new Reservations { FieldName="Terapia" ,Hour = new DateTime(2016,9,10,12,00,00) },
            new Reservations { FieldName="Terapia" ,Hour = new DateTime(2016,9,10,13,00,00) },
            new Reservations { FieldName="Terapia" ,Hour = new DateTime(2016,9,10,14,00,00) },

        };

        public List<Field> GetFields()
        {
            return fields;
        }
        [HttpGet]
        public User Login(string userName, string password)
        {

            var user = users.FirstOrDefault((q) => q.UserName.Equals(userName) && q.Password.Equals(password));
            return user;
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //return Ok(user);
        }
        public IHttpActionResult GetFieldByName(string name)
        {
            var field=fields.FirstOrDefault((q) => q.Name.Equals(name));
            if (field == null)
            {
                return NotFound();
            }
            return Ok(field);
        }
        public IHttpActionResult GetFieldByCity(string name)
        {
            var field = fields.FirstOrDefault((q) => q.Location.Equals(name));
            if (field == null)
            {
                return NotFound();
            }
            return Ok(field);
        }
        //public List<Field> GetAvaibility(List<DateTime> filter)
        //{
        //    var field = fields.FirstOrDefault((q) => q.Availability.Contains(filter.First<DateTime>());
        //    return field;
        //}
        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            foreach (var user1 in users)
                if (user1.Name.Equals(user.Name))
                    return NotFound();
            users.Add(user);
            return Ok(user);
        }
        [HttpPost]
        public IHttpActionResult AddField(User field)
        {
            foreach (var field1 in fields)
                if (field1.Name.Equals(field.Name))
                    return NotFound();
            users.Add(field);
            return Ok(field);
        }
        public List<Reservations> GetReservations()
        {
            //string yourJson = "{"Name":{0}}";
            //var response = this.Request.CreateResponse(HttpStatusCode.OK);
            //response.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            //return response;
            return reservations;

        }
    }
}
