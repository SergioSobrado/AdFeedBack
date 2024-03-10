using AdFeedBack.Client.Intefaces;
using AdFeedBack.Client.Services;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
using VueCliMiddleware;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.Builder.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddHttpClient<AdFeedBackApiServices>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["TemplateAPI:endpoint"]);
});

builder.Services.AddScoped<IAdFeedBackApiService, AdFeedBackApiServices>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IngeniEbrios", Version = "v1" });
});

builder.Services.AddSpaStaticFiles(options =>
{
    options.RootPath = "client-app/dist";
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IngeniEbrios v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllers();
if (System.Diagnostics.Debugger.IsAttached)
{
    app.MapToVueCliProxy(
    "{*path}",
        new SpaOptions { SourcePath = "client-app" },
        npmScript: System.Diagnostics.Debugger.IsAttached ? "serve" : null,
        regex: "running at",
        wsl: false
        );
}
else
{
    app.MapFallbackToFile("index.html");
}

app.Run();
