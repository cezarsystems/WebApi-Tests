using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Testes
{
    public class ApiHelper
    {
        public async static Task<HttpResponseMessage> Get(HttpClient httpClient)
        {
            return await httpClient.GetAsync(httpClient.BaseAddress.AbsoluteUri);
        }

        public async static Task<HttpResponseMessage> Create(HttpClient httpClient, string stringObject)
        {
            if (!string.IsNullOrEmpty(stringObject))
            {
                var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(stringObject));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return await httpClient.PostAsync(httpClient.BaseAddress.AbsoluteUri, content);
            }
            else
                return new HttpResponseMessage();
        }

        public async static Task<HttpResponseMessage> Update(HttpClient httpClient, string stringObject)
        {
            if (!string.IsNullOrEmpty(stringObject))
            {
                var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(stringObject));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return await httpClient.PutAsync(httpClient.BaseAddress.AbsoluteUri, content);
            }
            else
                return new HttpResponseMessage();
        }

        public async static Task<HttpResponseMessage> Delete(HttpClient httpClient)
        {
            return await httpClient.DeleteAsync(httpClient.BaseAddress.AbsoluteUri);
        }
    }
}