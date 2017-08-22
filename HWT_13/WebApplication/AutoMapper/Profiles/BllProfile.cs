using AutoMapper;
using BLL.Models;
using DataAccessLayer.Entities;

namespace WebApplication.AutoMapper.Profiles
{
    public class BllProfile : Profile
    {
        public BllProfile()
        {
            this.CreateMap<Order, OrderDTO>();
            this.CreateMap<ProductDetails, ProductDetailsDTO>();
            this.CreateMap<OrderDetails, OrderDetailsDTO>();
            this.CreateMap<Customer, CustomerDTO>();
            this.CreateMap<Product, ProductDTO>();
            this.CreateMap<ProductDetailsDTO, ProductDetails>();
            this.CreateMap<CustomerDTO, Customer>();
            this.CreateMap<OrderDTO, Order>();
        }
    }
}