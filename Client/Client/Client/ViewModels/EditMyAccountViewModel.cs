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
    public class EditMyAccountViewModel: BindableBase
    {
        private readonly IServiceClient _serviceClient;
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Status{ get; set; }
        public bool IsOwner { get; set; }

        public string FieldName { get; set; }
        public int SportIndex { get; set; }
        public string Adress { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Price { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public User User { get; set; }
        public Field Field { get; set; }
        public EditMyAccountViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task LoadGetUserByIdAsync()
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
            Field = await _serviceClient.GetFieldAsync(Settings.Token);
            FieldName = Field.Name;
            Adress = Field.Location;
            Length = Field.Length;
            Width = Field.Width;
            StartTime = Field.StartTime;
            EndTime = Field.EndTime;
            Price = Field.Price;
        }
    }
}
