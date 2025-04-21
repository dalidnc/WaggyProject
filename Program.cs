using WaggyProject.Context;
using WaggyProject.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WaggyContext>();
builder.Services.AddIdentity<AppUser, AppRole>(option=>
{
    option.User.RequireUniqueEmail = true;//Eþþiz bir email olmalý
})
    .AddEntityFrameworkStores<WaggyContext>();



builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(config=>
{
    config.LoginPath = "/Login/Index";
    config.LogoutPath = "/Login/Logout";
});

var app = builder.Build();
app.UseStaticFiles();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
