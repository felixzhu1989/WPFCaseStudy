using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WpfDiDemo.Options;
using WpfDiDemo.Services;
try
{
    //读取Json配置文件
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .Build();
    //依赖注入
    var serviceProvider = new ServiceCollection()
        .AddScoped<IUserService, UserService>()
        .AddSingleton<IConfiguration>(sp => config)
        .Configure<ApplicationOptions>(config.GetSection(nameof(ApplicationOptions)))
        .BuildServiceProvider();
    //获取IOC容器中的服务
    var userService = serviceProvider.GetRequiredService<IUserService>();
    var result = userService.Login("abc", "123");
    Console.WriteLine(result);
    //获取Json中的节点内容
    config = serviceProvider.GetRequiredService<IConfiguration>();
    var section = config.GetSection("ApplicationName");
    var applicationName = section.Value;
    Console.WriteLine(applicationName);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}