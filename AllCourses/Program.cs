using AllCourses.Domain;
using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Domain.Repositories.EntityFramevork;
using AllCourses.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//настраиваем политику авторизации для AdminArea
builder.Services.AddAuthorization(x =>
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); })
);

//добавляем сервисы для контроллеров и представлений (MVC)
builder.Services.AddControllersWithViews(options =>
    options.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"))
);

//Продключаем конфиг из appsettings.json
//builder.Configuration.Bind("Project", new Config());

//Получаем нужный функционал приложения в качестве сервисов
builder.Services.AddTransient<IMessageRepository, EFMessageRepository>();
builder.Services.AddTransient<INewsRepository, EFNewsRepository>();
builder.Services.AddTransient<IUserAvatarsRepository, EFUserAvatarsRepository>();

//настраивем Identity систему
builder.Services.AddIdentity<IdentityUser, IdentityRole>(ops =>
{
    ops.User.RequireUniqueEmail = true;// Требуется уникальный email для каждого пользователя
    ops.Password.RequiredLength = 6;// Минимальная длина пароля — 6 символов
    ops.Password.RequireNonAlphanumeric = true;// Пароль обязан содержать специальные символы (например, !, @, #)
    ops.Password.RequireUppercase = true;// Пароль обязан содержать заглавные буквы
    ops.Password.RequireLowercase = true;// Пароль обязан содержать строчные буквы
    ops.Password.RequireDigit = true;// Пароль обязан содержать цифры

}).AddEntityFrameworkStores<AllCoursesDbContext>()//Хранение данных пользователей в базе данных, связанной с AllCoursesDbContext
  .AddDefaultTokenProviders();// Добавление токенов для таких вещей, как подтверждение email или восстановление пароля

//подключаем контекст БД
builder.Services.AddDbContext<AllCoursesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"))
);


//настраиваем authentication cokie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "KpCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/Accessdenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/ServerError");
    app.UseHsts();
    app.UseStatusCodePagesWithReExecute("/Error/NotFound");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapFallbackToController("NotFound", "Error");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

