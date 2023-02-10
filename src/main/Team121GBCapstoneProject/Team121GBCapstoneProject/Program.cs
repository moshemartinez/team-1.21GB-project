using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Team121GBCapstoneProject.Data;
using Team121GBCapstoneProject.Services;//reCAPTCHA;


var builder = WebApplication.CreateBuilder(args);

string reCAPTCHASecretKey = builder.Configuration["GamingPlatform:reCAPTCHASecretKey"];
var reCAPTCHASiteKey = builder.Configuration["GamingPlatform:reCAPTCHASiteKey"];

// Add services to the container.

builder.Services.AddScoped<IReCaptchaService, ReCaptchaService>(recaptcha => new ReCaptchaService(reCAPTCHASecretKey));
//builder.Services.AddScoped<ReCaptcha>(r => new ReCaptcha(reCAPTCHASecretKey));
//builder.Services.AddHttpClient<ReCaptcha>(r => { r.BaseAddress = new Uri("https://www.google.com/recaptcha/api/siteverify"); }); 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

//builder.Services.AddScoped<ReCaptcha>(r => new ReCaptcha(reCAPTCHASiteKey, reCAPTCHASecretKey));
//builder.Services.Configure<ReCaptchaHelper>(builder.Configuration.)