# Consumo de Veículos (Banco de dados)
App criado na aula de Desenvolvimento Back-end (PUC-Minas) - Eixo 2 - .NET 5

## ASP.NET Core (MVC)
- EntityFramework 5.0.17
- SQL Server
- BCrypt
![image](https://user-images.githubusercontent.com/70844369/235548695-4c8a2c9f-ab8b-4159-bcda-66cdda300120.png)
![image](https://user-images.githubusercontent.com/70844369/235548563-d3eee00c-ee65-4bb0-9fcb-933f9b4cbdec.png)

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
## appsetings.json
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=server\\name;Database=app_web_backend;Trusted_Connection=True;"
```
## DbContext

- `Startup.cs` || `Program.cs`
```csharp
public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
```
- `ApplicationDbContext.cs`
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

## Cookie
```csharp
         services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
```
## Authentication
```csharp
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/Usuarios/AccessDenied/";
                    options.LoginPath = "/Usuarios/Login/";
                }
            );

 ```
