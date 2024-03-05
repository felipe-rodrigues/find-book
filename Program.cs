using find_book.Data;
using find_book.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("RoyalLibraryDatabase");
builder.Services.AddDatabase(connection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<RoyalLibraryContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while seeding the database." + e.Message);
            throw e;
        }
    }

}

app.Run();