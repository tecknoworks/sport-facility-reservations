using Commander;
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
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfimrPassword { get; set; }
        public int IndexType{ get; set; }
        public bool IsOwner { get; set; }
        public string FieldName { get; set; }
         
    }
}
