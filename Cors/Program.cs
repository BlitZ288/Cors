var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option =>
{
    option.AddPolicy("dev", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        
    });

    option.AddPolicy("OnlyGet", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500").WithMethods("GET").WithHeaders("Origin", "X-Requested-With", "Content-Type", "Accept"); ;
    });

    option.AddPolicy(name: "MyPolicy", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
                            .WithMethods("DELETE", "GET","POST", "PUT")
                            .WithHeaders("Origin", "X-Requested-With", "Content-Type", "Accept"); 
    });

    option.AddPolicy(name: "CookiePolicy", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
                            .WithMethods("DELETE", "GET", "POST")
                            .WithHeaders("Origin", "X-Requested-With", "Content-Type", "Accept")
                            .AllowCredentials();
                            
    });
    
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
