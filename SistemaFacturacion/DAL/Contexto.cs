using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Models;

namespace SistemaFacturacion.DAL;

public class Contexto: DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Productos> Productos { get; set; }
    public DbSet<Facturas> Facturas { get; set; }
}
