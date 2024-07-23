using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations
{
    public static class AuthorConfigurationExtension
    {
        public static ModelBuilder AddAuthorConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            return modelBuilder;
        }
    }
}
