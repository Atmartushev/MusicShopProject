using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicShopProject.Models;

namespace MusicShopProject.Data
{
    public class MusicShopProjectContext : DbContext
    {
        public MusicShopProjectContext (DbContextOptions<MusicShopProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MusicShopProject.Models.Songs> Songs { get; set; } = default!;
        public DbSet<MusicShopProject.Models.Users> Users { get; set; } = default!;
    }
}
