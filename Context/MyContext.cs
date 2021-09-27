using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Models;

namespace TASK_BE.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Pegawai> Users { get; set; }
        public DbSet<Unit> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //pegawai - unit
            modelBuilder.Entity<Pegawai>()
                .HasOne(r => r.Units)
                .WithMany(u => u.Pegawai)
                .HasForeignKey(r => r.Unit_Id);
        }
    }
}
