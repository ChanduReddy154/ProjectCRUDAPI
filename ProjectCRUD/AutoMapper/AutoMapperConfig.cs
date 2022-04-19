using AutoMapper;
using ProjectCRUD.Models;
using ProjectCRUD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<GenderViewModel, Gender>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
        }

    }
}
