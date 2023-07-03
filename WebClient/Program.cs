
// 1 - https://www.macoratti.net/21/03/aspn_idserv41.htm
// 2 - https://www.macoratti.net/21/03/aspn_idserv42.htm
// 3 - https://www.macoratti.net/21/03/aspn_idserv43.htm
// 4 - https://www.macoratti.net/21/03/aspn_idserv43.htm

// 1  - https://www.youtube.com/watch?v=SXJ377G5bOg
// 2  - https://www.youtube.com/watch?v=rNqgxAqGZJ8

// https://www.brunobrito.net.br/aspnet-core-identityserver4/
// https://balta.io/artigos/aspnetcore-3-autenticacao-autorizacao-bearer-jwt

// Fixando teoria OAUTH e OpenId: https://www.youtube.com/watch?v=68azMcqPpyo&list=WL&index=2

// https://www.youtube.com/watch?v=HJQ2-sJURvA

// https://www.youtube.com/watch?v=HJQ2-sJURvA&list=PLz9t0GSOz9eCS7Bd3ChKavbQgOyKVjleD
// https://github.com/IdentityServer/IdentityServer4.Quickstart.UI

using WebClient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
