using eBoletimServer.API.SignalHub;
using eBoletimServer.API.Timers;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository;
using eBoletimServer.Infra.Context;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Dependencies
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IGradesService, GradesService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IClassesService, ClassesService>();
builder.Services.AddScoped<ISubjectsService, SubjectsService>();
builder.Services.AddScoped<IStudentClassesService, StudentClassesService>();
builder.Services.AddScoped<ILoginService, LoginService>();
#endregion

#region Repository Dependencies
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IGradesRepository, GradesRepository>();
builder.Services.AddScoped<IClassesRepository, ClassesRepository>();
builder.Services.AddScoped<ISubjectsRepository, SubjectsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IStudentClassesRepository, StudentClassesRepository>();
#endregion


builder.Services.AddSingleton<TimerManager>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAnyOriginHeaderMethod", appBuilder =>
    {
        appBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
    });
});

builder.Services.AddSignalR(opt =>
{
    opt.EnableDetailedErrors = true;
});

builder.Services.AddRouting();

var connString = builder.Configuration.GetConnectionString("connString");
builder.Services.AddDbContext<EBoletimDbContext>(opt => opt.UseSqlServer(connString));
Environment.SetEnvironmentVariable("ConnString", connString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<BaseHub>("/base");
    endpoints.MapHub<ResultsHub>("/resultcon");

});

app.UseHttpsRedirection();


app.MapControllers();

app.UseCors("AllowAnyOriginHeaderMethod");

app.Run();
