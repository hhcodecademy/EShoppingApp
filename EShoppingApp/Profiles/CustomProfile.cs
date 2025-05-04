using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;

namespace EShoppingApp.Profiles
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<OrderViewModel, Order>().ReverseMap();
        }
    }
}
