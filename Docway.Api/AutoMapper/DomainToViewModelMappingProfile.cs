using AutoMapper;
using Dockway.Application.ViewModels;
using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Patient, PatientViewModel>().ForMember(dest=> dest.PhoneNumber, opt => opt.MapFrom(s=> s.User.PhoneNumber))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(s => s.User.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.User.Email));

        }
    }
}
