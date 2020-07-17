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
            CreateMap<Cliente, ClienteViewModel>().ForMember(x => x.EnderecoViewModel, o => o.MapFrom(s => s.Endereco)).ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
