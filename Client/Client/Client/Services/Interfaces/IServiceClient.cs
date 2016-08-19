using Client.Models;
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
        Task AcceptReservation(int id);
        Task RejectReservation(int id);
        Task<User> LoginAsync(string username, string password);
        Task<User> GetUserByIdAsync(string token);
        Task<Field> GetFieldAsync(string token);
        Task<List<Field>> GetFieldsAsync();
        string Register(string firstName, string lastName, string username, string password, string confirmPassword, bool IsOwner, string phone, string fieldName, string adress, int? length, int? width, TimeSpan startTime, TimeSpan endTime, float? price);
        Task<List<Reservation>> GetReservedFieldsAsync(string token);
        Task AddUserAsync(User user);
        Task AddFieldAsync(Field field);
        Task UpdateUserAsync(User user);
        List<Field> Search(string filter);
        Task<IEnumerable<Field>> SearchAsync(string token, string filter1, string filter2);
        Task<List<Field>> SearchAsync(string token, string filter1);
        List<Field> Search(DateTime availability);
        Task AddReservationAsync( Reservation reservation);
		Task<List<Reservation>> GetReservationsAsync(string token);
    }
}
    