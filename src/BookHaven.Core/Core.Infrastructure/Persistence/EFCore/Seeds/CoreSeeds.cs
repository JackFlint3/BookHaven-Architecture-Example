using BookHaven.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Core.Infrastructure.Persistence.EFCore.Seeds
{
    internal class CoreSeeds
    {
        public static Task Seed(ICoreUnitOfWork unitOfWork)
        {
            return Task.CompletedTask;
        }
    }
}
