var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
   .AddIdentityServerAuthentication("Bearer", options =>
   {
       options.ApiName = "myApi";
       //Endereço do IdentityServer
       options.Authority = "https://localhost:5053";
   });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
