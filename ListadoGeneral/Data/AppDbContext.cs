using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tabla1> Tabla1 { get; set; }
    public DbSet<Tabla2> Tabla2 { get; set; }
}

public class Tabla1
{
    public int Id { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaCreacion { get; set; }
    // Otras propiedades de la tabla 1
}

public class Tabla2
{
    public int Id { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaCreacion { get; set; }
    // Otras propiedades de la tabla 2
}
