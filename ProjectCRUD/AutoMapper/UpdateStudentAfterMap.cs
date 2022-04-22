using AutoMapper;
using ProjectCRUD.Models;
using ProjectCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.AutoMapper
{
    public class UpdateStudentAfterMap : IMappingAction<UpdateStudentViewModel, Student>
    {
        public void Process(UpdateStudentViewModel source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
