using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using CustomerModule.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services
builder.Services.AddScoped<CustomerModule.Web.Services.ToastService>();

// Add Customer Module services
builder.Services.AddCustomerModule(
    builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    "Server=(localdb)\\mssqllocaldb;Database=CustomerModule;Trusted_Connection=True;MultipleActiveResultSets=true"
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
