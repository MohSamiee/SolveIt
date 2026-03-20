var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllersWithViews();

#region Register Database
builder.ConfigDatabase();
#endregion Register Database

#endregion Services

#region Midlewares
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();
app.Run();

#endregion Midlewares