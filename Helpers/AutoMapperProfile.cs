using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Retail;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<HouseholdModel, Households>();
            CreateMap<Households,HouseholdModel>();
            CreateMap<ProductModel, Products>();
            CreateMap<Products, ProductModel>();
            CreateMap<TransactionModel, Transactions>();
            CreateMap<Transactions,TransactionModel>();
        }
    }
}