using AutoMapper;
using Dockway.Application.ViewModels;
using Docway.Domain.Commands.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PatientViewModel, RegisterNewPatientCommand>()
                .ConstructUsing(c => new RegisterNewPatientCommand(c.Name, c.Email, c.Cpf, c.PhoneNumber, c.Password, c.UserName)).IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<PatientViewModel, UpdatePatientCommand>()
                .ConstructUsing(c => new UpdatePatientCommand(c.Name, c.Email, c.Cpf, c.PhoneNumber, c.Password));
        }
    }
}
