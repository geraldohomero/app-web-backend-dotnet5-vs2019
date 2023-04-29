# app-web-backend-dotnet5
App criado na aula de Desenvolvimento Back-end (PUC-Minas) - Eixo 2 - .NET 5

## ASP.NET Core (MVC) 5.0
- EntityFramework 5.0.17
- SQL Server
- BCrypt

## Data Annotations
```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace app_web_backend.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o placa!")]
        public string Placa { get; set; }

        public ICollection<Consumo> Consumos { get; set; }
    }
}
```

## DbContext
```csharp
namespace app_web_backend.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Consumo> Consumos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


    }
}
```

## Database

- `Migration` - `add-migration`
- `update-database`
