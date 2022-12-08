using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSM.Models;

namespace MvcSM.Data
{
    public class MvcSMContext : DbContext
    {
        public MvcSMContext (DbContextOptions<MvcSMContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSM.Models.Structure> Structure { get; set; } = default!;
    }
}
