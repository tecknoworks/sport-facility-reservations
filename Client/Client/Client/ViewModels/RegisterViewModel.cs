using Client.Services.Interfaces;
using Commander;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    public class RegisterViewModel: BindableBase
    {
        private readonly IServiceClient _serviceClient;
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int IndexType{ get; set; }
        public bool IsOwner { get; set; }
        public string FieldName { get; set; }
        public string Sport { get; set; }
        public string Adress { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public int Price { get; set; }
        public string RegisterMessage { get; set; }

        public RegisterViewModel(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        [OnCommand("RegCommand")]
        public void OnReg()
        {
            Token = "";
            try
            {
                Token = _serviceClient.Register(FirstName,LastName,Username, Password, ConfirmPassword, Phone, IndexType);//, Sport,FieldName, Adress, Length, Width, StartTime, StopTime,  Price);
            }
            catch (ArgumentNullException)
            {
                RegisterMessage = "Unable to register. There are empty fields.";
            }
        }
    }
}
