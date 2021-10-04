using AutoMapper;
using EmployeeApi.Dtos;
using EmployeeApi.Entyties;

namespace EmployeeApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCompanyDto, Company>();
        }
    }
}
