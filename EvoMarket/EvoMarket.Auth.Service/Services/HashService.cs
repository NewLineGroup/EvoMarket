using System.Security.Cryptography;
using System.Text;
using EvoMarket.Auth.Service.Interfaces;

namespace EvoMarket.Auth.Service.Services;

public class HashService:IHashService
{
    public async ValueTask<string> HashClientPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}