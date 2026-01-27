
namespace StoreManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ============== CORS ===============

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Users", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") 
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // ================== Controllers & Filters ==================

            builder.Services.AddScoped<HandleErrorFilter>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<HandleErrorFilter>();
            });



            // ================ Swagger ==================

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // ================== AutoMapper ==================

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ================ Repositories ==================

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(ICrudRepository<,>), typeof(CrudRepository<,>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            builder.Services.AddScoped<ISupplierPaymentRepository, SupplierPaymentRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

            // ================== Services ==================

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductFlavorService, ProductFlavorService>();
            builder.Services.AddScoped<IProductUnitPriceService, ProductUnitPriceService>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();





            // ================== Identity ==================

            builder.Services.AddIdentity<AppIdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 " +
                    "«» ÀÃÕŒœ–—“”‘’÷ÿŸ⁄€›ﬁﬂ·„‰ÂÊÌ¡¬√ƒ≈∆»… ";

            })
            .AddEntityFrameworkStores<AppDbContext>();

            // ================== DbContext ==================

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });


            // ================== Authentication ==================

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))

                };
            });




            var app = builder.Build();

            
            // ================== Middleware ==================

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
             
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("Users");

            app.MapControllers();

            app.Run();
        }
    }
}
