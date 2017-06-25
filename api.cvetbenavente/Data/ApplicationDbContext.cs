using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web.cvetbenavente.Models;

namespace web.cvetbenavente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Especie> Especies { get; set; }
        public DbSet<Animal> Animais { get; set; }

        public DbSet<Evento> Eventos { get; set; }
    }
}
