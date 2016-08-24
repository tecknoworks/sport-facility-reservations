using Client.Services.Interfaces;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class EditMyAccountViewModel : BindableBase
    {
        private readonly IServiceClient _serviceClient;
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Status { get; set; }
        public bool IsOwner { get; set; }

        public string FieldName { get; set; }
        public int SportIndex { get; set; }
        public string Adress { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Price { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string OwnerName { get; set; }

        public User User { get; set; }
        public Field Field { get; set; }
        public EditMyAccountViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task GetUserByIdAsync()
        {
            User = await _serviceClient.GetUserByIdAsync(Settings.Token);
            FirstName = User.FirstName;
            LastName = User.LastName;
            Username = User.Username;
            Password = User.Password;
            ConfirmPassword = User.Password;
            Phone = User.PhoneNumber;
            IsOwner = User.Status;
            if (User.Status)
                Status = 0;
            else
                Status = 1;
        }
        public async Task GetFieldAsync()
        { 
            Field = await _serviceClient.GetFieldAsync(Settings.Token);
            FieldName = Field.Name;
            SportIndex = Field.Type;
            Adress = Field.Location;
            Length = Field.Length.ToString();
            Width = Field.Width.ToString();
            StartTime = Field.StartTime;
            EndTime = Field.EndTime;
            Price = Field.Price.ToString();
            OwnerName = Field.OwnerName;
        }
        public async Task UpdateUser()
        {
            User user = new User(FirstName, LastName, Username, Password, Phone, IsOwner);
            User.FirstName = FirstName;
            User.LastName = LastName;
            User.Username = Username;
            User.Password = Password;
            User.PhoneNumber = Phone;
            User.Status = IsOwner;
            if (User.Status)
                Status = 0;
            else
                Status = 1;
            await _serviceClient.UpdateUserAsync(User);
        }
        //public async Task UpdateField()
        //{
        //    Field field = new Field(SportIndex, FieldName, Adress, Length, Width, StartTime, EndTime, Price, OwnerName);
        //    Field.Type = SportIndex;
        //    Field.Name = FieldName;
        //    Field.Location = Adress;
        //    Field.Length = Legth;
        //    Field.Width = Width;
        //    Field.StartTime = StartTime;
        //    Field.EndTime = EndTime;
        //    Field.OwnerName = OwnerName;
        //    await _serviceClient.UpdateFieldAsync(Field);
        //}

    }
}
