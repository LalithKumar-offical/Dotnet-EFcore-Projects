var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapGet("/", context =>
{
    context.Response.Redirect("/Bank");
    return Task.CompletedTask;
});

app.MapRazorPages();
app.Run();
