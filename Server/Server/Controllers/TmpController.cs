using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class TmpController : ApiController
    {
        List<User> users = new List<User>
            {
            new User{ID=1, Name="Carson", Password="clock",UserName="wee"},
            new User{ID=2, Name="Carson1", Password="clock1",UserName="wee"},
            new User{ID=3, Name="Carson2", Password="clock2",UserName="wee"},
            };
        List<Field> fields = new List<Field>
            {
            new Field{ID=1, Name="ClujArena", Location="Cluj",Type="fotbal",
                Availability =new List<DateTime> { new DateTime(2016,04,12),
                                                   new DateTime(2016,04,12) } },
            new Field{ID=1, Name="Terapia", Location="Cluj",Type="fotbal"},
            new Field{ID=1, Name="ClubTransilvania", Location="Cluj",Type="tenis"},
            new Field{ID=1, Name="WinnerSportsClub", Location="Cluj",Type="tenis"},
            };

        public List<Field> GetFields()
        {
            return fields;
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
    }
}
