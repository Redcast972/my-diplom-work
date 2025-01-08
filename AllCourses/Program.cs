using AllCourses.Domain;
using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Domain.Repositories.EntityFramevork;
using AllCourses.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//����������� �������� ����������� ��� AdminArea
builder.Services.AddAuthorization(x =>
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); })
);

//��������� ������� ��� ������������ � ������������� (MVC)
builder.Services.AddControllersWithViews(options =>
    options.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"))
);

//����������� ������ �� appsettings.json
//builder.Configuration.Bind("Project", new Config());

//�������� ������ ���������� ���������� � �������� ��������
builder.Services.AddTransient<IMessageRepository, EFMessageRepository>();
builder.Services.AddTransient<INewsRepository, EFNewsRepository>();
builder.Services.AddTransient<IUserAvatarsRepository, EFUserAvatarsRepository>();

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

