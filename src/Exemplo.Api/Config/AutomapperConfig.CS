using AutoMapper;
using Exemplo.Application.ViewModel;
using Exemplo.Domain.Entities;

namespace Exemplo.Api.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
