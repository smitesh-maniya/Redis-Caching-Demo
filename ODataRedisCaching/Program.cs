using Microsoft.EntityFrameworkCore;
using ODataRedisCaching.DataCotext;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.OutputCaching;
using ODataRedisCaching.Models;
using ODataRedisCaching.Caching;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using StackExchange.Redis;
using ODataRedisCaching.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false);

builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddSwaggerGen();

builder.Services.AddOData();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDistrictDataService,DistrictDataService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect("localhost"));

builder.Services.AddRedisOutputCache(options =>
{
    options.AddBasePolicy(builder => {
        builder.Expire(TimeSpan.FromMinutes(5));
        //builder.Tag("Search");
    });
    //options.AddPolicy("VaryBySName", builder =>
    //{
    //    builder.VaryByQuery("SName");
    //    //builder.Tag("");
    //});
    //options.AddPolicy("RemoveCache", builder =>
    //{
    //    builder.NoCache();
    //    //builder.
    //});
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseOutputCache();

app.UseMvc(routeBuilder =>
{
    routeBuilder.Select().Expand().OrderBy().Count().Filter().MaxTop(100);
    routeBuilder.MapODataServiceRoute(routeName:"odata", routePrefix:"odata", model:GetEdmModel());
});

IEdmModel GetEdmModel()
{
    var edmBuilder = new ODataConventionModelBuilder();
    edmBuilder.EntitySet<Student>("Student");
    edmBuilder.EntitySet<District>("District");
    return edmBuilder.GetEdmModel();
}

app.MapControllers();

app.Run();
