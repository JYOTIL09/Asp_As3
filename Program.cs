using Assignment_3.AppUtilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(); // ✅ Add this line

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IQuestionService, QuestionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseSession(); // ✅ Make sure this is after UseRouting and before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Index}/{id?}");

app.Run();
