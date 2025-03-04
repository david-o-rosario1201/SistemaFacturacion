using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Components;
using SistemaFacturacion.DAL;
using SistemaFacturacion.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<Contexto>
		(o => o.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<FacturasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
