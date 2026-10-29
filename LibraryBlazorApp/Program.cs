using Microsoft.EntityFrameworkCore;
using LibraryBlazorApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси для Blazor Web App (Interactive Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Підключення до бази даних MySQL через Pomelo
var connectionString = "Server=localhost;Database=library_db;User=root;Password=;";
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// Мапування головного компонента
app.MapRazorComponents<LibraryBlazorApp.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();