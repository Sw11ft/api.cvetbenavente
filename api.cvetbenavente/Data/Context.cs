using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.cvetbenavente.Models;

namespace api.cvetbenavente.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Especie> Especies { get; set; }
        public DbSet<Animal> Animais { get; set; }
    }
}