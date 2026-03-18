
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eToursSystem.DAL;
using eToursSystem.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace eToursSystem
{
    public static class eToursExtensions
    {
        public static void eToursExtensionServices(this IServiceCollection services,
                   Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<eToursContext>(options);

            services.AddTransient<TourServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<eToursContext>();
                return new TourServices(context);
            });

            services.AddTransient<DestinationServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<eToursContext>();
                return new DestinationServices(context);
            });
        }
    }
}
