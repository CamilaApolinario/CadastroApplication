using CadastroApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace CadastroApplication.Infra
{
    public class CadastroApplicationContext : DbContext
    {
        public CadastroApplicationContext(DbContextOptions<CadastroApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
    }
}