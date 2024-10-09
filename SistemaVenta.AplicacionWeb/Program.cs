using SistemaVenta.AplicacionWeb.Utilidades.Automapper;
using SistemaVenta.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// SE HACE REFERENCIA A LA INYECCION DE TODAS LAS DEPENDENCIAS
// y con eso ya no hay que estar llamando cada una por separado.
builder.Services.InyectarDependencia(builder.Configuration);

// Se importa la libreria de automapper
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
