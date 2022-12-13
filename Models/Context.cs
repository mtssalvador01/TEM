using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecGas.Models;

namespace TEM.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            InicializaBD.Initialize(this);
        }

        public DbSet<Cli_Clientes> Cli_Clientes { get; set; }

        public DbSet<Ord_OrdemServicos> Ord_OrdemServicos { get; set; }

        public DbSet<Usu_Usuarios> Usu_Usuarios { get; set; }
    }
}
