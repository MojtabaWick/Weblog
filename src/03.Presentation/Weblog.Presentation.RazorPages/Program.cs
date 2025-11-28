using Microsoft.EntityFrameworkCore;
using Weblog.Domain.Core.AuthorAgg.Contracts;
using Weblog.Domain.Core.CategoryAgg.Contracts;
using Weblog.Domain.Core.CommentAgg.Contracts;
using Weblog.Domain.Core.PostAgg.Contracts;
using Weblog.Domain.Service.Services.AuthorAgg;
using Weblog.Domain.Service.Services.CategoryAgg;
using Weblog.Domain.Service.Services.CommentsAgg;
using Weblog.Domain.Service.Services.PostAgg;
using Weblog.Framework;
using Weblog.Framework.Contracts;
using Weblog.Infrastructure.EFCore.Persistence;
using Weblog.Infrastructure.EFCore.Repositories.AuthorAgg;
using Weblog.Infrastructure.EFCore.Repositories.CategoryAgg;
using Weblog.Infrastructure.EFCore.Repositories.CommentAgg;
using Weblog.Infrastructure.EFCore.Repositories.PostAgg;

var builder = WebApplication.CreateBuilder(args);

#region ServiceRegistrations

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Weblog;Trusted_Connection=True;"));

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

#endregion ServiceRegistrations

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();