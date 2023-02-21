using OnlinyBook.Configurations.LayerConfigurations;
using OnlinyBook.Middlewares;
using OnlinyBook.Service.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddService();
builder.Services.ConfigurWeb(builder.Configuration);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// сбрасывает на логин

//app.UseStatusCodePages(async context =>
//{
//    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
//    {
//        context.HttpContext.Response.Redirect("account/login");
//    }
//});

if (app.Services.GetService<IHttpContextAccessor>() != null)
	HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

app.UseMiddleware<TokenRedirectMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
