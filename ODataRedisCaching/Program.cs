using Microsoft.EntityFrameworkCore;
using ODataRedisCaching.DataCotext;
using Microsoft.OData.Edm;
using ODataRedisCaching.Models;
using ODataRedisCaching.Services;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using ODataRedisCaching.Caching;

var builder = WebApplication.CreateBuilder(args);

//get entity set edm model for district Model
IEdmModel GetEdmModel()
{
    var edmBuilder = new ODataConventionModelBuilder();
    edmBuilder.EntitySet<District>("District");
    return edmBuilder.GetEdmModel();
}

//odata api service enable
builder.Services.AddControllers().AddOData(
        options => options.Select().Expand().OrderBy().Count().Filter().SetMaxTop(null)
                    .AddRouteComponents("odata", GetEdmModel())
);


builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IDistrictDataService,DistrictDataService>();

//redis distributed cache service enable
//making connection to redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    var section = builder.Configuration.GetSection("RedisConnections");
    options.Configuration = section.GetValue<string>("Configuration");
    options.InstanceName = section.GetValue<string>("InstanceName");
});

//custom redis output cache service
builder.Services.AddRedisOutputCache(options =>
{
    options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromMinutes(5)));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseRouting();

app.UseAuthorization();

app.UseOutputCache();

app.UseEndpoints(endpoins => endpoins.MapControllers());


app.Run();
