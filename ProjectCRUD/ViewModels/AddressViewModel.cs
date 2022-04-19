using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.ViewModels
{
    public class AddressViewModel
    {

        public Guid Id { get; set; }

        public string PhysicalAddress { get; set; }

        public string PostalAddress { get; set; }


        public Guid StudentId { get; set; }
    }
}
