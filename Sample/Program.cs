using Microsoft.EntityFrameworkCore;
using Sample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<SampleDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SampleDb")));

builder.Services.AddScoped<IProjectData, SqlProjectData>();
//builder.Services.AddScoped<IProjectData, InMemoryProjectData>();

builder.Services.AddControllers();

var app = builder.Build();

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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

//MigrateDatabase(app);

void MigrateDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
        db.Database.Migrate();
    }
}

app.Run();
