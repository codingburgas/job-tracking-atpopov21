using System.Text;
using JobTracking.Application.Contracts;
using JobTracking.Application.Contracts.Base;
using JobTracking.Application.Implementation;
using JobTracking.DataAccess.Persistence;

namespace JobTracking.API
{
    public static class ServiceConfiguratorExtensions
    {
        public static void AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<AppDbContext>();
            /*builder.Services.AddDbContext<HrManagementContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });*/
        }
 
        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            /*builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("HrManagement")
                .AddEntityFrameworkStores<HrManagementContext>()
                .AddDefaultTokenProviders();
 
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration[Jwt.Issuer],
                    ValidAudience = builder.Configuration[Jwt.Audience],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[Jwt.Key]))
                };
            });*/
        }
 
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserServ, UserServ>();
            builder.Services.AddScoped<IJobAddServ, JobAdService>();
            builder.Services.AddScoped<IJobApplicationServ, JobApplicationServ>();
            builder.Services.AddScoped<DependencyProvider>();
        }
 
        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient",
                    policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            
            /*builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    config =>
                    {
                        config.WithOrigins("http://localhost:4200", "https://localhost:7184")
                            .AllowAnyHeader()
                            .WithMethods(HttpMethod.Get.Method, HttpMethod.Post.Method, HttpMethod.Put.Method,
                                HttpMethod.Delete.Method);
                    });
            });*/
        }
    }
}