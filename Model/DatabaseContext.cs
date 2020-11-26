using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class DatabaseContext:DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Professor> Professor { get; set; }

        public DbSet<Materia> Materia { get; set; }

    }
}
