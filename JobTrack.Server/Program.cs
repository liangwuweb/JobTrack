using JobTrack.Server.Data;
using JobTrack.Server.Mapping;
using JobTrack.Server.Repositories;
using JobTrack.Server.Repositories.Interface;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using JobTrack.Server.src;

var builder = WebApplication.CreateBuilder(args);

/*var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environments.Production
});*/

var configSection = builder.Configuration.GetRequiredSection(BaseUrlConfiguration.CONFIG_NAME);
builder.Services.Configure<BaseUrlConfiguration>(configSection);
var baseUrlConfig = configSection.Get<BaseUrlConfiguration>();

// Add services to the container.
const string CORS_POLICY = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
        corsPolicyBuilder =>
        {
            //corsPolicyBuilder.WithOrigins("https://localhost:5173");
            corsPolicyBuilder.WithOrigins(baseUrlConfig!.WebBase.TrimEnd('/'));
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicationRepository, SQLApplicationRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Database connection
builder.Services.AddDbContext<JobTrackDbContext>(
   options => options.UseSqlServer(builder.Configuration.GetConnectionString("JobTrackConnection"))
);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CORS_POLICY);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
