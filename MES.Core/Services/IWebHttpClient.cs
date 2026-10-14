using System.Threading.Tasks;

namespace MES.Core.Services
{
    public interface IWebHttpClient
    {
        Task<string> PostAsync(string url, string data, string authToken = null);
        Task<string> GetAsync(string url, string authToken = null);
        Task<string> PutAsync(string url, string data, string authToken = null);
        string POST(string url, string data, string authToken = null);
        string GET(string url, string authToken = null);
    }
}
