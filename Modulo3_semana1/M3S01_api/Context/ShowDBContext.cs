using Microsoft.EntityFrameworkCore;
using M3S01_api.Models;

namespace M3S01_api.Context;

public class ShowDBContext: DbContext
{
    public ShowDBContext(DbContextOptions<ShowDBContext> options) : base(options)
    {
    }
    
    public DbSet<BandaModel> Bandas { get; set; }
    
    public DbSet<EventoModel> Eventos { get; set; }

    
}