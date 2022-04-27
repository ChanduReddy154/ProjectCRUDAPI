using FluentValidation;
using ProjectCRUD.Repository;
using ProjectCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentViewModel>
    {

        public AddStudentValidator(IStudentInterface studentInterface)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DOB).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.GenderID).NotEmpty().Must(id =>
            {
                var gender = studentInterface.getGender().Result.ToList().FirstOrDefault(x => x.Id == id);
                if (gender != null)
                {
                    return true;
                }
                return false;
            }).WithMessage("Please select a valid gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();


        }

    }
}
