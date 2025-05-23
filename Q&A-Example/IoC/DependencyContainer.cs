using Q_A_Example.Services.Implementations;
using Q_A_Example.Services.Interfaces;

namespace Q_A_Example.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
