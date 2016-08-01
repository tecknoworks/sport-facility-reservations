﻿using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Services.Interfaces
{
    public interface IServiceClient
    {
        string Login(string username, string password);
        Task<List<Field>> GetFieldsAsync();
        string Register(string firstName, string lastName, string username, string password, string confirmPassword, bool IsOwner, string phone, string fieldName, string adress, int? length, int? width, TimeSpan startTime, TimeSpan endTime, float? price);
        Task<List<Reservation>> GetReservedFieldsAsync();
        List<Field> Search(string filter);
        List<Field> Search(string filter1, string filter2);
        List<Field> Search(DateTime availability);
    }
}
    