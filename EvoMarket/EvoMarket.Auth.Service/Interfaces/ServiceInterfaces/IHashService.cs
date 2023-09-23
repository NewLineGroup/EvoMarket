namespace EvoMarket.Auth.Service.Interfaces;

public interface IHashService
{
    public ValueTask<string> HashClientPassword(string password);
}