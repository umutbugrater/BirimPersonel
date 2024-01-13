﻿using Microsoft.EntityFrameworkCore;

namespace ProjeCore.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JCPO54A\\SQLEXPRESS; database=BirimDB; integrated security = true;TrustServerCertificate = True;");

        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
