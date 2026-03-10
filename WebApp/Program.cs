var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Custom route for /shirts/{id} -> Shirt/Details/{id}
app.MapControllerRoute(
    name: "shirtsDetails",
    pattern: "shirts/{id:int}",
    defaults: new { controller = "Shirt", action = "Details" });
/*
// Custom route for /shirts -> Shirt/Index
app.MapControllerRoute(
    name: "shirts",
    pattern: "shirts",
    defaults: new { controller = "Shirt", action = "Index" });
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();