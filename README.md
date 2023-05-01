# Consumo de Veículos (Banco de dados)
App criado na aula de Desenvolvimento Back-end (PUC-Minas) - Eixo 2 - .NET 5

## ASP.NET Core (MVC)
- EntityFramework 5.0.17
- SQL Server
- BCrypt

![image](https://user-images.githubusercontent.com/70844369/235548860-a630f1bd-b843-4650-90b9-ec52ba0fabbf.png)
![image](https://user-images.githubusercontent.com/70844369/235548819-65190ac7-7c0f-47e1-8b5b-c7694fce014a.png)
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
