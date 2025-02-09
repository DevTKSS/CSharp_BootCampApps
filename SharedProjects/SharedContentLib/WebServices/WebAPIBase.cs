using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using WebServices.DataModels;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace WebServices;
public abstract class WebAPIBase
{
    // Insert variables below here
    private readonly HttpClient _client;
    private readonly ApiClientOptions _options;
    private readonly ILogger? _logger;
    // Insert static constructor below here
   
    protected WebAPIBase(
        IOptions<ApiClientOptions> options,
        ILogger? logger = null)
    {
        _logger = logger;
        _options = options.Value;
        if (!_options.BaseUrl.StartsWith("https://") || !_options.BaseUrl.EndsWith('/'))
        {
            throw new ArgumentException("Invalid BaseUrl");
        }
        _client = new HttpClient
        {
            BaseAddress = new Uri(_options.BaseUrl)
        };
        
        //_client.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    private protected string GetQueryedUrl(Dictionary<string,string?> query)
    {
        return QueryHelpers.AddQueryString(_options.BaseUrl, query);
    } 

    // Insert CreateRequestMessage method below here
    private protected HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, Dictionary<string, string?>? headers = null)
    {
        headers ??= new Dictionary<string, string?>();
        var httpRequestMessage = new HttpRequestMessage(method, url);
        
        foreach (var header in headers)
        {
            if (header.Key != "Content-Type")
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
                if (_logger != null)
                {
                    _logger.LogTrace("Header {HeaderKey} with Value {HeaderValue} added in RequestMessage", header.Key,header.Value);
                }
            }
            else
            {

                if (_logger != null)
                {
                    _logger.LogTrace("{HeaderKey} header is not allowed in headers, will be skipped to be added in RequestMessage", header.Key);
                }
            }
        }
        return httpRequestMessage;
    }
   

    // Insert GetAsync method below here
    protected async Task<string> GetAsync(string url, Dictionary<string, string?>? headers = null)
    {
        headers ??= new Dictionary<string, string?>();
        using (var request = CreateRequestMessage(HttpMethod.Get, url, headers))
        using (var response = await _client.SendAsync(request))
        {

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                if (_logger != null)
                {
                    _logger.LogError("Error: {response.StatusCode}",response.StatusCode);
                }
                return string.Empty;
            }
        }
       
    }

    // Insert DeleteAsync method below here

    // Insert PostAsync method below here
   

    // Insert PutAsync method below here
}
