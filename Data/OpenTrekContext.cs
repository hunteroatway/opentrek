using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using opentrek.Models;

namespace opentrek.Data
{
    public class OpenTrekContext : DbContext
    {
        public OpenTrekContext(DbContextOptions<OpenTrekContext> options) : base(options)
        {
        }
        public DbSet<LocationModel> Locations { get; set; }
    }
}
