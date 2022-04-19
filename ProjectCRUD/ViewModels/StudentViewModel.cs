using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.ViewModels
{
    public class StudentViewModel
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfileImageURL { get; set; }

        public Guid GenderID { get; set; }

        public GenderViewModel Gender { get; set; }

        public AddressViewModel Address { get; set; }

    }
}
