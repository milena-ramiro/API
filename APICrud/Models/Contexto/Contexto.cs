using APICrud.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrud.Models.Contexto
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> option) : base(option) 
        {
            Database.EnsureCreated(); //Verificar se o banco existe
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
