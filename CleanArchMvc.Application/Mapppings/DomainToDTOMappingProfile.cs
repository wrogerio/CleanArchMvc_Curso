using AutoMapper;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mapppings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            
        }
    }
}