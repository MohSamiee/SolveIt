var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddControllersWithViews();

#region Register Unicode 
builder.RegisterHtmlEncoder();
#endregion Register Unicode

#region Register Database
builder.ConfigDatabase();
#endregion Register Database

#region Register Repositories
builder.Services.RegisterRepositories();
#endregion Register Repositories

#region Register Services
builder.Services.RegisterServices();
#endregion Register Services

#region Auth
builder.RegisterCookieAuthorize();
#endregion

#region Register  Others
builder.Services.RegisterOthers();
#endregion Register  Others

#endregion Services

#region Midlewares
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/NotFound");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();
app.Run();

#endregion Midlewares