using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<PropertyManager>().As<IPropertyService>();
            builder.RegisterType<EfPropertyDal>().As<IPropertyDal>();

            builder.RegisterType<ProductPropertyManager>().As<IProductPropertyService>();
            builder.RegisterType<EfProductPropertyDal>().As<IProductPropertyDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<AuthorizationHelper>().As<IAuthorizationHelper>();


        }
    }
}
