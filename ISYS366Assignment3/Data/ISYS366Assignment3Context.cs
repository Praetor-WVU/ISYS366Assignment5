using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ISYS366Assignment3.Models;

namespace ISYS366Assignment3.Data
{
    public class ISYS366Assignment3Context : DbContext
    {
        public ISYS366Assignment3Context (DbContextOptions<ISYS366Assignment3Context> options)
            : base(options)
        {
        }

        public DbSet<ISYS366Assignment3.Models.Movie> Movie { get; set; } = default!;
    }
}
