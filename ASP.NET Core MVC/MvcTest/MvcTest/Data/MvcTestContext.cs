using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTest.Models;

namespace MvcTest.Data
{
    public class MvcTestContext : DbContext
    {
        public MvcTestContext (DbContextOptions<MvcTestContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTest.Models.Test> Test { get; set; } = default!;
    }
}
