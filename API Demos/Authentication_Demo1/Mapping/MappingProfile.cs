using Authentication_Demo1.DTOs;
using Authentication_Demo1.Models;
using AutoMapper;

namespace Authentication_Demo1.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
