using WebServices.DataModels;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace WebServices;
public class BreedSearchApi : WebAPIBase, IBreedSearchApi
{

    private readonly ApiClientOptions _options;
    public BreedSearchApi(
        IOptions<ApiClientOptions> options,
        ILogger? logger = null) : base(options,logger)
    {
        _options = options.Value;
    }

    
    public async Task<IEnumerable<Breed>> GetBreeds(int limit = 1, int page = 0)
    {
        var queryParams = new Dictionary<string, string?>();
        if(limit > 1)
        {
            queryParams.Add("limit", limit.ToString());
        }
        if(page > 0)
        {
            queryParams.Add("page", page.ToString());
        };

        var queryedUrl = this.GetQueryedUrl(queryParams);
        
        var result = await this.GetAsync(
            queryedUrl,
            new Dictionary<string, string?>
            {
                { "x-api-key", _options.ApiKey }
            });

        if (!string.IsNullOrWhiteSpace(result))
        {
            IEnumerable<Breed>? breeds = JsonSerializer.Deserialize<IEnumerable<Breed>>(result);
            if (breeds != null)
            {
                return breeds;
            }
        }

        return new List<Breed>();
    }
}
