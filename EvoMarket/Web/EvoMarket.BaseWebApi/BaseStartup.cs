namespace OnlineShop.BaseWebApi;

public class BaseStartup : IStartup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication();

        return null;
    }

    public void Configure(IApplicationBuilder app)
    {
        throw new NotImplementedException();
    }
}