using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Task_Announcement.Models
{
    public class AnnounceContext : DbContext
    {
        public DbSet<Announce> Announces { get; set; }
        public AnnounceContext(DbContextOptions<AnnounceContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
