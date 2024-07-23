using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Configurations
{
    public static class BookConfigurationExtension
    {
        public static ModelBuilder AddBookConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            return modelBuilder;
        }
    }
}
