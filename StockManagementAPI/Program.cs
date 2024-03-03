
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockManagementAPI.Database;
using System.Runtime.Intrinsics.X86;

namespace StockManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SM_DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString")));
            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<SM_DBContext>();



//            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//.AddEntityFrameworkStores<SM_DBContext>().AddDefaultTokenProviders();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapIdentityApi<IdentityUser>();
            app.UseHttpsRedirection();

            //app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}