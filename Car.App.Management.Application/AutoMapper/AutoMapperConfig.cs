using AutoMapper;
using Car.App.Management.Application.ViewModels;
using Car.App.Management.Domain.Models;

namespace Car.App.Management.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Carro, CarroViewModel>().ReverseMap();
        }
    }
}
