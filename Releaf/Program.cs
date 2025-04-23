using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Releaf.Core.Interfaces;
using Releaf.EF;
using Releaf.EF.Repository;
using System.Security.Cryptography;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

byte[] SecretBytes= new byte[64];
using (var random = RandomNumberGenerator.Create()) 
{
	random.GetBytes(SecretBytes);
}

string secretkey = Convert.ToBase64String(SecretBytes);




	// Add services to the container.

	builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
			b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
			);

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
	});
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = "FreeTrained",
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey))
		};
	});


builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>(options=>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireNonAlphanumeric = false;

})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();


builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.MapIdentityApi<IdentityUser>();



builder.Services.AddCors();

app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
