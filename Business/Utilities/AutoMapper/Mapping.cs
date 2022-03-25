using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Category;
using Entities.Dtos.Product;
using Entities.Dtos.ProductProperty;
using Entities.Dtos.Property;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;

namespace Business.Utilities.AutoMapper
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
          {

              var config = new MapperConfiguration(cfg =>
              {
                  cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                  cfg.AddProfile<MappingProfile>();
              });
              var mapper = config.CreateMapper();
              return mapper;
          });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, AddCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, EditCategoryDto>();
            CreateMap<EditCategoryDto, Category>();
            CreateMap<CategoriesDto, Category>().ReverseMap();
            //CreateMap<List<Category>, List<ListCategoriesDto>>();
            //CreateMap<List<ListCategoriesDto>, List<Category>>();

            CreateMap<Product, AddProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<EditProductDto, Product>().ReverseMap();

            CreateMap<Property, AddPropertyDto>();
            CreateMap<AddPropertyDto, Property>();
            CreateMap<Property, EditPropertyDto>();
            CreateMap<EditPropertyDto, Property>();
            CreateMap<PropertyDto, Property>().ReverseMap();

            CreateMap<ProductProperty, AddProductPropertyDto>();
            CreateMap<AddProductPropertyDto, ProductProperty>();
            CreateMap<ProductProperty, EditProductPropertyDto>();
            CreateMap<EditProductPropertyDto, ProductProperty>();
            CreateMap<ProductPropertyDto, ProductProperty>().ReverseMap();

            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<User, EditUserDto>();
            CreateMap<EditUserDto, User>();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<LoginUserDto, User>().ReverseMap();
            CreateMap<EditUserDto,UserDto>().ReverseMap();

        }
    }
}
