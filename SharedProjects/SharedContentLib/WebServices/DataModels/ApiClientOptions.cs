using Windows.UI.Notifications;

namespace WebServices.DataModels;

public class ApiClientOptions
{
    public const string ApiClient = "ApiClientSettings";
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
};
    
