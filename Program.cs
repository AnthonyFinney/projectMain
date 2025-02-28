using Microsoft.EntityFrameworkCore;
using ProjectMain.Data;
using ProjectMain.Repositories;
using ProjectMain.Services;
using ProjectMain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? builder.Configuration.GetConnectionString("LocalDb");

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(connectionString));

builder.Services.AddSession();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
var host = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? "localhost" : "0.0.0.0";

app.Urls.Add($"http://{host}:{port}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseAuthorization();
app.MapControllers();

app.Run();
