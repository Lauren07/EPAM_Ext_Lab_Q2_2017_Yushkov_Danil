using AutoMapper;
using BLL.Models;
using WebApplication.Models;

namespace WebApplication.AutoMapper.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            this.CreateMap<OrderDTO, OrderViewModel>()
                .ForMember("CompanyName",x => x.MapFrom(c => c.Customer.CompanyName));
            this.CreateMap<OrderDetailsDTO, OrderInfoViewModel>()
                .ForMember("CompanyName",x => x.MapFrom(c => c.Order.Customer.CompanyName))
                .ForMember("Phone",x => x.MapFrom(c => c.Order.Customer.Phone))
                .ForMember("FullShipAddress",x => x.MapFrom(c => $"{c.Order.ShipAddress}, {c.Order.ShipCity}, {c.Order.ShipCountry}"))
                .ForMember("OrderID",x => x.MapFrom(c => c.Order.OrderID))
                .ForMember("OrderDate",x => x.MapFrom(c => c.Order.OrderDate));
            this.CreateMap<ProductDetailsDTO, ProductViewModel>();
            this.CreateMap<AddProductViewModel,ProductDetailsDTO>()
                .ForMember("Discount", x => x.MapFrom(c => c.Discount / 100.0));
            this.CreateMap<EditOrderViewModel, OrderDTO>();
            this.CreateMap<EditOrderViewModel, CustomerDTO>();
            this.CreateMap<OrderDTO, EditOrderViewModel>()
                .ForMember("CompanyName", x => x.MapFrom(c => c.Customer.CompanyName))
                .ForMember("Phone", x => x.MapFrom(c => c.Customer.Phone));
        }
    }
}