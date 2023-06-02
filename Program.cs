using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services;
using BooKingSystemForntEnd.Services.HttPClientServices;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<CompaniesClien>();

builder.Services.AddScoped<HTTPclientServices,RoomServices>();
builder.Services.AddScoped<BooKing_context, BooKing_Servicescs>();
builder.Services.AddScoped<GustHttpcs, GustServices>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
}
 app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Room}/{action=GetRoom}/{id?}")
);
app.Run();