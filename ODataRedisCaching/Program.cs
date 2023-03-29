using Microsoft.EntityFrameworkCore;
using ODataRedisCaching.DataCotext;
using Microsoft.OData.Edm;
using ODataRedisCaching.Models;
using ODataRedisCaching.Services;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);
IEdmModel GetEdmModel()
{
    var edmBuilder = new ODataConventionModelBuilder();
    edmBuilder.EntitySet<District>("District");
    return edmBuilder.GetEdmModel();
}

//builder.Services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false).AddOData(
//        options => options.Select().Expand().OrderBy().Count().Filter().SetMaxTop(null)
//                    .AddRouteComponents("odata", GetEdmModel())
    //);
builder.Services.AddControllers().AddOData(
        options => options.Select().Expand().OrderBy().Count().Filter().SetMaxTop(null)
                    .AddRouteComponents("odata", GetEdmModel())
    );

builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddScoped<IDistrictDataService,DistrictDataService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoins => endpoins.MapControllers());
//app.UseOutputCache();


app.Run();
