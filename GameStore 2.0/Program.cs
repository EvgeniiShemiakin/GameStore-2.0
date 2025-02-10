using GameStore_2._0.DBModels;
using GameStore_2._0.Models;
using GameStore_2._0.Models.Reps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IGamesRepository, DBGamesRepository>();
builder.Services.AddTransient<ICartsRepository, DBCartsRepository>();
builder.Services.AddTransient<IOrdersRepository, DBOrdersRepository>();
builder.Services.AddTransient<IWishlistRepository, DBWishlistRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<GameStoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("GameStoreDBConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;  // ��������� ���� �� ���� ����� (0-9)
    options.Password.RequireLowercase = false;  // ��������� ���� �� ���� �������� ����� (a-z)
    options.Password.RequireUppercase = false;  // ��������� ���� �� ���� ��������� ����� (A-Z)
    options.Password.RequireNonAlphanumeric = false;  // ��������� ���� �� ���� ���������� (@, !, # � �.�.)
    options.Password.RequiredLength = 6;  // ����������� ����� ������
    options.Password.RequiredUniqueChars = 1;  // ����������� ���������� ���������� �������� � ������
})
.AddEntityFrameworkStores<GameStoreDbContext>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.ExpireTimeSpan = TimeSpan.FromHours(24);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await InitializeIdentity(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"������ ��� ������������� Identity: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();

app.Run();

static async Task InitializeIdentity(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
{
    string adminEmail = "admin@admin.com";
    string password = "Admin123";
    string phoneNumber = "1234567890";

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new User { Email = adminEmail, UserName = adminEmail, PhoneNumber = phoneNumber };
        var result = await userManager.CreateAsync(admin, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}