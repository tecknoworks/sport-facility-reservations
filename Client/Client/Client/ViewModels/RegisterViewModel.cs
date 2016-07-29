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
    public class RegisterViewModel : BindableBase
    {
        private readonly IServiceClient _serviceClient;
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int IndexType { get; set; }
        public bool IsOwner { get; set; }
        public string FieldName { get; set; }
        public string Sport { get; set; }
        public string Adress { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Price { get; set; }
        public string RegisterMessage { get; set; }
        public string DateTimeMessage { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


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
                int? length = null;
                if (!string.IsNullOrWhiteSpace(Length))
                {
                    int convertedLength;
                    if (int.TryParse(Length, out convertedLength))
                        length = convertedLength;
                }

                int? width = null;
                if (!string.IsNullOrWhiteSpace(Width))
                {
                    int convertedWidth;
                    if (int.TryParse(Width, out convertedWidth))
                        width = convertedWidth;
                }

                float? price = null;
                if (!string.IsNullOrWhiteSpace(Price))
                {
                    float convertedPrice;
                    if (float.TryParse(Price, out convertedPrice))
                        price = convertedPrice;
                }

                Token = _serviceClient.Register(FirstName, LastName, Username, Password, ConfirmPassword, IsOwner, Phone, FieldName, Adress, length, width, StartTime, EndTime, price);
            }
            catch (ArgumentNullException)
            {
                RegisterMessage = "Unable to register. There are empty fields.";
            }
        }
    }
}
