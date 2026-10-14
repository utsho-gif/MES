using Microsoft.EntityFrameworkCore;
using MES.Models.Models;

namespace MES.Models.Context
{
    public class MESDbContext : DbContext
    {
        public MESDbContext(DbContextOptions<MESDbContext> options) : base(options)
        {
        }

        public DbSet<USER_INFO> USER_INFO { get; set; }
        public DbSet<ROLE_INFO> ROLE_INFO { get; set; }
        public DbSet<FORM_INFO> FORM_INFO { get; set; }
        public DbSet<ROLE_FORMS> ROLE_FORMS { get; set; }
        public DbSet<LOG_INFO> LOG_INFO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
