using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    [ImplementPropertyChanged]
    class LoginViewModel
    {
        private string Username { get; set; }
        private string Password { get; set; }
    }
}
