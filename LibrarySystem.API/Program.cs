using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database
var connectionString = builder.Configuration.GetConnectionString("LibraryDB");
builder.Services.AddDbContext<LibraryContext>(options =>
options.UseSqlServer(connectionString));
#endregion

//#region Identity Manager
//builder.Services.AddIdentity<User, IdentityRole>(options => {
//    options.Password.RequiredUniqueChars = 3;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 4;
//    options.User.RequireUniqueEmail = true;
//}
//)
//    .AddEntityFrameworkStores<ApplyIdentityContext>();
//#endregion

//#region Authentication
////verify token
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "Cool";
//    options.DefaultChallengeScheme = "Cool";
//})
//    .AddJwtBearer(
//    "Cool", options =>
//    {
//        var secertKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? "";
//        var secretKeyInBytes = Encoding.ASCII.GetBytes(secertKeyString);
//        var securityKey = new SymmetricSecurityKey(secretKeyInBytes);

//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            IssuerSigningKey = securityKey,
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    }

//    );
//#endregion

//#region Authorization
//builder.Services.AddAuthorization(Options =>
//{
//    Options.AddPolicy("AllowAdminsOnly",
//        builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));

//    Options.AddPolicy("AllowUsersOnly",
//        builder => builder.RequireClaim(ClaimTypes.Role, "User"));
//});
//#endregion

//#region CorsPolicy
//var AllowCorsPolicy = "AllowCorsPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(AllowCorsPolicy, builder =>
//    {
//        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
//    });
//});
//#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
