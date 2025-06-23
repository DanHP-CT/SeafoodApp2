using SeafoodApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ MVC
builder.Services.AddControllersWithViews();

// Đăng ký DbContext dùng SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Cho phép dùng các file tĩnh (css, js, ảnh)
app.UseStaticFiles();

// Thiết lập routing
app.UseRouting();

// Nếu có xác thực/authorization thì mở 2 dòng sau:
// app.UseAuthentication();
// app.UseAuthorization();

// Định tuyến mặc định: HomeController/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
