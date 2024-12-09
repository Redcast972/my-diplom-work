using AllCourses.Domain;
using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Domain.Repositories.EntityFramevork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//��������� ������� ��� ������������ � ������������� (MVC)
builder.Services.AddControllersWithViews();

//����������� ������ �� appsettings.json
//builder.Configuration.Bind("Project", new Config());

//�������� ������ ���������� ���������� � �������� ��������
builder.Services.AddTransient<IMessageRepository, EFMessageRepository>();
builder.Services.AddTransient<INewsRepository, EFNewsRepository>();

//���������� Identity �������
builder.Services.AddIdentity<IdentityUser, IdentityRole>(ops =>
{
    ops.User.RequireUniqueEmail = true;// ��������� ���������� email ��� ������� ������������
    ops.Password.RequiredLength = 6;// ����������� ����� ������ � 6 ��������
    ops.Password.RequireNonAlphanumeric = true;// ������ ������ ��������� ����������� ������� (��������, !, @, #)
    ops.Password.RequireUppercase = true;// ������ ������ ��������� ��������� �����
    ops.Password.RequireLowercase = true;// ������ ������ ��������� �������� �����
    ops.Password.RequireDigit = true;// ������ ������ ��������� �����

}).AddEntityFrameworkStores<AllCoursesDbContext>()//�������� ������ ������������� � ���� ������, ��������� � AllCoursesDbContext
  .AddDefaultTokenProviders();// ���������� ������� ��� ����� �����, ��� ������������� email ��� �������������� ������

//���������� �������� ��
builder.Services.AddDbContext<AllCoursesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"))
);


//����������� authentication cokie
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
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

