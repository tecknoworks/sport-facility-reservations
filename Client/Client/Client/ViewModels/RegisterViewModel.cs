using Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class RegisterViewModel
    {
        private string Username { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Phone { get; set; }
        private string Password { get; set; }
        private string ConfimrPassword { get; set; }

        [OnCommand("SubmitCommand")]
        public async void OnSubmit()
        {
            
        }

    }
}
