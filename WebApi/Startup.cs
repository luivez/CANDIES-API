using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Services;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));
            services.AddDbContext<DataContext>(
                opt => opt.UseSqlServer(Configuration["Data:CommandAPIConnection:ConnectionString"])
            );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserRepository, UserService>(); // User
            services.AddScoped<IRoleRepository, RoleService>(); // Role
            services.AddScoped<IPageRepository, PageService>(); // Page
            services.AddScoped<IUserRoleRepository, UserRoleService>();  // UserRole
            services.AddScoped<IRolePageRepository, RolePageService>();  // RolePage
            services.AddScoped<IProviderRepository, ProviderService>(); // Provider
            services.AddScoped<IProductRepository, ProductService>(); // Product
            services.AddScoped<IProductTypeRepository, ProductTypeService>(); // Product
            services.AddScoped<IOperationProductEntryRepository, OperationProductEntryService>();  // OperationProductEntry
            services.AddScoped<IOperationProductOutputRepository, OperationProductOutputService>();  // OperationProductOutput
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderService>(); // PurchaseOrder
            services.AddScoped<IPurchaseDetailRepository, PurchaseDetailService>(); // PurchaseDetail
            services.AddScoped<IStatusMachineRepository, StatusMachineService>(); // StatusMachine
            services.AddScoped<IMachineRepository, MachineService>(); // Machine
            services.AddScoped<IPersonRepository, PersonService>(); // Person
            services.AddScoped<IClientRepository, ClientService>(); // Client
            services.AddScoped<IClientMachineRepository, ClientMachineService>(); // ClientMachine
            services.AddScoped<INotificationRepository, NotificationService>(); // Notification

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
