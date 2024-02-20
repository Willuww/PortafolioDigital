using PortafolioJBR.Infraestructura;
using PortafolioJBR.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Inyeccion de Dependencias
builder.Services.AddTransient<IRepositorioServicios, RepositorioServicios>();
//middleware
builder.Services.AddTransient<IServiceEmailSendGrid, ServiceMailSendGrid> ();
// builder.Services.AddTransient<primero interfaz ',' luego la clase>

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
