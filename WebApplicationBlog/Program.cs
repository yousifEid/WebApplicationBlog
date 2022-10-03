using BLL.Domains;
using Blog.BLL.Domains;
using Blog.DAL.Repositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(BlogDbContext))));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddScoped<ArticlesDomain>();
builder.Services.AddScoped<AuthorsDomain>();
builder.Services.AddScoped<TagsDomain>();
builder.Services.AddScoped<ArticlesTagsDomain>();
builder.Services.AddScoped<AdminDomain>();



builder.Services.AddScoped<ArticlesRepository>();
builder.Services.AddScoped<AuthorsRepository>();
builder.Services.AddScoped<TagsRepository>();
builder.Services.AddScoped<ArticlesTagsRepository>();
builder.Services.AddScoped<AdminRepository>();


//builder.Services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);

//builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

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

app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
