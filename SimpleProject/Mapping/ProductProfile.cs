using AutoMapper;
using SimpleProject.ViewModels;

namespace SimpleProject.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductViewModel, Product>();// same names  no need for ForMember

            //CreateMap<AddProductViewModel, Product>().ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
