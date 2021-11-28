using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportIS.BL.Definitions;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Models.ListModels;
using TransportIS.BL.Repository;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.DAL;
using TransportIS.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services,builder.Configuration);

var app = builder.Build();

Configure(app);

app.Run();

static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
{
    var dbConnectionString = configuration.GetConnectionString("db");

    if(string.IsNullOrEmpty(dbConnectionString))
    {
        throw new InvalidOperationException("No connection string.");
    }

    var contextOptionsBuilder = new DbContextOptionsBuilder<TransportISDbContext>()
#if DEBUG
    .UseLoggerFactory(LoggerFactory.Create(a => a.AddConsole()))
        .EnableSensitiveDataLogging()
#endif
    .UseSqlServer(dbConnectionString);

    services.AddTransient(sp => contextOptionsBuilder.Options);
    services.AddDbContext<TransportISDbContext>(ServiceLifetime.Transient);
    services.AddIdentity<UserEntity, RoleEntity>()
       .AddEntityFrameworkStores<TransportISDbContext>()
       .AddDefaultTokenProviders();

    // mozem pridat reozne paths pre rozne situacie addCookie berie options => options.LoginPath = "/sign-in"
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
    {
        options.Events.OnRedirectToLogin = context =>
           {
               context.Response.StatusCode = 401;
               return Task.CompletedTask;
           };

        options.LoginPath = "/api/account/sign-in";
        options.AccessDeniedPath = "";

    });

    services.AddAuthorization();

    services.AddTransient<Func<TransportISDbContext>>(sp => () => sp.GetRequiredService<TransportISDbContext>());



    AddRepositories(services);
    
    AddAutoMapper(services);


    
    services.AddControllers();

}



static void Configure(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints => endpoints.MapControllers());
}

static void AddRepositories(IServiceCollection services)
{
    var repositoryType = typeof(IRepository<>);

    services.Scan(scan =>
       scan.FromAssembliesOf(repositoryType)
       .AddClasses(s => s.AssignableTo(repositoryType))
       .AsImplementedInterfaces()
       .AsSelf());
}

static IServiceCollection AddAutoMapper(IServiceCollection services)
{
    services.Scan(scan =>
       scan.FromAssembliesOf(typeof(IMapped))
       .AddClasses(s => s.AssignableTo<IMapped>())
       .AsSelf()
       .AsImplementedInterfaces());

    services.AddSingleton(provider => {
        var instances = provider.GetServices<IMapped>().ToList();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            // instances.ForEach(i => i.CreateMap(cfg));
            cfg.CreateMap<AddressEntity, AddressDetailModel>().ReverseMap();
            cfg.CreateMap<CarrierEntity, CarrierDetailModel>().ReverseMap();
            cfg.CreateMap<CarrierEntity, CarrierListModel>();
            cfg.CreateMap<ConnectionEntity, ConnectionDetialModel>().ReverseMap();
            cfg.CreateMap<ConnectionEntity, ConnectionListModel>();
            cfg.CreateMap<EmploeeEntity, EmploeeDetailModel>().ReverseMap();
            cfg.CreateMap<EmploeeEntity, EmploeeListModel>();
            cfg.CreateMap<StopEntity, StopDetailModel>().ReverseMap();
            cfg.CreateMap<StopEntity, StopListModel>();
            cfg.CreateMap<TimeTableEntity, TimeTableDetailModel>().ReverseMap();
            cfg.CreateMap<TimeTableEntity, TimeTableListModel>();
            cfg.CreateMap<VehicleEntity, VehicleDetailModel>().ReverseMap();
            cfg.CreateMap<VehicleEntity, VehicleListModel>();
            cfg.CreateMap<PassengerEntity, PassengerDetailModel>().ReverseMap();
            cfg.CreateMap<PassengerEntity, PassengerListModel>();
            cfg.CreateMap<TimeTableEntity, TimeTableDetailModel>().ReverseMap();
            cfg.CreateMap<TimeTableEntity, TimeTableListModel>();

        });
        return mapperConfig.CreateMapper();
    });

    return services;
}
