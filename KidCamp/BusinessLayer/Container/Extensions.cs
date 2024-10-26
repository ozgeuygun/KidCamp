using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFacilityService, FacilityManager>();
            services.AddScoped<IFacilityDal, EfFacilityDal>();

            services.AddScoped<ICollaborateService, CollaborateManager>();
            services.AddScoped<ICollaborateDal, EfCollaborateDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddScoped<IFavoriteActivityService, FavoriteActivityManager>();
            services.AddScoped<IFavoriteActivityDal, EfFavoriteActivityDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IEventDetailService, EventDetailManager>();
            services.AddScoped<IEventDetailDal, EfEventDetailDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IGenreDal, EfGenreDal>();

            services.AddScoped<IEventMasterService, EventMasterManager>();
            services.AddScoped<IEventMasterDal, EfEventMasterDal>();

			services.AddScoped<IActivityInformationService, ActivityInformationManager>();
			services.AddScoped<IActivityInformationDal, EfActivityInformationDal>();

            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppRoleDal, EfAppRoleDal>();
        }
    }
}
