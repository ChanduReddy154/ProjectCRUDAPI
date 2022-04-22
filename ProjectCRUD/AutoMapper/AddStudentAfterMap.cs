using AutoMapper;
using ProjectCRUD.Models;
using ProjectCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.AutoMapper
{
    public class AddStudentAfterMap : IMappingAction<AddStudentViewModel, Student>
    {
        public void Process(AddStudentViewModel source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
            
        }
    }
}
