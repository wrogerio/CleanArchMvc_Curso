using AutoMapper;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Mapppings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}